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
    public partial class formFleet : Form
    {
        public formFleet(int[] tempFleet, int[] targetCoord, string name, string mission, int tempPlanetID, int[] tempResources)
        {
            InitializeComponent();
            readAllShipInfo();
            readShipQtt(tempFleet);
            readLocalCoordinates(tempPlanetID);
            readTargetCoordinates(targetCoord);
            namePlayer = name;
            missionType = mission;
            fillVariables(tempResources);
        }
        //Invocação de classes
        readFileManage autoRead = new readFileManage();
        mysqlInsertOrUpdate update = new mysqlInsertOrUpdate();
        mysqlQuery myquery = new mysqlQuery();
        //Contador aAuxiliar para leituras de métodos
        int count = 0;
        //Nomo do player target
        string namePlayer;
        //Tipo de missão
        string missionType = null;
        //Cordenadas do planeta local
        int[] localCoordinates = new int[3];
        //coordenadas do planeta alvo
        int[] targetCoordinates = new int[3] {0,0,0};
        //quantiddade de cada nave
        int[] shipQtt = new int[11];
        //Especificações das naves
        int [,] shipinfo = new int[11,8];
        //Quantidade de capacidade de transporte usada
        int usedLoad = 0;

        private void fillVariables(int[] resources)
        {
            nudGold.Maximum = resources[0];
            nudCitizens.Maximum = resources[2];
            nudTitanium.Maximum = resources[6];
            nudDeuterium.Maximum = resources[7];
            nudUranium.Maximum = resources[11];
            nudOil.Maximum = resources[12];
            nudIron.Maximum = resources[8];
            nudCrystal.Maximum = resources[9];
            nudStone.Maximum = resources[10];
            nudFood.Maximum = resources[5];
            nudGrain.Maximum = resources[13];
            nudWater.Maximum = resources[14];

            lbl_fighter.Text = Convert.ToString(shipQtt[0]);
            lbl_hunter.Text = Convert.ToString(shipQtt[1]);
            lbl_bomber.Text = Convert.ToString(shipQtt[2]);
            lbl_destroyer.Text = Convert.ToString(shipQtt[3]);
            lbl_slayer.Text = Convert.ToString(shipQtt[4]);
            lbl_armageddon.Text = Convert.ToString(shipQtt[5]);
            lbl_sattelite.Text = Convert.ToString(shipQtt[6]);
            lbl_colonyship.Text = Convert.ToString(shipQtt[7]);
            lbl_recycler.Text = Convert.ToString(shipQtt[8]);
            lbl_espionage_probe.Text = Convert.ToString(shipQtt[9]);
            lbl_cargoship.Text = Convert.ToString(shipQtt[10]);

            nudShipFighter.Maximum = shipQtt[0];
            nudShipHunter.Maximum = shipQtt[1];
            nudShipBomber.Maximum = shipQtt[2];
            nudShipDestroyer.Maximum = shipQtt[3];
            nudShipSlayer.Maximum = shipQtt[4];
            nudShipArmageddon.Maximum = shipQtt[5];
            nudShipSatellite.Maximum = shipQtt[6];
            nudShipColonyship.Maximum = shipQtt[7];
            nudShipRecycler.Maximum = shipQtt[8];
            nudShipEspionageprobe.Maximum = shipQtt[9];
            nudShipCargoship.Maximum = shipQtt[10];

            picBoxSatellite.Enabled = false;
            nudShipSatellite.Enabled = false;


            if ((targetCoordinates[0] != 0) && (targetCoordinates[1] != 0) && (targetCoordinates[2] != 0))
            {
                maskedCoordX.Text = Convert.ToString(targetCoordinates[0]);
                maskedCoordY.Text = Convert.ToString(targetCoordinates[1]);
                maskedCoordZ.Text = Convert.ToString(targetCoordinates[2]);
                checkBoxLock.Checked = true;
                maskedCoordX.Enabled = false;
                maskedCoordY.Enabled = false;
                maskedCoordZ.Enabled = false;
                txtName.Text = namePlayer;
                if ((missionType == "colonize") || (missionType == "transport"))
                {
                    changeSize();
                    groupBoxResource.Visible = true;
                }
            }
        }

        private void readLocalCoordinates(int planetID)
        {
            localCoordinates[0] = 1;
            localCoordinates[1] = 1;
            localCoordinates[2] = 1;
            /*
            count=0;
            foreach (int val in myquery.localCoordinatesConsult(Convert.ToString(planetID)))
            {
                localCoordinates[count] = val;
                count++;
            }
             * */
        }

        private void readTargetCoordinates(int[] val)
        {
            targetCoordinates[0] = 1;
            targetCoordinates[1] = 100;
            targetCoordinates[2] = 1;

            /*
            for (int i = 0; i < 3; i++)
            {
                targetCoordinates[i] = val[i];
            }
             * */
        }

        private void readShipQtt(int[] val)
        {
            for(int i=0; i<11;i++)
            {
                shipQtt[i]=val[i];
            }
        }

        private void readAllShipInfo()
        {
            count = 0;
            foreach (int val in autoRead.shipSkill(2))
            {
                shipinfo[0, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(11))
            {
                shipinfo[1, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(20))
            {
                shipinfo[2, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(29))
            {
                shipinfo[3, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(38))
            {
                shipinfo[4, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(47))
            {
                shipinfo[5, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(56))
            {
                shipinfo[6, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(65))
            {
                shipinfo[7, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(74))
            {
                shipinfo[8, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(83))
            {
                shipinfo[9, count] = val;
                count++;
            }
            count = 0;
            foreach (int val in autoRead.shipSkill(92))
            {
                shipinfo[10, count] = val;
                count++;
            }
        }

        private void changeSize()
        {
        }

        public static string secondToString(int segundos)
        {
            string horas = Convert.ToInt32(segundos / 3600).ToString();
            string minutos = Convert.ToInt32((segundos % 3600) / 60).ToString();
            string seg = Convert.ToInt32((segundos % 3600) % 60).ToString();
            if (horas.Length == 1)
            {
                horas = "0" + horas;
            }
            if (minutos.Length == 1)
            {
                minutos = "0" + minutos;
            }
            if (seg.Length == 1)
            {
                seg = "0" + seg;
            }
            return horas + ":" + minutos + ":" + seg;
        }

        private int calcShipSlowest()
        {
            int ship=0;
            if (nudShipArmageddon.Value == 0)
            {
                if (nudShipRecycler.Value == 0)
                {
                    if (nudShipSlayer.Value == 0)
                    {
                        if (nudShipDestroyer.Value == 0)
                        {
                            if (nudShipCargoship.Value == 0)
                            {
                                if (nudShipBomber.Value == 0)
                                {
                                    if (nudShipColonyship.Value == 0)
                                    {
                                        if (nudShipHunter.Value == 0)
                                        {
                                            if (nudShipFighter.Value == 0)
                                            {
                                                if (nudShipEspionageprobe.Value != 0)
                                                {
                                                    ship = 9;
                                                }
                                            }
                                            else
                                            {
                                                ship = 0;
                                            }
                                        }
                                        else
                                        {
                                            ship = 1;
                                        }
                                    }
                                    else
                                    {
                                        ship = 7;
                                    }
                                }
                                else
                                {
                                    ship = 2;
                                }
                            }
                            else
                            {
                                ship = 10;
                            }
                        }
                        else
                        {
                            ship = 3;
                        }
                    }
                    else
                    {
                        ship = 4;
                    }
                }
                else
                {
                    ship = 8;
                }
            }
            else
            {
                ship = 5;
            }
            return ship;
        }


        private int calcDistance()
        {
            //MessageBox.Show(Convert.ToString("Target: "+targetCoordinates[0]+"-"+targetCoordinates[1]+"-"+targetCoordinates[2]+"\nLocal: "+localCoordinates[0]+"-"+localCoordinates[1]+"-"+localCoordinates[2]));
            int[] coord = new int[3];
            coord[0] = Math.Abs(targetCoordinates[0] - localCoordinates[0]) * 8991;
            coord[1] = Math.Abs(targetCoordinates[1] - localCoordinates[1]) * 9;
            coord[2] = Math.Abs(targetCoordinates[2] - localCoordinates[2]);
            //MessageBox.Show(Convert.ToString("Distancex1: " + coord[0]+"\nDistancex2: " + coord[1] +"\nDistancex3: "+ coord[2]));
            return coord[0] + coord[1] + coord[2];
        }

        private int calculateTimeseconds(int shipSelected)
        {
            int distance = calcDistance();
            int speed = shipinfo[shipSelected, 4];
            int per = Convert.ToInt32((speed * Convert.ToInt32(comboBoxSpeed.Text))/100);
            if (per == 0)
            {
                per = 1;
            }
            return Convert.ToInt32(distance/per);
        }
         
        private int calculateLoad()
        {
            int totalLoad=0;
            int[] shipTypeLoad = new int[11];
            shipTypeLoad[0] = Convert.ToInt32(nudShipFighter.Value) * shipinfo[0, 3];
            shipTypeLoad[1] = Convert.ToInt32(nudShipHunter.Value) * shipinfo[1, 3];
            shipTypeLoad[2] = Convert.ToInt32(nudShipBomber.Value) * shipinfo[2, 3];
            shipTypeLoad[3] = Convert.ToInt32(nudShipDestroyer.Value) * shipinfo[3, 3];
            shipTypeLoad[4] = Convert.ToInt32(nudShipSlayer.Value) * shipinfo[4, 3];
            shipTypeLoad[5] = Convert.ToInt32(nudShipArmageddon.Value) * shipinfo[5, 3];
            shipTypeLoad[6] = Convert.ToInt32(nudShipSatellite.Value) * shipinfo[6, 3];
            shipTypeLoad[7] = Convert.ToInt32(nudShipColonyship.Value) * shipinfo[7, 3];
            shipTypeLoad[8] = Convert.ToInt32(nudShipRecycler.Value) * shipinfo[8, 3];
            shipTypeLoad[9] = Convert.ToInt32(nudShipEspionageprobe.Value) * shipinfo[9, 3];
            shipTypeLoad[10] = Convert.ToInt32(nudShipCargoship.Value) * shipinfo[10, 3];
            for (int i=0; i<11; i++)
            {
                totalLoad += shipTypeLoad[i];
            }
            return totalLoad;
        }

        private int calculateConsuption()
        {
            int totalConsuption = 0;
            int distance = calcDistance();
            int[] shipTypeConsup = new int[11];
            shipTypeConsup[0] = Convert.ToInt32((distance * nudShipFighter.Value) * shipinfo[0, 5]);
            shipTypeConsup[1] = Convert.ToInt32((distance * nudShipHunter.Value) * shipinfo[1, 5]);
            shipTypeConsup[2] = Convert.ToInt32((distance * nudShipBomber.Value) * shipinfo[2, 5]);
            shipTypeConsup[3] = Convert.ToInt32((distance * nudShipDestroyer.Value) * shipinfo[3, 5]);
            shipTypeConsup[4] = Convert.ToInt32((distance * nudShipSlayer.Value) * shipinfo[4, 5]);
            shipTypeConsup[5] = Convert.ToInt32((distance * nudShipArmageddon.Value) * shipinfo[5, 5]);
            shipTypeConsup[6] = Convert.ToInt32((distance * nudShipSatellite.Value) * shipinfo[6, 5]);
            shipTypeConsup[7] = Convert.ToInt32((distance * nudShipColonyship.Value) * shipinfo[7, 5]);
            shipTypeConsup[8] = Convert.ToInt32((distance * nudShipRecycler.Value) * shipinfo[8, 5]);
            shipTypeConsup[9] = Convert.ToInt32((distance * nudShipEspionageprobe.Value) * shipinfo[9, 5]);
            shipTypeConsup[10] = Convert.ToInt32((distance * nudShipCargoship.Value) * shipinfo[10, 5]);
            for (int i = 0; i < 11; i++)
            {
                totalConsuption += Convert.ToInt32((shipTypeConsup[i]* Convert.ToInt32(comboBoxSpeed.Text)) / 100);
            }
            return totalConsuption;
        }

        

        //Faz o enable ou o disable dos botões de adicionar recursos
        private void changeLoad()
        {
            int avaibelload = Convert.ToInt32(lblAvailableLoad.Text);
            if (avaibelload == 0)
            {
                progressBarLoad.Value = 0;
            }
            if (usedLoad == 0)
            {
                progressBarLoad.Value = 0;
            }
            if ((avaibelload != 0) && (usedLoad != 0))
            {
                progressBarLoad.Value = Convert.ToInt32((usedLoad * 100) / avaibelload);
            }   
        }
        
        private void updateCalculations()
        {
            lblConsumption.Text = Convert.ToString(calculateConsuption());
            lblLoadCapacity.Text=Convert.ToString(calculateLoad());
            lblAvailableLoad.Text = lblLoadCapacity.Text;
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + lblConsumption.Text);
            changeLoad();
            lblTime.Text = Convert.ToString(secondToString(calculateTimeseconds(calcShipSlowest())));
        }

        private void nudShipFighter_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipHunter_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipBomber_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipDestroyer_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipSlayer_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipArmageddon_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipSatellite_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipColonyship_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipRecycler_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipEspionageprobe_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudShipCargoship_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void comboBoxSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCalculations();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControlFleet.SelectTab(1);
        }

        private void nudGold_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudCitizens_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudTitanium_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudDeuterium_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudUranium_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudOil_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudIron_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudCrystal_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudStone_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudFood_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudGrain_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void nudWater_ValueChanged(object sender, EventArgs e)
        {
            int consup = Convert.ToInt32(lblConsumption.Text);
            usedLoad = Convert.ToInt32(nudGold.Value + nudCitizens.Value + nudTitanium.Value + nudDeuterium.Value + nudOil.Value + nudUranium.Value + nudIron.Value + nudCrystal.Value + nudStone.Value + nudFood.Value + nudGrain.Value + nudWater.Value + consup);
            changeLoad();
        }

        private void checkBoxLock_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLock.Enabled == false)
            {
                maskedCoordX.Enabled = true;
                maskedCoordY.Enabled = true;
                maskedCoordZ.Enabled = true;
            }
        }


        //SHIPINFO
        /*[X,-]
         * fighter          0
         * hunter           1
         * bomber           2
         * destroyer        3
         * slayer           4
         * armageddon       5
         * satellite       6
         * colonyship       7   
         * recycler         8
         * espionageprobe   9
         * cargoship        10
         * 
         * [-,Y]
         * firepower        0
         * armour           1
         * shield           2
         * capacity         3       
         * speed            4
         * cosumption       5   
         * energy           6
         * integrity        7
         * */
    }
}
