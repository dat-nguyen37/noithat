
using MimeKit;
using System;
using System.Threading.Tasks;
using MailKit.Security;

namespace api.MailUtils
{
    public class MailUtils
    {
        public static async Task<string> SendMail(string _to, string _subject, string _body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Nhà Đẹp", "dat958734@gmail.com"));
            message.To.Add(new MailboxAddress(_to, _to));
            message.Subject = _subject;

            // Tạo nội dung email
            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = _body // Gửi email với nội dung HTML
            };
            message.Body = bodyBuilder.ToMessageBody();

            // Cấu hình SMTP client và gửi email
            using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                // Kết nối tới máy chủ SMTP của Gmail
                await smtpClient.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                // Xác thực với Gmail
                await smtpClient.AuthenticateAsync("Dat958734@gmail.com", "eika gaso olfr rhuz");

                // Gửi email
                await smtpClient.SendAsync(message);
                return "Gửi email thành công";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi gửi email: {ex.Message}");
                return "Gửi email thất bại";
            }
            finally
            {
                // Đảm bảo ngắt kết nối sau khi gửi email
                await smtpClient.DisconnectAsync(true);
            }
        }
    }
}
