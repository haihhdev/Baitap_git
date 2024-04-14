Hoàng Huỳnh Hải - 22520381 ; Chu Đức Hải - 22520378 ; Trịnh Minh Hiếu - 22520447

Link demo TCP Chat: https://drive.google.com/file/d/1Nqn20iRERptqJV4UaRF45y0bSoWWCtE8/view?usp=sharing

Link demo SSL: https://drive.google.com/file/d/1HuygZNZGyTEK_D2QzmAxhPGV3KwnnQw6/view?usp=sharing

Password in this video is: nt106  
Install OpenSSL. Open terminal with admnistrator role.

I. Generate CA(certificate authority)

Generate a Private Key : openssl genrsa -aes256 -out caa-key.pem 4096

Create a Certificate Signing Request (CSR): : openssl req -new -x509 -sha256 -days 365 -key caa-key.pem -out caa.pem

II. Generate Certificate

- Create a RSA key : openssl genrsa -out certa-key.pem 4096

- Create a Certificate Signing Request (CSR) : openssl req -new -sha256 -subj "/CN=MySSL" -key certa-key.pem -out certa.csr

- Create the certificate : openssl x509 -req -sha256 -days 365 -in certa.csr -CA caa.pem -CAkey caa-key.pem -out certa.pem -CAcreateserial

- Assuming the path to your generated CA certificate as C:\Users\HungPhung\ca.pem, run: : Import-Certificate -FilePath "C:\Users\HOANG HAI\caa.pem" -CertStoreLocation Cert:\LocalMachine\My

- Combine SSL Certificate and Private Key, and apply. : openssl pkcs12 -export -out certa.pfx -inkey certa-key.pem -in certa.pem
