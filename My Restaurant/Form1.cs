using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Restaurant
{
    public partial class Form1 : Form
    {
        ketnoivathucthicoban sql1 = new ketnoivathucthicoban();
        public Form1()
        {
            InitializeComponent();
        }
        private Point lastPoint;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X; this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            lastPoint = Point.Empty;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //timer_slide_bar.Start();
        }
        bool k = true;
        private void timer_slide_bar_Tick(object sender, EventArgs e)
        {
            if (k == true)
            {
                //flow_slide_bar.Height = flowLayoutPanel1.Height;
                flow_slide_bar.Width -= 10;
                if (flow_slide_bar.Width == flow_slide_bar.MinimumSize.Width)
                {
                    timer_slide_bar.Stop();
                    k = false;
                }
            }
            else
            {
                //flow_slide_bar.Height = flowLayoutPanel1.Height;
                flow_slide_bar.Width += 10;
                if (flow_slide_bar.Width == flow_slide_bar.MaximumSize.Width)
                {
                    timer_slide_bar.Stop();
                    k = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //timer_slide_bar.Start();
            form_foof fom = new form_foof();
            fom.mydata = new form_foof.getdata(getdata);
        }
        bool k1 = true;
        bool k2 = true;
        bool k3 = true;

        public void slide_btn1(Panel p)
        {
            if (k1 == true)
            {
                p.Height += 10;
                if (p.Height == p.MaximumSize.Height)
                {
                    timer_slide_btn.Stop();
                    k1 = false;
                }
            }
            else
            {
                p.Height -= 10;
                if (p.Height == p.MinimumSize.Height)
                {
                    timer_slide_btn.Stop();
                    k1 = true;
                }
            }
        }
        public void slide_btn2(Panel p)
        {
            if (k2 == true)
            {
                p.Height += 10;
                if (p.Height == p.MaximumSize.Height)
                {
                    timer_slide_btn.Stop();
                    k2 = false;
                }
            }
            else
            {
                p.Height -= 10;
                if (p.Height == p.MinimumSize.Height)
                {
                    timer_slide_btn.Stop();
                    k2 = true;
                }
            }
        }
        public void slide_btn3(Panel p)
        {
            if (k3 == true)
            {
                p.Height += 10;
                if (p.Height == p.MaximumSize.Height)
                {
                    timer_slide_btn.Stop();
                    k3 = false;
                }
            }
            else
            {
                p.Height -= 10;
                if (p.Height == p.MinimumSize.Height)
                {
                    timer_slide_btn.Stop();
                    k3 = true;
                }
            }
        }
        string trangthai_slide = "";
        private void timer_slide_btn_Tick(object sender, EventArgs e)
        {
            if (trangthai_slide == "gioithieu")
            {
                slide_btn1(panel_introduce);
            }
            else if (trangthai_slide == "doan")
            {
                slide_btn2(panel_do_an);
            }
            else if (trangthai_slide == "douong")
            {
                slide_btn3(panel_do_uong);
            }
        }


        private void button16_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;
        }
        public void getdata(string value)
        {
            lb_total1.Text = value;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lb_date_time.Text = DateTime.Now.ToString("MM/dd/yyyy");
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            lb_search.SendToBack();
            tb_search.Text = tb_search.Text.Insert(0, "").Trim();
        }

        private void tb_search_MouseClick(object sender, MouseEventArgs e)
        {
            lb_search.SendToBack();
            tb_search.Text = tb_search.Text.Insert(0, "").Trim();
        }
        private void btn_home_Click(object sender, EventArgs e)
        {
            lb_date_time.Text = DateTime.Now.ToString("M/dd/yyyy");
            flow_main.BackgroundImage = base.BackgroundImage;
            try
            {
                lb_search.BringToFront();
                flow_main.Controls.Clear();
                DataTable dt = sql1.laybangdulieu("SELECT[No],[Name],[Price],[Image],[Category],[Note]FROM [DataFoodandDrink].[dbo].[ListFoodAndDrink]");
                if (dt.Rows.Count > 0)
                {
                    form_foof[] form = new form_foof[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            form[i] = new form_foof();
                            flow_main.Controls.Add(form[i]);
                            form[i].Namefood = dt.Rows[i][1].ToString();
                            form[i].Pricefood = dt.Rows[i][2].ToString();
                            string a = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\" + dt.Rows[i][5].ToString() + ".png";
                            Image myimage = new Bitmap(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\" + dt.Rows[i][5].ToString() + ".png");
                            form[i].BackgroundImage = myimage;
                        }
                        catch
                        {
                            //MessageBox.Show("Hình ảnh không tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi truy cập vào server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_introduce_Click(object sender, EventArgs e)
        {
            trangthai_slide = "gioithieu";
            timer_slide_btn.Start();
        }

        private void btn_food_Click(object sender, EventArgs e)
        {
            trangthai_slide = "doan";
            timer_slide_btn.Start();
        }

        private void btn_drink_Click(object sender, EventArgs e)
        {
            trangthai_slide = "douong";
            timer_slide_btn.Start();
        }

        private void btn_dani_fatfood_Click(object sender, EventArgs e)
        {
            try
            {
                flow_main.Controls.Clear();
                Image myimage = new Bitmap(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\resort-4471852_1280.jpg");
                flow_main.BackgroundImage = myimage;
                flow_main.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }

        private void btn_dedication_Click(object sender, EventArgs e)
        {
            //chef-4807317_1280.jpg
            try
            {
                flow_main.Controls.Clear();
                Image myimage = new Bitmap(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\chef-4807317_1280.jpg");
                flow_main.BackgroundImage = myimage;
                flow_main.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }

        private void btn_dream_Click(object sender, EventArgs e)
        {
            //cooks-1661131_1280.jpg
            try
            {
                flow_main.Controls.Clear();
                Image myimage = new Bitmap(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\cooks-1661131_1280.jpg");
                flow_main.BackgroundImage = myimage;
                flow_main.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch
            {

            }
        }
        public void search_item()
        {
            flow_main.BackgroundImage = base.BackgroundImage;
            if (tb_search.Text == "")
            {
                try
                {
                    flow_main.Controls.Clear();
                    DataTable dt = sql1.laybangdulieu("SELECT[No],[Name],[Price],[Image],[Category],[Note]FROM [DataFoodandDrink].[dbo].[ListFoodAndDrink]");
                    if (dt.Rows.Count > 0)
                    {
                        form_foof[] form = new form_foof[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            try
                            {
                                form[i] = new form_foof();
                                flow_main.Controls.Add(form[i]);
                                form[i].Namefood = dt.Rows[i][1].ToString();
                                form[i].Pricefood = dt.Rows[i][2].ToString();
                                string a = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\" + dt.Rows[i][5].ToString() + ".png";
                                Image myimage = new Bitmap(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\" + dt.Rows[i][5].ToString() + ".png");
                                form[i].BackgroundImage = myimage;
                            }
                            catch
                            {
                                //MessageBox.Show("Hình ảnh không tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            }

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi truy cập vào server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                try
                {
                    flow_main.Controls.Clear();
                    DataTable dt1 = sql1.laybangdulieu("SELECT[No],[Name],[Price],[Category],[Image],[Note]FROM [DataFoodandDrink].[dbo].[ListFoodAndDrink] where [Name] like N'%" + tb_search.Text + "%'");
                    if (dt1.Rows.Count > 0)
                    {
                        form_foof[] form = new form_foof[dt1.Rows.Count];
                        for (int i = 0; i < dt1.Rows.Count; i++)
                        {
                            try
                            {
                                form[i] = new form_foof();
                                flow_main.Controls.Add(form[i]);
                                form[i].Namefood = dt1.Rows[i][1].ToString();
                                form[i].Pricefood = dt1.Rows[i][2].ToString();
                                string a = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\" + dt1.Rows[i][5].ToString() + ".png";
                                Image myimage = new Bitmap(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\" + dt1.Rows[i][5].ToString() + ".png");
                                form[i].BackgroundImage = myimage;
                            }
                            catch
                            {
                                //MessageBox.Show("Hình ảnh không tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            }

                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi truy cập vào server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
        }
        string country = "";
        public void load_food_and_drink()
        {
            try
            {
                flow_main.Controls.Clear();
                flow_main.BackgroundImage = base.BackgroundImage;
                DataTable dt = sql1.laybangdulieu("SELECT[No],[Name],[Price],[Image],[Category],[Note]FROM [DataFoodandDrink].[dbo].[ListFoodAndDrink] where [Country] = '" + country + "'");
                if (dt.Rows.Count > 0)
                {
                    form_foof[] form = new form_foof[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            form[i] = new form_foof();
                            flow_main.Controls.Add(form[i]);
                            form[i].Namefood = dt.Rows[i][1].ToString();
                            form[i].Pricefood = dt.Rows[i][2].ToString();
                            string a = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\" + dt.Rows[i][5].ToString() + ".png";
                            Image myimage = new Bitmap(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Image\" + dt.Rows[i][5].ToString() + ".png");
                            form[i].BackgroundImage = myimage;
                        }
                        catch
                        {
                            //MessageBox.Show("Hình ảnh không tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        }

                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi truy cập vào server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tb_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                search_item();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            search_item();
        }
        private void btn_food_japan_Click(object sender, EventArgs e)
        {
            country = "japan";
            load_food_and_drink();
        }

        private void btn_food_korea_Click(object sender, EventArgs e)
        {
            country = "Korea";
            load_food_and_drink();
        }

        private void btn_food_vn_Click(object sender, EventArgs e)
        {
            country = "VietNam";
            load_food_and_drink();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                string price1 = lb_total1.Text.Replace('đ', ' ').Trim();
                price1 = price1.Split('.')[0] + price1.Split('.')[1];

                string discount = lb_discount.Text.Replace('-',' ');
                discount = discount.Replace('%', ' ').Trim();

                lb_total2.Text = (Convert.ToInt32(price1) * (100 - Convert.ToInt32(discount)) / 100).ToString()+"đ";
            }  
            else
            {
                lb_total2.Text = lb_total1.Text;
            }
        }
    }
}
