using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace MMORTS___Greed_War_Game_Client
{
    class mysqlCon
    {
        public MySqlConnection server1 = new MySqlConnection(" Persist Security Info=False;" +
       "server=mysql.magicianware.com;database=db_gwg_serv1;uid=????;pwd=????");
        public void checkConnection()
        {
            if ((server1.State == ConnectionState.Closed) || (server1.State == ConnectionState.Closed))
            {
                server1.Open();
            }
        }
    }
}
