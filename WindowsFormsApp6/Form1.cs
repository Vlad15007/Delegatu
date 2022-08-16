using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public delegate void AccauntStory();

    public partial class Form1 : Form
    {
        Accaunt myAcc;

        public Form1()
        {
            InitializeComponent();
            AccauntStory myZapis = delegate
            {
                label1.Text = myAcc.Schet + "UAN";
                textBox1.Text += myAcc.Schet + "\r\n";
            };


            myAcc = new Accaunt(myZapis);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myAcc.Popolnit(1000);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myAcc.Snatie(200);
        }
    }

    class Accaunt
    {
        AccauntStory show;
        double schet = 1000;
        public double Schet 
        {
            get
            {
                return schet;
            }
        }

        public void Popolnit(double symma)
        {
            schet += symma;
            show();
        }
        public void Snatie(double symma)
        {
            schet -= symma;
            show();
        }

        public Accaunt(AccauntStory zapisuvanie)
        {
            show = zapisuvanie;
        }
    }
}
