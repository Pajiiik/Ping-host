using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Ping_program
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



            public static bool PingHost(string adresa)
            {
                bool pingnuto = false;
                Ping pinger = null;

                try
                {
                    pinger = new Ping();
                    PingReply odpoved = pinger.Send(adresa);
                    pingnuto = odpoved.Status == IPStatus.Success;
                }
                catch (PingException)
                {

                }
            return pingnuto;
            }
        string ip_adress;
        private void button1_Click(object sender, EventArgs e)
        {
            ip_adress = textBox1.Text;
            label1.Text = "Status: True";
            timer1.Interval = 1;
            timer1.Start();
        }
        bool status;
        bool status_before = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
            status = PingHost(ip_adress);
            if (status != status_before)
            {
                label1.Text = "Status: " + status.ToString();
                status_before = status;
            }
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Status: ";
            timer1.Stop();
        }
    }
}
