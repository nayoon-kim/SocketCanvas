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
using System.Net;
using System.Drawing.Drawing2D;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace winform_client
{

    public partial class Client : Form
    {
        private bool pen_pen;
        private bool line;
        private bool rect;
        private bool circle;
        private bool hand;
        private Point start; //선, 도형의 시작 포인트
        private Point finish; //선, 도형의 끝 포인트
        private Point old;
        private Point current;

        private Pen pen; //펜
        private Pen pencil;
        private int npen; //현재 저장된 연필긋기의 개수
        private int nline;  //현재 저장된 선의 개수
        private int nrect;  //현재 저장된 사각형의 개수
        private int ncircle; //현재 저장된 원의 개수
        private int nobject; //현재 저장된 전체 도형의 개수
        //private int dyna;
        private int lines;
        private int i;
        private int thick;
        private bool isSolid;
        private bool isFill;
        private MyPen[] pens;
        private MyLines[] mylines;
        private MyRect[] myrects;
        private MyCircle[] mycircles;

        private int wheel_line;
        private bool painting; // 채우기
        private SolidBrush sb;
        private Color line_color;
        private Color fill_color;
        private All_Shapes[] all_shapes;

        private bool isHold;
        //private Object[] all_object;
        //소켓 연결과 다중 클라이언트를 위한 변수 및 메소드
        Modal_Client mc;
        string ip;
        int port;
        string id;

        private Point imgPoint;
        private Rectangle imgRect;

        public Graphics graphics;

        delegate void AppendTextDelegate(Control ctrl, string s);
        AppendTextDelegate _textAppender;
        Socket mainSock;

        //마우스 휠 구현
        private double ratio;

        public Client()
        {
            InitializeComponent();
            mainSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            _textAppender = new AppendTextDelegate(AppendText);
            SetupVar();
        }

        void AppendText(Control ctrl, string s)
        {
            if (ctrl.InvokeRequired) ctrl.Invoke(_textAppender, ctrl, s);
            else
            {
                string source = ctrl.Text;
                ctrl.Text = source + Environment.NewLine + s;
            }
        }

        private void Client_Load(object sender, EventArgs e)
        {
            mc = new Modal_Client();
            mc.Owner = this;
            mc.ShowDialog();
            if (mc.DialogResult == DialogResult.OK)
            {
                ip = mc.set_ip();
                port = mc.set_port();
                id = mc.set_id();
                InitSocket();
            }
            this.ActiveControl = txt_say;
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color color = cd.Color;
                if (painting == true)
                {
                    fill_color = color;
                }
                else
                {
                    fill_color = Color.Empty;
                }
            }

        }
        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                Color color = cd.Color;
                line_color = color;
            }
        }
        private void InitSocket()
        {
            if (mainSock.Connected)
            {
                MessageBox.Show("이미 연결되어 있습니다!");
                return;
            }

            try { mainSock.Connect(ip, port); }
            catch (Exception ex)
            {
                MessageBox.Show("연결에 실패했습니다!\n오류 내용: {0}", ex.Message);
                return;
            }

            // 연결 완료되었다는 메세지를 띄워준다.
            AppendText(txt_chat, "서버와 연결되었습니다.");

            // 연결 완료, 서버에서 데이터가 올 수 있으므로 수신 대기한다.
            Element_Async obj = new Element_Async(4096);
            obj.WorkingSocket = mainSock;

            mainSock.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
        }

        void DataReceived(IAsyncResult ar)
        {
            // BeginReceive에서 추가적으로 넘어온 데이터를 Element_Async 형식으로 변환한다.
            Element_Async obj = (Element_Async)ar.AsyncState;

            if (obj.WorkingSocket.Connected)
            {
                // 데이터 수신을 끝낸다.
                int received = obj.WorkingSocket.EndReceive(ar);

                // 받은 데이터가 없으면(연결끊어짐) 끝낸다.
                if (received <= 0)
                {
                    obj.WorkingSocket.Close();
                    return;
                }

                // 텍스트로 변환한다.
                byte[] byteType = new byte[4];
                Buffer.BlockCopy(obj.Buffer, 0, byteType, 0, 4);
                string text = Encoding.UTF8.GetString(byteType);
                byte[] byteMessage = new byte[obj.BufferSize - 4];
                Buffer.BlockCopy(obj.Buffer, 4, byteMessage, 0, obj.BufferSize - 4);
                if (text.Equals("text"))
                {
                    string message = Encoding.UTF8.GetString(byteMessage);
                    string[] tokens = message.Split('\x01');
                    string _id = tokens[0];
                    string _msg = tokens[1];

                    AppendText(txt_chat, string.Format("{0}: {1}", _id, _msg));
                }
                else if (text.Equals("exit"))
                {
                    return;
                }
                else
                {
                    using (MemoryStream stream = new MemoryStream(obj.Buffer))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        stream.Position = 0;

                        all_shapes[nobject] = (All_Shapes)bf.Deserialize(stream);
                        nobject++;

                        //all_object = (Object[])bf.Deserialize(stream);

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
            }
            obj.ClearBuffer();
            obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);

        }

        private void DisplayText(string text)
        {
            if (txt_chat.InvokeRequired)
            {
                txt_chat.BeginInvoke(new MethodInvoker(delegate
                {
                    txt_chat.AppendText(Environment.NewLine + id + ": " + text);
                }));

            }
            else
            {
                txt_chat.AppendText(Environment.NewLine + " >> " + text);
            }
        }

        private void Btn_say_Click(object sender, EventArgs e)
        {
            //NetworkStream stream = clientSocket.GetStream();

            if (!mainSock.IsBound)
            {
                System.Windows.Forms.MessageBox.Show("서버가 실행되고 있지 않습니다!");
                return;
            }

            // 보낼 텍스트
            string tts = txt_say.Text.Trim();
            if (string.IsNullOrEmpty(tts))
            {
                MessageBox.Show("텍스트가 입력되지 않았습니다!");
                txt_say.Focus();
                return;
            }

            byte[] bDts = Encoding.UTF8.GetBytes("text" + id + '\x01' + tts);

            // 서버에 전송한다.
            mainSock.Send(bDts);

            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            AppendText(txt_chat, string.Format("{0}: {1}", id, tts));
            txt_say.Clear();
        }


        //그림판에 대한 메소드
        private void SetupVar()
        {
            i = 0;
            thick = 1;
            isSolid = true;
            hand = false;
            pen_pen = false;
            line = false;
            rect = false;
            circle = false;
            start = new Point(0, 0);
            finish = new Point(0, 0);

            isHold = false;
            current = new Point();
            pen = new Pen(Color.Black, 1);
            pencil = new Pen(Color.Black);
            pencil.SetLineCap(LineCap.Round, LineCap.Round, DashCap.Round);

            mylines = new MyLines[100];
            myrects = new MyRect[100];
            mycircles = new MyCircle[100];
            pens = new MyPen[3000];
            all_shapes = new All_Shapes[3000];

            line_color = Color.Black;
            fill_color = Color.Empty;
            painting = false;
            sb = new SolidBrush(Color.Black);
            wheel_line = 0;

            npen = 0;
            nline = 0;
            nrect = 0;
            ncircle = 0;
            nobject = 0;
            ratio = 1.0F;
            //dyna = 0;
            graphics = panel.CreateGraphics();

            panel.MouseWheel += new MouseEventHandler(panel_MouseWheel);
            SetupMine();
        }

        private void panel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (hand == true)
            {
                lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;

                if (lines > 0)
                {
                    ratio *= 0.9F;
                    if (ratio < 1) ratio = 1;
                    wheel_line--;
                    if (wheel_line <= 0)
                    {
                        wheel_line = 0;
                    }
                }
                else if (lines < 0)
                {
                    ratio *= 1.1F;
                    if (ratio > 100.0) ratio = 100.0;
                    wheel_line++;
                    if (wheel_line > 5)
                    {
                        wheel_line = 4;
                    }
                }

                for (i = 0; i < all_shapes.Length; i++)
                {
                    if (all_shapes[i].GetType() == new MyRect().GetType())
                    {
                        MyRect myrect = (MyRect)all_shapes[i];
                        myrect.setSize(lines, wheel_line);
                        AppendText(txt_chat, wheel_line.ToString());
                    }
                    else if (all_shapes[i].GetType() == new MyLines().GetType())
                    {
                        MyLines myline = (MyLines)all_shapes[i];
                        myline.setSize(lines, wheel_line);
                    }
                    else if (all_shapes[i].GetType() == new MyCircle().GetType())
                    {
                        MyCircle mycircle = (MyCircle)all_shapes[i];
                        mycircle.setSize(lines, wheel_line);
                        AppendText(txt_chat, mycircle.getThick().ToString());

                    }
                    else if (all_shapes[i].GetType() == new MyPen().GetType())
                    {
                        MyPen mypen = (MyPen)all_shapes[i];
                        mypen.setSize(lines, wheel_line);
                    }
                }

                panel.Invalidate(true);
            }
        }
        private void SetupMine()
        {
            for (i = 0; i < 100; i++)
            {
                myrects[i] = new MyRect();
                mylines[i] = new MyLines();
                mycircles[i] = new MyCircle();
            }
            for (i = 0; i < 3000; i++)
            {
                all_shapes[i] = new All_Shapes();
                pens[i] = new MyPen();
            }
        }
        private void Pencilbtn_Click(object sender, EventArgs e)
        {
            hand = false;
            pen_pen = true;
            line = false;
            rect = false;
            circle = false;

            this.handbtn.Checked = false;
            this.pencilbtn.Checked = true;
            this.linebtn.Checked = false;
            this.rectbtn.Checked = false;
            this.circlebtn.Checked = false;
        }
        private void Linebtn_Click(object sender, EventArgs e)
        {
            hand = false;
            pen_pen = false;
            line = true;
            rect = false;
            circle = false;

            this.handbtn.Checked = false;
            this.pencilbtn.Checked = false;
            this.linebtn.Checked = true;
            this.rectbtn.Checked = false;
            this.circlebtn.Checked = false;
        }

        private void Rectbtn_Click(object sender, EventArgs e)
        {
            hand = false;
            pen_pen = false;
            line = false;
            rect = true;
            circle = false;

            this.handbtn.Checked = false;
            this.pencilbtn.Checked = false;
            this.linebtn.Checked = false;
            this.rectbtn.Checked = true;
            this.circlebtn.Checked = false;
        }

        private void Circlebtn_Click(object sender, EventArgs e)
        {
            hand = false;
            pen_pen = false;
            line = false;
            rect = false;
            circle = true;

            this.handbtn.Checked = false;
            this.pencilbtn.Checked = false;
            this.linebtn.Checked = false;
            this.rectbtn.Checked = false;
            this.circlebtn.Checked = true;
        }

        private void Line1btn_Click(object sender, EventArgs e)
        {
            isSolid = false;
            thick = 1;
            this.line1btn.Checked = true;
            this.line2btn.Checked = false;
            this.line3btn.Checked = false;
            this.line4btn.Checked = false;
            this.line5btn.Checked = false;

        }

        private void Line2btn_Click(object sender, EventArgs e)
        {
            isSolid = true;
            thick = 1;
            this.line1btn.Checked = false;
            this.line2btn.Checked = true;
            this.line3btn.Checked = false;
            this.line4btn.Checked = false;
            this.line5btn.Checked = false;
        }

        private void Line3btn_Click(object sender, EventArgs e)
        {
            isSolid = true;
            thick = 3;
            this.line1btn.Checked = false;
            this.line2btn.Checked = false;
            this.line3btn.Checked = true;
            this.line4btn.Checked = false;
            this.line5btn.Checked = false;
        }

        private void Line4btn_Click(object sender, EventArgs e)
        {
            isSolid = true;
            thick = 5;
            this.line1btn.Checked = false;
            this.line2btn.Checked = false;
            this.line3btn.Checked = false;
            this.line4btn.Checked = true;
            this.line5btn.Checked = false;
        }

        private void Line5btn_Click(object sender, EventArgs e)
        {
            isSolid = true;
            thick = 7;
            this.line1btn.Checked = false;
            this.line2btn.Checked = false;
            this.line3btn.Checked = false;
            this.line4btn.Checked = false;
            this.line5btn.Checked = true;
        }

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            start.X = e.X;
            start.Y = e.Y;
            current = e.Location;
            if (hand == true)
            {
                isHold = true;
            }

        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if ((start.X == 0) && (start.Y == 0))
                return;

            finish.X = e.X;
            finish.Y = e.Y;

            if (line == true)
            {
                mylines[nline].setPoint(start, finish, thick, isSolid, line_color);
                all_shapes[nobject] = (All_Shapes)mylines[nline];
                panel.Invalidate(true);
            }
            if (rect == true)
            {
                myrects[nrect].setRect(start, finish, thick, isSolid, isFill, line_color, fill_color);
                all_shapes[nobject] = (All_Shapes)myrects[nrect];
                panel.Invalidate(true);
            }
            if (circle == true)
            {
                mycircles[ncircle].setRectC(start, finish, thick, isSolid, isFill, line_color, fill_color);
                all_shapes[nobject] = (All_Shapes)mycircles[ncircle];
                panel.Invalidate(true);
            }
            if (pen_pen == true)
            {
                if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                {
                    using (Graphics oGraphics = this.panel.CreateGraphics())
                    {
                        if (current != new Point(0, 0))
                        {
                            pen.Color = line_color;
                            pen.Width = thick;
                            oGraphics.DrawLine(pen, e.X, e.Y, current.X, current.Y);
                        }
                        oGraphics.FillEllipse(new SolidBrush(pen.Color), e.X - 6, e.Y - 6, 1, 1);
                        pens[npen].setPen(e.Location, current, thick, isSolid, line_color);
                        all_shapes[nobject] = (All_Shapes)pens[npen];
                        current = e.Location;
                        npen++;
                        nobject++;
                    }
                }
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {

                    stream.Position = 0;
                    bf.Serialize(stream, all_shapes[nobject - 1]);

                    byte[] array = stream.ToArray();

                    mainSock.Send(array);

                }
            }
            //if (hand == true)
            //{
            //    if ((e.Button & MouseButtons.Left) == MouseButtons.Left && isHold)
            //    {
            //        int x = e.X - start.X;
            //        int y = e.Y - start.Y;
            //        AppendText(txt_chat, string.Format(x + " " + y));
            //        for (int i = 0; i < all_shapes.Length; i++)
            //        {
            //            //all_shapes[i].(all_shapes[i].X + (int)Math.Round((double)(x) / 5));
            //            //if (all_shapes[i].getX() >= 0) all_shapes[i].setX(0);
            //            //if (Math.Abs(all_shapes[i].getX()) >= Math.Abs(all_shapes[i].getWidth() - panel.Width)) all_shapes[i].setX(-(all_shapes[i].getWidth() - panel.Width));
            //            //all_shapes[i].setY(all_shapes[i].getY() + (int)Math.Round((double)(e.Y - start.Y) / 5));
            //            //if (all_shapes[i].getY() >= 0) all_shapes[i].setY(0);
            //            //if (Math.Abs(all_shapes[i].getY()) >= Math.Abs(all_shapes[i].getHeight() - panel.Height)) all_shapes[i].setY(-(all_shapes[i].getHeight() - panel.Height));
            //            all_shapes[i].setX(x);
            //            all_shapes[i].setY(y);
            //            //all_shapes[i].setStart(new Point(x,))
            //            //all_shapes[i].setFinish(new Point(x/30, y/30));
            //            panel.Invalidate();
            //        }

            //   }

            panel.Invalidate();
        
    }
        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            for(i = 0; i<all_shapes.Length; i++)
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
                   
                    if (all_shapes[i].GetType() == new MyPen().GetType())
                    {
                        MyPen mypen = (MyPen)all_shapes[i];
                    
                    e.Graphics.DrawLine(pen, mypen.getStart(), mypen.getFinish());
                    e.Graphics.FillEllipse(new SolidBrush(pen.Color), mypen.getStart().X, mypen.getStart().Y, 1, 1);
                    }
                    else if(all_shapes[i].GetType() == new MyLines().GetType())
                    {
                    MyLines myline = (MyLines)all_shapes[i];
                   
                    e.Graphics.DrawLine(pen, all_shapes[i].getStart(), all_shapes[i].getFinish());
                    }
                 else if(all_shapes[i].GetType() == new MyCircle().GetType())
                        {
                        MyCircle mycircle = (MyCircle)all_shapes[i];
                    
                        e.Graphics.DrawEllipse(pen, mycircle.getRectC());
                        if (mycircle.getFill())
                        {
                            sb.Color = mycircle.getColor();
                            e.Graphics.FillEllipse(sb, mycircle.getRectC());
                        }
                    }else if(all_shapes[i].GetType() == new MyRect().GetType())
                    {
                        MyRect myrect = (MyRect)all_shapes[i];
                        
                        e.Graphics.DrawRectangle(pen, myrect.getRect());
                        if (myrect.getFill())
                        {
                            sb.Color = myrect.getColor();
                            e.Graphics.FillRectangle(sb, myrect.getRect());
                        }
                    }
                
            }
         
        }

        private void Panel_MouseUp(object sender, MouseEventArgs e)
        {
            // 소켓 통신 위치
            if (line == true)
            {
                nline++;
                nobject++;
            }
            if (rect == true)
            {
                nrect++;
                nobject++;

            }
            if (circle == true)
            {
                ncircle++;
                nobject++;
            }
            if( hand == true)
            {
                isHold = false;
            }

            start.X = 0;
            start.Y = 0;
            finish.X = 0;
            finish.Y = 0;
            if (hand != true)
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (MemoryStream stream = new MemoryStream())
                {
                    bf.Serialize(stream, all_shapes[nobject - 1]);
                    byte[] array = stream.ToArray();
                    mainSock.Send(array);
                }
            }
            panel.Update();
            pen.Width = thick;
            pen.DashStyle = DashStyle.Solid;

        }

        private void 채우기btn_Click(object sender, EventArgs e)
        {
            if (painting == false)
            {
                painting = true;
                isFill = true;
                this.채우기btn.Checked = true;
            }
            else
            {
                painting = false;
                isFill = false;
                this.채우기btn.Checked = false;
            }
        }

        private void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            if (!mainSock.IsBound)
            {
                MessageBox.Show("서버가 실행되고 있지 않습니다!");
                return;
            }

            byte[] buffer = Encoding.UTF8.GetBytes("exit");
            mainSock.Send(buffer);
            mainSock.Shutdown(SocketShutdown.Both);
            mainSock.Close();
            //mainSock.Dispose();
            //this.Close();
        }

        private void Handbtn_Click(object sender, EventArgs e)
        {
            pen_pen = false;
            line = false;
            rect = false;
            circle = false;
            hand = true;

            this.handbtn.Checked = true;
            this.pencilbtn.Checked = false;
            this.linebtn.Checked = false;
            this.rectbtn.Checked = false;
            this.circlebtn.Checked = false;
        }
    }
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
}
