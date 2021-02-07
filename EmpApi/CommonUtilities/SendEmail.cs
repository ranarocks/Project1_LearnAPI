using System.Net;
using System.Net.Mail;
namespace EmpApi.CommonUtilities
{
    public class SendEmail
    {
        public void Email (string ToMail)
        {
            SmtpClient SendMail = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("nikkusajwan25@gmail.com", "uclchamp@2016"),
                EnableSsl = true,
            };
            SendMail.Send("nikkusajwan25@gmail.com", ToMail, "Registeration Done", "Welcome User, We are happy to share our services");
        }


        //MailMessage Mail = new MailMessage
        //{
        //    From = new MailAddress("tarunsajwan16@gmail.com"),
        //    Subject = "Registeration Done",
        //    Body = "<h3><b>Welcome , We are glad you choose our service.</b></h3>",
        //    IsBodyHtml = true
        //};
        //Mail.To.Add("nikkusajwan25@gmail.com");
        








        //public string SendMail(string mail)
        //{
        //    SmtpClient Client = new SmtpClient()
        //    {
        //        Host = "smtp.@gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential()
        //        {
        //            UserName = "nikkusajwan25@gmail.com",
        //            Password = "uclchamp@2016"
        //        }
        //    };
        //    MailAddress FromEmail = new MailAddress("nikkusajwan25@gmail.com", "Registeration Done");
        //    MailAddress ToEmail = new MailAddress("");
        //}
        //SmtpClient Client = new SmtpClient()
        //{
        //    Host = "smtp.@gmail.com",
        //    Port = 587,
        //    EnableSsl = true,
        //    DeliveryMethod = SmtpDeliveryMethod.Network,
        //    UseDefaultCredentials = false,
        //    Credentials = new NetworkCredential()
        //    {
        //        UserName = "nikkusajwan25@gmail.com",
        //        Password = "uclchamp@2016"
        //    }
        //};
        //MailAddress FromEmail = new MailAddress("nikkusajwan25@gmail.com", "Registeration Done");
        //MailAddress ToEmail = new MailAddress("mail", "New Member");
        //MailMessage message = new MailMessage()
        //{
        //    From = FromEmail,
        //    Subject = "Welcome to Xyz Pvt. Ltd.",
        //    Body = "Welcome User , Your Registeration is Successful. We Are Happy to lend our Services"

        //};

        //public string MailSend (EmpApi.Models.EmailModel model)
        //{
        //    MailMessage mail = new MailMessage("nikkusajwan25@gmail.com", "tarunsajwan16@gmail.com");
        //    mail.Subject = model.Subject;
        //    mail.Body = model.Body;
        //    mail.IsBodyHtml = false;

        //    SmtpClient smtp = new SmtpClient();
        //    smtp.Host = "smtp.@gmail.com";
        //    smtp.Port = 587;
        //    smtp.EnableSsl = true;

        //    NetworkCredential nc = new NetworkCredential("nikkusajwan25@gmail.com","uclchamp@2016");
        //    smtp.UseDefaultCredentials = false;
        //    smtp.Credentials = nc;
        //    smtp.Send(mail);

        //    return "Check Your Email";

        //}


    }

}