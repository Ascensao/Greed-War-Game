using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace MMORTS___Greed_War_Game_Client
{
    class writeFileManage: mysqlCon
    {
        encryption encrypter = new encryption();
        errorMSG errorX = new errorMSG();
        public MySqlCommand consult;
        public MySqlDataReader myReader;
        FileStream stream;
        StreamWriter writer;
        string query;
        string path;
        string[] itemPrice = new string[49] {"iron_mine", "crystal_mine", "stone_mine", "uranium_mine", 
        "oil_mine", "farm", "water_pump", "titanium_factory", "deuterium_refinary", "power_plant",
        "nuclear_reactor", "food_industry", "nanite_factory", "metropolis", "bank", "black_market",
        "research_lab", "hangar", "weapon", "armour", "shield", "energy", "combustion", "accelaration",
        "laser", "plasma", "gravity", "espionage", "computer", "expedition", "sattelite", "colonyship", "recycler",
        "espionage_probe", "cargoship", "fighter", "hunter", "bomber", "destroyer", "slayer", "armageddon",
        "laser_cannon", "accelaration_cannon", "plasma_cannon", "gravity_cannon", "nuclear_cannon", 
        "jericho", "energy_shield", "anti_ballistic"};
        string[] shipList = new string[11] { "fighter", "hunter", "bomber", "destroyer", "slayer", "armageddon",
        "satellite", "colonyship", "recycler", "espionageprobe", "cargoship" };

        public bool fileExist(string path)
        {
            return File.Exists(path);
        }

        public void fileDelete(string path)
        {
            File.Delete(path);
        }

        public void remember(string user, string pass)
        {
            try
            {
                stream = new FileStream(@"gamedata\configlog.dat", FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                writer.WriteLine(user);
                writer.WriteLine(pass);
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));      
            }
            finally
            {
                writer.Close();
            }
        }

        public void userStatus(string idUser, string path)
        {
            try
            {
                query = "SELECT * FROM tbl_user_stats WHERE id_user_stats LIKE " + "\'" + idUser + "\'";
                stream = new FileStream(path, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                checkConnection();
                consult = new MySqlCommand(query, server1);
                myReader = consult.ExecuteReader();
                while (myReader.Read())
                {
                    writer.WriteLine(Convert.ToString(myReader.GetString(1)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(2)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(3)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(4)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(5)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(13)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(16)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(17)));
                }
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));
            }
            finally
            {
                writer.Close();
                myReader.Close();
            }
        }


        public void itemPriceSave()
        {
            path = @"gamedata/price.dat";
            try
            {
                stream = new FileStream(path, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                checkConnection();
                for (int i = 0; i < 49; i++)
                {
                    query = "SELECT * FROM tbl_item_price WHERE name LIKE " + "\'" + itemPrice[i] + "\'";
                    consult = new MySqlCommand(query, server1);
                    myReader = consult.ExecuteReader();
                    while (myReader.Read())
                    {
                        writer.WriteLine(Convert.ToString(myReader.GetString(1)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(2)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(3)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(4)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(5)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(6)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(7)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(8)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(9)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(10)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(11)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(12)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(13)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(14)));
                    }
                    myReader.Close();
                }
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));
            }
            finally
            {
                writer.Close();
            }
        }

        public void shipConf()
        {
            path = @"gamedata\ship.dat";
            try
            {
                stream = new FileStream(path, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                checkConnection();
                for (int i = 0; i < 11; i++)
                {
                    query = "SELECT * FROM tbl_ship_skill WHERE ship LIKE " + "\'" + shipList[i] + "\'";
                    consult = new MySqlCommand(query, server1);
                    myReader = consult.ExecuteReader();
                    while (myReader.Read())
                    {
                        writer.WriteLine(Convert.ToString(myReader.GetString(1)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(2)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(3)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(4)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(5)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(6)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(7)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(8)));
                        writer.WriteLine(Convert.ToString(myReader.GetString(9)));

                    }
                    myReader.Close();
                }
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));
            }
            finally
            {
                writer.Close();
            }
        }

        public void planetIdSave(string idUser)
        {
            path = @"gamedata/planetID.dat";
            try
            {
                query = "SELECT * FROM tbl_user_save WHERE id_user_save LIKE " + "\'" + idUser + "\'";
                stream = new FileStream(path, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                checkConnection();
                consult = new MySqlCommand(query, server1);
                myReader = consult.ExecuteReader();
                while (myReader.Read())
                {
                    writer.WriteLine(Convert.ToString(myReader.GetString(1)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(2)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(3)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(4)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(5)));
                }
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));
            }
            finally
            {
                writer.Close();
                myReader.Close();
            }
        }


        public void researchSave(string idUser, string path)
        {
            try
            {
                query = "SELECT * FROM tbl_user_research WHERE id_user_research LIKE " + "\'" + idUser + "\'";
                stream = new FileStream(path, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                checkConnection();
                consult = new MySqlCommand(query, server1);
                myReader = consult.ExecuteReader();
                while (myReader.Read())
                {
                    writer.WriteLine(Convert.ToString(myReader.GetString(1)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(2)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(3)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(4)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(5)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(6)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(7)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(8)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(9)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(10)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(11)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(12)));
                }
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));
            }
            finally
            {
                writer.Close();
                myReader.Close();
            }
        }

        public void buildingSave(int idPlanet, string path)
        {
            try
            {
                query = "SELECT * FROM tbl_planet_buildings WHERE id_planet_buildings LIKE " + "\'" + Convert.ToString(idPlanet) + "\'";
                stream = new FileStream(path, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                checkConnection();
                consult = new MySqlCommand(query, server1);
                myReader = consult.ExecuteReader();
                while (myReader.Read())
                {
                    writer.WriteLine(Convert.ToString(myReader.GetString(1)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(2)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(3)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(4)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(5)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(6)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(7)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(8)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(9)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(10)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(11)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(12)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(13)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(14)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(15)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(16)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(17)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(18)));
                }
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));
            }
            finally
            {
                writer.Close();
                myReader.Close();
            }
        }

        public void resourcesSave(int idPlanet, string path)
        {
            try
            {
                query = "SELECT * FROM tbl_planet_resources WHERE id_planet_resources LIKE " + "\'" + Convert.ToString(idPlanet) + "\'";
                stream = new FileStream(path, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                checkConnection();
                consult = new MySqlCommand(query, server1);
                myReader = consult.ExecuteReader();
                while (myReader.Read())
                {
                    writer.WriteLine(Convert.ToString(myReader.GetString(1)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(2)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(3)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(4)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(5)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(6)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(7)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(8)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(9)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(10)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(11)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(12)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(13)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(14)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(15)));
                }
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));
            }
            finally
            {
                writer.Close();
                myReader.Close();
            }

        }

        public void fleetSave(int idPlanet, string path)
        {
            try
            {
                query = "SELECT * FROM tbl_planet_fleet WHERE id_planet_fleet LIKE " + "\'" + Convert.ToString(idPlanet) + "\'";
                stream = new FileStream(path, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                checkConnection();
                consult = new MySqlCommand(query, server1);
                myReader = consult.ExecuteReader();
                while (myReader.Read())
                {
                    writer.WriteLine(Convert.ToString(myReader.GetString(1)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(2)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(3)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(4)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(5)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(6)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(7)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(8)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(9)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(10)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(11)));
                }
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));
            }
            finally
            {
                writer.Close();
                myReader.Close();
            }

        }

        public void defenseSave(int idPlanet, string path)
        {
            try
            {
                query = "SELECT * FROM tbl_planet_defense WHERE id_planet_defense LIKE " + "\'" + Convert.ToString(idPlanet) + "\'";
                stream = new FileStream(path, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                checkConnection();
                consult = new MySqlCommand(query, server1);
                myReader = consult.ExecuteReader();
                while (myReader.Read())
                {
                    writer.WriteLine(Convert.ToString(myReader.GetString(1)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(2)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(3)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(4)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(5)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(6)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(7)));
                    writer.WriteLine(Convert.ToString(myReader.GetString(8)));
                }
            }
            catch (Exception e)
            {
                errorX.errorExeption(Convert.ToString(e));
            }
            finally
            {
                writer.Close();
                myReader.Close();
            }
        }

    }
}
