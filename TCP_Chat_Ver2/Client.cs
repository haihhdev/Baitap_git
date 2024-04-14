using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MultichatApplication
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }

        private TcpClient tcpClient;
        private Thread clientThread;
        private bool connecting = true;
        private delegate void SafeCallDelegate(string username, string data);

        private void UpdateChatHistorySafeCall(string username, string data)
        {
            if (lstChatBox.InvokeRequired)
            {
                var method = new SafeCallDelegate(UpdateChatHistorySafeCall);
                lstChatBox.Invoke(method, new object[] { username, data });
            }
            else
            {
                if (username == null)
                {
                    lstChatBox.Items.Add(data);
                }
                else
                {
                    lstChatBox.Items.Add($"{username}: {data}");
                }
            }
        }

        private void Receive()
        {
            NetworkStream net_stream = tcpClient.GetStream();
            byte[] data = new byte[1024];
            try
            {
                while (connecting && tcpClient.Connected)
                {
                    int byte_count = net_stream.Read(data, 0, data.Length);
                    string message = Encoding.UTF8.GetString(data, 0, byte_count);
                    if (message.StartsWith("[IMAGE]"))
                    {
                        // Xử lý hình ảnh
                        byte[] imageBytes = data.Skip(7).ToArray(); // Bỏ qua 7 byte đầu tiên ("[IMAGE]")
                        Image image = ByteArrayToImage(imageBytes);
                        pictureBox1.Image = image; // Hiển thị hình ảnh trong PictureBox
                    }
                    else
                    {
                        // Xử lý văn bản
                        UpdateChatHistorySafeCall(null, message);
                    }
                    if (byte_count == 0)
                    {
                        connecting = false;
                    }
                }
            }
            catch
            {
                tcpClient.Close();
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                IPEndPoint tcpServer = new IPEndPoint(IPAddress.Parse(txtServerIP.Text), int.Parse(txtServerPort.Text));
                tcpClient = new TcpClient();
                tcpClient.Connect(tcpServer);

               
                NetworkStream net_stream = tcpClient.GetStream();
                byte[] message = Encoding.UTF8.GetBytes(txtUsername.Text);
                net_stream.Write(message, 0, message.Length);
                net_stream.Flush();

               
                clientThread = new Thread(Receive);
                clientThread.IsBackground = true;
                clientThread.Start();
                txtServerIP.ReadOnly = txtServerPort.ReadOnly = txtUsername.ReadOnly = true;
            } 
            catch
            {
                MessageBox.Show("Lỗi kết nối!");
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            NetworkStream net_stream = tcpClient.GetStream();
            byte[] message = Encoding.UTF8.GetBytes("TEXT: " + txtMessage.Text);
            net_stream.Write(message, 0, message.Length);
            UpdateChatHistorySafeCall("Tôi", txtMessage.Text);
            net_stream.Flush();
            txtMessage.Text = string.Empty;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            clientThread = null;
            tcpClient.Close();
            UpdateChatHistorySafeCall(null, "Đang ngắt kết nối...");
        }

        private void txtServerIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblServerIP_Click(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmClient_Load(object sender, EventArgs e)
        {

        }
        // Chuyển hình ảnh thành dạng byte
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

        // Chuyển dạng byte thành hình ảnh
        public System.Drawing.Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                return returnImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog.FileName);
                byte[] imageBytes = ImageToByteArray(image);
                string imageBase64 = Convert.ToBase64String(imageBytes);
                string message = "IMAGE: " + imageBase64;
                byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                NetworkStream net_stream = tcpClient.GetStream();
                net_stream.Write(messageBytes, 0, messageBytes.Length);
                net_stream.Flush();
            }
        }

    }
}