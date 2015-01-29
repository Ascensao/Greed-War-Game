using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace MMORTS___Greed_War_Game_Client
{
    class mysqlInsertOrUpdate : mysqlCon
    {
        public MySqlDataReader myReader;
        encryption encrypt = new encryption();
        errorMSG msg = new errorMSG();
        public MySqlCommand cmd;
        string sql = null;

        public void sendMsg(string to, string from ,string text)
        {
            try
            {
                sql = "INSERT INTO tbl_user_chat (from_username,to_username, text) values ("+"\'"+from+"\'"+", \'"+to+"\', \'"+text+"\')";
                cmd = new MySqlCommand(sql, server1);
                checkConnection();
                cmd.ExecuteNonQuery();

                DialogResult result =
                MessageBox.Show("Message sent successfully", "Successfuly Send",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                sql = "INSERT INTO tbl_user_chat (from_username,to_username, text) values (" + "\'" + from + "\'" + ", \'" + to + "\', \'" + text + "\')";
                cmd = new MySqlCommand(sql, server1);
                checkConnection();
                cmd.ExecuteNonQuery();
                if (from == to)
                {
                    MessageBox.Show("From: " + to + "\nText: " + text, "Message Received");
                }

            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
        }

        public string[] readMsg(string to)
        {
            string[] info = new string[2];
            try
            {
                sql = "SELECT * FROM tbl_user_chat WHERE to_username LIKE " + "\'" + to + "\'";
                checkConnection();
                cmd = new MySqlCommand(sql, server1);
                myReader = cmd.ExecuteReader();
                while (myReader.Read())
                {
                    info[0] = Convert.ToString(myReader.GetString(1));
                    info[1] = Convert.ToString(myReader.GetString(5));
                }
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
                myReader.Close();
                return info;
        }


        public void updateAccount(string[] val, string id)
        {
            sql = "UPDATE tbl_user_account SET email=@email , username=@username , name=@name , surname=@surname , gender=@gender , birthDate=@birthDate , country=@country WHERE id_user_account = @id";
            try
            {
                cmd = new MySqlCommand(sql, server1);
                cmd.Parameters.Add(new MySqlParameter("@email", val[5]));
                cmd.Parameters.Add(new MySqlParameter("@username", val[6]));
                cmd.Parameters.Add(new MySqlParameter("@name", val[0]));
                cmd.Parameters.Add(new MySqlParameter("@surname", val[1]));
                cmd.Parameters.Add(new MySqlParameter("@gender", val[2]));
                cmd.Parameters.Add(new MySqlParameter("@birthDate", val[3]));
                cmd.Parameters.Add(new MySqlParameter("@country", val[4]));
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                checkConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
        }
        public void updatePassword(string pass, string id)
        {
            sql = "UPDATE tbl_user_account SET password=@password  WHERE id_user_account = @id";
            try
            {
                cmd = new MySqlCommand(sql, server1);
                cmd.Parameters.Add(new MySqlParameter("@password", encrypt.generateMD5(pass)));
                cmd.Parameters.Add(new MySqlParameter("@id", id));
                checkConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
        }
        public void updateResourcesAfterPurchase(int[] resources, string planetID)
        {
            sql = "UPDATE tbl_planet_resources SET gold=@gold, citizens=@citizens, energy=@energy, food=@food, titanium=@titanium, deuterium=@deuterium, iron=@iron, crystal=@crystal, stone=@stone, uranium=@uranium, oil=@oil, grain=@grain, water=@water WHERE id_planet_resources=@id";
            try
            {
                cmd = new MySqlCommand(sql, server1);
                cmd.Parameters.Add(new MySqlParameter("@gold", Convert.ToString(resources[0])));
                cmd.Parameters.Add(new MySqlParameter("@citizens", Convert.ToString(resources[2])));
                cmd.Parameters.Add(new MySqlParameter("@energy", Convert.ToString(resources[4])));
                cmd.Parameters.Add(new MySqlParameter("@food", Convert.ToString(resources[5])));
                cmd.Parameters.Add(new MySqlParameter("@titanium", Convert.ToString(resources[6])));
                cmd.Parameters.Add(new MySqlParameter("@deuterium", Convert.ToString(resources[7])));
                cmd.Parameters.Add(new MySqlParameter("@iron", Convert.ToString(resources[8])));
                cmd.Parameters.Add(new MySqlParameter("@crystal", Convert.ToString(resources[9])));
                cmd.Parameters.Add(new MySqlParameter("@stone", Convert.ToString(resources[10])));
                cmd.Parameters.Add(new MySqlParameter("@uranium", Convert.ToString(resources[11])));
                cmd.Parameters.Add(new MySqlParameter("@oil", Convert.ToString(resources[12])));
                cmd.Parameters.Add(new MySqlParameter("@grain", Convert.ToString(resources[13])));
                cmd.Parameters.Add(new MySqlParameter("@water", Convert.ToString(resources[14])));
                cmd.Parameters.Add(new MySqlParameter("@id", planetID));
                checkConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
        }
        public void updateBuilding(string planetID, string building, int buildingNivel)
        {
            try
            {
            sql = "UPDATE tbl_planet_buildings SET " + building + "=@building WHERE id_planet_buildings=@planetID";
            cmd = new MySqlCommand(sql, server1);
            cmd.Parameters.Add(new MySqlParameter("@building", Convert.ToString(buildingNivel)));
            cmd.Parameters.Add(new MySqlParameter("@planetID", planetID));
            checkConnection();
            cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
        }
        public void updateResearch(string userID, string research, int researchNivel)
        {
            try
            {
                sql = "UPDATE tbl_user_research SET " + research + "=@research WHERE id_user_research=@userID";
                cmd = new MySqlCommand(sql, server1);
                cmd.Parameters.Add(new MySqlParameter("@research", Convert.ToString(researchNivel)));
                cmd.Parameters.Add(new MySqlParameter("@userID", userID));
                checkConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
        }
        public void updateFleet(string planetID, string fleet, int qtt)
        {
            try
            {
                sql = "UPDATE tbl_planet_fleet SET " + fleet + "=@fleet WHERE id_user_research=@planetID";
                cmd = new MySqlCommand(sql, server1);
                cmd.Parameters.Add(new MySqlParameter("@fleet", Convert.ToString(qtt)));
                cmd.Parameters.Add(new MySqlParameter("@planetID", planetID));
                checkConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
        }
        public void updateDefense(string planetID, string defense, int qtt)
        {
            try
            {
                sql = "UPDATE tbl_planet_defense SET " + defense + "=@defense WHERE id_user_research=@planetID";
                cmd = new MySqlCommand(sql, server1);
                cmd.Parameters.Add(new MySqlParameter("@defense", Convert.ToString(qtt)));
                cmd.Parameters.Add(new MySqlParameter("@planetID", planetID));
                checkConnection();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                msg.errorExeption(e.Message.ToString());
            }
        }
    }
}
