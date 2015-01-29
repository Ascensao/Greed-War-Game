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
    public partial class formBuildings : Form
    {
        public formBuildings(int[] tempBuildings,int[]tempResources ,int tempPlanetID, int[] tempResearch)
        {
            InitializeComponent();
            fillVariables(tempBuildings, tempResources, tempPlanetID, tempResearch);
        }
        readFileManage autoRead = new readFileManage();
        mysqlInsertOrUpdate update = new mysqlInsertOrUpdate();
        mysqlQuery myquery = new mysqlQuery();
        // Preços do aumento de nivel de todos os edificios
        int[,] priceValue = new int[18,13];
        // Recursos actuais do utilizador
        int[] currentUserResources = new int[15]; 
        // Diferença entre os recursos actuais e o preço do edificio
        int[] finalResources = new int[15];
        int[] currentResearch = new int[12];
        int count = 0; 
        bool purchase=false; 
        int buildingSelected;
        string planetID;

        private string calculatePrice(int currentNivel, int basePrice)
        {
            for (int i = 0; i < currentNivel; i++)
            {
                basePrice = basePrice * 2;
            }
            return Convert.ToString(basePrice);
        }

        private void fillVariables(int[] buildings, int[] resources, int planetID, int[] research)
        {
            lbl_iron_mine.Text = Convert.ToString(buildings[0]);
            lbl_crystal_mine.Text = Convert.ToString(buildings[1]);
            lbl_stone_mine.Text = Convert.ToString(buildings[2]);
            lbl_uranium_mine.Text = Convert.ToString(buildings[3]);
            lbl_oil_mine.Text = Convert.ToString(buildings[4]);
            lbl_farm.Text = Convert.ToString(buildings[5]);
            lbl_water_pump.Text = Convert.ToString(buildings[6]);
            lbl_titanium_factory.Text = Convert.ToString(buildings[7]);
            lbl_deuterium_refinary.Text = Convert.ToString(buildings[8]);
            lbl_power_plant.Text = Convert.ToString(buildings[9]);
            lbl_nuclear_reactor.Text = Convert.ToString(buildings[10]);
            lbl_food_industry.Text = Convert.ToString(buildings[11]);
            lbl_nanite_factory.Text = Convert.ToString(buildings[12]);
            lbl_metropolis.Text = Convert.ToString(buildings[13]);
            lbl_bank.Text = Convert.ToString(buildings[14]);
            lbl_black_market.Text = Convert.ToString(buildings[15]);
            lbl_resarch_lab.Text = Convert.ToString(buildings[16]);
            lbl_hangar.Text = Convert.ToString(buildings[17]);
            for (int i = 0; i < 15; i++)
            {
                currentUserResources[i] = resources[i];
            }
            for (int i = 0; i < 12; i++)
            {
                currentResearch[i] = research[i];
            }
            this.planetID = Convert.ToString(planetID);
        }

        private void whiteLabel()
        {
            lblGold.ForeColor = System.Drawing.Color.White;
            lblCitizens.ForeColor = System.Drawing.Color.White;
            lblEnergy.ForeColor = System.Drawing.Color.White;
            lblTitanium.ForeColor = System.Drawing.Color.White;
            lblDeuterium.ForeColor = System.Drawing.Color.White;
            lblIron.ForeColor = System.Drawing.Color.White;
            lblCrystal.ForeColor = System.Drawing.Color.White;
            lblStone.ForeColor = System.Drawing.Color.White;
            lblUranium.ForeColor = System.Drawing.Color.White;
            lblOil.ForeColor = System.Drawing.Color.White;
            lblFood.ForeColor = System.Drawing.Color.White;
            lblGrain.ForeColor = System.Drawing.Color.White;
            lblWater.ForeColor = System.Drawing.Color.White;
        }


        private void checkResources()
        {
            purchase = true;
            //Gold
            if (Convert.ToInt32(lblGold.Text) > currentUserResources[0])
            {
                lblGold.ForeColor = System.Drawing.Color.Red;
                lblGold.Text = lblGold.Text + "\n(" + Convert.ToString(currentUserResources[0] - Convert.ToInt32(lblGold.Text)) + ")";
                purchase = false;
            }
            //Citizens
            if (Convert.ToInt32(lblCitizens.Text) > currentUserResources[2])
            {
                lblCitizens.ForeColor = System.Drawing.Color.Red;
                lblCitizens.Text = lblCitizens.Text + "\n(" + Convert.ToString(currentUserResources[2] - Convert.ToInt32(lblCitizens.Text)) + ")";
                purchase = false;
            }
            //Energy
            if (Convert.ToInt32(lblEnergy.Text) > (currentUserResources[3] - currentUserResources[4])) //Resultado do que sobra
            {
                lblEnergy.ForeColor = System.Drawing.Color.Red;
                lblEnergy.Text = lblEnergy.Text + "\n(" + Convert.ToString(currentUserResources[3] - Convert.ToInt32(lblEnergy.Text)) + ")";
                purchase = false;
            }
            //Titanium
            if (Convert.ToInt32(lblTitanium.Text) > currentUserResources[6])
            {
                lblTitanium.ForeColor = System.Drawing.Color.Red;
                lblTitanium.Text = lblTitanium.Text + "\n(" + Convert.ToString(currentUserResources[6] - Convert.ToInt32(lblTitanium.Text)) + ")";
                purchase = false;

            }
            //Deuterium
            if (Convert.ToInt32(lblDeuterium.Text) > currentUserResources[7])
            {
                lblDeuterium.ForeColor = System.Drawing.Color.Red;
                lblDeuterium.Text = lblDeuterium.Text + "\n(" + Convert.ToString(currentUserResources[7] - Convert.ToInt32(lblDeuterium.Text)) + ")";
                purchase = false;
            }
            //Iron
            if (Convert.ToInt32(lblIron.Text) > currentUserResources[8])
            {
                lblIron.ForeColor = System.Drawing.Color.Red;
                lblIron.Text = lblIron.Text + "\n(" + Convert.ToString(currentUserResources[8] - Convert.ToInt32(lblIron.Text)) + ")";
                purchase = false;
            }
            //Crystal
            if (Convert.ToInt32(lblCrystal.Text) > currentUserResources[9])
            {
                lblCrystal.ForeColor = System.Drawing.Color.Red;
                lblCrystal.Text = lblCrystal.Text + "\n(" + Convert.ToString(currentUserResources[9] - Convert.ToInt32(lblCrystal.Text)) + ")";
                purchase = false;
            }
            //Stone
            if (Convert.ToInt32(lblStone.Text) > currentUserResources[10])
            {
                lblStone.ForeColor = System.Drawing.Color.Red;
                lblStone.Text = lblStone.Text + "\n(" + Convert.ToString(currentUserResources[10] - Convert.ToInt32(lblStone.Text)) + ")";
                purchase = false;
            }
            //Uranium
            if (Convert.ToInt32(lblUranium.Text) > currentUserResources[11])
            {
                lblUranium.ForeColor = System.Drawing.Color.Red;
                lblUranium.Text = lblUranium.Text + "\n(" + Convert.ToString(currentUserResources[11] - Convert.ToInt32(lblUranium.Text)) + ")";
                purchase = false;
            }
            //Oil
            if (Convert.ToInt32(lblOil.Text) > currentUserResources[12])
            {
                lblOil.ForeColor = System.Drawing.Color.Red;
                lblOil.Text = lblOil.Text + "\n(" + Convert.ToString(currentUserResources[12] - Convert.ToInt32(lblOil.Text)) + ")";
                purchase = false;
            }
            //Food
            if (Convert.ToInt32(lblFood.Text) > currentUserResources[5])
            {
                lblFood.ForeColor = System.Drawing.Color.Red;
                lblFood.Text = lblFood.Text + "\n(" + Convert.ToString(currentUserResources[5] - Convert.ToInt32(lblFood.Text)) + ")";
                purchase = false;
            }
            //Grain
            if (Convert.ToInt32(lblGrain.Text) > currentUserResources[13])
            {
                lblGrain.ForeColor = System.Drawing.Color.Red;
                lblGrain.Text = lblGrain.Text + "\n(" + Convert.ToString(currentUserResources[14] - Convert.ToInt32(lblGrain.Text)) + ")";
                purchase = false;
            }
            //Water
            if (Convert.ToInt32(lblWater.Text) > currentUserResources[14])
            {
                lblWater.ForeColor = System.Drawing.Color.Red;
                lblWater.Text = lblWater.Text + "\n(" + Convert.ToString(currentUserResources[14] - Convert.ToInt32(lblWater.Text)) + ")";
                purchase = false;
            }
            switch (purchase)
            {
                case true:
                    picBoxImprove.Image = Properties.Resources.improve2;
                    break;
                case false:
                    picBoxImprove.Image = Properties.Resources.improve1;
                    break;
            }
        }
   
        private void picBoxIron_mine_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Iron Mine";
            picBoxSelected.Image = Properties.Resources.imgIron;

            buildingSelected = 0;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(2))
            {
                priceValue[0, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_iron_mine.Text), priceValue[0, 12]);
            checkResources();
        }
        
        private void picBoxCrystal_mine_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Crystal Mine";
            picBoxSelected.Image = Properties.Resources.imgCrystal;

            buildingSelected = 1;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(16))
            {
                priceValue[1, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_crystal_mine.Text), priceValue[1, 12]);
            checkResources();
            
        }

        private void picBoxStone_mine_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Stone Mine";
            picBoxSelected.Image = Properties.Resources.imgStone;

            buildingSelected = 2;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(30))
            {
                priceValue[2, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_stone_mine.Text), priceValue[2, 12]);
            checkResources();
        }

        private void picBoxUranium_mine_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Uranium Mine";
            picBoxSelected.Image = Properties.Resources.imgUranium;

            buildingSelected = 3;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(44))
            {
                priceValue[3, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_uranium_mine.Text), priceValue[3, 12]);
            checkResources();
        }

        private void picBoxOil_mine_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Oil Mine";
            picBoxSelected.Image = Properties.Resources.imgOil;

            buildingSelected = 4;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(58))
            {
                priceValue[4, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_oil_mine.Text), priceValue[4, 12]);
            checkResources();
        }

        private void picBoxFarm_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Farm";
            picBoxSelected.Image = Properties.Resources.imgFarm;

            buildingSelected = 5;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(72))
            {
                priceValue[5, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_farm.Text), priceValue[5, 12]);
            checkResources();
        }

        private void picBoxWater_pump_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Water Pump";
            picBoxSelected.Image = Properties.Resources.imgWater;

            buildingSelected = 6;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(86))
            {
                priceValue[6, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_water_pump.Text), priceValue[6, 12]);
            checkResources();
        }

        private void picBoxTitanium_factory_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Titanium Factory";
            picBoxSelected.Image = Properties.Resources.imgTitanium;

            if (Convert.ToInt32(lbl_iron_mine.Text) >= 5)
            {
                buildingSelected = 7;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(100))
                {
                    priceValue[7, count] = val;
                    count++;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_titanium_factory.Text), priceValue[7, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have iron mine at level 5", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxDeuterium_refinery_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Deuterium Refinary";
            picBoxSelected.Image = Properties.Resources.imgDeuterium;


            if (Convert.ToInt32(lbl_oil_mine.Text) >= 5)
            {
                buildingSelected = 8;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(114))
                {
                    priceValue[8, count] = val;
                    count++;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_deuterium_refinary.Text), priceValue[8, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have oil mine at level 5", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxPower_plant_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Power Plant";
            picBoxSelected.Image = Properties.Resources.imgPower;

            buildingSelected = 9;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(128))
            {
                priceValue[9, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_power_plant.Text), priceValue[9, 12]);
            checkResources();
        }

        private void picBoxNuclear_reactor_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Nuclear Reactor";
            picBoxSelected.Image = Properties.Resources.imgNuclear;

            if ((Convert.ToInt32(lbl_power_plant.Text) >= 10) && (Convert.ToInt32(lbl_uranium_mine.Text) >= 4) && (currentResearch[3] >= 5))
            {
                buildingSelected = 10;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(142))
                {
                    priceValue[10, count] = val;
                    count++;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_nuclear_reactor.Text), priceValue[10, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have power plant at level 10, uranium mine at level 4 and energy tech at level 5", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxFood_industry_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Food Industry";
            picBoxSelected.Image = Properties.Resources.imgFood;

            if ((Convert.ToInt32(lbl_farm.Text) > 3) && (Convert.ToInt32(lbl_water_pump.Text) >= 4))
            {
                buildingSelected = 11;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(156))
                {
                    priceValue[11, count] = val;
                    count++;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_food_industry.Text), priceValue[11, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have farm at level 3 and water pump at level 4", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxNanite_factory_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Nanite Factory";
            picBoxSelected.Image = Properties.Resources.imgNanite;

            if ((currentResearch[6] >= 10) && (currentResearch[7] >= 3))
            {
                buildingSelected = 12;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(170))
                {
                    priceValue[12, count] = val;
                    count++;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_nanite_factory.Text), priceValue[12, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have laser tech at level 10 and plasma tech at level 4", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxMetropolis_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Metropolis";
            picBoxSelected.Image = Properties.Resources.imgMetro;

            buildingSelected = 13;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(184))
            {
                priceValue[13, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_metropolis.Text), priceValue[13, 12]);
            checkResources();
        }

        private void picBoxBank_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Bank";
            picBoxSelected.Image = Properties.Resources.imgBank;

            buildingSelected = 14;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(198))
            {
                priceValue[14, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_bank.Text), priceValue[14, 12]);
            checkResources();
        }

        private void picBoxBlack_market_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Market";
            picBoxSelected.Image = Properties.Resources.imgMarket;

            buildingSelected = 15;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(212))
            {
                priceValue[15, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_black_market.Text), priceValue[15, 12]);
            checkResources();
        }

        private void picBoxResearch_lab_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Research Lab";
            picBoxSelected.Image = Properties.Resources.imgLab;

            buildingSelected = 16;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(226))
            {
                priceValue[16, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_resarch_lab.Text), priceValue[16, 12]);
            checkResources();
        }

        private void picBoxHangar_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Shipyard";
            picBoxSelected.Image = Properties.Resources.imgShip;

            buildingSelected = 17;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(240))
            {
                priceValue[17, count] = val;
                count++;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_hangar.Text), priceValue[17, 12]);
            checkResources();
        }

        private void picBoxImprove_MouseHover(object sender, EventArgs e)
        {
            if (purchase == true)
            {
                picBoxImprove.Image = Properties.Resources.improve3;
            }
        }

        private void picBoxImprove_MouseLeave(object sender, EventArgs e)
        {
            if (purchase==true)
            {
            picBoxImprove.Image = Properties.Resources.improve2;
            }
        }

        private void picBoxImprove_Click(object sender, EventArgs e)
        {         
            if (purchase == true)
            {
                finalResources[0] = currentUserResources[0] - Convert.ToInt32(lblGold.Text);                                //gold
                finalResources[1] = 0;                                                                                      //Coins
                finalResources[2] = currentUserResources[2] - Convert.ToInt32(lblCitizens.Text);                            //Citizens
                finalResources[3] = 0;                                                                                      //Energy Total
                finalResources[4] = currentUserResources[4] + Convert.ToInt32(lblEnergy.Text);                              //Energy
                finalResources[5] = currentUserResources[5] - Convert.ToInt32(lblFood.Text);                                //Food
                finalResources[6] = currentUserResources[6] - Convert.ToInt32(lblTitanium.Text);                            //Titanium
                finalResources[7] = currentUserResources[7] - Convert.ToInt32(lblDeuterium.Text);                           //Deuterium
                finalResources[8] = currentUserResources[8] - Convert.ToInt32(lblIron.Text);                                //Iron
                finalResources[9] = currentUserResources[9] - Convert.ToInt32(lblCrystal.Text);                             //Crystal
                finalResources[10] = currentUserResources[10] - Convert.ToInt32(lblStone.Text);                             //Stone
                finalResources[11] = currentUserResources[11] - Convert.ToInt32(lblUranium.Text);                           //Uranium
                finalResources[12] = currentUserResources[12] - Convert.ToInt32(lblOil.Text);                               //Oil
                finalResources[13] = currentUserResources[13] - Convert.ToInt32(lblGrain.Text);                             //Grain
                finalResources[14] = currentUserResources[14] - Convert.ToInt32(lblWater.Text);
                update.updateResourcesAfterPurchase(finalResources, planetID);
                switch (buildingSelected)
                {
                    case 0:
                        update.updateBuilding(planetID, "ironmine", Convert.ToInt32(lbl_iron_mine.Text)+1);
                        break;
                    case 1:
                        update.updateBuilding(planetID, "crystalmine", Convert.ToInt32(lbl_crystal_mine.Text)+1);
                        break;
                    case 2:
                        update.updateBuilding(planetID, "stonemine", Convert.ToInt32(lbl_stone_mine.Text) + 1);
                        break;
                    case 3:
                        update.updateBuilding(planetID, "uraniummine", Convert.ToInt32(lbl_uranium_mine.Text) + 1);
                        break;
                    case 4:
                        update.updateBuilding(planetID, "oilmine", Convert.ToInt32(lbl_oil_mine.Text) + 1);
                        break;
                    case 5:
                        update.updateBuilding(planetID, "farm", Convert.ToInt32(lbl_farm.Text) + 1);
                        break;
                    case 6:
                        update.updateBuilding(planetID, "waterpump", Convert.ToInt32(lbl_water_pump.Text) + 1);
                        break;
                    case 7:
                        update.updateBuilding(planetID, "titaniumfactory", Convert.ToInt32(lbl_titanium_factory.Text) + 1);
                        break;
                    case 8:
                        update.updateBuilding(planetID, "deuteriumrefinary", Convert.ToInt32(lbl_deuterium_refinary.Text) + 1);
                        break;
                    case 9:
                        update.updateBuilding(planetID, "powerplant", Convert.ToInt32(lbl_power_plant.Text) + 1);
                        break;
                    case 10:
                        update.updateBuilding(planetID, "nuclearreactor", Convert.ToInt32(lbl_nuclear_reactor.Text) + 1);
                        break;
                    case 11:
                        update.updateBuilding(planetID, "foodindustry", Convert.ToInt32(lbl_food_industry.Text) + 1);
                        break;
                    case 12:
                        update.updateBuilding(planetID, "nanitefactory", Convert.ToInt32(lbl_nanite_factory.Text) + 1);
                        break;
                    case 13:
                        update.updateBuilding(planetID, "metropolis", Convert.ToInt32(lbl_metropolis.Text) + 1);
                        break;
                    case 14:
                        update.updateBuilding(planetID, "bank", Convert.ToInt32(lbl_bank.Text) + 1);
                        break;
                    case 15:
                        update.updateBuilding(planetID, "market", Convert.ToInt32(lbl_black_market.Text) + 1);
                        break;
                    case 16:
                        update.updateBuilding(planetID, "researchlab", Convert.ToInt32(lbl_resarch_lab.Text) + 1);
                        break;
                    case 17:
                        update.updateBuilding(planetID, "hangar", Convert.ToInt32(lbl_hangar.Text) + 1);
                        break;
                }
                MessageBox.Show("Building Built");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not have enough resources!");
            }
        }

        //LISTA DE COLUNAS DE TABELAS MYSQL
        //priceValue[X, -]
        /*
         *iron_mine             0
         *crystal_mine          1
         *stone_mine            2
         *uranium_mine          3
         *oil_mine              4
         *farm                  5
         *water_pump            6
         *titanium_factory      7
         *deuterium_refinary    8
         *power_plant           9
         *nuclear_reactor       10
         *food_industry         11
         *nanite_factory        12
         *metropolis            13
         *bank                  14
         *black_market          15
         *research_lab          16
         *hangar                17
         *
         */
        //priceValue[-, Y]
        /*
         Gold                   0
         Citizens               1
         Energy                 2
         Titanium               3
         Deuterium              4
         Iron                   5
         Crystal                6
         Stone                  7
         Uranium                8
         Oil                    9
         Food                   10
         Grain                  11   
         Water                  12
         * */
        //currentUserResources[15]
        /*
         *Gold              0
         *Coin              1
         *Citizens          2
         *Energy_total      3
         *energy            4
         *Food              5
         *Titanium          6
         *Deuterium         7
         *Iron              8
         *Crystal           9
         *Stone             10  
         *Uranium           11
         *Oil               12
         *Grain             13
         *Water             14    
         */      
    }
}
