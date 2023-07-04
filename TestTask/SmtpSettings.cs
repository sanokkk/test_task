using System.Net.Mail;

namespace TestTask
{
    public class SmtpSettings
    {
        public string From{ get; set; }
        public string Key{ get; set; }
        public int Port { get; set; }
        public string Server { get; set; }
        public SmtpDeliveryMethod DeliveryMethod { get; set; } = SmtpDeliveryMethod.Network;
        public bool EnableSSl { get; } = true;
        public bool UseDefaultCredentials { get; set; } = false;
    }
}
