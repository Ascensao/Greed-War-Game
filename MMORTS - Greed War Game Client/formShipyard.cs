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
    public partial class formShipyard : Form
    {
        public formShipyard(int[] tempFleet, int[] tempResources, int tempPlanetID, int tempBuilding, int[] tempResearch)
        {
            InitializeComponent();
            fillVariables(tempFleet, tempResources, tempPlanetID, tempBuilding, tempResearch);
        }
        readFileManage autoRead = new readFileManage();
        mysqlInsertOrUpdate update = new mysqlInsertOrUpdate();
        mysqlQuery myquery = new mysqlQuery();
        //Nivel do Hangar
        int hangar;
        //Nivel das Pesquisas
        int[] currentResearch = new int[12];
        int[,] priceValue = new int[11, 13];
        // Recursos actuais do utilizador
        int[] currentUserResources = new int[15];
        // Diferença entre os recursos actuais e o preço do edificio
        int[] finalResources = new int[15];
        int count = 0;
        bool purchase = false;
        int shipSelected=-1;
        string planetID;

        private void fillVariables(int[] fleet, int[] resources, int planetID, int tempHangar, int[] research)
        {
            lbl_sattelite.Text = Convert.ToString(fleet[0]);
            lbl_colonyship.Text = Convert.ToString(fleet[1]);
            lbl_recycler.Text = Convert.ToString(fleet[2]);
            lbl_espionage_probe.Text = Convert.ToString(fleet[3]);
            lbl_cargoship.Text = Convert.ToString(fleet[4]);
            lbl_fighter.Text = Convert.ToString(fleet[5]);
            lbl_hunter.Text = Convert.ToString(fleet[6]);
            lbl_bomber.Text = Convert.ToString(fleet[7]);
            lbl_destroyer.Text = Convert.ToString(fleet[8]);
            lbl_slayer.Text = Convert.ToString(fleet[9]);
            lbl_armageddon.Text = Convert.ToString(fleet[10]);
            for (int i = 0; i < 15; i++)
            {
                currentUserResources[i] = resources[i];
            }
            for (int i = 0; i < 12; i++)
            {
                currentResearch[i] = research[i];
            }
            hangar = tempHangar;
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

        private void picBoxFighter_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Fighter";
            picBoxSelected.Image = Properties.Resources.shipFighter;

            if ((hangar >= 1) && (currentResearch[5] >= 1) && (currentResearch[7] >= 1))
            {
                shipSelected = 5;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(492))
                {
                    priceValue[5, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[5, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[5, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[5, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[5, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[5, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[5, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[5, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[5, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[5, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[5, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[5, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[5, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[5, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 1, combustion tech at level 1 and laser tech at level 1", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
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

        private void picBoxHunter_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Hunter";
            picBoxSelected.Image = Properties.Resources.shipHunter;

            if((hangar>=3)&&(currentResearch[6]>=1)&&(currentResearch[7]>=5)&&(currentResearch[3]>=1)&&(currentResearch[2]>=3))
            {
            shipSelected = 6;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(506))
            {
                priceValue[6, count] = val;
                count++;
            }
            lblGold.Text = Convert.ToString(priceValue[6, 0] * numericUpDownQtt.Value);
            lblCitizens.Text = Convert.ToString(priceValue[6, 1] * numericUpDownQtt.Value);
            lblEnergy.Text = Convert.ToString(priceValue[6, 2] * numericUpDownQtt.Value);
            lblTitanium.Text = Convert.ToString(priceValue[6, 3] * numericUpDownQtt.Value);
            lblDeuterium.Text = Convert.ToString(priceValue[6, 4] * numericUpDownQtt.Value);
            lblIron.Text = Convert.ToString(priceValue[6, 5] * numericUpDownQtt.Value);
            lblCrystal.Text = Convert.ToString(priceValue[6, 6] * numericUpDownQtt.Value);
            lblStone.Text = Convert.ToString(priceValue[6, 7] * numericUpDownQtt.Value);
            lblUranium.Text = Convert.ToString(priceValue[6, 8] * numericUpDownQtt.Value);
            lblOil.Text = Convert.ToString(priceValue[6, 9] * numericUpDownQtt.Value);
            lblFood.Text = Convert.ToString(priceValue[6, 10] * numericUpDownQtt.Value);
            lblGrain.Text = Convert.ToString(priceValue[6, 11] * numericUpDownQtt.Value);
            lblWater.Text = Convert.ToString(priceValue[6, 12] * numericUpDownQtt.Value);
            checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 3, accelaration tech at level 1, laser tech at level 5, shield tech at level 1, armour tech at level 3", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxBomber_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Bomber";
            picBoxSelected.Image = Properties.Resources.shipBomber;

            if ((hangar >= 8) && (currentResearch[6] >= 4) && (currentResearch[8] >= 5) && (currentResearch[3] >= 2) && (currentResearch[2] >= 6))
            {
                shipSelected = 7;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(520))
                {
                    priceValue[7, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[7, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[7, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[7, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[7, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[7, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[7, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[7, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[7, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[7, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[7, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[7, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[7, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[7, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 8, accelaration tech at level 4, plasma tech at level 5, shield tech at level 3, armour tech at level 6", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picboxDestroyer_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Destroyer";
            picBoxSelected.Image = Properties.Resources.shipDestroyer;

            if ((hangar >= 9) && (currentResearch[6] >= 1) && (currentResearch[8] >= 6) && (currentResearch[3] >= 4) && (currentResearch[2] >= 10))
            {
                shipSelected = 8;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(534))
                {
                    priceValue[8, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[8, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[8, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[8, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[8, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[8, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[8, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[8, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[8, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[8, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[8, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[8, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[8, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[8, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 9, accelaration tech at level 5, plasma tech at level 6, shield tech at level 4, armour tech at level 10", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxSlayer_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Slayer";
            picBoxSelected.Image = Properties.Resources.shipSlayer;

            if ((hangar >= 10) && (currentResearch[6] >= 8) && (currentResearch[8] >= 8) && (currentResearch[3] >= 6) && (currentResearch[2] >= 10))
            {
                shipSelected = 9;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(548))
                {
                    priceValue[9, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[9, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[9, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[9, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[9, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[9, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[9, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[9, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[9, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[9, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[9, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[9, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[9, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[9, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 10, accelaration tech at level 8, plasma tech at level 8, shield tech at level 6, armour tech at level 10", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxArmageddon_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Armageddon";
            picBoxSelected.Image = Properties.Resources.shipArmageddon;

            if ((hangar >= 12) && (currentResearch[6] >= 10) && (currentResearch[8] >= 10) && (currentResearch[3] >= 10) && (currentResearch[2] >= 10))
            {
                shipSelected = 10;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(562))
                {
                    priceValue[10, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[10, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[10, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[10, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[10, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[10, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[10, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[10, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[10, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[10, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[10, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[10, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[10, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[10, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 12, accelaration tech at level 10, plasma tech at level 10, shield tech at level 10, armour tech at level 10", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxSatellite_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Satellite";
            picBoxSelected.Image = Properties.Resources.shipSatellite;

            if (hangar >= 1)
            {
                shipSelected = 0;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(422))
                {
                    priceValue[0, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[0, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[0, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[0, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[0, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[0, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[0, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[0, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[0, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[0, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[0, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[0, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[0, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[0, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 1", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxColonyShip_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Colony Ship";
            picBoxSelected.Image = Properties.Resources.shipColony;

            if ((hangar >= 4) && (currentResearch[6] >= 2))
            {
                shipSelected = 1;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(436))
                {
                    priceValue[1, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[1, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[1, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[1, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[1, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[1, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[1, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[1, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[1, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[1, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[1, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[1, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[1, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[1, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 4 and accelaration tech at level 2", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxRecycler_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Recycler";
            picBoxSelected.Image = Properties.Resources.shipRecycler;

            if ((hangar >= 4) && (currentResearch[2] >= 6) && (currentResearch[3] >= 2) && (currentResearch[5] >= 5))
            {
                shipSelected = 2;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(450))
                {
                    priceValue[2, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[2, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[2, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[2, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[2, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[2, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[2, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[2, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[2, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[2, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[2, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[2, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[2, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[2, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 4, armour tech at level 6, shield tech at level 2 and combustion tech at level 5", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxEspionage_Probe_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Espionage Probe";
            picBoxSelected.Image = Properties.Resources.shipEspionage;

            if ((hangar >= 3) && (currentResearch[5] >= 3) && (currentResearch[10] >= 2))
            {
                shipSelected = 3;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(464))
                {
                    priceValue[3, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[3, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[3, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[3, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[3, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[3, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[3, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[3, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[3, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[3, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[3, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[3, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[3, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[3, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 3, combustion tech at level 3 and espionage tech at level 2", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxCargoShip_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Cargo Ship";
            picBoxSelected.Image = Properties.Resources.shipCargo;

            if ((hangar >= 3) && (currentResearch[5] >= 4))
            {
                shipSelected = 4;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(478))
                {
                    priceValue[4, count] = val;
                    count++;
                }
                lblGold.Text = Convert.ToString(priceValue[4, 0] * numericUpDownQtt.Value);
                lblCitizens.Text = Convert.ToString(priceValue[4, 1] * numericUpDownQtt.Value);
                lblEnergy.Text = Convert.ToString(priceValue[4, 2] * numericUpDownQtt.Value);
                lblTitanium.Text = Convert.ToString(priceValue[4, 3] * numericUpDownQtt.Value);
                lblDeuterium.Text = Convert.ToString(priceValue[4, 4] * numericUpDownQtt.Value);
                lblIron.Text = Convert.ToString(priceValue[4, 5] * numericUpDownQtt.Value);
                lblCrystal.Text = Convert.ToString(priceValue[4, 6] * numericUpDownQtt.Value);
                lblStone.Text = Convert.ToString(priceValue[4, 7] * numericUpDownQtt.Value);
                lblUranium.Text = Convert.ToString(priceValue[4, 8] * numericUpDownQtt.Value);
                lblOil.Text = Convert.ToString(priceValue[4, 9] * numericUpDownQtt.Value);
                lblFood.Text = Convert.ToString(priceValue[4, 10] * numericUpDownQtt.Value);
                lblGrain.Text = Convert.ToString(priceValue[4, 11] * numericUpDownQtt.Value);
                lblWater.Text = Convert.ToString(priceValue[4, 12] * numericUpDownQtt.Value);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have hangar at level 3 and comvustion tech at level 4", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
                switch (shipSelected)
                {
                    case 0:
                        update.updateFleet(planetID, "sattelite", Convert.ToInt32(lbl_sattelite.Text) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 1:
                        update.updateFleet(planetID, "colonyship", Convert.ToInt32(lbl_colonyship.Text) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 2:
                        update.updateFleet(planetID, "recycler", Convert.ToInt32(lbl_recycler.Text) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 3:
                        update.updateFleet(planetID, "espionage_probe", Convert.ToInt32(lbl_espionage_probe) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 4:
                        update.updateFleet(planetID, "cargoship", Convert.ToInt32(lbl_cargoship.Text) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 5:
                        update.updateFleet(planetID, "fighter", Convert.ToInt32(lbl_fighter.Text) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 6:
                        update.updateFleet(planetID, "hunter", Convert.ToInt32(lbl_hunter) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 7:
                        update.updateFleet(planetID, "bomber", Convert.ToInt32(lbl_bomber.Text) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 8:
                        update.updateFleet(planetID, "destroyer", Convert.ToInt32(lbl_destroyer.Text) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 9:
                        update.updateFleet(planetID, "slayer", Convert.ToInt32(lbl_slayer.Text) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                    case 10:
                        update.updateFleet(planetID, "armageddon", Convert.ToInt32(lbl_armageddon.Text) + Convert.ToInt32(numericUpDownQtt.Value));
                        break;
                }
                MessageBox.Show("Ship Built");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not have enough resources!");
            }
        }

        private void numericUpDownQtt_ValueChanged(object sender, EventArgs e)
        {
             
            switch (shipSelected)
            {
            case 0:
            picBoxSatellite_Click(this, new EventArgs());
            break;
            case 1:
            picBoxColonyShip_Click(this, new EventArgs());
            break;
            case 2:
            picBoxRecycler_Click(this, new EventArgs());
            break;
            case 3:
            picBoxEspionage_Probe_Click(this, new EventArgs());
            break;
            case 4:
            picBoxCargoShip_Click(this, new EventArgs());
            break;
            case 5:
            picBoxFighter_Click(this, new EventArgs());
            break;
            case 6:
            picBoxHunter_Click(this, new EventArgs());
            break;
            case 7:
            picBoxBomber_Click(this, new EventArgs());
            break;
            case 8:
            picboxDestroyer_Click(this, new EventArgs());
            break;
            case 9:
            picboxDestroyer_Click(this, new EventArgs());
            break;
            case 10:
            picBoxArmageddon_Click(this, new EventArgs());
            break;
            default:
            MessageBox.Show("Selecione uma Nave");
            break;
            }
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
            if (purchase == true)
            {
                picBoxImprove.Image = Properties.Resources.improve2;
            }
        }
        //LISTA DE COLUNAS DE TABELAS MYSQL
        //priceValue[-, ?]
        /*
         *satellite                  0
         *colonyship                 1
         *recycler                   2
         *espionage_probe            3
         *cargoshiep                 4
         *fighter                    5
         *hunter                     6
         *bomber                     7
         *destroyer                  8
         *slayer                     9
         *armageddon                 10
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
