using System;
using System.Drawing;
using System.Windows.Forms;

namespace BestOilProject
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
            radioButton_quantity.Checked = true;
            tb2_sum.Enabled = false;
            tb2_liters.Enabled = true;

            tb_hotdog_price.Text = price_hotdog.ToString("0.00");
            tb_hamburger_price.Text = price_hamburger.ToString("0.00");
            tb_potatoes_price.Text = price_potatoes.ToString("0.00");
            tb_cola_price.Text = price_cola.ToString("0.00");
            tb_coffee_price.Text = price_coffee.ToString("0.00");
            tb_tea_price.Text = price_tea.ToString("0.00");

            tb_hotdog_quantity.Enabled = false;
            tb_hamburger_quantity.Enabled = false;
            tb_potatoes_quantity.Enabled = false;
            tb_cola_quantity.Enabled = false;
            tb_coffee_quantity.Enabled = false;
            tb_tea_quantity.Enabled = false;
        }

        int help_quantity1 = 0, help_quantity2 = 0, help_quantity3 = 0, help_quantity4 = 0, help_quantity5 = 0, help_quantity6 = 0;

        float price_95plus = 28.99f;
        float price_95 = 27.81f;
        float price_92 = 25.99f;
        float price_dt = 26.75f;
        float price_gas = 12.78f;

        float price_hotdog = 29.25f;
        float price_hamburger = 25f;
        float price_potatoes = 74.23f;
        float price_cola = 24.80f;
        float price_coffee = 21.75f;
        float price_tea = 19f;

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox.SelectedIndex == 0) tb_price.Text = price_95plus.ToString("0.00");
            else if (comboBox.SelectedIndex == 1) tb_price.Text = price_95.ToString("0.00");
            else if (comboBox.SelectedIndex == 2) tb_price.Text = price_92.ToString("0.00");
            else if (comboBox.SelectedIndex == 3) tb_price.Text = price_dt.ToString("0.00");
            else if (comboBox.SelectedIndex == 4) tb_price.Text = price_gas.ToString("0.00");
            else tb_price.Text = "";

            if (tb2_sum.Text != "" && tb2_liters.Enabled == true)
            {
                float price = Convert.ToSingle(tb_price.Text);
                float x = Convert.ToSingle(tb2_liters.Text) * price;
                tb2_sum.Text = " ";
                tb2_sum.Text = Math.Round(x, 2).ToString();
                lb_price_station.Text = Math.Round(x, 2).ToString();

            }
            if (tb2_liters.Text != "" && tb2_sum.Enabled == true)
            {
                float x = Convert.ToSingle(tb2_sum.Text) / Convert.ToSingle(tb_price.Text);
                tb2_liters.Text = " ";
                tb2_liters.Text = Math.Round(x, 2).ToString();
            }
        }

        private void radioButton_quantity_MouseClick(object sender, MouseEventArgs e)
        {
            tb2_sum.Enabled = false;
            tb2_liters.Enabled = true;

        }

        private void radioButton_sum_MouseClick(object sender, MouseEventArgs e)
        {
            tb2_liters.Enabled = false;
            tb2_sum.Enabled = true;
        }

        private void tb2_liters_TextChanged(object sender, EventArgs e)
        {
            if (tb2_liters.Text == "" && radioButton_quantity.Checked)
            {
                lb_price_station.Text = "00,00";
                tb2_sum.Text = "";
            }

            if (tb2_liters.Enabled == true)
            {
                int mark = 0, flag = 0;
                for (int i = 0; i < tb2_liters.Text.Length; i++)
                {
                    if (!((tb2_liters.Text[i] >= '0' && tb2_liters.Text[i] <= '9') || tb2_liters.Text[i] == ','))
                    {
                        if (tb2_liters.Text[i] == ',') flag++;
                        mark++;
                    }
                }
                if (mark == 0 && (flag == 1 || flag == 0))
                {
                    if (!(tb2_liters.Text == ""))
                    {
                        float sum = Convert.ToSingle(tb2_liters.Text) * Convert.ToSingle(tb_price.Text);
                        tb2_sum.Text = Math.Round(sum, 2).ToString();
                        lb_price_station.Text = Math.Round(sum, 2).ToString();
                    }
                    else tb2_liters.Text = "";
                }
            }
            


        }

        private void tb2_sum_TextChanged(object sender, EventArgs e)
        {
            if (tb2_sum.Text == "" && radioButton_sum.Checked)
            {
                lb_price_station.Text = "00,00";
                tb2_liters.Text = "";
            }

            if (tb2_sum.Enabled == true)
            {
                int mark = 0, flag = 0;
                for (int i = 0; i < tb2_sum.Text.Length; i++)
                {
                    if (!((tb2_sum.Text[i] >= '0' && tb2_sum.Text[i] <= '9') || tb2_sum.Text[i] == ','))
                    {
                        mark++;
                        if (tb2_sum.Text[i] == ',') flag++;
                        
                    }
                }
                if (mark == 0 && (flag == 1 || flag == 0))
                {
                    if (!(tb2_sum.Text == ""))
                    {
                        float str = Convert.ToSingle(tb2_sum.Text);
                        lb_price_station.Text = str.ToString("0.00");
                        float liters = Convert.ToSingle(tb2_sum.Text) / Convert.ToSingle(tb_price.Text);
                        tb2_liters.Text = Math.Round(liters, 2).ToString();
                    }
                    else
                    {
                        tb2_sum.Text = "";
                        lb_price_station.Text = "00,00";
                    }
                }
            }
            
        }

        private void cb_hotdog_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_hotdog.Checked) tb_hotdog_quantity.Enabled = true;
            else tb_hotdog_quantity.Enabled = false;

            if (tb_hotdog_quantity.Text != "" && cb_hotdog.Checked)
            {
                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int hotdog_quantity = Convert.ToInt32(tb_hotdog_quantity.Text);
                

                price_cafe += price_hotdog * hotdog_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }


            if (tb_hotdog_quantity.Text != "" && !(cb_hotdog.Checked))
            {
                float new_price = Convert.ToSingle(lb_price_cafe.Text) - (price_hotdog * Convert.ToSingle(tb_hotdog_quantity.Text));
                lb_price_cafe.Text = new_price.ToString("0.00");
            }

             
        }

        private void cb_hamburger_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_hamburger.Checked) tb_hamburger_quantity.Enabled = true;
            else tb_hamburger_quantity.Enabled = false;

            if (tb_hamburger_quantity.Text != "" && cb_hamburger.Checked)
            {
                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int hamburger_quantity = Convert.ToInt32(tb_hamburger_quantity.Text);


                price_cafe += price_hamburger * hamburger_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }


            if (tb_hamburger_quantity.Text != "" && !(cb_hamburger.Checked))
            {
                float new_price = Convert.ToSingle(lb_price_cafe.Text) - (price_hamburger * Convert.ToSingle(tb_hamburger_quantity.Text));
                lb_price_cafe.Text = new_price.ToString("0.00");
            }
        }

        private void cb_potatoes_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_potatoes.Checked) tb_potatoes_quantity.Enabled = true;
            else tb_potatoes_quantity.Enabled = false;

            if (tb_potatoes_quantity.Text != "" && cb_potatoes.Checked)
            {
                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int potatoes_quantity = Convert.ToInt32(tb_potatoes_quantity.Text);


                price_cafe += price_potatoes * potatoes_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }


            if (tb_potatoes_quantity.Text != "" && !(cb_potatoes.Checked))
            {
                float new_price = Convert.ToSingle(lb_price_cafe.Text) - (price_potatoes * Convert.ToSingle(tb_potatoes_quantity.Text));
                lb_price_cafe.Text = new_price.ToString("0.00");
            }
        }

        private void cb_cola_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_cola.Checked) tb_cola_quantity.Enabled = true;
            else tb_cola_quantity.Enabled = false;

            if (tb_cola_quantity.Text != "" && cb_cola.Checked)
            {
                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int cola_quantity = Convert.ToInt32(tb_cola_quantity.Text);


                price_cafe += price_cola * cola_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }


            if (tb_cola_quantity.Text != "" && !(cb_cola.Checked))
            {
                float new_price = Convert.ToSingle(lb_price_cafe.Text) - (price_cola * Convert.ToSingle(tb_cola_quantity.Text));
                lb_price_cafe.Text = new_price.ToString("0.00");
            }
        }

        private void cb_coffee_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_coffee.Checked) tb_coffee_quantity.Enabled = true;
            else tb_coffee_quantity.Enabled = false;

            if (tb_coffee_quantity.Text != "" && cb_coffee.Checked)
            {
                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int coffee_quantity = Convert.ToInt32(tb_coffee_quantity.Text);


                price_cafe += price_coffee * coffee_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }


            if (tb_coffee_quantity.Text != "" && !(cb_coffee.Checked))
            {
                float new_price = Convert.ToSingle(lb_price_cafe.Text) - (price_coffee * Convert.ToSingle(tb_coffee_quantity.Text));
                lb_price_cafe.Text = new_price.ToString("0.00");
            }
        }

        private void cb_tea_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_tea.Checked) tb_tea_quantity.Enabled = true;
            else tb_tea_quantity.Enabled = false;

            if (tb_tea_quantity.Text != "" && cb_tea.Checked)
            {
                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int tea_quantity = Convert.ToInt32(tb_tea_quantity.Text);


                price_cafe += price_tea * tea_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }


            if (tb_tea_quantity.Text != "" && !(cb_tea.Checked))
            {
                float new_price = Convert.ToSingle(lb_price_cafe.Text) - (price_tea * Convert.ToSingle(tb_tea_quantity.Text));
                lb_price_cafe.Text = new_price.ToString("0.00");
            }
        }

        private void tb_hotdog_quantity_TextChanged(object sender, EventArgs e)
        {
            int mark = 0;
            int hotdog_quantity = 0;
            for (int i = 0; i < tb_hotdog_quantity.Text.Length; i++)
            {
                if (!(tb_hotdog_quantity.Text[i] >= '0' && tb_hotdog_quantity.Text[i] <= '9'))
                {
                    tb_hotdog_quantity.ForeColor = System.Drawing.Color.Red;
                    mark++;
                }
            }
            if (mark == 0 && tb_hotdog_quantity.Text != "")
            {
                help_quantity1 = Convert.ToInt32(tb_hotdog_quantity.Text);
                tb_hotdog_quantity.ForeColor = System.Drawing.Color.Black;
                
                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                hotdog_quantity = Convert.ToInt32(tb_hotdog_quantity.Text);
                price_cafe  += price_hotdog * hotdog_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }
            if (tb_hotdog_quantity.Text == "" && tb_hotdog_quantity.Enabled == true)
            {
                float minus_price = Convert.ToSingle(lb_price_cafe.Text);
                minus_price -= help_quantity1 * price_hotdog;
                lb_price_cafe.Text = minus_price.ToString("0.00");
            }
        }

        private void tb_hamburger_quantity_TextChanged(object sender, EventArgs e)
        {
            int mark = 0;
            int hamburger_quantity = 0;
            for (int i = 0; i < tb_hamburger_quantity.Text.Length; i++)
            {
                if (!(tb_hamburger_quantity.Text[i] >= '0' && tb_hamburger_quantity.Text[i] <= '9'))
                {
                    tb_hamburger_quantity.ForeColor = System.Drawing.Color.Red;
                    mark++;
                }
            }
            if (mark == 0 && tb_hamburger_quantity.Text != "")
            {
                help_quantity2 = Convert.ToInt32(tb_hamburger_quantity.Text);
                tb_hamburger_quantity.ForeColor = System.Drawing.Color.Black;

                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                hamburger_quantity = Convert.ToInt32(tb_hamburger_quantity.Text);

                price_cafe += price_hamburger * hamburger_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }
            if (tb_hamburger_quantity.Text == "" && tb_hamburger_quantity.Enabled == true)
            {
                float minus_price = Convert.ToSingle(lb_price_cafe.Text);
                minus_price -= help_quantity2 * price_hamburger;
                lb_price_cafe.Text = minus_price.ToString("0.00");
            }
        }
        int mouse_click_help = 0;
        private void btn_changePrices_Click(object sender, EventArgs e)
        {
            mouse_click_help++;
            if (mouse_click_help%2==0) this.Size = new Size(609, 530);
            else this.Size = new Size(609, 674);

        }

        private void btn_save_changes_Click(object sender, EventArgs e)
        {
            if (tb_change95p.Text!="") price_95plus = Convert.ToSingle(tb_change95p.Text);
            if (tb_change95.Text != "") price_95 = Convert.ToSingle(tb_change95.Text);
            if (tb_change92.Text != "") price_92 = Convert.ToSingle(tb_change92.Text);
            if (tb_changeDt.Text != "") price_dt = Convert.ToSingle(tb_changeDt.Text);
            if (tb_changeGas.Text != "") price_gas = Convert.ToSingle(tb_changeGas.Text);

            if (tb_changeHotdog.Text != "") price_hotdog = Convert.ToSingle(tb_changeHotdog.Text);
            if (tb_changeHamburger.Text != "") price_hamburger = Convert.ToSingle(tb_changeHamburger.Text);
            if (tb_changePotatoes.Text != "") price_potatoes = Convert.ToSingle(tb_changePotatoes.Text);
            if (tb_changeCola.Text != "") price_cola = Convert.ToSingle(tb_changeCola.Text);
            if (tb_changeCoffee.Text != "") price_coffee = Convert.ToSingle(tb_changeCoffee.Text);
            if (tb_changeTea.Text != "") price_tea = Convert.ToSingle(tb_changeTea.Text);

            tb_hotdog_price.Text = price_hotdog.ToString("0.00");
            tb_hamburger_price.Text = price_hamburger.ToString("0.00");
            tb_potatoes_price.Text = price_potatoes.ToString("0.00");
            tb_cola_price.Text = price_cola.ToString("0.00");
            tb_coffee_price.Text = price_coffee.ToString("0.00");
            tb_tea_price.Text = price_tea.ToString("0.00");

            if (comboBox.SelectedIndex == 0) tb_price.Text = price_95plus.ToString("0.00");
            else if (comboBox.SelectedIndex == 1) tb_price.Text = price_95.ToString("0.00");
            else if (comboBox.SelectedIndex == 2) tb_price.Text = price_92.ToString("0.00");
            else if (comboBox.SelectedIndex == 3) tb_price.Text = price_dt.ToString("0.00");
            else if (comboBox.SelectedIndex == 4) tb_price.Text = price_gas.ToString("0.00");
            else tb_price.Text = "";
        }

        private void tb_potatoes_quantity_TextChanged(object sender, EventArgs e)
        {
            int mark = 0;
            for (int i = 0; i < tb_potatoes_quantity.Text.Length; i++)
            {
                if (!(tb_potatoes_quantity.Text[i] >= '0' && tb_potatoes_quantity.Text[i] <= '9'))
                {
                    tb_potatoes_quantity.ForeColor = System.Drawing.Color.Red;
                    mark++;
                }
            }
            if (mark == 0 && tb_potatoes_quantity.Text != "")
            {
                help_quantity3 = Convert.ToInt32(tb_potatoes_quantity.Text);
                tb_potatoes_quantity.ForeColor = System.Drawing.Color.Black;

                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int potatoes_quantity = Convert.ToInt32(tb_potatoes_quantity.Text);

                price_cafe += price_potatoes * potatoes_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }
            if (tb_potatoes_quantity.Text == "" && tb_potatoes_quantity.Enabled == true)
            {
                float minus_price = Convert.ToSingle(lb_price_cafe.Text);
                minus_price -= help_quantity3 * price_potatoes;
                lb_price_cafe.Text = minus_price.ToString("0.00");
            }
        }

        private void tb_cola_quantity_TextChanged(object sender, EventArgs e)
        {
            int mark = 0;
            for (int i = 0; i < tb_cola_quantity.Text.Length; i++)
            {
                if (!(tb_cola_quantity.Text[i] >= '0' && tb_cola_quantity.Text[i] <= '9'))
                {
                    tb_cola_quantity.ForeColor = System.Drawing.Color.Red;
                    mark++;
                }
            }
            if (mark == 0 && tb_cola_quantity.Text != "")
            {
                help_quantity4 = Convert.ToInt32(tb_cola_quantity.Text);
                tb_cola_quantity.ForeColor = System.Drawing.Color.Black;

                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int cola_quantity = Convert.ToInt32(tb_cola_quantity.Text);

                price_cafe += price_cola * cola_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }
            if (tb_cola_quantity.Text == "" && tb_cola_quantity.Enabled == true)
            {
                float minus_price = Convert.ToSingle(lb_price_cafe.Text);
                minus_price -= help_quantity4 * price_cola;
                lb_price_cafe.Text = minus_price.ToString("0.00");
            }
        }

        private void tb_coffee_quantity_TextChanged(object sender, EventArgs e)
        {
            int mark = 0;
            for (int i = 0; i < tb_coffee_quantity.Text.Length; i++)
            {
                if (!(tb_coffee_quantity.Text[i] >= '0' && tb_coffee_quantity.Text[i] <= '9'))
                {
                    tb_coffee_quantity.ForeColor = System.Drawing.Color.Red;
                    mark++;
                }
            }
            if (mark == 0 && tb_coffee_quantity.Text != "")
            {
                help_quantity5 = Convert.ToInt32(tb_coffee_quantity.Text);
                tb_coffee_quantity.ForeColor = System.Drawing.Color.Black;

                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int coffee_quantity = Convert.ToInt32(tb_coffee_quantity.Text);

                price_cafe += price_coffee * coffee_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }
            if (tb_coffee_quantity.Text == "" && tb_coffee_quantity.Enabled == true)
            {
                float minus_price = Convert.ToSingle(lb_price_cafe.Text);
                minus_price -= help_quantity5 * price_coffee;
                lb_price_cafe.Text = minus_price.ToString("0.00");
            }
        }

        private void tb_tea_quantity_TextChanged(object sender, EventArgs e)
        {
            int mark = 0;
            for (int i = 0; i < tb_tea_quantity.Text.Length; i++)
            {
                if (!(tb_tea_quantity.Text[i] >= '0' && tb_tea_quantity.Text[i] <= '9'))
                {
                    tb_tea_quantity.ForeColor = System.Drawing.Color.Red;
                    mark++;
                }
            }
            if (mark == 0 && tb_tea_quantity.Text != "")
            {
                help_quantity6 = Convert.ToInt32(tb_tea_quantity.Text);
                tb_tea_quantity.ForeColor = System.Drawing.Color.Black;

                float price_cafe = Convert.ToSingle(lb_price_cafe.Text);
                int tea_quantity = Convert.ToInt32(tb_tea_quantity.Text);

                price_cafe += price_tea * tea_quantity;
                lb_price_cafe.Text = price_cafe.ToString("0.00");
            }
            if (tb_tea_quantity.Text == "" && tb_tea_quantity.Enabled == true)
            {
                float minus_price = Convert.ToSingle(lb_price_cafe.Text);
                minus_price -= help_quantity6 * price_tea;
                lb_price_cafe.Text = minus_price.ToString("0.00");
            }
        }

        private void btn_count_Click(object sender, EventArgs e)
        {
            float general_price = Convert.ToSingle(lb_price_station.Text) + Convert.ToSingle(lb_price_cafe.Text);
            lb_price_general.Text = general_price.ToString("0.00");
        }
    }
}
