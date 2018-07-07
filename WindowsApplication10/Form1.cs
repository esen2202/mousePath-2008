using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication10
{
    public partial class Form1 : Form
    {
        int x, y, i, eu, ex, ey, fx, fy, ed, px, py, j, k,hareketx,harekety,durum,farex,farey,hareketcarpan;
        string koordinat;
        Pen p = new Pen(Color.Black, 2);
        SolidBrush pr = new SolidBrush(Color.Blue);
        SolidBrush pro = new SolidBrush(Color.Crimson);
        SolidBrush prop = new SolidBrush(Color.Chocolate);
        Int32[,] fare = new Int32[10, 10];

        public Form1()
        {
            InitializeComponent();
        }

        private void engel(int x, int y, int eu, int ed, PaintEventArgs e)
        {    
            e.Graphics.FillRectangle(pr, (x) * 20, (y) * 20, eu * 20, ed * 20);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (k = 0; k <= 9; k++)
                for (j = 0; j <= 9; j++)
                {
                    fare[j, k] = 0;
                    this.checkedListBox1.Items.Add(fare[j, k]);
                }

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = Convert.ToInt32(textBox1.Text);
            y = Convert.ToInt32(textBox2.Text);
            label22.Text  = textBox1.Text +" x "+ textBox2.Text;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(10, 10);
            labirentciz(e);
            engel(ex, ey, eu, ed, e);
            //e.Graphics.TranslateTransform(10, 10);
            e.Graphics.FillEllipse(pro, (fx * 20)+hareketx , (fy * 20)+harekety , 20, 20);
            e.Graphics.FillEllipse(prop, px * 20, py * 20, 15, 15);
            farex = ((fx * 20) + hareketx)/20;
            farey = ((fy * 20) + harekety)/20;
            
            
            

        }

        private void labirentciz(PaintEventArgs e)
        {
            
            e.Graphics.DrawRectangle(p, 0, 0, x * 20, y * 20);

            for (i = 1; i <= x; i++)
            {
                e.Graphics.DrawLine(p, i * 20, 0, i * 20, y * 20);
            }
            for (i = 1; i <= y; i++)
            {
                e.Graphics.DrawLine(p, 0, i * 20, x * 20, i * 20);
            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string ad;
            this.checkedListBox3.Items.Clear();
            for (k = 0; k <= 9; k++)
                for (j = 0; j <= 9; j++)
                {
                    fare[j, k] = 0;
                    this.checkedListBox1.Items.Add(fare[j, k]);
                }
            for (j = ey ; j <= ey - 1 + ed; j++)
                for (i = ex ; i <= ex - 1 + eu; i++) {
                    ad = "engel(x:" + Convert.ToString(i) +" , y:"+ Convert.ToString(j)+")";
                    this.checkedListBox3.Items.Add(ad);
                    
                }
                  
            ex = Convert.ToInt32(textBox7.Text);
            ey = Convert.ToInt32(textBox8.Text);
            eu = Convert.ToInt32(textBox9.Text);
            ed = Convert.ToInt32(textBox10.Text);

            for (j = ey; j <= ey -1 + ed; j++)
                for (i = ex; i <= ex -1 + eu; i++)
                    fare[i, j] = 1;

            this.checkedListBox1.Items.Clear();
            for (k = 0; k <= 9; k++)
                for (j = 0; j <= 9; j++)
                    this.checkedListBox1.Items.Add(fare[j, k]);

            this.checkedListBox3.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fx = Convert.ToInt32(textBox3.Text);
            fy = 0;
            label23.Text = "x=" + textBox3.Text + " * y=0";
            label29.Text = textBox3.Text;
            label30.Text = "0";
            this.checkedListBox2.Items.Clear();
            this.checkedListBox2.Items.Add(label23.Text);
            durum = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fx = Convert.ToInt32(textBox4.Text);
            fy = y-1;
            label23.Text = "x=" + textBox4.Text + " * y="+Convert.ToString(fy);
            label29.Text = textBox4.Text;
            label30.Text = Convert.ToString(fy);
            this.checkedListBox2.Items.Clear();
            this.checkedListBox2.Items.Add(label23.Text);
            durum = 4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fy = Convert.ToInt32(textBox5.Text);
            fx = 0;
            label23.Text = "x=0 * y=" + textBox5.Text;
            label29.Text = "0";
            label30.Text = textBox5.Text;
            this.checkedListBox2.Items.Clear();
            this.checkedListBox2.Items.Add(label23.Text);
            durum = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fy = Convert.ToInt32(textBox6.Text);
            fx = x-1;
            label23.Text = "x=" + Convert.ToString(fx) + " * y=" + textBox6.Text;
            label29.Text = Convert.ToString(fx);
            label30.Text = textBox6.Text;
            this.checkedListBox2.Items.Clear();
            this.checkedListBox2.Items.Add(label23.Text);
            durum = 3;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            px = Convert.ToInt32(textBox11.Text);
            py = Convert.ToInt32(textBox12.Text);
            fare[px,py] = 2;
            label24.Text = "x=" + textBox11.Text + " * y=" + textBox12.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.checkedListBox2.Items.Clear();
           /* textBox1.Enabled = !textBox1.Enabled;
            textBox2.Enabled = !textBox2.Enabled;
            textBox3.Enabled = !textBox3.Enabled;
            textBox4.Enabled = !textBox4.Enabled;
            textBox5.Enabled = !textBox5.Enabled;
            textBox6.Enabled = !textBox6.Enabled;
            textBox7.Enabled = !textBox7.Enabled;
            textBox8.Enabled = !textBox8.Enabled;
            textBox9.Enabled = !textBox9.Enabled;
            textBox10.Enabled = !textBox10.Enabled;
            textBox11.Enabled = !textBox11.Enabled;
            textBox12.Enabled = !textBox12.Enabled;*/

            hareketreset();
            timer1.Enabled = !timer1.Enabled ;
        }

        private void hareketreset()
        {
            hareketx = 0;
            harekety = 0;
            hareketcarpan = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            
            label29.Text = Convert.ToString(farex);
            label30.Text = Convert.ToString(farey);
            koordinat = "fare(x: " + Convert.ToString(farex) + ", y:" + Convert.ToString(farey)+")";
            this.checkedListBox2.Items.Add(koordinat);
            fare_engel_algoritma();
            hareketcarpan++;
        }

        private void fare_engel_algoritma()
        {
           switch(durum){
               case 1: hareketx = hareketcarpan * 20;
                   sinirdisi();
                   finish();
                   break;
               case 2: harekety =hareketcarpan * 20;
                   sinirdisi2();
                   finish();
                   break;
               case 3: hareketx = -(hareketcarpan * 20);
                   sinirdisi1(); 
                   finish();
                   break;
               case 4: harekety = -(hareketcarpan * 20);
                   sinirdisi3();
                   finish();
                   break;

           }
        
            
        }

        private void finish()
        {
            if (Convert.ToInt32(textBox12.Text) == farey && Convert.ToInt32(textBox11.Text) == farex)
            {
                timer1.Enabled = false;
                MessageBox.Show("finish");
            }
        }

        private void sinirdisi()
        {
            if (farex== Convert.ToInt32(textBox1.Text)-1)
            {
                timer1.Enabled = false;
            }
            
        }
        private void sinirdisi1()
        {
            if (farex == 0)
            {
                timer1.Enabled = false;
            }
            
        }
        private void sinirdisi2()
        {
            if (farey == Convert.ToInt32(textBox2.Text) - 1)
            {
                timer1.Enabled = false;
            }
        }
        private void sinirdisi3()
        {
            if (farey == 0)
            {
                timer1.Enabled = false;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            Invalidate();
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       
    }
}