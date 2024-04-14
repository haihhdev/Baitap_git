using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MultichatApplication
{
    public partial class frmServer : Form
    {
        public frmServer()
        {
            InitializeComponent();
        }

        private TcpListener tcpServer;
        private Thread listenThread;
        private Dictionary<string, TcpClient> dic_clients = new Dictionary<string, TcpClient>();
        private bool listening = true;
        private delegate void SafeCallDelegate(string username, string message);

        private void UpdateChatHistorySafeCall(string username, string message)
        {
            if (richTextBox1.InvokeRequired)
            {
                var method = new SafeCallDelegate(UpdateChatHistorySafeCall);
                richTextBox1.Invoke(method, new object[] { username, message });
            }
            else
            {
                richTextBox1.AppendText($"{username}: {message}\r\n");
            }
        }

        private void Listen()
        {
            // Máy chủ bắt đầu lắng nghe các kết nối đến
            tcpServer = new TcpListener(IPAddress.Any, int.Parse(txtServerPort.Text));

            // Máy chủ bắt đầu lắng nghe các kết nối đến
            tcpServer.Start();
            try
            {
                while (listening)
                {
                    // Máy chủ chấp nhận một kết nối đến từ một người dùng
                    TcpClient client = tcpServer.AcceptTcpClient();

                    // Mở một luồng mạng từ người dùng
                    NetworkStream net_stream = client.GetStream();

                    // Khởi tạo một mảng byte để lưu dữ liệu nhận được
                    byte[] data = new byte[1024];

                    // Đọc dữ liệu từ luồng mạng vào mảng byte và lưu số byte đã đọc
                    int byte_count = net_stream.Read(data, 0, data.Length);

                    // Chuyển đổi dữ liệu từ dạng byte sang chuỗi để lấy tên người dùng
                    string username = Encoding.UTF8.GetString(data, 0, byte_count);

                    // Kiểm tra xem tên người dùng đã tồn tại trong từ điển dic_clients hay không
                    if (dic_clients.ContainsKey(username))
                    {
                        byte[] response = Encoding.UTF8.GetBytes("Username đã tồn tại!");
                        net_stream.Write(response, 0, response.Length);
                        net_stream.Flush();
                        client.Close();
                    }
                    else if (username == "Administrator")
                    {
                        byte[] response = Encoding.UTF8.GetBytes("Username không dùng được!");
                        net_stream.Write(response, 0, response.Length);
                        net_stream.Flush();
                        client.Close();
                    }
                    else
                    {
                        // Nếu tên người dùng hợp lệ, cập nhật lịch sử trò chuyện và thêm người dùng vào từ điển
                        UpdateChatHistorySafeCall("Administrator", $"User {username} đã kết nối thành công");
                        dic_clients.Add(username, client);

                        // Khởi động một luồng mới để nhận dữ liệu từ người dùng 
                        Thread receiveThread = new Thread(Receive);
                        receiveThread.IsBackground = true;
                        receiveThread.Start(username);
                    }
                }
            }
            catch
            {
                // Nếu có lỗi xảy ra, khởi động lại máy chủ
                tcpServer = new TcpListener(IPAddress.Any, int.Parse(txtServerPort.Text));
            }
        }

        private void Broadcast(string username, string message, TcpClient except_this_client)
        {
            // Đầu tiên, hàm tạo một thông điệp từ tên người dùng và tin nhắn.
            // Thông điệp này được mã hóa thành dạng byte để có thể gửi qua mạng.
            byte[] flooding_message = Encoding.UTF8.GetBytes($"{username}: {message}");
            
            // Duyệt qua từ điển dic_clients để gửi thông điệp đến tất cả người dùng khác trừ người gửi
            foreach (TcpClient client in dic_clients.Values)
            {
                if (client != except_this_client)
                {
                    NetworkStream net_stream = client.GetStream();
                    net_stream.Write(flooding_message, 0, flooding_message.Length);
                    net_stream.Flush();
                }
            }
        }

        private void Receive(object obj)
        {
            string username = obj.ToString();
            TcpClient client = dic_clients[username];
            NetworkStream net_stream = client.GetStream();
            byte[] data = new byte[1024];

            try
            {
                while (listening)
                {
                    int byte_count = net_stream.Read(data, 0, data.Length);

                    // Nếu ko có dữ liệu nào được nhận (số byte đọc đc là 0), đặt listening thành false để dừng vòng lặp
                    if (byte_count == 0)
                    {
                        listening = false;
                        UpdateChatHistorySafeCall("Administrator", $"Người dùng {username} đã rời khỏi cuộc trò chuyện");
                    }
                    else
                    {
                        string message = Encoding.UTF8.GetString(data, 0, byte_count);
                        
                        //Kiểm tra imaeg hay văn bản
                        if (message.StartsWith("TEXT: "))
                        {
                            // Văn bản thì loại bỏ tiền tố và hiển thị trong TextBox 
                            message = message.Substring(6);
                            message = ReplaceEmojis(message); // Thay thế mã emoji bằng emoji 
                            Broadcast(username, message, client);

                            // Cập nhật TextBox trên luồng giao diện người dùng
                            if (richTextBox1.InvokeRequired)
                            {
                                richTextBox1.Invoke(new MethodInvoker(delegate { richTextBox1.AppendText($"Người dùng {username}: {message}\r\n"); }));
                            }
                            else
                            {
                                richTextBox1.AppendText($"Người dùng {username}: {message}\r\n");
                            }  
                        }
                        else if (message.StartsWith("IMAGE: "))
                        {
                            //Thông báo người dùng đã gửi hình ảnh kèm username 
                            UpdateChatHistorySafeCall("Administrator", $"Người dùng {username} đã gửi một hình ảnh");
                        }
                    }
                }
            }
            catch
            {
                // Nếu có lỗi xảy ra, loại bỏ khách hàng khỏi danh sách, đóng kết nối và hiển thị thông báo
                dic_clients.Remove(username);
                client.Close();
                UpdateChatHistorySafeCall("Administrator", $"Người dùng {username} đã rời khỏi cuộc trò chuyện");
            }
            
        }
        private string ReplaceEmojis(string message)
        {
            // Thay thế mã emoji bằng emoji thực
            message = message.Replace(":smile:", "😄");
            message = message.Replace(":laugh:", "😂");
            message = message.Replace(":wink:", "😉");
            message = message.Replace(":sad:", "😔");
            message = message.Replace(":angry:", "😠");
            message = message.Replace(":surprised:", "😮");
            message = message.Replace(":cool:", "😎");
            message = message.Replace(":confused:", "😕");
            message = message.Replace(":crying:", "😢");
            message = message.Replace(":heart:", "❤️");

            return message;
        }

        private bool IsImage(byte[] data)
        {
            // Các định dạng hình ảnh phổ biến và các byte đầu tiên tương ứng của chúng
            var imageFormats = new Dictionary<byte[], string>
    {
        { new byte[] { 0x47, 0x49, 0x46, 0x38 }, "GIF" }, // GIF
        { new byte[] { 0xFF, 0xD8, 0xFF }, "JPEG" }, // JPEG
        { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }, "PNG" }, // PNG
    };

            foreach (var imageFormat in imageFormats)
            {
                var imageFormatByte = imageFormat.Key;
                var bytes = data.Take(imageFormatByte.Length).ToArray();

                if (imageFormatByte.SequenceEqual(bytes))
                {
                    return true;
                }
            }

            return false;
        }


        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }


        private void btnListen_Click(object sender, EventArgs e)
        {
          
            int users_num = int.Parse(txtUserNumber.Text);
            while (users_num > 0)
            {
                frmClient client = new frmClient();
                client.Show();
                users_num--;
            }
            
            
            UpdateChatHistorySafeCall("Admin", "Chờ kết nối...");
            listenThread = new Thread(new ThreadStart(Listen));
            listenThread.IsBackground = true;
            listenThread.Start();
            this.btnListen.Enabled = false;
            txtServerPort.ReadOnly = txtUserNumber.ReadOnly = true;
        }

        private void lblPort_Click(object sender, EventArgs e)
        {

        }

        private void txtServerPort_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmServer_Load(object sender, EventArgs e)
        {

        }

        private void lstChatBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}