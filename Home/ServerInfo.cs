using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerApp
{
    public partial class ServerInfo : Form
    {
        public string[] IPS { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }

        public ServerInfo()
        {
            InitializeComponent();
        }

        private void ServerInfo_Load(object sender, EventArgs e)
        {
            foreach (string s in IPS)
                cbIPAddress.Items.Add(s);
            if (cbIPAddress.Items.Count > 0)
                cbIPAddress.SelectedIndex = 0;
            tbPort.Text = Port.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                IP = cbIPAddress.Text;
                Port = int.Parse(tbPort.Text);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IP = "";
            Port = 0;
            this.Close();
        }


    }
}
