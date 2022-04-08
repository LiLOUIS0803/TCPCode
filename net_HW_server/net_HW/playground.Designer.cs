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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ball1 = new System.Windows.Forms.PictureBox();
            this.score = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.server_state = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ball1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // ball1
            // 
            this.ball1.Image = ((System.Drawing.Image)(resources.GetObject("ball1.Image")));
            this.ball1.Location = new System.Drawing.Point(429, 189);
            this.ball1.Name = "ball1";
            this.ball1.Size = new System.Drawing.Size(34, 34);
            this.ball1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ball1.TabIndex = 0;
            this.ball1.TabStop = false;
            this.ball1.Visible = false;
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.BackColor = System.Drawing.SystemColors.HighlightText;
            this.score.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.score.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.score.Location = new System.Drawing.Point(1313, 7);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(85, 17);
            this.score.TabIndex = 2;
            this.score.Text = "Leader Board";
            this.score.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.score);
            this.panel1.Controls.Add(this.ball1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1415, 646);
            this.panel1.TabIndex = 3;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // server_state
            // 
            this.server_state.AutoSize = true;
            this.server_state.ForeColor = System.Drawing.SystemColors.Control;
            this.server_state.Location = new System.Drawing.Point(1419, 9);
            this.server_state.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.server_state.Name = "server_state";
            this.server_state.Size = new System.Drawing.Size(75, 15);
            this.server_state.TabIndex = 4;
            this.server_state.Text = " server close";
            // 
            // playground
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1496, 651);
            this.Controls.Add(this.server_state);
            this.Controls.Add(this.panel1);
            this.Name = "playground";
            this.Text = "server";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.playground_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ball1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ball1;
        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label server_state;
    }
}
