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
    public partial class formResearch : Form
    {
        public formResearch(int[] tempResearch, int[] tempResources, int tempPlanetID, string tempUserID, int tempLab)
        {
            InitializeComponent();
            fillVariables(tempResearch, tempResources, tempPlanetID, userID, tempLab);
        }
        readFileManage autoRead = new readFileManage();
        mysqlInsertOrUpdate update = new mysqlInsertOrUpdate();
        mysqlQuery myquery = new mysqlQuery();
        int[,] priceValue = new int[12, 13];
        // Recursos actuais do utilizador
        int[] currentUserResources = new int[15];
        // Diferença entre os recursos actuais e o preço do edificio
        int[] finalResources = new int[15];
        int count = 0;
        bool purchase = false;
        int lab;
        int researchSelected = 0;
        string planetID;
        string userID;


        private void fillVariables(int[] researchs, int[] resources, int planetID, string userID, int laboratory)
        {
            lbl_weapon.Text = Convert.ToString(researchs[0]);
            lbl_armour.Text = Convert.ToString(researchs[1]);
            lbl_shield.Text = Convert.ToString(researchs[2]);
            lbl_energy.Text = Convert.ToString(researchs[3]);
            lbl_combustion.Text = Convert.ToString(researchs[4]);
            lbl_accelaration.Text = Convert.ToString(researchs[5]);
            lbl_laser.Text = Convert.ToString(researchs[6]);
            lbl_plasma.Text = Convert.ToString(researchs[7]);
            lbl_gravity.Text = Convert.ToString(researchs[8]);
            lbl_espionage.Text = Convert.ToString(researchs[9]);
            lbl_computer.Text = Convert.ToString(researchs[10]);
            lbl_expedition.Text = Convert.ToString(researchs[11]);
            for (int i = 0; i < 15; i++)
            {
                currentUserResources[i] = resources[i];
            }
            lab = laboratory;
            this.planetID = Convert.ToString(planetID);
            this.userID = userID;
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

        private string calculatePrice(int currentNivel, int basePrice)
        {
            for (int i = 0; i < currentNivel; i++)
            {
                basePrice = basePrice * 2;
            }
            return Convert.ToString(basePrice);
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

        private void picBoxWeaponTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Weapon Tech";
            picBoxSelected.Image = Properties.Resources.imagWeapon;

            if (lab >= 4)
            {
                researchSelected = 0;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(254))
                {
                    priceValue[0, count] = val;
                    count++;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_weapon.Text), priceValue[0, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level 4", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxArmourTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Armour Tech";
            picBoxSelected.Image = Properties.Resources.imgArmour;

            if (lab >= 2)
            {
                researchSelected = 1;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(268))
                {
                    priceValue[1, count] = val;
                    count++;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_armour.Text), priceValue[1, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level 2", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxShieldTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Shild Tech";
            picBoxSelected.Image = Properties.Resources.imgShield;

            if ((lab >= 6) && (Convert.ToInt32(lbl_energy.Text) >= 3))
            {
                researchSelected = 2;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(282))
                {
                    priceValue[2, count] = val;
                    count++;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_shield.Text), priceValue[2, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level 6 and energy tech at level 3", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxEnergyTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Energy Tech";
            picBoxSelected.Image = Properties.Resources.imgenergy;

            if (lab >= 1)
            {
                researchSelected = 3;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(296))
                {
                    priceValue[3, count] = val;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_energy.Text), priceValue[3, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level 1", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxCombustionTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Combustion Tech";
            picBoxSelected.Image = Properties.Resources.imgCombustion;

            if ((lab >= 1) && (Convert.ToInt32(lbl_energy.Text) >= 1))
            {
                researchSelected = 4;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(310))
                {
                    priceValue[4, count] = val;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_combustion.Text), priceValue[4, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level 1 and energy tech at level 1", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxAccelarationTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Accelaration Tech";
            picBoxSelected.Image = Properties.Resources.imgAccelaration;

            if ((lab >= 7) && (Convert.ToInt32(lbl_energy.Text) >= 6))
            {
                researchSelected = 5;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(324))
                {
                    priceValue[5, count] = val;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_accelaration.Text), priceValue[5, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level 7 and energy tech at level 6", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxLaserTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Laser Tech";
            picBoxSelected.Image = Properties.Resources.imgLaser;

            if ((lab >= 1) && (Convert.ToInt32(lbl_energy.Text) >= 2))
            {
                researchSelected = 6;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(338))
                {
                    priceValue[6, count] = val;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_laser.Text), priceValue[6, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level 1 and energy tech at level 2", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxPlasmaTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Plasma Tech";
            picBoxSelected.Image = Properties.Resources.imgPlasma;

            researchSelected = 7;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(352))
            {
                priceValue[7, count] = val;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_plasma.Text), priceValue[7, 12]);
            checkResources();
        }

        private void picBoxGravityTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Gravity Tech";
            picBoxSelected.Image = Properties.Resources.imgGravity;

            if ((lab >= 10))
            {
                researchSelected = 8;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(366))
                {
                    priceValue[8, count] = val;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_gravity.Text), priceValue[8, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level ~10", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxEspionageTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Espionage Tech";
            picBoxSelected.Image = Properties.Resources.imgEspionage;

            if (lab >= 3)
            {
                researchSelected = 9;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(380))
                {
                    priceValue[9, count] = val;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_espionage.Text), priceValue[9, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level 3", "Low Technology",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void picBoxComputerTec_Click(object sender, EventArgs e)
        {
            groupBoxResourcesPrice.Text = "Computer Tech";
            picBoxSelected.Image = Properties.Resources.imgComputer;

            researchSelected = 10;
            whiteLabel();
            count = 0;
            foreach (int val in autoRead.itemPrice(394))
            {
                priceValue[10, count] = val;
            }
            lblGold.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 0]);
            lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 1]);
            lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 2]);
            lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 3]);
            lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 4]);
            lblIron.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 5]);
            lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 6]);
            lblStone.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 7]);
            lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 8]);
            lblOil.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 9]);
            lblFood.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 10]);
            lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 11]);
            lblWater.Text = calculatePrice(Convert.ToInt32(lbl_computer.Text), priceValue[10, 12]);
            checkResources();
        }

        private void picBoxExpeditionTec_Click(object sender, EventArgs e)
        {
            if ((lab >= 4) && (Convert.ToInt32(lbl_espionage.Text) >= 5))
            {
                researchSelected = 11;
                whiteLabel();
                count = 0;
                foreach (int val in autoRead.itemPrice(408))
                {
                    priceValue[11, count] = val;
                }
                lblGold.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 0]);
                lblCitizens.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 1]);
                lblEnergy.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 2]);
                lblTitanium.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 3]);
                lblDeuterium.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 4]);
                lblIron.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 5]);
                lblCrystal.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 6]);
                lblStone.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 7]);
                lblUranium.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 8]);
                lblOil.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 9]);
                lblFood.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 10]);
                lblGrain.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 11]);
                lblWater.Text = calculatePrice(Convert.ToInt32(lbl_expedition.Text), priceValue[11, 12]);
                checkResources();
            }
            else
            {
                DialogResult result =
                MessageBox.Show("Need to have research lab at level 4 and espionage tech at level 5", "Low Technology",
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
                switch (researchSelected)
                {
                    case 0:
                        update.updateResearch(userID, "weapon", Convert.ToInt32(lbl_weapon.Text) + 1);
                        break;
                    case 1:
                        update.updateResearch(userID, "armour", Convert.ToInt32(lbl_armour.Text) + 1);
                        break;
                    case 2:
                        update.updateResearch(userID, "shield", Convert.ToInt32(lbl_shield.Text) + 1);
                        break;
                    case 3:
                        update.updateResearch(userID, "energy", Convert.ToInt32(lbl_energy.Text) + 1);
                        break;
                    case 4:
                        update.updateResearch(userID, "combustion", Convert.ToInt32(lbl_combustion.Text) + 1);
                        break;
                    case 5:
                        update.updateResearch(userID, "accelaration", Convert.ToInt32(lbl_accelaration.Text) + 1);
                        break;
                    case 6:
                        update.updateResearch(userID, "laser", Convert.ToInt32(lbl_laser.Text) + 1);
                        break;
                    case 7:
                        update.updateResearch(userID, "plasma", Convert.ToInt32(lbl_plasma.Text) + 1);
                        break;
                    case 8:
                        update.updateResearch(userID, "gravity", Convert.ToInt32(lbl_gravity.Text) + 1);
                        break;
                    case 9:
                        update.updateResearch(userID, "espionage", Convert.ToInt32(lbl_espionage.Text) + 1);
                        break;
                    case 10:
                        update.updateResearch(userID, "computer", Convert.ToInt32(lbl_computer.Text) + 1);
                        break;
                    case 11:
                        update.updateResearch(userID, "expedition", Convert.ToInt32(lbl_expedition.Text) + 1);
                        break;

                }
                MessageBox.Show("Research Built");
                this.Close();
            }
            else
            {
                MessageBox.Show("Not have enough resources!");
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
        //priceValue[X, -]
        /*
         *weapon                0
         *armour                1
         *shield                2
         *energy                3
         *combustion            4
         *accelaration          5
         *laser                 6
         *plasma                7
         *gravity               8
         *espionage             9
         *computer              10
         *expedition            11
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
