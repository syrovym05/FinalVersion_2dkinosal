using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kiinoo
{
    public partial class Form1 : Form
    {
        public int Sloupce;
        public int Radky;
        private ZměnarozměrůKina FormNastavení;
        public Button tlacitko;
        


        public Form1()
        {
            InitializeComponent();
            Sloupce = 17;
            Radky = 10;
            GenerateCollection();                        
        }

        public Form1(int ASloupce, int ARadky)
        {
            InitializeComponent();
            Sloupce = ASloupce;
            Radky = ARadky;
            GenerateCollection();
        }

        string[] indPole;

        private void GenerateCollection()
        {
            int rozmer = 50;

            panel1.Controls.Clear();

            
            int[,] dvoupole = new int[Sloupce, Radky];
            int Dvojsedacky;
            if ((Sloupce + 1) % 3 == 0)
            {
                Dvojsedacky = (Sloupce+1) / 3;
            }
            else if ((Sloupce + 2) % 3 == 0)
            {
                Dvojsedacky = (Sloupce) / 3;
            }
            else  Dvojsedacky = Sloupce / 3;

            panel1.Width = Sloupce * rozmer + rozmer * 2;
            panel1.Height = Radky * rozmer + rozmer * 2;
            

            for (int i = 0; i < Radky; i++)
            {
                for (int j = 0; j < Sloupce; j++)
                {
                    dvoupole[j, i] = 0;
                }
            }

            for (int i = 1; i <= Radky; i++)
            {
                if (i == 1)
                {
                    int pomocna = 0;
                    for (int j = 1; j <= Dvojsedacky; j++)
                    {
                        tlacitko = new Button();
                        tlacitko.Text = "" + Convert.ToChar(i + 64) + " " + j.ToString();
                        tlacitko.ForeColor = Color.FromArgb(60, 198, 50);            // zelena #3CC632
                        tlacitko.Width = rozmer * 2;
                        tlacitko.Height = rozmer;
                        tlacitko.Left = rozmer + pomocna;
                        tlacitko.Top = rozmer;
                        tlacitko.Click += tlacitko_Click;
                        tlacitko.BackgroundImage = Properties.Resources._2sedadlo_volne;
                        tlacitko.FlatStyle = FlatStyle.Flat;
                        tlacitko.FlatAppearance.BorderSize = 0;



                        panel1.Controls.Add(tlacitko);
                        pomocna += 150;
                    }
                }
                else
                {
                    for (int j = 1; j <= Sloupce; j++)
                    {
                        tlacitko = new Button();
                        tlacitko.Text = "" + Convert.ToChar(i + 64) + " " + j.ToString();
                        tlacitko.ForeColor = Color.FromArgb(60, 198, 50);            // zelena #3CC632

                        tlacitko.Width = rozmer;
                        tlacitko.Height = rozmer;
                        tlacitko.Left = rozmer * j;
                        tlacitko.Top = rozmer * i;
                        tlacitko.Click += tlacitko_Click;
                        tlacitko.BackgroundImage = Properties.Resources.sedadlo_volne;
                        tlacitko.FlatStyle = FlatStyle.Flat;
                        tlacitko.FlatAppearance.BorderSize = 0;
                        panel1.Controls.Add(tlacitko);
                    }
                }
            }


            indPole = new string[Sloupce * Radky];

        }


        bool pomocnaa = true;
        private void tlacitko_Click(object sender, EventArgs e)
        {            
            string vypis = "Vyber nasldeujíci akci!";
            bool zakoup_btn = true, rezerv_btn = true, volny_btn = false;
            int ind = panel1.Controls.GetChildIndex((Button)sender);

            //string[] indPole = new string[Sloupce * Radky];
            /*string[] indPole;
            if (pomocnaa == true)
            {
                indPole = new string[Sloupce * Radky];

                for (int i = 0; i < Sloupce * Radky && pomocnaa == true; i++)
                {
                    indPole[i] = "volne";
                }
                pomocnaa = false;
            }´*/
            /*if (panel1.Controls[ind].BackgroundImage == Properties.Resources._2sedadlo_volne || panel1.Controls[ind].BackgroundImage == Properties.Resources.sedadlo_volne)
            {             
                vypis = "Vyber nasldeujíci akci!";
                zakoup_btn = true;
                rezerv_btn = true;
                volny_btn = false;
            }
            else if (panel1.Controls[ind].BackgroundImage == Properties.Resources._2sedadlo_obsazene || panel1.Controls[ind].BackgroundImage == Properties.Resources.sedadlo_obsazene)
            {           
                vypis = "Toto sedadlo je již zakoupené!";
                zakoup_btn = false;
                rezerv_btn = false;
                volny_btn = false;
            }
            else if (panel1.Controls[ind].BackgroundImage == Properties.Resources._2sedadlo_rezervovane || panel1.Controls[ind].BackgroundImage == Properties.Resources.sedadlo_rezervovane)
            {               
                vypis = "Toto sedadlo je zarezervované!\nChcete zrušit rezervaci??";
                zakoup_btn = false;
                rezerv_btn = false;
                volny_btn = true;
            }*/


            if (indPole[ind] == "volne")
            {
                vypis = "Vyber nasldeujíci akci!";
                zakoup_btn = true;
                rezerv_btn = true;
                volny_btn = false;
            }
            else if (indPole[ind] == "obsazene")
            {
                vypis = "Toto sedadlo je již zakoupené!";
                zakoup_btn = false;
                rezerv_btn = false;
                volny_btn = false;
            }
            else if (indPole[ind] == "rezervovane")
            {
                vypis = "Toto sedadlo je zarezervované!\n\nChcete zrušit rezervaci??";
                zakoup_btn = false;
                rezerv_btn = false;
                volny_btn = true;
            }




            MyMessageBox myMessageBox = new MyMessageBox(vypis, zakoup_btn, rezerv_btn, volny_btn);
            DialogResult res = myMessageBox.ShowDialog();
            if (res == DialogResult.OK)
            {
                panel1.Controls[ind].ForeColor = Color.FromArgb(223, 17, 28);                //223, 17, 28
                indPole[ind] = "obsazene";
                if (ind >= 0 && ind < 6)
                {
                    panel1.Controls[ind].BackgroundImage = Properties.Resources._2sedadlo_obsazene;                    
                }
                else
                {
                    panel1.Controls[ind].BackgroundImage = Properties.Resources.sedadlo_obsazene;
                }
                
            }
            else if (res == DialogResult.No)
            {
                panel1.Controls[ind].ForeColor = Color.FromArgb(241, 218, 54);           //241, 218, 54
                indPole[ind] = "rezervovane";
                if (ind >= 0 && ind < 6)
                {
                    panel1.Controls[ind].BackgroundImage = Properties.Resources._2sedadlo_rezervovane;
                }
                else
                {
                    panel1.Controls[ind].BackgroundImage = Properties.Resources.sedadlo_rezervovane;
                }
                
            }
            else if(res == DialogResult.Abort)
            {
                panel1.Controls[ind].ForeColor = Color.FromArgb(60, 198, 50);
                indPole[ind] = "volne";
                if (ind >= 0 && ind < 6)
                {
                    panel1.Controls[ind].BackgroundImage = Properties.Resources._2sedadlo_volne;
                }
                else
                {
                    panel1.Controls[ind].BackgroundImage = Properties.Resources.sedadlo_volne;
                }               
            }                                           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Přihlášení Přihlášení = new Přihlášení(Radky, Sloupce);
            Přihlášení.ShowDialog();
            FormNastavení = new ZměnarozměrůKina(Radky, Sloupce);
            FormNastavení.Radky = Radky;
            FormNastavení.sloupce = Sloupce;
            Radky = FormNastavení.Radky;
            Sloupce = FormNastavení.sloupce;
            Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
