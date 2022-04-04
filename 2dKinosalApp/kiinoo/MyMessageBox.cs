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
    public partial class MyMessageBox : Form
    {
        public MyMessageBox(string pomocna, bool btn1, bool btn2, bool btn3)
        {
            InitializeComponent();

            string vypis = pomocna;


            label1.Text = vypis;
            button1.Visible = btn1;
            button2.Visible = btn2;
            button3.Visible = btn3;
            
        }
    }
}
