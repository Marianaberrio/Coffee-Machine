using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Coffee_Machine
{
    public partial class Form1 : Form
    {
        private CoffeeMachine coffeeMachine = new CoffeeMachine();

        public Form1()
        {
            InitializeComponent();
        }
        /*
        double balance = 0.00;
        double water = 500.00;
        double milk = 500.00;
        double coffee = 500.00;
        double money = 0;
        */

        private void showBalance()
        {
            lblBalance.Text = String.Format("{0:C}", coffeeMachine.Balance);

        }
        private void pourEsspreso()
        {
            double cost = 1.5;
            if (!coffeeMachine.PourEspresso())
            {
                // Check which resource is lacking and show the appropriate message
                if (coffeeMachine.Water < 50)
                {
                    MessageBox.Show("Sorry there is not enough water.");
                }
                else if (coffeeMachine.Coffee < 18)
                {
                    MessageBox.Show("Sorry there is not enough coffee.");
                }
                else if (coffeeMachine.Balance < cost)
                {
                    MessageBox.Show("Sorry you don't have enough balance to purchase this item, you need\n\n" + cost.ToString("C2") + "\n\nto purchase this item");
                }
            }
            else
            {
                showBalance();
                DialogResult result = MessageBox.Show("Here is your Espresso. Enjoy!");
                if (result == DialogResult.OK && coffeeMachine.Balance > 0)
                {
                    MessageBox.Show("Here is your " + coffeeMachine.Balance.ToString("C2") + " change");
                    coffeeMachine.Balance = 0;
                    showBalance();
                }
            }

        }

        private void pourLatte()
        {
            double cost = 2.5;
            if (!coffeeMachine.PourLatte())
            {
                // Check which resource is lacking and show the appropriate message
                if (coffeeMachine.Water < 200)
                {
                    MessageBox.Show("Sorry there is not enough water.");
                }
                else if (coffeeMachine.Milk < 150)
                {
                    MessageBox.Show("Sorry there is not enough milk.");
                }
                else if (coffeeMachine.Coffee < 24)
                {
                    MessageBox.Show("Sorry there is not enough coffee.");
                }
                else if (coffeeMachine.Balance < cost)
                {
                    MessageBox.Show("Sorry you don't have enough balance to purchase this item, you need\n\n" + cost.ToString("C2") + "\n\nto purchase this item");
                }
            }
            else
            {
                showBalance();
                DialogResult result = MessageBox.Show("Here is your Latte. Enjoy!");
                if (result == DialogResult.OK && coffeeMachine.Balance > 0)
                {
                    MessageBox.Show("Here is your " + coffeeMachine.Balance.ToString("C2") + " change");
                    coffeeMachine.Balance = 0;
                    showBalance();
                }
            }
        }

        private void pourCappucino()
        {
            double cost = 3.0;
            if (!coffeeMachine.PourCappuccino())
            {
                // Check which resource is lacking and show the appropriate message
                if (coffeeMachine.Water < 250)
                {
                    MessageBox.Show("Sorry there is not enough water.");
                }
                else if (coffeeMachine.Milk < 50)
                {
                    MessageBox.Show("Sorry there is not enough milk.");
                }
                else if (coffeeMachine.Coffee < 24)
                {
                    MessageBox.Show("Sorry there is not enough coffee.");
                }
                else if (coffeeMachine.Balance < cost)
                {
                    MessageBox.Show("Sorry you don't have enough balance to purchase this item, you need\n\n" + cost.ToString("C2") + "\n\nto purchase this item");
                }
            }
            else
            {
                showBalance();
                DialogResult result = MessageBox.Show("Here is your Cappuccino. Enjoy!");
                if (result == DialogResult.OK && coffeeMachine.Balance > 0)
                {
                    MessageBox.Show("Here is your " + coffeeMachine.Balance.ToString("C2") + " change");
                    coffeeMachine.Balance = 0;
                    showBalance();
                }
            }
        }
        private void lblBalance_Click(object sender, EventArgs e)
        {
        }

        private void btn25c_Click(object sender, EventArgs e)
        {
            coffeeMachine.AddBalance(0.25);
            showBalance();
        }

        private void btn10c_Click(object sender, EventArgs e)
        {
            coffeeMachine.AddBalance(0.10);
            showBalance();
        }

        private void btn5c_Click(object sender, EventArgs e)
        {
            coffeeMachine.AddBalance(0.05);
            showBalance();
        }

        private void btn1c_Click(object sender, EventArgs e)
        {
            coffeeMachine.AddBalance(0.01);
            showBalance();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            pnlReport.Visible = true;
            lblWater.Text = coffeeMachine.Water.ToString() + " ml";
            lblMilk.Text = coffeeMachine.Milk.ToString() + " ml";
            lblCoffee.Text = coffeeMachine.Coffee.ToString() + " g";
            lblMoney.Text = String.Format("{0:C}", coffeeMachine.Money);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlReport.Visible=false;
        }

        private void BtnEsspreso_Click(object sender, EventArgs e)
        {
            pourEsspreso();
        }

        private void BtnLatte_Click(object sender, EventArgs e)
        {
            pourLatte();
        }

        private void btnCapuccino_Click(object sender, EventArgs e)
        {
            pourCappucino();
        }

        private void showMessageBox(string message)
        {
            Form customForm = new Form
            {
                Text = "Error",
                Size = new Size(300, 150),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.Black,  // Set background color to black
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            Label messageLabel = new Label
            {
                Text = message,
                ForeColor = Color.White,  // Set text color to white
                AutoSize = true,
                Location = new Point(50, 20)
            };
            customForm.Controls.Add(messageLabel);

            Button nextButton = new Button
            {
                Text = "Next",
                Size = new Size(75, 30),
                Location = new Point(100, 70)
            };
            nextButton.Click += (s, e) => { customForm.DialogResult = DialogResult.OK; customForm.Close(); };
            customForm.Controls.Add(nextButton);

            customForm.ShowDialog();
        }
    }
}
