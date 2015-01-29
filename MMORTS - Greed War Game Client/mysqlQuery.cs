using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace MMORTS___Greed_War_Game_Client
{
    class mysqlQuery: mysqlCon
    {
        errorMSG msg = new errorMSG();
        public MySqlCommand consult;
        public MySqlDataReader myReader;
        string query = null;


        public void executeQuery(string query)
        {
            consult = new MySqlCommand(query, server1);
            consult.ExecuteScalar();
        }
        public string singleResult(string query)
        {
            try
            {
                checkConnection();
                consult = new MySqlCommand(query, server1);
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
            return Convert.ToString(consult.ExecuteScalar());
        }
        public string[] multiResult(int size, string query)
        {
            string[] content = new string[size];
            try
            {
                checkConnection();
                consult = new MySqlCommand(query, server1);
                myReader = consult.ExecuteReader();
                myReader.Read();
                for (int i = 0; i < size; i++)
                {
                    content[i] = Convert.ToString(myReader.GetString(i));
                }
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
            finally
            {
                myReader.Close(); 
            }
            return content;
        }

        public int[] localCoordinatesConsult(string planetID)
        {
            int[] coord = new int[3];
            try
            {
                query = "SELECT * FROM tbl_planet WHERE id_planet LIKE " + "\'" + planetID + "\'";
                checkConnection();
                consult = new MySqlCommand(query, server1);
                myReader = consult.ExecuteReader();
                myReader.Read();
                while (myReader.Read())
                {
                    coord[0] = Convert.ToInt32(myReader.GetString(7));
                    coord[1] = Convert.ToInt32(myReader.GetString(8));
                    coord[2] = Convert.ToInt32(myReader.GetString(9));
                }
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
            finally
            {
                myReader.Close();
            }
            return coord;
        }

        public string checkVersion()
        {
            try
            {
                query = "SELECT version FROM tbl_software_info WHERE id_software_info LIKE '1'";
                checkConnection();
                consult = new MySqlCommand(query, server1);
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
            return Convert.ToString(consult.ExecuteScalar());
        }

    }
}
