using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using winform_client;

namespace WindowsFormsApp2
{
    public class Element_Async
    {
        public byte[] Buffer;
        public Socket WorkingSocket;
        public readonly int BufferSize;
        public Element_Async(int bufferSize)
        {
            BufferSize = bufferSize;
            Buffer = new byte[BufferSize];
        }

        public void ClearBuffer()
        {
            Array.Clear(Buffer, 0, BufferSize);
        }
    }
    public partial class Server : Form
    {

        Modal_Server ms;
        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate text;
        Socket mainSocket;
        IPAddress address;
        int port;


        private int i;
        private winform_client.All_Shapes[] all_shapes;
        private winform_client.MyPen[] mypens;
        private winform_client.MyLines[] mylines;
        private winform_client.MyRect[] myrects;
        private winform_client.MyCircle[] mycircles;
        private Pen pen;
        private SolidBrush sb;
        private int thick;
        private int nobject;

        public Server()
        {
            InitializeComponent();
            mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            text = new AppendTextDelegate(AppendText);
            SetupVar();
        }
        void AppendText(Control ctrl, string s)
        {
            if (ctrl.InvokeRequired) ctrl.Invoke(text, ctrl, s);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
            }
        }
        private void Server_Load(object sender, EventArgs e)
        {

            ms = new Modal_Server();
            ms.Owner = this;
            ms.ShowDialog();
            if (ms.DialogResult == DialogResult.OK)
            {
                address = IPAddress.Parse(ms.set_ip());
                port = ms.set_port();
                InitSocket();
            }

        }
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mainSocket != null)
            {
                mainSocket.Close();
            }
        }
        public void InitSocket()
        {
            txt_chat.AppendText("Server started...");
            // 서버에서 클라이언트의 연결 요청을 대기하기 위해
            // 소켓을 열어둔다.
            IPEndPoint serverEP = new IPEndPoint(address, port);
            mainSocket.Bind(serverEP);
            mainSocket.Listen(10);

            // 비동기적으로 클라이언트의 연결 요청을 받는다.
            mainSocket.BeginAccept(AcceptCallback, null);
        }

        List<Socket> connectedClients = new List<Socket>();

        void AcceptCallback(IAsyncResult ar)
        {
            Socket client = mainSocket.EndAccept(ar);

            mainSocket.BeginAccept(AcceptCallback, null);

            Element_Async obj = new Element_Async(4096);
            obj.WorkingSocket = client;

            connectedClients.Add(client);
            AppendText(txt_chat, string.Format("client connect" + connectedClients.Count));
            client.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);

        }

        void DataReceived(IAsyncResult ar)
        {
            Element_Async obj = (Element_Async)ar.AsyncState;

            int received = obj.WorkingSocket.EndReceive(ar);

            if (received <= 0)
            {
                obj.WorkingSocket.Close();
                return;
            }

                byte[] byteType = new byte[4];
                Buffer.BlockCopy(obj.Buffer, 0, byteType, 0, 4);
                string text = Encoding.UTF8.GetString(byteType);
               

                if (text.Equals("text"))
                {
                 byte[] byteMessage = new byte[obj.BufferSize - 4];
                 Buffer.BlockCopy(obj.Buffer, 4, byteMessage, 0, obj.BufferSize - 4);
                string message = Encoding.UTF8.GetString(byteMessage);
                    string[] tokens = message.Split('\x01');
                    string _id = tokens[0];
                    string _msg = tokens[1];

                    AppendText(txt_chat, string.Format("{0}: {1}", _id, _msg));


            }
                else if (text.Equals("exit"))
                {
                    for (int i = connectedClients.Count - 1; i >= 0; i--)
                    {
                        if (connectedClients[i] == obj.WorkingSocket)
                        {
                            connectedClients.RemoveAt(i);
                            break;
                        }

                    }
                }
                else
                {
                    using (MemoryStream stream = new MemoryStream(obj.Buffer))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        stream.Position = 0;
                    
                    all_shapes[nobject] = (winform_client.All_Shapes)bf.Deserialize(stream);
                     nobject++;
                    if (panel.InvokeRequired)
                        {
                            panel.Invoke(new MethodInvoker(delegate ()
                                  {
                                      panel.Invalidate(true);
                                      panel.Update();
                                  }));
                        }
                    }
          
            }
            for (int i = connectedClients.Count - 1; i >= 0; i--)
            {
                Socket socket = connectedClients[i];
                if (socket != obj.WorkingSocket)
                {
                    try
                    {
                        socket.Send(obj.Buffer);
                    }
                    catch
                    {
                        try
                        {
                            socket.Dispose();
                        }
                        catch { }
                        connectedClients.RemoveAt(i);
                    }
                }


            }


            obj.ClearBuffer();
            
                obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);

        }
        void OnSendData(object sender, EventArgs e)
        {
            if (!mainSocket.IsBound)
            {
                MessageBox.Show("서버가 제대로 실행되고 있지 않다!");
                return;
            }

            string tts = txt_chat.Text.Trim();
            if (string.IsNullOrEmpty(tts))
            {
                MessageBox.Show("텍스트가 입력되지 않았습니다!");
                txt_chat.Focus();
                return;
            }

            byte[] bDts = Encoding.UTF8.GetBytes("text" + address.ToString() + '\x01' + tts);

            for (int i = connectedClients.Count - 1; i >= 0; i--)
            {
                Socket socket = connectedClients[i];
                try { socket.Send(bDts);
                    
                }
                catch
                {
                    try { socket.Dispose(); } catch { }
                    connectedClients.RemoveAt(i);
                }
            }
            AppendText(txt_chat, string.Format("[send]{0} : {1}", address.ToString(), tts));
        }
        private void SetupVar()
        {
            thick = 1;
            pen = new Pen(Color.Black);
            mypens = new winform_client.MyPen[3000];
            mylines = new winform_client.MyLines[100];
            myrects = new winform_client.MyRect[100];
            mycircles = new winform_client.MyCircle[100];
            sb = new SolidBrush(Color.Black);
            all_shapes  = new winform_client.All_Shapes[3000];
            
            SetupMine();
        }
        private void SetupMine()
        {
            for (i = 0; i < 100; i++)
            {
                myrects[i] = new winform_client.MyRect();
                mylines[i] = new winform_client.MyLines();
                mycircles[i] = new winform_client.MyCircle();
            }
            for (i = 0; i < 3000; i++)
            {
                all_shapes[i] = new winform_client.All_Shapes();
                mypens[i] = new winform_client.MyPen();
            }
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                for (i = 0; i < all_shapes.Length; i++)
                {

                    if (!all_shapes[i].getSolid())
                    {
                        pen.Width = 1;
                        pen.Color = all_shapes[i].getLineColor();
                        pen.DashStyle = DashStyle.Dot;
                    }
                    else
                    {
                        pen.Width = all_shapes[i].getThick();
                        pen.Color = all_shapes[i].getLineColor();
                        pen.DashStyle = DashStyle.Solid;
                    }

                    if (all_shapes[i].GetType() == new winform_client.MyPen().GetType())
                    {
                        winform_client.MyPen mypen = (winform_client.MyPen)all_shapes[i];
                        e.Graphics.DrawLine(pen, mypen.getStart(), mypen.getFinish());
                        e.Graphics.FillEllipse(new SolidBrush(pen.Color), mypen.getStart().X, mypen.getStart().Y, 1, 1);
                    }
                    else if (all_shapes[i].GetType() == new winform_client.MyLines().GetType())
                    {
                        e.Graphics.DrawLine(pen, all_shapes[i].getStart(), all_shapes[i].getFinish());
                    }
                    else if (all_shapes[i].GetType() == new winform_client.MyCircle().GetType())
                    {
                        winform_client.MyCircle mycircle = (winform_client.MyCircle)all_shapes[i];
                        e.Graphics.DrawEllipse(pen, mycircle.getRectC());
                        if (mycircle.getFill())
                        {
                            sb.Color = mycircle.getColor();
                            e.Graphics.FillEllipse(sb, mycircle.getRectC());
                        }
                    }
                    else if (all_shapes[i].GetType() == new winform_client.MyRect().GetType())
                    {
                        winform_client.MyRect myrect = (winform_client.MyRect)all_shapes[i];
                        e.Graphics.DrawRectangle(pen, myrect.getRect());
                        if (myrect.getFill())
                        {
                            sb.Color = myrect.getColor();
                            e.Graphics.FillRectangle(sb, myrect.getRect());
                        }
                    }

                }

            }
    }

}
