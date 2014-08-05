using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using ServerApp;

namespace Home
{
    public partial class Home : Form
    {
        private int delayHide = 0;
        private TcpClient client;
        private int ServerPort = 1412;
        private IPAddress ServerAddr = IPAddress.Parse("192.168.1.101");
        private StreamReader str;
        private StreamWriter stw;
        private TcpListener listener;
        private struct MessageState
        {
            public MessageState(String msg, int duration)
            {
                this.msg = msg;
                this.duration = duration;
            }
            public string msg;
            public int duration;
            public override string ToString()
            {
                return String.Format("Message: {0}. Duration: {1}", this.msg, this.duration);
            }
        };
        private Queue<MessageState> states = new Queue<MessageState>();
        private Queue<string> Command = new Queue<string>();

        private void changeState(String msg, int ms) 
        {
            MessageState newState = new MessageState(msg, ms / 100);
            states.Enqueue(newState);
        }

        public Home()
        {
            InitializeComponent();

            IPAddress[] ipAddr = Dns.GetHostAddresses(Dns.GetHostName());
            if (ipAddr.Length == 0)
            {
                changeState("Cannot get IP address, use the default IP.", 3000);
            }
            else
            {
                foreach (IPAddress ip in ipAddr)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ServerAddr = ip;
                        changeState("New Server IP address: " + ServerAddr.ToString() + ", press Ctl + R to change.", 3000);
                        break;
                    }
                }
            }
        }

        private void hotkey(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.R)       // Ctrl-R change IP and port
            {
                ServerInfo sinfo = new ServerInfo();
                IPAddress[] ipAddr = Dns.GetHostAddresses(Dns.GetHostName());
                if (ipAddr.Length != 0)
                {
                    int count = 0;
                    foreach (IPAddress ip in ipAddr)
                    {
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        sinfo.IPS = new string[count];
                        count = 0;
                        foreach (IPAddress ip in ipAddr)
                        {
                            if (ip.AddressFamily == AddressFamily.InterNetwork)
                            {
                                sinfo.IPS[count++] = ip.ToString();
                            }
                        }
                    }
                }
                //sinfo.IP = ServerAddr.ToString();
                sinfo.Port = ServerPort;
                var r = sinfo.ShowDialog();
                if (r == DialogResult.OK)
                {
                    if (sinfo.IP == "" || sinfo.Port == 0)
                        return;
                    ServerAddr = IPAddress.Parse(sinfo.IP);
                    ServerPort = sinfo.Port;
                    backgroundWorkerListenClient.CancelAsync();
                    listener.Stop();
                    listener = new TcpListener(IPAddress.Any, ServerPort);
                    listener.Start();
                    changeState("Start new Server with IP address: " + ServerAddr.ToString() +
                        ", port: " + ServerPort.ToString(), 3000);
                    backgroundWorkerListenClient.WorkerSupportsCancellation = true;
                    backgroundWorkerListenClient.RunWorkerAsync();
                }
                e.SuppressKeyPress = true;  // stops bing! also sets handeled which stop event bubbling
            }
        }

        private void radioButtonLED3_Click(object sender, EventArgs e)
        {
            if (this.radioButtonLED3.Checked)
            {
                this.radioButtonLED3.Checked = false;
                this.radioButtonLED3.Text = "Off";
                this.Command.Enqueue("LED3 Off");
            }
            else
            {
                this.radioButtonLED3.Checked = true;
                this.radioButtonLED3.Text = "On";
                this.Command.Enqueue("LED3 On");
            }
        }

        private void radioButtonLED4_Click(object sender, EventArgs e)
        {
            if (this.radioButtonLED4.Checked)
            {
                this.radioButtonLED4.Checked = false;
                this.radioButtonLED4.Text = "Off";
                this.Command.Enqueue("LED4 Off");
            }
            else
            {
                this.radioButtonLED4.Checked = true;
                this.radioButtonLED4.Text = "On";
                this.Command.Enqueue("LED4 On");
            }
        }

        private void radioButtonSW_Click(object sender, EventArgs e)
        {
            this.changeState("This device cannot change from Server.", 1000);
        }
        
        private void Home_Load(object sender, EventArgs e)
        {
            this.timerUI.Start();
            listener = new TcpListener(IPAddress.Any, ServerPort);
            listener.Start();
            changeState("Server start with IP: " + ServerAddr.ToString() + " port: " + ServerPort.ToString(), 3000);
            backgroundWorkerListenClient.WorkerSupportsCancellation = true;
            backgroundWorkerListenClient.RunWorkerAsync();
        }

        private void Home_closing(object sender, EventArgs e)
        {
            this.timerUI.Stop();
            listener.Stop();
            if (backgroundWorkerListenClient.IsBusy)
                backgroundWorkerListenClient.CancelAsync();
        }

        private void timerUI_Tick(object sender, EventArgs e)
        {
            if (delayHide > 0)
                delayHide--;
            else if (states.Count != 0)
            {
                MessageState state = states.Dequeue();
                delayHide = state.duration;
                this.textBoxState.Text = states.Count.ToString() + " Msg: " + state.msg;
            }
            else
            {
                this.textBoxState.Text = "Idle";
            }
        }

        private void backgroundWorkerListenClient_DoWork(object sender, DoWorkEventArgs e)
        {
            changeState("Back Ground Worker is running", 1000);
            // wait for connection
            while (true)
            {
                if (listener.Pending())
                {
                    client = listener.AcceptTcpClient();
                    str = new StreamReader(client.GetStream());
                    stw = new StreamWriter(client.GetStream());
                    stw.AutoFlush = true;
                    while (client.Connected)
                    {
                        if (client.Available != 0)
                        {
                            try
                            {
                                string mes = str.ReadLine();
                                changeState(mes, 300);
                                if (mes == "send me data")
                                {
                                    if (Command.Count != 0)
                                    {
                                        stw.WriteLine(Command.Dequeue());
                                    }
                                    else
                                    {
                                        stw.WriteLine("OK");
                                    }
                                }
                                else if (mes == "Switch on")
                                {
                                    radioButtonSW.Checked = true;
                                    radioButtonSW.Text = "On";
                                }
                                else if (mes == "Switch off")
                                {
                                    radioButtonSW.Checked = false;
                                    radioButtonSW.Text = "Off";
                                }
                            }
                            catch (Exception)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void backgroundWorkerClientProcess_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
