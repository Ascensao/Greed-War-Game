using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MMORTS___Greed_War_Game_Client
{
    class readFileManage
    {        
        FileStream stream;
        StreamReader reader;
        samfile sam = new samfile();
        string content;
        string path;
        string line;
        int count;
        public void rememberLogin(out string user, out string pass)
        {
                path = @"gamedata\configlog.dat";
                stream = new FileStream(path, FileMode.Open);
                reader = new StreamReader(stream);
                user = Convert.ToString(reader.ReadLine());
                pass = Convert.ToString(reader.ReadLine());
                reader.Close(); //finally
        }
        public string OneArgument(int numberLine, string path)
        {
            count = 0;
            stream = new FileStream(path, FileMode.Open);
            reader = new StreamReader(stream);
            do
            {
                count=count+1;
                line = reader.ReadLine();
            } while ((numberLine != count));
            reader.Close();
            return line;
        }
        public int[] planetID()
        {
            content = null;
            path = @"gamedata/planetID.dat";
            stream = new FileStream(path, FileMode.Open);
            reader = new StreamReader(stream);
            int[] planet = new int[5];
            for (int i = 0; i < 5; i++)
            {
                planet[i] = Convert.ToInt32(reader.ReadLine());
                content = content + planet[i];
            }
            reader.Close();
            sam.securityView("planetID",content ,0);
            return planet;
        }
        public int[] researchQtt()
        {
            content = null;
            path = @"usersave/research1.sav";
            stream = new FileStream(path, FileMode.Open);
            reader = new StreamReader(stream);
            int[] research = new int[12];
            for (int i = 0; i < 12; i++)
            {
                research[i] = Convert.ToInt32(reader.ReadLine());
                content = content + research[i];
            }
            reader.Close();
            sam.securityView("research",content ,0);
            return research;
        }
        public int[] resourceQtt(int planet)
        {
            content = null;
            path = @"usersave/resource" + Convert.ToString(planet) + ".sav";
            stream = new FileStream(path, FileMode.Open);
            reader = new StreamReader(stream);
            int[] resource = new int[15];
            for(int i=0; i<15; i++)
            {
                resource[i] = Convert.ToInt32(reader.ReadLine());
                content = content + resource[i];
            }
            reader.Close();
            sam.securityView("resource",content, planet);
            return resource;
        }
        public int[] buildingQtt(int planet)
        {
            content = null;
            path = @"usersave/building" + Convert.ToString(planet) + ".sav";
            stream = new FileStream(path, FileMode.Open);
            reader = new StreamReader(stream);
            int[] building = new int[18];
            for (int i = 0; i < 18; i++)
            {
                building[i] = Convert.ToInt32(reader.ReadLine());
                content = content + building[i];
            }
            reader.Close();
            sam.securityView("building", content, planet);
            return building;
        }
        public int[] fleetQtt(int planet)
        {
            content = null;
            path = @"usersave/fleet" + Convert.ToString(planet) + ".sav";
            stream = new FileStream(path, FileMode.Open);
            reader = new StreamReader(stream);
            int[] fleet = new int[11];
            for (int i = 0; i < 11; i++)
            {
                fleet[i] = Convert.ToInt32(reader.ReadLine());
                content = content + fleet[i];
            }
            reader.Close();
            sam.securityView("fleet", content, planet);
            return fleet;
        }
        public int[] defenseQtt(int planet)
        {
            content = null;
            path = @"usersave/defense" + Convert.ToString(planet) + ".sav";
            stream = new FileStream(path, FileMode.Open);
            reader = new StreamReader(stream);
            int[] defense = new int[8];
            for (int i = 0; i < 8; i++)
            {
                defense[i] = Convert.ToInt32(reader.ReadLine());
                content = content + defense[i];
            }
            reader.Close();
            sam.securityView("defense", content, planet);
            return defense;
        }
        public int[] itemPrice(int firstLine)
        {
            content = null;
            line = null;
            path = @"gamedata/price.dat";
            stream = new FileStream(path, FileMode.Open);
            reader = new StreamReader(stream);
            int[] price = new int[13];
            for (int i = 0; i < firstLine - 1; i++)
            {
                line = reader.ReadLine();
            }
            for (int i = 0; i < 13; i++)
            {
                price[i] = Convert.ToInt32(reader.ReadLine());
            }
            line = null;
            reader.Close();
            StreamReader reader2 = new StreamReader(@"gamedata/price.dat");
            do
            {
                line = reader2.ReadLine();
                content = content + line;
            } while (line != null);
            reader2.Close();
            sam.securityView("price", content, 0);
            return price;
        }
        public int[] shipSkill(int firstLine)
        {
            content = null;
            line = null;
            path = @"gamedata/ship.dat";
            stream = new FileStream(path, FileMode.Open);
            reader = new StreamReader(stream);
            int[] ship = new int[8];
            for (int i = 0; i < firstLine - 1; i++)
            {
                line = reader.ReadLine();
            }
            for (int i = 0; i < 8; i++)
            {
                ship[i] = Convert.ToInt32(reader.ReadLine());
            }
            line = null;
            reader.Close();
            StreamReader reader2 = new StreamReader(@"gamedata/ship.dat");
            do
            {
                line = reader2.ReadLine();
                content = content + line;
            } while (line != null);
            reader2.Close();
            sam.securityView("ship", content, 0);
            return ship;
        }
    }
}
