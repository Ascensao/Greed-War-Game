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
    public partial class formAccount : Form
    {
        public formAccount(string id)
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtRePassword.PasswordChar = '*';
            lblID.Text = id;
            fillField(id);
            lblID.Visible = false;
            lblDelete.Visible = false;
        }
        //DECLARAÇÃO DE VARIAVEIS
        mysqlQuery consult = new mysqlQuery();
        mysqlInsertOrUpdate updateData = new mysqlInsertOrUpdate();
        string[] content = new string[10];
        string query;
        int count = 0;
        int countNeverDate = 0;
        bool neverDate = false;
        bool Pass = false;

        //PREENCHE O FORMULÁRIO COM OS DADOS REGISTADOS PELO UTILIZADOR
        private void fillField(string idUser)
        {
            count = 0;
            query = "SELECT * FROM tbl_user_account WHERE id_user_account LIKE " + "\'" + idUser + "\'";
            foreach (string line in consult.multiResult(10, query))
            {
                content[count] = line;
                count++;
            }
            content[7]=content[7].Substring(0,10);
            if (content[7] == "01/01/2000")
            {
                neverDate = true;
            }
            txtFirstName.Text = content[4];
            txtLastName.Text = content[5];
            if (content[6] == "m")
            {
                radioButtonMale.Checked = true;
            }
            else
            {
                radioButtonFemale.Checked = false;
            }
            if (neverDate==false)
            {
                comboBoxDay.Text = content[7].Substring(0, 2);
                comboBoxMonth.Text = numberToWord(content[7].Substring(3, 2));
                comboBoxYear.Text = content[7].Substring(6, 4);
            }
            comboBoxCountry.Text = content[8];
            txtEmail.Text = content[1];
            txtUsername.Text = content[2];
        }

        //ENTRA O NOME DO MÊS E SAI O NUMERO CORRESPONDENTE
        private string wordToNumber(string word)
        {
            string number;
            switch (word)
            {
                case "January":
                    number = "01";
                    break;
                case "February":
                    number = "02";
                    break;
                case "March":
                    number = "03";
                    break;
                case "April":
                    number = "04";
                    break;
                case "May":
                    number = "05";
                    break;
                case "June":
                    number = "06";
                    break;
                case "July":
                    number = "07";
                    break;
                case "August":
                    number = "08";
                    break;
                case "September":
                    number = "09";
                    break;
                case "October":
                    number = "10";
                    break;
                case "November":
                    number = "11";
                    break;
                case "December":
                    number = "12";
                    break;
                default:
                    number = "01";
                    break;
            }
            return number;
        }
        //ENTRA O NUMERO DO MÊS  E SAI O NOME CORRESPONDENTE
        private string numberToWord(string number)
        {
            string word;
            switch (number)
            {
                case "01":
                    word = "January";
                    break;
                case "02":
                    word = "February";
                    break;
                case "03":
                    word = "March";
                    break;
                case "04":
                    word = "April";
                    break;
                case "05":
                    word = "May";
                    break;
                case "06":
                    word = "June";
                    break;
                case "07":
                    word = "July";
                    break;
                case "08":
                    word = "August";
                    break;
                case "09":
                    word = "September";
                    break;
                case "10":
                    word = "October";
                    break;
                case "11":
                    word = "November";
                    break;
                case "12":
                    word = "December";
                    break;
                default:
                    word = "January";
                    break;
            }
            return word;
        }
        // PREENCHE A ComboBoxDay COM O NUMERO DE DIAS CORRESPONDENTE AO MÊS (EX: JANEIRO = 31 DIAS)
        private void fillComboDay(string month)
        {
            comboBoxDay.Items.Clear();
            switch (month)
            {
                case "January":
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "February":
                    if (DateTime.IsLeapYear(Convert.ToInt32(comboBoxYear.Text)))
                    {
                        for (int i = 1; i <= 29; i++)
                        {
                            comboBoxDay.Items.Add(i);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= 28; i++)
                        {
                            comboBoxDay.Items.Add(i);
                        }
                    }
                    break;
                case "March":
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "April":
                    for (int i = 1; i <= 30; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "May":
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "June":
                    for (int i = 1; i <= 30; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "July":
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "August":
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "September":
                    for (int i = 1; i <= 30; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "October":
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "November":
                    for (int i = 1; i <= 30; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
                case "December":
                    for (int i = 1; i <= 31; i++)
                    {
                        comboBoxDay.Items.Add(i);
                    }
                    break;
            }
        }
        //VERIFICA SE APROVA OU NÃO OS DADOS INTRODUZIDOS PELO UTILIZADOR PARA ACTUALIZAR O SEU REGISTO NA BASE DE DADOS
        /*
         * Se haver algum problema com algum(s) dos dados inseridos, o software avisará o utilizador qual e onde está o dado incorrecto.
         * */
        private void dataProcessing()
        {
            bool warning = false;
            string[] fields = new string[8] { "default", "default", "default", "default", "default", "default", "default", "default"};
            /* Form Data
             * 0 - firstname
             * 1 - last name
             * 2 - gender
             * 3 - date
             * 4 - country
             * 5 - email
             * 6 - username
             * 7 - password
             */

            //Tratamento de Texto
            if ((txtFirstName.Text != "")&&(txtFirstName.Text!="Enter First Name"))
            {
                // Regras
                fields[0] = txtFirstName.Text;
            }
            if ((txtFirstName.Text == "")&&(txtFirstName.Text=="Enter First Name"))
            {
                warning = true;
                txtFirstName.Text = "Enter First Name";
            }
            if (txtLastName.Text != "")
            {
                //Regras
                fields[1] = txtLastName.Text;
            }
            if (txtLastName.Text == "")
            {
                warning = true;
                txtLastName.Text = "Enter Last Name";
            }
            if (radioButtonMale.Checked)
            {
                fields[2] = "m";
            }
            if (radioButtonFemale.Checked)
            {
                fields[2] = "f";
            }
            if ((radioButtonMale.Checked == false) && (radioButtonFemale.Checked == false))
            {
                warning = true;
                MessageBox.Show("Enter your gender");
            }
            if ((comboBoxDay.Text != "") || (comboBoxDay.Text != "Day"))
            {
                fields[3] = comboBoxDay.Text;
            }
            if (comboBoxDay.Text == "")
            {
                warning = true;
                comboBoxDay.Text = "Day";
            }
            if ((comboBoxMonth.Text != "") || (comboBoxMonth.Text != "Month"))
            {
                fields[3] = wordToNumber(comboBoxMonth.Text) + "/" + fields[3];
            }
            if (comboBoxMonth.Text == "")
            {
                warning = true;
                comboBoxMonth.Text = "Month";
            }
            if ((comboBoxYear.Text != null) || (comboBoxYear.Text != "Year"))
            {
                fields[3] = comboBoxYear.Text + "/" + fields[3];
            }
            if (comboBoxYear.Text == "")
            {
                warning = true;
                comboBoxYear.Text = "Year";
            }
            if (comboBoxCountry.Text != "")
            {
                fields[4] = comboBoxCountry.Text;
            }
            if (comboBoxCountry.Text == "")
            {
                warning = true;
                comboBoxCountry.Text = "Enter your country";
            }
            if (txtEmail.Text != "")
            {
                fields[5] = txtEmail.Text;
            }
            if (txtEmail.Text == "")
            {
                warning = true;
                txtEmail.Text = "Enter your Email";
            }
            if (txtUsername.Text != "")
            {
                fields[6] = txtUsername.Text;
            }
            if (txtUsername.Text == "")
            {
                warning = true;
                txtUsername.Text = "Enter your Username";
            }
            if ((txtPassword.Text != ""))
            {
                if (txtPassword.Text == txtRePassword.Text)
                {
                    lblPassWarning.Text = "";
                    fields[7] =txtPassword.Text;
                    Pass = true;
                }
                if(txtPassword.Text != txtRePassword.Text)
                {
                    warning = true;
                    txtPassword.Clear();
                    txtRePassword.Clear();
                    lblPassWarning.Text = "Passwords do not match";
                }
            }
            if (warning == false)
            {
                if(Pass==true)
                {
                    updateData.updatePassword(fields[7], lblID.Text);
                }
                updateData.updateAccount(fields, lblID.Text);
                DialogResult result =
                MessageBox.Show("Changed data successfully! \n You want out? ", "Register",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            dataProcessing(); // Chama o método para processar e aprovar/reprovar os dados inseridos pelo utilizador
        }

        // Quando o utilizador seleciona um determinado mês na comboBoxMonth este adaptas ao numero de dias do mês selecionado
        private void comboBoxMonth_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            countNeverDate++;
            if (neverDate == true)
            {
                fillComboDay(comboBoxMonth.Text);
                comboBoxDay.Text = "1";
            }
            if (countNeverDate >= 2)
            {
                fillComboDay(comboBoxMonth.Text);
                comboBoxDay.Text = "1";
            }
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMonth.Text == "February")
            {
                fillComboDay(comboBoxMonth.Text);
                comboBoxDay.Text = "1";
            }
        }

        private void checkBoxDeleteAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDeleteAccount.Checked)
            {
                lblDelete.Visible = true;
            }
            else
            {
                lblDelete.Visible = false;
            }
        }

    }
}
