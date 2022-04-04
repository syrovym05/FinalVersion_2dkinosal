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
    public partial class Přihlášení : Form
    {
        public int Radky;
        public int sloupce;
        public Přihlášení(int Aradky, int Asloupce)
        {
            InitializeComponent();
            Radky = Aradky;
            sloupce = Asloupce;
            textBox2.PasswordChar = '*';
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        string jmeno = "Admin";
        string Heslo = "12345";

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            try
            {
                string Jmenooduzivatele = textBox1.Text;
                string Heslooduzivate = textBox2.Text;
                if ((Jmenooduzivatele == jmeno) && (Heslooduzivate == Heslo))
                {
                    ZměnarozměrůKina ZměnarozměrůKina = new ZměnarozměrůKina(Radky, sloupce);
                    ZměnarozměrůKina.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Špatné Heslo nebo Jméno");
                }
            }catch (Exception ex)
            {
               MessageBox.Show("byla Zachycena chyba");
            }
            
        }

        private void Přihlášení_Load(object sender, EventArgs e)
        {

        }
    }
}

