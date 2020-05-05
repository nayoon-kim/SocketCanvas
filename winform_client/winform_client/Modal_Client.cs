using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winform_client
{
    public partial class Modal_Client : Form
    {
        public string ip;
        public int port;
        public string id;

        public Modal_Client()
        {
            InitializeComponent();
        }
        public string set_ip()
        {
            return ip;
        }
        public int set_port()
        {
            return port;
        }
        public string set_id()
        {
            return id;
        }
        private void Btn_server_Click(object sender, EventArgs e)
        {

            Client cli = new Client();

            try
            {
                int a = 0;
                if (!txt_ip.Text.Equals(""))
                {
                    ip = txt_ip.Text;
                    a++;
                }
                if (!txt_port.Text.Equals(""))
                {
                    port = Int32.Parse(txt_port.Text);
                    a++;
                }
                if (!txt_id.Text.Equals(""))
                {
                    id = txt_id.Text;
                    a++;
                }
                if (a == 3) {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
