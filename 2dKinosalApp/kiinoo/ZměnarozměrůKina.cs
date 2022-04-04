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
    public partial class ZměnarozměrůKina : Form
    {
        public int Radky;
        public int sloupce;

        public ZměnarozměrůKina(int Aradky, int Asloupce)
        {
            InitializeComponent();
            Radky = Aradky;
            sloupce = Asloupce;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            try
            {
                Radky = Convert.ToInt32(textBox1.Text);
                sloupce = Convert.ToInt32(textBox2.Text);
                Form1 form1 = new Form1(Radky, sloupce);
                form1.ShowDialog();

            }catch(Exception)
            {
                MessageBox.Show("chyba");
            }
            
        }
    }
}
