namespace net_HW
{
    partial class playground
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(playground));
            this.score = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ball1 = new System.Windows.Forms.PictureBox();
            this.connect_buttom = new System.Windows.Forms.Button();
            this.text_name = new System.Windows.Forms.TextBox();
            this.text_port = new System.Windows.Forms.TextBox();
            this.text_ip = new System.Windows.Forms.TextBox();
            this.msg_label = new System.Windows.Forms.Label();
            this.ip_label = new System.Windows.Forms.Label();
            this.port_label = new System.Windows.Forms.Label();
            this.name_label = new System.Windows.Forms.Label();
            this.state_label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.msg_label2 = new System.Windows.Forms.Label();
            this.bonus_count = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ball1)).BeginInit();
            this.SuspendLayout();
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.BackColor = System.Drawing.SystemColors.HighlightText;
            this.score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.score.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.score.Location = new System.Drawing.Point(1313, 7);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(78, 17);
            this.score.TabIndex = 2;
            this.score.Text = "Score Board";
            this.score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ball1);
            this.panel1.Controls.Add(this.score);
            this.panel1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1415, 646);
            this.panel1.TabIndex = 3;
            // 
            // ball1
            // 
            this.ball1.Image = ((System.Drawing.Image)(resources.GetObject("ball1.Image")));
            this.ball1.Location = new System.Drawing.Point(689, 306);
            this.ball1.Name = "ball1";
            this.ball1.Size = new System.Drawing.Size(34, 34);
            this.ball1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ball1.TabIndex = 3;
            this.ball1.TabStop = false;
            this.ball1.Visible = false;
            // 
            // connect_buttom
            // 
            this.connect_buttom.Enabled = false;
            this.connect_buttom.ForeColor = System.Drawing.SystemColors.Info;
            this.connect_buttom.Location = new System.Drawing.Point(1420, 252);
            this.connect_buttom.Name = "connect_buttom";
            this.connect_buttom.Size = new System.Drawing.Size(75, 23);
            this.connect_buttom.TabIndex = 7;
            this.connect_buttom.Text = "Connect";
            this.connect_buttom.UseVisualStyleBackColor = true;
            this.connect_buttom.Click += new System.EventHandler(this.connect_buttom_Click);
            // 
            // text_name
            // 
            this.text_name.Location = new System.Drawing.Point(1421, 173);
            this.text_name.Name = "text_name";
            this.text_name.Size = new System.Drawing.Size(74, 23);
            this.text_name.TabIndex = 11;
            // 
            // text_port
            // 
            this.text_port.Location = new System.Drawing.Point(1420, 112);
            this.text_port.Name = "text_port";
            this.text_port.Size = new System.Drawing.Size(75, 23);
            this.text_port.TabIndex = 14;
            // 
            // text_ip
            // 
            this.text_ip.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.text_ip.Location = new System.Drawing.Point(1421, 43);
            this.text_ip.Name = "text_ip";
            this.text_ip.Size = new System.Drawing.Size(74, 23);
            this.text_ip.TabIndex = 15;
            // 
            // msg_label
            // 
            this.msg_label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msg_label.Location = new System.Drawing.Point(1420, 436);
            this.msg_label.Name = "msg_label";
            this.msg_label.Size = new System.Drawing.Size(66, 209);
            this.msg_label.TabIndex = 16;
            this.msg_label.Visible = false;
            // 
            // ip_label
            // 
            this.ip_label.AutoSize = true;
            this.ip_label.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ip_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ip_label.Location = new System.Drawing.Point(1421, 10);
            this.ip_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ip_label.Name = "ip_label";
            this.ip_label.Size = new System.Drawing.Size(17, 15);
            this.ip_label.TabIndex = 17;
            this.ip_label.Text = "IP";
            // 
            // port_label
            // 
            this.port_label.AutoSize = true;
            this.port_label.BackColor = System.Drawing.SystemColors.HighlightText;
            this.port_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.port_label.Location = new System.Drawing.Point(1420, 82);
            this.port_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.port_label.Name = "port_label";
            this.port_label.Size = new System.Drawing.Size(30, 15);
            this.port_label.TabIndex = 18;
            this.port_label.Text = "Port";
            // 
            // name_label
            // 
            this.name_label.AutoSize = true;
            this.name_label.BackColor = System.Drawing.SystemColors.HighlightText;
            this.name_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.name_label.Location = new System.Drawing.Point(1421, 155);
            this.name_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.name_label.Name = "name_label";
            this.name_label.Size = new System.Drawing.Size(42, 15);
            this.name_label.TabIndex = 19;
            this.name_label.Text = "Name";
            // 
            // state_label
            // 
            this.state_label.BackColor = System.Drawing.SystemColors.HighlightText;
            this.state_label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.state_label.Location = new System.Drawing.Point(1421, 210);
            this.state_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.state_label.Name = "state_label";
            this.state_label.Size = new System.Drawing.Size(74, 19);
            this.state_label.TabIndex = 20;
            this.state_label.Text = "Unconnected";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // msg_label2
            // 
            this.msg_label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msg_label2.Location = new System.Drawing.Point(1420, 317);
            this.msg_label2.Name = "msg_label2";
            this.msg_label2.Size = new System.Drawing.Size(66, 103);
            this.msg_label2.TabIndex = 21;
            this.msg_label2.Visible = false;
            // 
            // bonus_count
            // 
            this.bonus_count.AutoSize = true;
            this.bonus_count.Location = new System.Drawing.Point(1421, 292);
            this.bonus_count.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bonus_count.Name = "bonus_count";
            this.bonus_count.Size = new System.Drawing.Size(42, 15);
            this.bonus_count.TabIndex = 22;
            this.bonus_count.Text = "label1";
            this.bonus_count.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // playground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1496, 651);
            this.Controls.Add(this.bonus_count);
            this.Controls.Add(this.msg_label2);
            this.Controls.Add(this.state_label);
            this.Controls.Add(this.name_label);
            this.Controls.Add(this.port_label);
            this.Controls.Add(this.ip_label);
            this.Controls.Add(this.msg_label);
            this.Controls.Add(this.text_ip);
            this.Controls.Add(this.text_port);
            this.Controls.Add(this.text_name);
            this.Controls.Add(this.connect_buttom);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "playground";
            this.Text = "client";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playground_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ball1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button connect_buttom;
        private System.Windows.Forms.TextBox text_name;
        private System.Windows.Forms.TextBox text_port;
        private System.Windows.Forms.TextBox text_ip;
        private System.Windows.Forms.Label msg_label;
        private System.Windows.Forms.Label ip_label;
        private System.Windows.Forms.Label port_label;
        private System.Windows.Forms.Label name_label;
        private System.Windows.Forms.Label state_label;
        private System.Windows.Forms.PictureBox ball1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label msg_label2;
        private System.Windows.Forms.Label bonus_count;
        private System.Windows.Forms.Timer timer2;
    }
}
