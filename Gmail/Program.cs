using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gmail
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string from = Console.ReadLine();
                string to = Console.ReadLine();
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.Host = "smtp.gmail.com";
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(from, Console.ReadLine());

                MailMessage mm = new MailMessage(from, to, Console.ReadLine(), Console.ReadLine());
                mm.BodyEncoding = UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not send e-mail. Exception caught: " + e);
                Console.ReadLine();
            }
        }
    }
}
