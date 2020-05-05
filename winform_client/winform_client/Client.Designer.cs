namespace winform_client
{
    partial class Client
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client));
            this.txt_chat = new System.Windows.Forms.TextBox();
            this.txt_say = new System.Windows.Forms.TextBox();
            this.btn_say = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.handbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.pencilbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.linebtn = new System.Windows.Forms.ToolStripMenuItem();
            this.circlebtn = new System.Windows.Forms.ToolStripMenuItem();
            this.rectbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.line1btn = new System.Windows.Forms.ToolStripMenuItem();
            this.line2btn = new System.Windows.Forms.ToolStripMenuItem();
            this.line3btn = new System.Windows.Forms.ToolStripMenuItem();
            this.line4btn = new System.Windows.Forms.ToolStripMenuItem();
            this.line5btn = new System.Windows.Forms.ToolStripMenuItem();
            this.채우기btn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel = new winform_client.DoublePanel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_chat
            // 
            this.txt_chat.Location = new System.Drawing.Point(0, 432);
            this.txt_chat.Multiline = true;
            this.txt_chat.Name = "txt_chat";
            this.txt_chat.Size = new System.Drawing.Size(800, 131);
            this.txt_chat.TabIndex = 0;
            // 
            // txt_say
            // 
            this.txt_say.Location = new System.Drawing.Point(0, 569);
            this.txt_say.Name = "txt_say";
            this.txt_say.Size = new System.Drawing.Size(670, 25);
            this.txt_say.TabIndex = 1;
            // 
            // btn_say
            // 
            this.btn_say.Location = new System.Drawing.Point(676, 568);
            this.btn_say.Name = "btn_say";
            this.btn_say.Size = new System.Drawing.Size(124, 26);
            this.btn_say.TabIndex = 2;
            this.btn_say.Text = "Say";
            this.btn_say.UseVisualStyleBackColor = true;
            this.btn_say.Click += new System.EventHandler(this.Btn_say_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.채우기btn,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.handbtn,
            this.pencilbtn,
            this.linebtn,
            this.circlebtn,
            this.rectbtn});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // handbtn
            // 
            this.handbtn.Image = global::winform_client.Properties.Resources.손;
            this.handbtn.Name = "handbtn";
            this.handbtn.Size = new System.Drawing.Size(224, 26);
            this.handbtn.Text = "Hand";
            this.handbtn.Click += new System.EventHandler(this.Handbtn_Click);
            // 
            // pencilbtn
            // 
            this.pencilbtn.Image = global::winform_client.Properties.Resources.연필;
            this.pencilbtn.Name = "pencilbtn";
            this.pencilbtn.Size = new System.Drawing.Size(224, 26);
            this.pencilbtn.Text = "Pencil";
            this.pencilbtn.Click += new System.EventHandler(this.Pencilbtn_Click);
            // 
            // linebtn
            // 
            this.linebtn.Image = global::winform_client.Properties.Resources.직선;
            this.linebtn.Name = "linebtn";
            this.linebtn.Size = new System.Drawing.Size(224, 26);
            this.linebtn.Text = "Line";
            this.linebtn.Click += new System.EventHandler(this.Linebtn_Click);
            // 
            // circlebtn
            // 
            this.circlebtn.Image = global::winform_client.Properties.Resources.원;
            this.circlebtn.Name = "circlebtn";
            this.circlebtn.Size = new System.Drawing.Size(224, 26);
            this.circlebtn.Text = "Circle";
            this.circlebtn.Click += new System.EventHandler(this.Circlebtn_Click);
            // 
            // rectbtn
            // 
            this.rectbtn.Image = global::winform_client.Properties.Resources.사각형;
            this.rectbtn.Name = "rectbtn";
            this.rectbtn.Size = new System.Drawing.Size(224, 26);
            this.rectbtn.Text = "Rect";
            this.rectbtn.Click += new System.EventHandler(this.Rectbtn_Click);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.line1btn,
            this.line2btn,
            this.line3btn,
            this.line4btn,
            this.line5btn});
            this.toolStripDropDownButton2.Image = global::winform_client.Properties.Resources.line1Button;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton2";
            // 
            // line1btn
            // 
            this.line1btn.Image = global::winform_client.Properties.Resources.line1Button;
            this.line1btn.Name = "line1btn";
            this.line1btn.Size = new System.Drawing.Size(100, 26);
            this.line1btn.Text = "1";
            this.line1btn.Click += new System.EventHandler(this.Line1btn_Click);
            // 
            // line2btn
            // 
            this.line2btn.Image = global::winform_client.Properties.Resources.line2Button;
            this.line2btn.Name = "line2btn";
            this.line2btn.Size = new System.Drawing.Size(100, 26);
            this.line2btn.Text = "2";
            this.line2btn.Click += new System.EventHandler(this.Line2btn_Click);
            // 
            // line3btn
            // 
            this.line3btn.Image = global::winform_client.Properties.Resources.line3Button;
            this.line3btn.Name = "line3btn";
            this.line3btn.Size = new System.Drawing.Size(100, 26);
            this.line3btn.Text = "3";
            this.line3btn.Click += new System.EventHandler(this.Line3btn_Click);
            // 
            // line4btn
            // 
            this.line4btn.Image = global::winform_client.Properties.Resources.line4Button;
            this.line4btn.Name = "line4btn";
            this.line4btn.Size = new System.Drawing.Size(100, 26);
            this.line4btn.Text = "4";
            this.line4btn.Click += new System.EventHandler(this.Line4btn_Click);
            // 
            // line5btn
            // 
            this.line5btn.Image = global::winform_client.Properties.Resources.line5Button;
            this.line5btn.Name = "line5btn";
            this.line5btn.Size = new System.Drawing.Size(100, 26);
            this.line5btn.Text = "5";
            this.line5btn.Click += new System.EventHandler(this.Line5btn_Click);
            // 
            // 채우기btn
            // 
            this.채우기btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.채우기btn.Image = ((System.Drawing.Image)(resources.GetObject("채우기btn.Image")));
            this.채우기btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.채우기btn.Name = "채우기btn";
            this.채우기btn.Size = new System.Drawing.Size(58, 24);
            this.채우기btn.Text = "채우기";
            this.채우기btn.Click += new System.EventHandler(this.채우기btn_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::winform_client.Properties.Resources.꽉찬_사각형;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::winform_client.Properties.Resources.사각형;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "line1Button.JPG");
            this.imageList1.Images.SetKeyName(1, "line2Button.JPG");
            this.imageList1.Images.SetKeyName(2, "line3Button.JPG");
            this.imageList1.Images.SetKeyName(3, "line4Button.JPG");
            this.imageList1.Images.SetKeyName(4, "line5Button.JPG");
            this.imageList1.Images.SetKeyName(5, "꽉찬 사각형.jpg");
            this.imageList1.Images.SetKeyName(6, "꽉찬 원.jpg");
            this.imageList1.Images.SetKeyName(7, "사각형.jpg");
            this.imageList1.Images.SetKeyName(8, "손.png");
            this.imageList1.Images.SetKeyName(9, "연필.jpg");
            this.imageList1.Images.SetKeyName(10, "원.jpg");
            this.imageList1.Images.SetKeyName(11, "직선.jpg");
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 426);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Paint);
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseUp);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 602);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btn_say);
            this.Controls.Add(this.txt_say);
            this.Controls.Add(this.txt_chat);
            this.Controls.Add(this.panel);
            this.Name = "Client";
            this.Text = "세계그림판";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_FormClosing);
            this.Load += new System.EventHandler(this.Client_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_chat;
        private System.Windows.Forms.TextBox txt_say;
        private System.Windows.Forms.Button btn_say;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem handbtn;
        private System.Windows.Forms.ToolStripMenuItem pencilbtn;
        private System.Windows.Forms.ToolStripMenuItem linebtn;
        private System.Windows.Forms.ToolStripMenuItem circlebtn;
        private System.Windows.Forms.ToolStripMenuItem rectbtn;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripButton 채우기btn;
        private System.Windows.Forms.ToolStripMenuItem line1btn;
        private System.Windows.Forms.ToolStripMenuItem line2btn;
        private System.Windows.Forms.ToolStripMenuItem line3btn;
        private System.Windows.Forms.ToolStripMenuItem line4btn;
        private System.Windows.Forms.ToolStripMenuItem line5btn;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ImageList imageList1;
        private DoublePanel panel;
    }
}

