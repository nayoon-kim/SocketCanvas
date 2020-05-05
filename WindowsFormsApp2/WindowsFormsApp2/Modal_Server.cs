using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp2
{
    public partial class Modal_Server : Form
    {
        public Modal_Server()
        {
            InitializeComponent();
        }
        public string ip;
        public int port;
        public string set_ip()
        {
            return ip;
        }
        public int set_port()
        {
            return port;
        }
        private void Btn_server_Click(object sender, EventArgs e)
        {

            Server serv = new Server();
            try
            {

                int a = 0;
                if (!server_ip.Text.Equals(""))
                {
                    ip = server_ip.Text;
                    a++;
                }
                if (!server_port.Text.Equals(""))
                {
                    port = Int32.Parse(server_port.Text);
                    a++;
                }
                if (a == 2)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
