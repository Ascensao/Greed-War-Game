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
    public partial class formMsg : Form
    {
        public formMsg(string name)
        {
            InitializeComponent();
            fromx=name;
        }
        string fromx;
        mysqlInsertOrUpdate insert = new mysqlInsertOrUpdate();
        private void btnSend_Click(object sender, EventArgs e)
        {
            insert.sendMsg(txtTo.Text, fromx, txtMsg.Text);
        }
    }
}
