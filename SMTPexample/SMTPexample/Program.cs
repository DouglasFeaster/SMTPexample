using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SMTPexample
{
    class Program
    {
        static void Main(string[] args)
        {

            SMTPMessage();
            Console.ReadKey();
        }

        static void SMTPMessage()
        {

            string[] addressBook = {
                "john.doe@domain.com",
                "jane.doe@domain.com"
                             };
            try
            {

                SmtpClient client = new SmtpClient("SMTP.office365.com", 587);

                client.EnableSsl = true;

                NetworkCredential myCreds = new NetworkCredential("<Email>", "<Account Password>", "");

                client.Credentials = myCreds;

                foreach (string email in addressBook)
                {

                    MailAddress from = new MailAddress("<Email Address>", "<Account Display Name>");

                    MailAddress to = new MailAddress(email);

                    MailMessage message = new MailMessage(from, to);

                    message.Subject = "<Subject>";

                    message.Body = "<Body>";

                    client.Send(message);

                }
                Console.WriteLine("Message Sent!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
