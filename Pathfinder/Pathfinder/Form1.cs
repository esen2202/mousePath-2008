using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pathfinder
{
    public partial class Form1 : Form
    {
        double x, y,dogu,bati,kuzey,guney,fare=0,peynir=0;
        Int32  i,nesnekontrol=0;
        Int32[,] yolmatris, farematris, engelmatris, peynirmatris;
        Int32[] engel = new Int32[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            labirentCiz(e);
        }

        private void labirentCiz(PaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(Color.Silver);
            Pen p = new Pen(Color.Blue, 1);
            e.Graphics.TranslateTransform(20, 20);
            e.Graphics.FillRectangle(b, 0, 0, Convert.ToSingle(x * 20), Convert.ToSingle(y * 20));
            for (i = 1; i <= x; i++)
            {
                e.Graphics.DrawLine(p, Convert.ToSingle(i * 20), 0, Convert.ToSingle(i * 20), Convert.ToSingle(y * 20));
            }
            for (i = 1; i <= y; i++)
            {
                e.Graphics.DrawLine(p, 0, Convert.ToSingle(i * 20), Convert.ToSingle(x * 20), Convert.ToSingle(i * 20));
            }
        }
        private void FareTestLabirentCiz(PaintEventArgs e)
        {
            SolidBrush b = new SolidBrush(Color.Silver);
            Pen p = new Pen(Color.Blue, 1);
            e.Graphics.TranslateTransform(20, 20);
            e.Graphics.FillRectangle(b, 0, 0, Convert.ToSingle(x * 20), Convert.ToSingle(y * 20));
            for (i = 1; i <= x; i++)
            {
                e.Graphics.DrawLine(p, Convert.ToSingle(i * 20), 0, Convert.ToSingle(i * 20), Convert.ToSingle(y * 20));
            }
            for (i = 1; i <= y; i++)
            {
                e.Graphics.DrawLine(p, 0, Convert.ToSingle(i * 20), Convert.ToSingle(x * 20), Convert.ToSingle(i * 20));
            }
        }
        private void nesnelerSabit()
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
            fare = 0;
            peynir = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 0; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
  
        }

        private void matriscreate(Int32 xdeger, Int32 ydeger) 
        {
            Int32  dongu,dongu2;
            yolmatris = new int[xdeger, ydeger];
            farematris = new int[xdeger, ydeger];
            engelmatris = new int[xdeger, ydeger];
            peynirmatris = new int[xdeger, ydeger];
            for (dongu = 0; dongu <= xdeger-1; dongu++) {
                for (dongu2 = 0; dongu2 <= ydeger-1; dongu2++) {
                    yolmatris[dongu, dongu2] = 0;
                    farematris[dongu, dongu2] = 0;
                    engelmatris[dongu, dongu2] = 0;
                    peynirmatris[dongu, dongu2] = 0;
                }
                
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            x = Convert.ToDouble(textBox1.Text);
            y = Convert.ToDouble(textBox2.Text);
            matriscreate(Convert.ToInt32(x),Convert.ToInt32(y));
            Invalidate();
           // timer1.Enabled = !timer1.Enabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double farex;
            double farey;
            double peynirx;
            double peyniry,farkx,farky;
            int d1, d2, d3, d4, t1, t2, t3, t4,yonust = 0, yonalt = 0, win = 0; 
            farepeynirbul(out farex, out farey, out peynirx, out peyniry);
            farkx = Math.Abs(farex-peynirx);
            farky = Math.Abs(farey - peyniry);
            if (farex <= peynirx) {dogu = 1; bati = 0; }else{ dogu = 0;bati = 1; }
            if (farey <= peyniry){  guney = 1;kuzey = 0;}else{guney = 0;kuzey = 1;}
            yonalt = 0; yonust = 0; 
            //ZAFER Start
            if (farex == peynirx && farey == peyniry)
            {
                kontrolet("Peynir Farenin");
                win = -1;

            }
            else 
            {
                win = 0;
            }

            //ZAFER Timer Finish


            //GÜNEY_DOÐU Start 
            if (dogu == 1 && guney == 1 && win==0) 
            {
                //Doðuya doðru Engel Aþma BAþla
                //3 yanýda doluysa engellerle
                //if (Convert.ToInt32(farey) > 1 && Convert.ToInt32(farey) < Convert.ToInt32(y)) 
                //{
                //    if (farematris[Convert.ToInt32(farex), Convert.ToInt32(farey) - 2] == 99 && farematris[Convert.ToInt32(farex), Convert.ToInt32(farey)] == 99 && farematris[Convert.ToInt32(farex)+1, Convert.ToInt32(farey) - 1] == 99)
                //    {
                //        kontrolet("çýkmaz sokak");
                //        win = 1;
                //    } //finish
                //}
                if (Convert.ToInt32(farex) > 1 && Convert.ToInt32(farex) < Convert.ToInt32(x))
                {
                    if (farematris[Convert.ToInt32(farex)-2, Convert.ToInt32(farey)] == 99 && farematris[Convert.ToInt32(farex), Convert.ToInt32(farey)] == 99 && farematris[Convert.ToInt32(farex) -1, Convert.ToInt32(farey) + 1] == 99)
                    {
                        kontrolet("çýkmaz sokak");
                        win = 1;
                    } //finish
                }
                
                //bir sonraki adýmýn altýnda ve üstünde engel yoksa 
               /* if (Convert.ToInt32(farey) > 1 && Convert.ToInt32(farey) < Convert.ToInt32(y))
                { 
                    if (farematris[Convert.ToInt32(farex) - 1, Convert.ToInt32(farey) - 2] != 99 && farematris[Convert.ToInt32(farex) - 1, Convert.ToInt32(farey)] != 99)
                    {
                        if (farematris[Convert.ToInt32(farex), Convert.ToInt32(farey) - 1] == 99)//Karþýsýnda engel varsa
                        {
                            for (d1 = Convert.ToInt32(farex); d1 <= Convert.ToInt32(peynirx); d1++)//engelin yukarýsýndan peynire toplam deðer
                            {
                                yonust = yonust + farematris[d1 - 1, Convert.ToInt32(farey) - 2];
                                if (yonust == 99)
                                {
                                    yonust = -2;
                                    break;
                                }
                            }
                            for (d1 = Convert.ToInt32(farex); d1 <= Convert.ToInt32(peynirx); d1++)//engelin aþaðýsýndan peynire toplam deðer
                            {
                                yonalt = yonalt + farematris[d1 - 1, Convert.ToInt32(farey)];
                                if (yonalt == 99)
                                {
                                    yonalt = -2;
                                    break;
                                }
                            }
                            if (yonalt != -2 || yonust != -2)
                            {
                                if (yonalt > yonust)
                                {
                                    fareyon("K");
                                    farepictureBox.Top = farepictureBox.Top - 20;
                                }
                                else
                                {
                                    fareyon("G");
                                    farepictureBox.Top = farepictureBox.Top + 20;
                                }
                            }
                        }
                    }
                    else 
                    {
                        //kontrolet("her tarafta dolu");
                        //win = 1;
                    }
                }
                */
               



                //TEK KOORDÝNAT AYNIYSA Start
                if (farex == peynirx && win==0)
                {
                    if (Convert.ToInt32(farey)>1&& Convert.ToInt32(farey)< Convert.ToInt32(y)) 
                    {
                        if (farematris[Convert.ToInt32(farex)-1, Convert.ToInt32(farey)] != 99)
                        {
                            fareyon("G");
                            farepictureBox.Top = farepictureBox.Top + 20;  
                        }
                        else 
                        {
                            //solu ve aþaðýsý doluysa baþla
                            if (farematris[Convert.ToInt32(farex)-2, Convert.ToInt32(farey)-1] == 99 && farematris[Convert.ToInt32(farex)-1, Convert.ToInt32(farey)] == 99)
                            {
                                fareyon("D");
                                farepictureBox.Left = farepictureBox.Left + 20;
                            }
                            //önü ve aþaðýsý doluyusa baþla
                            if (farematris[Convert.ToInt32(farex) , Convert.ToInt32(farey)-1] == 99 && farematris[Convert.ToInt32(farex)-1, Convert.ToInt32(farey)] == 99)
                            {
                                fareyon("B");
                                farepictureBox.Left = farepictureBox.Left - 20;
                            }
                            //önü ve yukarýsý+aþagýsý doluysa bitir
                           // kontrolet("engel var");
                            win = 1;
                        }
                    }
                }
                if (farey == peyniry && win==0) 
                {
                    if (Convert.ToInt32(farex)>1&& Convert.ToInt32(farex)< Convert.ToInt32(x))
                    {
                        if (farematris[Convert.ToInt32(farex), Convert.ToInt32(farey)-1] != 99)
                        {
                            fareyon("D");
                            farepictureBox.Left = farepictureBox.Left + 20;
                        }
                        else
                        {
                            //önü ve yukarýsý doluysa baþla
                            if (farematris[Convert.ToInt32(farex)-1, Convert.ToInt32(farey) - 2] == 99 && farematris[Convert.ToInt32(farex), Convert.ToInt32(farey) - 1] == 99)
                            {
                                fareyon("G");
                                farepictureBox.Top = farepictureBox.Top + 20;
                            }
                            //önü ve aþaðýsý doluyusa baþla
                            if (farematris[Convert.ToInt32(farex)-1, Convert.ToInt32(farey)] == 99 && farematris[Convert.ToInt32(farex), Convert.ToInt32(farey) - 1] == 99)
                            {
                                fareyon("K");
                                farepictureBox.Top = farepictureBox.Top - 20;
                            }
                            //önü ve yukarýsý+aþagýsý doluysa bitir
                           // kontrolet("engel var");
                            win = 1;
                        }
                    }
                }
                //TEK KOORDÝNAT AYNIYSA Finish
            }
            //GÜNEY DOÐU Finish

            //KUZEY DOGU Start
            /*   if (dogu == 1 && kuzey == 1 && win == 1)
               {
                   //TEK KOORDÝNAT AYNIYSA Start
                   if (farex == peynirx && win==0)
                   {
                       if (Convert.ToInt32(farey) > 0)
                       {
                           if (farematris[Convert.ToInt32(farex) - 1, Convert.ToInt32(farey)-2] != 99 && farematris[Convert.ToInt32(farex) - 1, Convert.ToInt32(farey)-2] != 99)
                           {
                               fareyon("K");
                               farepictureBox.Top = farepictureBox.Top - 20;
                           }
                           else
                           {
                               kontrolet("engel var");
                               win=2;           
                           }
                       }
                   }
                   if (farey == peyniry && win==1)
                   {
                       if (Convert.ToInt32(farex) < Convert.ToInt32(x))
                       {
                           if (farematris[Convert.ToInt32(farex), Convert.ToInt32(farey) - 1] != 99 && farematris[Convert.ToInt32(farex), Convert.ToInt32(farey) - 1] != 99)
                           {
                               fareyon("D");
                               farepictureBox.Left = farepictureBox.Left + 20;
                           }
                           else
                           {
                               kontrolet("engel var");
                               win=2;
                           }
                       }
                   }
                   //TEK KOORDÝNAT AYNIYSA Finish
               }
               //KUZEY DOÐU Finish

               //GÜNEY BATI Start
               if (bati == 1 && guney == 1 && win == 2)
               {
                   //TEK KOORDÝNAT AYNIYSA Start
                   if (farex == peynirx && win==0)
                   {
                       if (Convert.ToInt32(farey) < Convert.ToInt32(y))
                       {
                           if (farematris[Convert.ToInt32(farex) - 1, Convert.ToInt32(farey)] != 99 && farematris[Convert.ToInt32(farex) - 1, Convert.ToInt32(farey)] != 99)
                           {
                               fareyon("G");
                               farepictureBox.Top = farepictureBox.Top + 20;
                           }
                           else
                           {
                               kontrolet("engel var");
                               win=3;  
                           }
                       }
                   }
                   if (farey == peyniry && win==2)
                   {
                       if (Convert.ToInt32(farex) > 0)
                       {
                           if (farematris[Convert.ToInt32(farex)-2, Convert.ToInt32(farey) - 1] != 99 && farematris[Convert.ToInt32(farex)-2, Convert.ToInt32(farey) - 1] != 99)
                           {
                               fareyon("B");
                               farepictureBox.Left = farepictureBox.Left - 20;
                           }
                           else
                           {
                               kontrolet("engel var");
                               win=3;  
                           }
                       }
                   }
                   //TEK KOORDÝNAT AYNIYSA Finish
               }
               */







            //Invalidate();
        }

        private void fareyon(string ad)
        {
            farepictureBox.Image = Image.FromFile(@"\img\FARE_" + ad + ".bmp");
        }

        private void kontrolet(string kon)
        {
            Baslat.Text = "Baþlat";
            timer1.Enabled = false;
            MessageBox.Show(kon);
            matrisler0();
            
        }

        private void farepeynirbul(out double farex, out double farey, out double peynirx, out double peyniry)
        {

            farex = Convert.ToDouble(farepictureBox.Left - 1) / 20;
            farey = Convert.ToDouble(farepictureBox.Top - 1) / 20;
            farex = Math.Floor(farex);
            farey = Math.Floor(farey);
            peynirx = Convert.ToDouble(peynirpictureBox.Left - 1) / 20;
            peyniry = Convert.ToDouble(peynirpictureBox.Top - 1) / 20;
            peynirx = Math.Floor(peynirx);
            peyniry = Math.Floor(peyniry);
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            double nesnex, nesney;
            if ((Convert.ToDouble(e.X) >= 40) && (Convert.ToDouble(e.Y) >= 40) && (Convert.ToDouble(e.X) <= (20 * x)) && (Convert.ToDouble(e.Y) <= (20 * y)) && (Convert.ToDouble(fare)==1)) {
                nesnex = Convert.ToDouble(e.X) / 20;
                nesney = Convert.ToDouble(e.Y) / 20;
                nesnex=Math.Floor(nesnex);
                nesney = Math.Floor(nesney);
                if (nesnex < Convert.ToDouble(x / 2)) {
                    farepictureBox.Image= Image.FromFile(@"\img\FARE_D.bmp" );
                } if (nesnex > Convert.ToDouble(x / 2)) { 
                    farepictureBox.Image= Image.FromFile(@"\img\FARE_B.bmp" );
                }
                if (nesney < Convert.ToDouble(y / 2)) {
                    farepictureBox.Image= Image.FromFile(@"\img\FARE_G.bmp" );
                } if (nesney > Convert.ToDouble(y / 2)) { 
                    farepictureBox.Image= Image.FromFile(@"\img\FARE_K.bmp" );
                }  
                this.farepictureBox.Left = Convert.ToInt32(nesnex * 20)+1;
                this.farepictureBox.Top =Convert.ToInt32(nesney * 20)+1;
                nesnelerSabit();
            }
            if ((Convert.ToDouble(e.X) >= 40) && (Convert.ToDouble(e.Y) >= 40) && (Convert.ToDouble(e.X) <= (20 * x)) && (Convert.ToDouble(e.Y) <= (20 * y)) && (Convert.ToDouble(peynir)==1)) {
                nesnex = Convert.ToDouble(e.X) / 20;
                nesney = Convert.ToDouble(e.Y) / 20;
                nesnex=Math.Floor(nesnex);
                nesney=Math.Floor(nesney);
                this.peynirpictureBox.Left = Convert.ToInt32(nesnex * 20)+1;
                this.peynirpictureBox.Top =Convert.ToInt32(nesney * 20)+1;
                nesnelerSabit();
            }
            engelobject(e,pictureBox1,1);
            engelobject(e,pictureBox2,2);
            engelobject(e, pictureBox3,3);
            engelobject(e, pictureBox4,4);
            engelobject(e, pictureBox5,5);
            engelobject(e, pictureBox6,6);
            engelobject(e, pictureBox7,7);
            engelobject(e, pictureBox8,8);
            

            
           
        }

        private void engelobject(MouseEventArgs e,PictureBox pic,int whichpic)
        {
            double nesnex, nesney;
                if ((Convert.ToDouble(e.X) >= 40) && (Convert.ToDouble(e.Y) >= 40) && (Convert.ToDouble(e.X) <= (20 * x)) && (Convert.ToDouble(e.Y) <= (20 * y)) && (Convert.ToDouble(engel[whichpic]) == 1))
                {
                    nesnex = Convert.ToDouble(e.X) / 20;
                    nesney = Convert.ToDouble(e.Y) / 20;
                    nesnex = Math.Floor(nesnex);
                    nesney = Math.Floor(nesney);
                    pic.Left = Convert.ToInt32(nesnex * 20) + 1;
                    pic.Top = Convert.ToInt32(nesney * 20) + 1;
                    //PictureBox engel1 = new PictureBox();
                    //engel1.Left = Convert.ToInt32(nesnex * 20) + 1;
                    //engel1.Top=Convert.ToInt32(nesney * 20)+1;
                    //engel1.Size.Height = 19;
                    //engel1.Size.Width = 19;
                    //engel1.Image = Image.FromFile(Pathfinder.Properties.Resources.DUVAR);       
                }    
        }

        private void farepictureBox_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++) { 
            engel[dongu] = 0;
            }
            fare = 1;
            peynir = 0;
           
        }

        private void peynirpictureBox_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
            fare = 0;
            peynir = 1;
            

        } 

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 2; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
            fare = 0;
            peynir = 0;
            engel[1] = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++)
            {
               engel[dongu] = 0;     
            }
            fare = 0;
            peynir = 0;
            engel[2] = 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
            fare = 0;
            peynir = 0;
            engel[3] = 1;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
            fare = 0;
            peynir = 0;
            engel[4] = 1;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
            fare = 0;
            peynir = 0;
            engel[5] = 1;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
            fare = 0;
            peynir = 0;
            engel[6] = 1;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
            fare = 0;
            peynir = 0;
            engel[7] = 1;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            int dongu;
            for (dongu = 1; dongu <= 8; dongu++)
            {
                engel[dongu] = 0;
            }
            fare = 0;
            peynir = 0;
            engel[8] = 1;
        }

        private void Baslat_Click(object sender, EventArgs e)
        {
            double nesnex, nesney;
            int dongu, dongu2;
            nesnelerSabit();
            if ((Convert.ToDouble(farepictureBox.Left) <= (20 * x) + 20) && (Convert.ToDouble(farepictureBox.Top) <= (20 * y) + 20) && (Convert.ToDouble(peynirpictureBox.Left) <= (20 * x) + 20) && (Convert.ToDouble(peynirpictureBox.Top) <= (20 * y) + 20))
            {
                nesnekontrol = 1;
                nesnelerSabit();
            }
            if (nesnekontrol == 0) {
                MessageBox.Show ("Önce Nesneleri Yerleþtir");
            } else { 
                if (Baslat.Text == "Baþlat")
                {
                    int bati,sayac=0;
                    nesnex = (Convert.ToDouble(farepictureBox.Left)) / 20;
                    nesney = (Convert.ToDouble(farepictureBox.Top)) / 20;
                    nesnex = Math.Floor(nesnex);
                    nesney = Math.Floor(nesney);
                    farematris[Convert.ToInt32(nesnex-1),Convert.ToInt32(nesney-1)] =Convert.ToInt32(x + y);
                    nesnex = (Convert.ToDouble(peynirpictureBox.Left)) / 20;
                    nesney = (Convert.ToDouble(peynirpictureBox.Top)) / 20;
                    nesnex = Math.Floor(nesnex);
                    nesney = Math.Floor(nesney);
                    farematris[Convert.ToInt32(nesnex - 1), Convert.ToInt32(nesney - 1)] = -1;
                    engelBul(pictureBox1,1);
                    engelBul(pictureBox2,2);
                    engelBul(pictureBox3,3);
                    engelBul(pictureBox4,4);
                    engelBul(pictureBox5,5);
                    engelBul(pictureBox6,6);
                    engelBul(pictureBox7,7);
                    engelBul(pictureBox8,8);



                    Baslat.Text = "Durdur";
                }else 
                {
                    matrisler0();
                    Baslat.Text = "Baþlat";
                    groupBox2.Visible = false;
                }
                // Algoritma.Visible = !Algoritma.Visible;
                timer1.Enabled = !timer1.Enabled;
                 
            }
            

        }

        private void matrisler0()
        {
            int dongu, dongu2;
            for (dongu = 0; dongu <= x - 1; dongu++)
            {
                for (dongu2 = 0; dongu2 <= y - 1; dongu2++)
                {
                    yolmatris[dongu, dongu2] = 0;
                    farematris[dongu, dongu2] = 0;
                    engelmatris[dongu, dongu2] = 0;
                    peynirmatris[dongu, dongu2] = 0;
                }

            }
        }

        private void engelBul(PictureBox pic, int whichpic)
        {
            double nesnex, nesney;
            Int32 don,sayac=0;
            if ((Convert.ToDouble(pic.Left) <= (20 * x) + 20) && (Convert.ToDouble(pic.Top) <= (20 * y) + 20))
            {
                nesnex = (Convert.ToDouble(pic.Left)) / 20;
                nesney = (Convert.ToDouble(pic.Top)) / 20;
                nesnex = Math.Floor(nesnex);
                nesney = Math.Floor(nesney);
                farematris[Convert.ToInt32(nesnex - 1), Convert.ToInt32(nesney - 1)] = 99;

                for (don = Convert.ToInt32(nesnex)-1; don >= 0; don--)
                {
                    if (don - 1 < 0) { break;}
                    if (farematris[don-1, Convert.ToInt32(nesney)-1] != 0) { break; }
                    farematris[don-1, Convert.ToInt32(nesney)-1] = Convert.ToInt32(x) - sayac;
                    sayac++;
                }
                sayac = 0;
                for (don = Convert.ToInt32(nesnex)-1; don <=Convert.ToInt32(x)-1; don++)
                {
                    if (don + 1 ==Convert.ToInt32(x)) { break; }
                    if (farematris[don+1, Convert.ToInt32(nesney) - 1] != 0) { break; }
                    farematris[don+1, Convert.ToInt32(nesney)-1] = Convert.ToInt32(x) - sayac;
                    sayac++;
                    
                }
                sayac = 0;
                for (don = Convert.ToInt32(nesney)-1; don >= 0; don--)
                {                    
                    if (don - 1 < 0) { break; }
                    if (farematris[Convert.ToInt32(nesnex) - 1, don-1] != 0) { break; }
                    farematris[Convert.ToInt32(nesnex)-1, don-1] = Convert.ToInt32(y) - sayac;
                    sayac++;
                }
                sayac = 0;
                for (don = Convert.ToInt32(nesney) - 1; don <= Convert.ToInt32(y) - 1; don++)
                { 
                    if (don + 1 == Convert.ToInt32(y)) { break; }
                    if (farematris[Convert.ToInt32(nesnex) - 1, don+1] != 0) { break; }
                    farematris[Convert.ToInt32(nesnex)-1, don+1] = Convert.ToInt32(y) - sayac;
                    sayac++;
                }
                sayac = 0;

            }
        }


        private void Algoritma_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = !groupBox2.Visible;
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            int dx, dy,strx=20,stry=20;
            SolidBrush b = new SolidBrush(Color.Black);
            Font drawFont = new Font("Arial", 10);
            FareTestLabirentCiz(e);
            for (dx = 0; dx <=Convert.ToInt32(x)-1; dx++ ) 
            {
                for (dy = 0; dy <= Convert.ToInt32(y)-1; dy++)
                {
                    e.Graphics.DrawString(Convert.ToString(farematris[dx, dy]),drawFont , b,strx*dx,stry*dy);  
                }
               
            }

            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }





    }
}