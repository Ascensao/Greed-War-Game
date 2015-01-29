using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace MMORTS___Greed_War_Game_Client
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            rememberExeRead();
        }
        formMain gameForm;
        //mysqlCon conn = new mysqlCon();
        mysqlQuery query = new mysqlQuery();
        encryption encript = new encryption();
        samfile sam = new samfile();
        writeFileManage writeFile = new writeFileManage();
        readFileManage readFile = new readFileManage();
        int count = 0;
        int[] planetID = new int[5];
        string userID;

 

        private void picBoxLogo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.gwg.magicianware.com/en-us/index.php");
        }

        private void btnFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.facebook.com/pages/Greed-War-Game/103439693075049");
        }

        private void btnTwitter_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://twitter.com/#!/Magicianware");
        }

        private void btnYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.youtube.com/watch?v=m2hOH8LkjqE");
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            writeFile.remember(txtUsername.Text, txtPassword.Text);
            login();
            btnStartGame.Enabled = true;
        }
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            this.Hide();
            gameForm = new formMain(txtUsername.Text, userID);
            gameForm.Show();
        }

        //MÉTODOS
        public void startServerConnection()
        {
        }
        public void resetLogin()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            lblProgress.Text = null;
            progressBarLogin.Value = 0;
        }
        public void login()
        {
            string idQuery = "SELECT id_user_account FROM tbl_user_account WHERE username LIKE " + "\'" + (Convert.ToString(txtUsername.Text)) + "\'";
            string passQuery = "SELECT password FROM tbl_user_account WHERE id_user_account LIKE " + "\'" + userID + "\'";
            lblProgress.Text = "Verifying Login Details...";
            userID = query.singleResult(idQuery);
            if (query.singleResult(passQuery) == encript.generateMD5(txtPassword.Text))
            {
                progressBarLogin.Value=10;
                loadUserData();
                lblProgress.Text="";
                progressBarLogin.Value=100;
                MessageBox.Show("Login correct");
            }
            else
            {
                MessageBox.Show("Username or Password Incorret !");
                resetLogin();
            }
        }
        public void loadUserData()
        {
            lblProgress.Text = "Loanding Planet Data..";

            writeFile.itemPriceSave();
            sam.SecuritySave("price", 0);

            writeFile.shipConf();
            sam.SecuritySave("ship", 0);

            writeFile.planetIdSave(userID);
            sam.SecuritySave("planetID", 0);

            writeFile.userStatus(userID, @"gamedata/userdata.dat");
            sam.SecuritySave("userdata", 0);

            writeFile.researchSave(userID, @"usersave/research1.sav");
            sam.SecuritySave("research", 0);

            count = 0;
            foreach (int val in readFile.planetID())
            {
                planetID[count] = val;
                count++;
            }
            
            //PLANET1
            writeFile.resourcesSave(planetID[0], @"usersave/resource0.sav");
            sam.SecuritySave("resource", 0);

            writeFile.buildingSave(planetID[0], @"usersave/building0.sav");
            sam.SecuritySave("building", 0);

            writeFile.fleetSave(planetID[0], @"usersave/fleet0.sav");
            sam.SecuritySave("fleet", 0);

            writeFile.defenseSave(planetID[0], @"usersave/defense0.sav");
            sam.SecuritySave("defense", 0);

            //PLANET 2
            if(planetID[1] != 0)
            {
                writeFile.resourcesSave(planetID[1], @"usersave/resource1.sav");
                sam.SecuritySave("resource", 1);

                writeFile.buildingSave(planetID[1], @"usersave/building1.sav");
                sam.SecuritySave("building", 1);

                writeFile.fleetSave(planetID[1], @"usersave/fleet1.sav");
                sam.SecuritySave("fleet", 1);

                writeFile.defenseSave(planetID[1], @"usersave/defense1.sav");
                sam.SecuritySave("defense", 1);
            }

            //PLANET 3
            if (planetID[2] != 0)
            {
                writeFile.resourcesSave(planetID[2], @"usersave/resource2.sav");
                sam.SecuritySave("resource", 2);

                writeFile.buildingSave(planetID[2], @"usersave/building2.sav");
                sam.SecuritySave("building", 2);

                writeFile.fleetSave(planetID[2], @"usersave/fleet2.sav");
                sam.SecuritySave("fleet", 2);

                writeFile.defenseSave(planetID[2], @"usersave/defense2.sav");
                sam.SecuritySave("defense", 2);
            }

            //PLANET 4
            if (planetID[3] != 0)
            {
                writeFile.resourcesSave(planetID[3], @"usersave/resource3.sav");
                sam.SecuritySave("resource", 3);

                writeFile.buildingSave(planetID[3], @"usersave/building3.sav");
                sam.SecuritySave("building", 3);

                writeFile.fleetSave(planetID[3], @"usersave/fleet3.sav");
                sam.SecuritySave("fleet", 3);

                writeFile.defenseSave(planetID[3], @"usersave/defense3.sav");
                sam.SecuritySave("defense", 3);
            }

            //PLANET 5
            if (planetID[4] != 0)
            {
                writeFile.resourcesSave(planetID[4], @"usersave/resource4.sav");
                sam.SecuritySave("resource", 4);

                writeFile.buildingSave(planetID[4], @"usersave/building4.sav");
                sam.SecuritySave("building", 4);

                writeFile.fleetSave(planetID[4], @"usersave/fleet4.sav");
                sam.SecuritySave("fleet", 4);

                writeFile.defenseSave(planetID[4], @"usersave/defense4.sav");
                sam.SecuritySave("defense", 4);
            }


        }
        private void rememberExeRead()
        {
            if (writeFile.fileExist(@"gamedata\configlog.dat"))
            {
                checkBoxRemember.Checked = true;
                string[] txtvalues = new string[2];
                readFile.rememberLogin(out txtvalues[0], out txtvalues[1]);
                txtUsername.Text = txtvalues[0];
                txtPassword.Text = txtvalues[1];
            }
        }
        private void checkBoxRemember_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxRemember.Checked==false)
            {
                writeFile.fileDelete(@"gamedata\configlog.dat");
            }
        }

        private void lblNewAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.gwg.magicianware.com/en-us/register.php");
        }

        private void lblLostAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.gwg.magicianware.com/en-us/recovery.php");
        }
    }
}
