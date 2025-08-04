using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Restaurant
{
    public partial class form_foof : UserControl
    {
        public delegate void getdata(string data);
        public getdata mydata;
        public form_foof()
        {
            InitializeComponent();
        }
        private string _name_food;

        public string Namefood
        {
            get { return _name_food; }
            set { _name_food = value; lb_name.Text = value; }
        }
        private string _price_food;

        public string Pricefood
        {
            get { return _price_food; }
            set { _price_food = value; lb_price.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Visible == false)
            {
                pictureBox2.Visible = true;
                button1.FlatAppearance.BorderSize = 2;
                button1.FlatAppearance.BorderColor = Color.Orange;
                //mydata(lb_price.Text);
            }
            else
            {
                pictureBox2.Visible = false;
                button1.FlatAppearance.BorderSize = 2;
                button1.FlatAppearance.BorderColor = Color.SlateBlue;
            }
        }
    }
}
