
using System.Net;
using System.Net.Mail;
namespace EMAIL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fromEmail = "zgye28102003@gmail.com";
            string password = "lityystgpllhguuk";
            MailMessage mail = new MailMessage();
            mail.To.Add("togneok@gmail.com");
            mail.From = new MailAddress(fromEmail);
            mail.Subject = "Xin chao";
            mail.Body = "tognoek";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(fromEmail, password);
            try
            {

                smtp.Send(mail);
                label1.Text = "WIN";
            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
