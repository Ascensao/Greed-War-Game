using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Windows.Forms;

namespace MMORTS___Greed_War_Game_Client
{
    class errorMSG
    {

        MailMessage mail;
        SmtpClient client = new SmtpClient("smtp.gmail.com");

        public void errorExeption(string e)
        {
            DialogResult result =
                MessageBox.Show("Sorry a system error occurred:\n\n" + e + "\n\nWould you like to report the problem?",
                "System Error",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                mail = new MailMessage("admin@magicianware.com", "admin@magicianware.com", "Application Error", e);
                client.Port = 587;
                client.Credentials = new System.Net.NetworkCredential("admin@magicianware.com", "greedwargame");
                client.EnableSsl = true;
                client.Send(mail);
                DialogResult result2 =
                    MessageBox.Show("Problem Reported Successfully", "Thank You",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            Environment.Exit(1);
        }
    }
}
