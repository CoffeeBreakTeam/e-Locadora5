using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace e_Locadora5.Email
{
    public class SMTP
    {
        private System.Net.Mail.SmtpClient smtp;
        private System.Net.Mail.MailMessage mail;

        public SMTP()
        {
            smtp = new System.Net.Mail.SmtpClient();
            mail = new System.Net.Mail.MailMessage();
        }

        public void criarConexaoSMTP() {
            using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("CoffeeBreakAcademia@gmail.com", "senhaNDD");
                this.smtp = smtp;
            }
        }

        public void criarMailMessage(string para, string cc, string cco, string subject, string body) {
            using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage())
            {
                mail.From = new System.Net.Mail.MailAddress("CoffeeBreakAcademia@gmail.com");

                if (!string.IsNullOrWhiteSpace(para))
                {
                    mail.To.Add(new System.Net.Mail.MailAddress(para));
                }
                else
                {
                    //MessageBox.Show("Campo 'para' é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(cc))
                    mail.CC.Add(new System.Net.Mail.MailAddress(cc));
                if (!string.IsNullOrWhiteSpace(cco))
                    mail.Bcc.Add(new System.Net.Mail.MailAddress(cco));
                mail.Subject = subject;
                mail.Body = body;
                this.mail = mail;
            }
        }

        /*
        public void adicionarAnexo() {
            //pegar pdf para adicionar como anexo
            foreach (string file in listBoxAttachments.Items)
            {
                mail.Attachments.Add(new System.Net.Mail.Attachment(file));
            }
        }*/

        public void enviarEmail(string emailCliente, string subject, string body, string localPDF)
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("CoffeeBreakAcademia@gmail.com", "senhaNDD")
            };

            var message = new MailMessage("CoffeeBreakAcademia@gmail.com", emailCliente)
            {
                Subject = subject,
                Body = body,
            };

            smtp.SendCompleted += (s, e) => {
                smtp.Dispose();
                message.Dispose();
            };
            message.Attachments.Add(new Attachment(localPDF));
            smtp.Send(message);
        }

        public bool estaConectadoInternet()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

 }
