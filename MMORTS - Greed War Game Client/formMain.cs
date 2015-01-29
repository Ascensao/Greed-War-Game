using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MMORTS___Greed_War_Game_Client
{
    public partial class formMain : Form
    {
        public formMain(string tempUsername, string id)
        {
            InitializeComponent();
            userID = id;
            readPlanetID();
            planetSelect = 0;
            readResource(planetSelect);
            readBuildings(planetSelect); //Metodo Chamado Temporariamente
            startLabels(tempUsername);
            timerProduc.Start();
            timerSave.Start();
            timerProgress.Start();
            progressSave.Value = 0;

            //Temp
            pictureBoxPlanet2.Visible = false;
            pictureBoxPlanet3.Visible = false;
            pictureBoxPlanet4.Visible = false;
            pictureBoxPlanet5.Visible = false;
            lblID.Visible = false;
        }
        DateTime time;
        //Variavel do  Método Read
        readFileManage autoRead = new readFileManage();
        mysqlInsertOrUpdate update = new mysqlInsertOrUpdate();
        Thread groundCode; 
        //Variaveis de Forms
        formBuildings fBuildings;
        formResearch fResearch;
        formShipyard fShipyard;
        formDefense fDefense;
        formFleet fFleet;
        formAccount fAccount;
        formMsg fMsg;
        //Variavel que indica o planeta selecionado de momento
        int planetSelect;
        string userID; 
        int count;
        int[] coordinates = new int[3] { 0, 0, 0 };
        public int[] planetID = new int[5];
        int[] resourchProduction = new int[15] { 2, 1, 5, 0, 0, 10, 15, 20, 55, 50, 45, 35, 40, 30, 25 }; 

        public int[] researchNivel = new int[12];
        //Variaveis de caracterização do Planeta 1
        public int[] resourcesNumber1 = new int[15];
        public int[] buildingsNumber1 = new int[18];
        public int[] fleetNumber1 = new int[11];
        public int[] defenseNumber1 = new int[8];
        //Variaveis de caracterização do Planeta 2
        public int[] resourcesNumber2 = new int[15];
        public int[] buildingsNumber2 = new int[18];
        public int[] fleetNumber2 = new int[11];
        public int[] defenseNumber2 = new int[8];
        //Variaveis de caracterização do Planeta 3
        public int[] resourcesNumber3 = new int[15];
        public int[] buildingsNumber3 = new int[18];
        public int[] fleetNumber3 = new int[11];
        public int[] defenseNumber3 = new int[8];
        //Variaveis de caracterização do Planeta 4
        public int[] resourcesNumber4 = new int[15];
        public int[] buildingsNumber4 = new int[18];
        public int[] fleetNumber4 = new int[11];
        public int[] defenseNumber4 = new int[8];
        //Variaveis de caracterização do Planeta 5
        public int[] resourcesNumber5 = new int[15];
        public int[] buildingsNumber5 = new int[18];
        public int[] fleetNumber5 = new int[11];
        public int[] defenseNumber5 = new int[8];

        private void WorkThreadFunction()
        {
            saveResources();
        }

        //MÉTODOS DE PREENCHIMENTO DE LABELS DA GROUPBOX DOS RECURSOS NATURAIS
        private void startLabels(string username)
        {
            lblPlayer.Text = username;
            lblGold.Text = Convert.ToString(resourcesNumber1[0]);
            lblCoins.Text = Convert.ToString(resourcesNumber1[1]);
            lblCitizens.Text = Convert.ToString(resourcesNumber1[2]);
            lblEnergy.Text = Convert.ToString(resourcesNumber1[4]) + "/" + Convert.ToString(resourcesNumber1[3]);
            lblFood.Text = Convert.ToString(resourcesNumber1[5]);
            lblTitanium.Text = Convert.ToString(resourcesNumber1[6]);
            lblDeuterium.Text = Convert.ToString(resourcesNumber1[7]);
            lblIron.Text = Convert.ToString(resourcesNumber1[8]);
            lblCrystal.Text = Convert.ToString(resourcesNumber1[9]);
            lblStone.Text = Convert.ToString(resourcesNumber1[10]);
            lblUranium.Text = Convert.ToString(resourcesNumber1[11]);
            lblOil.Text = Convert.ToString(resourcesNumber1[12]);
            lblGrain.Text = Convert.ToString(resourcesNumber1[13]);
            lblWater.Text = Convert.ToString(resourcesNumber1[14]);
        }
        private void readPlanetID()
        {
            count = 0;
            foreach (int val in autoRead.planetID())
            {
                planetID[count] = val;
                count++;
            }
        }

        private void industrialProduction() //5 em 5 segundos
        {
            lblGold.Text = Convert.ToString(Convert.ToInt32(lblGold.Text)+(resourchProduction[0]*buildingsNumber1[15]));
            lblCoins.Text = Convert.ToString(resourcesNumber1[0] * Convert.ToInt32(lblCoinRatio.Text));
            lblCitizens.Text = Convert.ToString(Convert.ToInt32(lblCitizens.Text) + (resourchProduction[2] * buildingsNumber1[13]));
            lblFood.Text = Convert.ToString(Convert.ToInt32(lblFood.Text)+(resourchProduction[5]*buildingsNumber1[11]));
            lblTitanium.Text = Convert.ToString(Convert.ToInt32(lblTitanium.Text) + (resourchProduction[6] * buildingsNumber1[7]));
            lblDeuterium.Text = Convert.ToString(Convert.ToInt32(lblDeuterium.Text) + (resourchProduction[7] * buildingsNumber1[8]));
            lblIron.Text = Convert.ToString(Convert.ToInt32(lblIron.Text)+(resourchProduction[8]*buildingsNumber1[0]));
            lblCrystal.Text = Convert.ToString(Convert.ToInt32(lblCrystal.Text)+(resourchProduction[9]*buildingsNumber1[1]));
            lblStone.Text = Convert.ToString(Convert.ToInt32(lblStone.Text)+(resourchProduction[10]*buildingsNumber1[2]));
            lblUranium.Text = Convert.ToString(Convert.ToInt32(lblUranium.Text)+(resourchProduction[11]*buildingsNumber1[3]));
            lblOil.Text = Convert.ToString(Convert.ToInt32(lblOil.Text)+(resourchProduction[12]*buildingsNumber1[4]));
            lblGrain.Text = Convert.ToString(Convert.ToInt32(lblGrain.Text)+(resourchProduction[13]*buildingsNumber1[5]));
            lblWater.Text = Convert.ToString(Convert.ToInt32(lblWater.Text)+(resourchProduction[14]*buildingsNumber1[6]));
            resourcesNumber1[0] = Convert.ToInt32(lblGold.Text);
            resourcesNumber1[1] = Convert.ToInt32(lblCoins.Text);
            resourcesNumber1[2] = Convert.ToInt32(lblCitizens.Text);
            /*resourcesNumber1[3] = Convert.ToInt32(lbl);
            resourcesNumber1[4] = Convert.ToInt32(lblGold.Text); Energia - Tratamento de String*/
            resourcesNumber1[5] = Convert.ToInt32(lblFood.Text);
            resourcesNumber1[6] = Convert.ToInt32(lblTitanium.Text);
            resourcesNumber1[7] = Convert.ToInt32(lblDeuterium.Text);
            resourcesNumber1[8] = Convert.ToInt32(lblIron.Text);
            resourcesNumber1[9] = Convert.ToInt32(lblCrystal.Text);
            resourcesNumber1[10] = Convert.ToInt32(lblStone.Text);
            resourcesNumber1[11] = Convert.ToInt32(lblUranium.Text);
            resourcesNumber1[12] = Convert.ToInt32(lblOil.Text);
            resourcesNumber1[13] = Convert.ToInt32(lblGrain.Text);
            resourcesNumber1[14] = Convert.ToInt32(lblWater.Text);
        }

        private void saveResources()
        {
            update.updateResourcesAfterPurchase(resourcesNumber1, Convert.ToString(planetID[0]));
        }

        //MÉTODOS DE PREENCHIMENTO DE VARIAVEIS DE CONSTITUIÇÃO DO PLANETAS
        private void readResearch()
        {
            count = 0;
            foreach (int qtt in autoRead.researchQtt())
            {
                researchNivel[count] = qtt;
                count++;
            }
        }
        private void readResource(int planetNumber)
        {
            /*Este método preenche os arrays de resources (Recursos) do palenta:
             * caso 0: Preenche todos os arrays
             * caso 1: Preenche array de planeta 1
             * caso 2: Preenche array de planeta 2
             * caso 3: Preenche array de planeta 3
             * caso 4: Preenche array de planeta 4
             * caso 5: Preenche array de planeta 5
             */
            count = 0;
            switch (planetNumber)
            {
                case 0:
                    foreach (int qtt in autoRead.resourceQtt(planetNumber))
                    {
                        resourcesNumber1[count] = qtt;
                        count++;
                    }
                    break;
                case 1:
                    foreach (int qtt in autoRead.resourceQtt(planetNumber))
                    {
                        resourcesNumber2[count] = qtt;
                        count++;
                    }
                    break;
                case 2:
                    foreach (int qtt in autoRead.resourceQtt(planetNumber))
                    {
                        resourcesNumber3[count] = qtt;
                        count++;
                    }
                    break;
                case 3:
                    foreach (int qtt in autoRead.resourceQtt(planetNumber))
                    {
                        resourcesNumber4[count] = qtt;
                        count++;
                    }
                    break;
                case 4:
                    foreach (int qtt in autoRead.resourceQtt(planetNumber))
                    {
                        resourcesNumber5[count] = qtt;
                        count++;
                    }
                    break;
            }
        }
        private void readBuildings(int planetNumber)
        {
            count = 0;
            switch (planetNumber)
            {
                case 0:
                    foreach (int qtt in autoRead.buildingQtt(planetNumber))
                    {
                        buildingsNumber1[count] = qtt;
                        count++;
                    }
                    break;
                case 1:
                    foreach (int qtt in autoRead.buildingQtt(planetNumber))
                    {
                        buildingsNumber2[count] = qtt;
                        count++;
                    }
                    break;
                case 2:
                    foreach (int qtt in autoRead.buildingQtt(planetNumber))
                    {
                        buildingsNumber3[count] = qtt;
                        count++;
                    }
                    break;
                case 3:
                    foreach (int qtt in autoRead.buildingQtt(planetNumber))
                    {
                        buildingsNumber4[count] = qtt;
                        count++;
                    }
                    break;
                case 4:
                    foreach (int qtt in autoRead.buildingQtt(planetNumber))
                    {
                        buildingsNumber5[count] = qtt;
                        count++;
                    }
                    break;
            }
        }
        private void readFleet(int planetNumber)
        {
            count=0;
            switch (planetNumber)
            {
                case 0:
                    foreach (int qtt in autoRead.fleetQtt(planetNumber))
                    {
                        fleetNumber1[count] = qtt;
                        count++;
                    }
                    break;
                case 1:
                    foreach (int qtt in autoRead.fleetQtt(planetNumber))
                    {
                        fleetNumber2[count] = qtt;
                        count++;
                    }
                    break;
                case 2:
                    foreach (int qtt in autoRead.fleetQtt(planetNumber))
                    {
                        fleetNumber3[count] = qtt;
                        count++;
                    }
                    break;
                case 3:
                    foreach (int qtt in autoRead.fleetQtt(planetNumber))
                    {
                        fleetNumber4[count] = qtt;
                        count++;
                    }
                    break;
                case 4:
                    foreach (int qtt in autoRead.fleetQtt(planetNumber))
                    {
                        fleetNumber5[count] = qtt;
                        count++;
                    }
                    break;
            }
        }

        private void readDefense(int planetNumber)
        {
            count = 0;
            switch (planetNumber)
            {
                case 0:
                    foreach (int qtt in autoRead.defenseQtt(planetNumber))
                    {
                        defenseNumber1[count] = qtt;
                        count++;
                    }
                    break;
                case 1:
                    foreach (int qtt in autoRead.defenseQtt(planetNumber))
                    {
                        defenseNumber2[count] = qtt;
                        count++;
                    }
                    break;
                case 2:
                    foreach (int qtt in autoRead.defenseQtt(planetNumber))
                    {
                        defenseNumber3[count] = qtt;
                        count++;
                    }
                    break;
                case 3:
                    foreach (int qtt in autoRead.defenseQtt(planetNumber))
                    {
                        defenseNumber4[count] = qtt;
                        count++;
                    }
                    break;
                case 4:
                    foreach (int qtt in autoRead.defenseQtt(planetNumber))
                    {
                        defenseNumber5[count] = qtt;
                        count++;
                    }
                    break;
            }
        }
        //FIM DE MÉTODOS DE PREENCHIMENTO DE VARIAVEIS DE CONSTITUIÇÃO DE PLANETAS

        //EVENTOS
        private void btnBuildings_Click(object sender, EventArgs e)
        {
            readBuildings(planetSelect);
            switch (planetSelect)
            {
                case 0:
                    fBuildings = new formBuildings(buildingsNumber1, resourcesNumber1, planetID[0], researchNivel);
                    break;
                case 1:
                    fBuildings = new formBuildings(buildingsNumber2, resourcesNumber2, planetID[1], researchNivel);
                    break;
                case 2:
                    fBuildings = new formBuildings(buildingsNumber3, resourcesNumber3, planetID[2], researchNivel);
                    break;
                case 3:
                    fBuildings = new formBuildings(buildingsNumber4, resourcesNumber4, planetID[3], researchNivel);
                    break;
                case 4:
                    fBuildings = new formBuildings(buildingsNumber5, resourcesNumber5, planetID[4], researchNivel);
                    break;
            }
           fBuildings.Show();
        }

        private void btnResearch_Click(object sender, EventArgs e)
        {
            readResearch();
            switch (planetSelect)
            {
                case 0:
                    fResearch = new formResearch(researchNivel, resourcesNumber1, planetID[0], userID, buildingsNumber1[17]);
                    break;
                case 1:
                    fResearch = new formResearch(researchNivel, resourcesNumber2, planetID[1], userID, buildingsNumber2[17]);
                    break;
                case 2:
                    fResearch = new formResearch(researchNivel, resourcesNumber3, planetID[2], userID, buildingsNumber3[17]);
                    break;
                case 3:
                    fResearch = new formResearch(researchNivel, resourcesNumber4, planetID[3], userID, buildingsNumber4[17]);
                    break;
                case 4:
                    fResearch = new formResearch(researchNivel, resourcesNumber5, planetID[4], userID, buildingsNumber5[17]);
                    break;
            }
            fResearch.Show();
        }

        private void btnShipyard_Click(object sender, EventArgs e)
        {
            readFleet(planetSelect);
            switch (planetSelect)
            {
                case 0:
                    fShipyard = new formShipyard(fleetNumber1, resourcesNumber1, planetID[0], buildingsNumber1[17], researchNivel);
                    break;
                case 1:
                    fShipyard = new formShipyard(fleetNumber2, resourcesNumber2, planetID[1], buildingsNumber2[17], researchNivel);
                    break;
                case 2:
                    fShipyard = new formShipyard(fleetNumber3, resourcesNumber3, planetID[2], buildingsNumber3[17], researchNivel);
                    break;
                case 3:
                    fShipyard = new formShipyard(fleetNumber4, resourcesNumber4, planetID[3], buildingsNumber4[17], researchNivel);
                    break;
                case 4:
                    fShipyard = new formShipyard(fleetNumber5, resourcesNumber5, planetID[4], buildingsNumber5[17], researchNivel);
                    break;
            }
            fShipyard.Show();
        }

        private void btnDefense_Click(object sender, EventArgs e)
        {
            readDefense(planetSelect);
            switch (planetSelect)
            {
                case 0:
                    fDefense = new formDefense(defenseNumber1, resourcesNumber1, planetID[0], buildingsNumber1[17], researchNivel);
                    break;
                case 1:
                    fDefense = new formDefense(defenseNumber2, resourcesNumber2, planetID[1], buildingsNumber2[17], researchNivel);
                    break;
                case 2:
                    fDefense = new formDefense(defenseNumber3, resourcesNumber3, planetID[2], buildingsNumber3[17], researchNivel);
                    break;
                case 3:
                    fDefense = new formDefense(defenseNumber4, resourcesNumber4, planetID[3], buildingsNumber4[17], researchNivel);
                    break;
                case 4:
                    fDefense = new formDefense(defenseNumber5, resourcesNumber5, planetID[4], buildingsNumber5[17], researchNivel);
                    break;
            }
            fDefense.Show();
        }

        private void btnFleet_Click(object sender, EventArgs e)
        {
            readFleet(planetSelect);
            switch (planetSelect)
            {
                case 0:
                    fFleet = new formFleet(fleetNumber1,coordinates, null, null, planetID[0], resourcesNumber1);
                    break;
                case 1:
                    fFleet = new formFleet(fleetNumber1, coordinates, null, null, planetID[1], resourcesNumber1);
                    break;
                case 2:
                    fFleet = new formFleet(fleetNumber1, coordinates, null, null, planetID[2], resourcesNumber1);
                    break;
                case 3:
                    fFleet = new formFleet(fleetNumber1, coordinates, null, null, planetID[3], resourcesNumber1);
                    break;
                case 4:
                    fFleet = new formFleet(fleetNumber1, coordinates, null, null, planetID[4], resourcesNumber1);
                    break;
            }
            fFleet.Show();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            fAccount = new formAccount(userID);
            fAccount.Show();
        }

        private void formMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveResources();
            Application.Exit();
        }

        private void timerProduc_Tick(object sender, EventArgs e)
        {
            industrialProduction();
        }

        private void timerSave_Tick(object sender, EventArgs e)
        {

            groundCode = new Thread(new ThreadStart(WorkThreadFunction));
            groundCode.Start();
                               
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now;
            lblData.Text= "Date: " + time.ToLongDateString();
            lblHora.Text="Time: " + time.ToLongTimeString();
            if (progressSave.Value < 100)
            {
                progressSave.Value += 4;
            }
            else
            {
                progressSave.Value = 0;
            }
        }

        private void brnFriend_Click(object sender, EventArgs e)
        {
            fMsg = new formMsg(lblPlayer.Text);
            fMsg.Show();
        }
    }
}
