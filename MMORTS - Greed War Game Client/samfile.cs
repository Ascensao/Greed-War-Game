using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace MMORTS___Greed_War_Game_Client
{
    class samfile
    {
        encryption encrypt = new encryption();
        errorMSG msg = new errorMSG();
        string line = null;   //writeSam
        string content = null; //writeSam
        FileStream stream;
        StreamWriter writer;
        StreamReader reader;

        public void securityView(string type, string text, int planetID)
        {
            switch (type)
            {
                case "ship":
                    if (readSam(@"gamedata\sam\ship.dat") != encrypt.encryptCode(text))
                    {
                        sabotage();
                    }
                    break;
                case "planetID":
                    if (readSam(@"gamedata\sam\planetID.dat") != encrypt.encryptCode(text))
                    {
                        sabotage();
                    }
                    break;
                case "price":
                    if (readSam(@"gamedata\sam\price.dat") != encrypt.encryptCode(text))
                    {
                        sabotage();
                    }
                    break;
                case "userdata":
                    if (readSam(@"gamedata\sam\userdata.dat") != encrypt.encryptCode(text))
                    {
                        sabotage();
                    }
                    break;
                case "research":
                    if (readSam(@"gamedata\sam\research1.dat") != encrypt.encryptCode(text))
                    {
                        sabotage();
                    }
                    break;
                case "building":
                    switch (planetID)
                    {
                        case 0:
                            if (readSam(@"gamedata\sam\building0.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 1:
                            if (readSam(@"gamedata\sam\building1.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 2:
                            if (readSam(@"gamedata\sam\building2.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 3:
                            if (readSam(@"gamedata\sam\building3.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 4:
                            if (readSam(@"gamedata\sam\building4.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                    }
                    break;
                case "defense":
                    switch (planetID)
                    {
                        case 0:
                            if (readSam(@"gamedata\sam\defense0.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 1:
                            if (readSam(@"gamedata\sam\defense1.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 2:
                            if (readSam(@"gamedata\sam\defense2.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 3:
                            if (readSam(@"gamedata\sam\defense3.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 4:
                            if (readSam(@"gamedata\sam\defense4.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                    }
                    break;
                case "fleet":
                    switch (planetID)
                    {
                        case 0:
                            if (readSam(@"gamedata\sam\fleet0.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 1:
                            if (readSam(@"gamedata\sam\fleet1.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 2:
                            if (readSam(@"gamedata\sam\fleet2.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 3:
                            if (readSam(@"gamedata\sam\fleet3.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 4:
                            if (readSam(@"gamedata\sam\fleet4.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                    }
                    break;
                case "resource":
                    switch (planetID)
                    {
                        case 0:
                            if (readSam(@"gamedata\sam\resource0.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 1:
                            if (readSam(@"gamedata\sam\resource1.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 2:
                            if (readSam(@"gamedata\sam\resource2.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 3:
                            if (readSam(@"gamedata\sam\resource3.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                        case 4:
                            if (readSam(@"gamedata\sam\resource4.dat") != encrypt.encryptCode(text))
                            {
                                sabotage();
                            }
                            break;
                    }

                    break;
                default:
                    MessageBox.Show("Sorry! Error on reading file SAM [All]", "SAM FILE ERROR");
                    break;
            }
        }
        public void SecuritySave(string type, int planetID)
        {
            switch (type)
            {
                case "ship":
                    writeSam(@"gamedata\sam\ship.dat", @"gamedata\ship.dat");
                    break;
                case "planetID":
                    writeSam(@"gamedata\sam\planetID.dat", @"gamedata\planetID.dat");
                    break;
                case "price":
                    writeSam(@"gamedata\sam\price.dat", @"gamedata\price.dat");
                    break;
                case "userdata":
                    writeSam(@"gamedata\sam\userdata.dat", @"gamedata\userdata.dat");
                    break;
                case "research":
                    writeSam(@"gamedata\sam\research1.dat", @"usersave\research1.sav");
                    break;
                case "building":
                    switch (planetID)
                    {
                        case 0:
                            writeSam(@"gamedata\sam\building0.dat", @"usersave\building0.sav");
                            break;
                        case 1:
                            writeSam(@"gamedata\sam\building1.dat", @"usersave\building1.sav");
                            break;
                        case 2:
                            writeSam(@"gamedata\sam\building2.dat", @"usersave\building2.sav");
                            break;
                        case 3:
                            writeSam(@"gamedata\sam\building3.dat", @"usersave\building3.sav");
                            break;
                        case 4:
                            writeSam(@"gamedata\sam\building4.dat", @"usersave\building4.sav");
                            break;
                    }
                    break;
                case "defense":
                    switch (planetID)
                    {
                        case 0:
                            writeSam(@"gamedata\sam\defense0.dat", @"usersave\defense0.sav");
                            break;
                        case 1:
                            writeSam(@"gamedata\sam\defense1.dat", @"usersave\defense1.sav");
                            break;
                        case 2:
                            writeSam(@"gamedata\sam\defense2.dat", @"usersave\defense2.sav");
                            break;
                        case 3:
                            writeSam(@"gamedata\sam\defense3.dat", @"usersave\defense3.sav");
                            break;
                        case 4:
                            writeSam(@"gamedata\sam\defense4.dat", @"usersave\defense4.sav");
                            break;
                    }
                    break;
                case "fleet":
                    switch (planetID)
                    {
                        case 0:
                            writeSam(@"gamedata\sam\fleet0.dat", @"usersave\fleet0.sav");
                            break;
                        case 1:
                            writeSam(@"gamedata\sam\fleet1.dat", @"usersave\fleet1.sav");
                            break;
                        case 2:
                            writeSam(@"gamedata\sam\fleet2.dat", @"usersave\fleet2.sav");
                            break;
                        case 3:
                            writeSam(@"gamedata\sam\fleet3.dat", @"usersave\fleet3.sav");
                            break;
                        case 4:
                            writeSam(@"gamedata\sam\fleet4.dat", @"usersave\fleet4.sav");
                            break;
                    }
                    break;
                case "resource":
                    switch (planetID)
                    {
                        case 0:
                            writeSam(@"gamedata\sam\resource0.dat", @"usersave\resource0.sav");
                            break;
                        case 1:
                            writeSam(@"gamedata\sam\resource1.dat", @"usersave\resource1.sav");
                            break;
                        case 2:
                            writeSam(@"gamedata\sam\resource2.dat", @"usersave\resource2.sav");
                            break;
                        case 3:
                            writeSam(@"gamedata\sam\resource3.dat", @"usersave\resource3.sav");
                            break;
                        case 4:
                            writeSam(@"gamedata\sam\resource4.dat", @"usersave\resource4.sav");
                            break;
                    }
                    break;
                default:
                    MessageBox.Show("Sorry! Error on writing file SAM", "SAM FILE ERROR");
                    break;
            }
        }
        private void sabotage()
        {
            MessageBox.Show("It was verified an attempt to sabotage", "Anti-Cheat Error");
        }
        private string readSam(string from)
        {
            try
            {
                content = null;
                line = null;
                stream = new FileStream(from, FileMode.Open);
                reader = new StreamReader(stream);
                do
                {
                    line = reader.ReadLine();
                    content = content + line;
                } while (line != null);
            }
            catch (Exception e)
            {
                msg.errorExeption(Convert.ToString(e));
            }
            finally
            {
                reader.Close();
            }
            return content;
        }
        private void writeSam(string to, string from)
        {
            try
            {
                line = null;
                content = null;
                stream = new FileStream(to, FileMode.OpenOrCreate);
                writer = new StreamWriter(stream);
                stream = new FileStream(from, FileMode.Open);
                reader = new StreamReader(stream);
                do
                {
                    line = reader.ReadLine();
                    content = content + line;
                } while (line != null);
                writer.WriteLine(encrypt.encryptCode(content));
            }
            catch (Exception e)
            {
                msg.errorExeption(Convert.ToString(e));
            }
            finally
            {
            writer.Close();
            reader.Close();
            }
        }

    }
}
