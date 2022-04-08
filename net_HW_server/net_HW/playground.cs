using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace net_HW
{
    public partial class playground : Form
    {
        int stepX = 10, stepY = 10, initial_size = 44, score_high = 21;
        static Socket server_socket;
        List<Socket> user_list = new List<Socket>();
        List<string> msg_box = new List<string>();
        List<PictureBox> ball_picture_box_list = new List<PictureBox>();
        List<PictureBox> bonus_picture_box_list = new List<PictureBox>();
        
        int bonus_name = 0;
        private static int server_port = 5566;
        public playground()
        {
            InitializeComponent();

            //伺服器設定
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            server_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server_socket.Bind(new IPEndPoint(ip, server_port));
            server_socket.Listen(10);
            server_state.Text = "Server Open";

            //開啟客戶端連線
            Thread Listen_thread = new Thread(Listen_Client);
            Listen_thread.IsBackground = true;
            Listen_thread.Start();
        }
        private void playground_Load(object sender, EventArgs e)
        {

        }

        //等待連線
        private void Listen_Client()
        {
            while (true)
            {
                //客戶端連線
                Socket client_socket = server_socket.Accept();                
                //msg_box.Add("get");

                //開啟接收訊息
                Thread Receive_thread = new Thread(Receive_Msg);
                Receive_thread.IsBackground = true;
                Receive_thread.Start(client_socket);

            }
        }

        //接收訊息
        private void Receive_Msg(Object obj)
        {
            Socket client = obj as Socket;            
            while (true) {                
                byte[] str_byte = new byte[1024];
                string str = "";
                try
                {
                    str = Encoding.Default.GetString(str_byte, 0, client.Receive(str_byte));
                    if(str[0] == '0')
                    {
                        string str_ = str.Remove(0, 1);
                        bool check_name = false;
                        for(int i = 0; i < ball_picture_box_list.Count; i++)
                        {
                            if(str_ == ball_picture_box_list[i].Name)
                            {                                
                                client.Send(Encoding.Default.GetBytes("###"));
                                check_name = true;                                
                                break;
                            }
                        }                        
                        //建立ball
                        Generate_ball(str);
                        user_list.Add(client);

                    }
                    if(str[0] == '1')
                    {
                        //取得移動指令
                        get_move_ball(str);
                    }    
                    if (str != "")
                    {
                        msg_box.Add(str);
                    }
                    //msg_label.Text = str;
                    //Send_Msg(str);
                }
                catch (Exception ex)
                {
                    //刪除user
                    int ball_idx = -1;
                    for(int i = 0; i < user_list.Count; i++)
                    {
                        if(user_list[i] == client)
                        {
                            ball_idx = i;
                            break;
                        }
                    }
                    
                    ball_picture_box_list[ball_idx].Visible = false;
                    ball_picture_box_list.RemoveAt(ball_idx);
                    //Thread.CurrentThread.Abort();
                    msg_box.Add("delete");
                    break;
                }
            }
            try
            {
                user_list.Remove(client);
                client.Dispose();
                client.Close();
                
            }
            catch(Exception ex)
            {

            }
            return;
        }

        //生成player
        private void Generate_ball(string str)
        {
            string ball_name = "";
            for(int i = 1; i < str.Length; i++)
            {
                ball_name += str[i];
            }
            bool check_ball = false;
            for(int i = 0; i < ball_picture_box_list.Count; i++)
            {
                if(ball_name == ball_picture_box_list[i].Name)
                {
                    check_ball = true;
                }
            }
            if (!check_ball)
            {
                PictureBox temp_picture = new PictureBox();
                Random SetRandomX = new Random(), SetRandomY = new Random();
                int LocationRandomX = SetRandomX.Next(0, panel1.Width), LocationRandomY = SetRandomY.Next(0, panel1.Height);
                temp_picture.Name = ball_name;
                temp_picture.Image = Image.FromFile(@"skin\circle.png");
                temp_picture.SizeMode = PictureBoxSizeMode.AutoSize;
                temp_picture.SizeMode = PictureBoxSizeMode.Zoom;
                temp_picture.Location = new Point(LocationRandomX, LocationRandomY);
                temp_picture.Width = initial_size;
                temp_picture.Height = initial_size;
                msg_box.Add("generate " + ball_name);
                
                ball_picture_box_list.Add(temp_picture);
                
            }
            return;
        }

        //取得移動球的指令
        private void get_move_ball(string str)
        {
            bool check_active = false;
            string ball_name = "", active_name = "";
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] == '_')
                {
                    check_active = true;
                }
                else if (!check_active)
                {
                    ball_name += str[i];
                }
                else if (check_active)
                {
                    active_name += str[i];
                }
            }
            int active_idx = -1;

            for (int i=0; i < ball_picture_box_list.Count; i++)
            {
                if(ball_picture_box_list[i].Name == ball_name)
                {
                    active_idx = i;
                }
            }
            if(active_idx > -1)
            {
                move_ball(ball_name, active_name, active_idx);
            }
            
            return;
        }

        //移動球
        private void move_ball(string active_ball, string active_move, int active_idx)
        {
            if (active_move == "L")
            {
                ball_picture_box_list[active_idx].Location = new Point(ball_picture_box_list[active_idx].Location.X - stepX, ball_picture_box_list[active_idx].Location.Y);
            }
            if (active_move == "R")
            {
                ball_picture_box_list[active_idx].Location = new Point(ball_picture_box_list[active_idx].Location.X + stepX, ball_picture_box_list[active_idx].Location.Y);
            }
            if (active_move == "U")
            {
                ball_picture_box_list[active_idx].Location = new Point(ball_picture_box_list[active_idx].Location.X, ball_picture_box_list[active_idx].Location.Y - stepY);
            }
            if (active_move == "D")
            {
                ball_picture_box_list[active_idx].Location = new Point(ball_picture_box_list[active_idx].Location.X, ball_picture_box_list[active_idx].Location.Y + stepY);
            }            
        }

        //碰撞檢測
        private void collision()
        {            
            //palyer and bonus
            for (int i = 0; i < ball_picture_box_list.Count; i++)
            {
                if (ball_picture_box_list[i].Visible == true)
                {
                    int x1 = ball_picture_box_list[i].Location.X + ball_picture_box_list[i].Width / 2, y1 = ball_picture_box_list[i].Location.Y + ball_picture_box_list[i].Height / 2, r1 = ball_picture_box_list[i].Height / 2;
                    for (int j = 0; j < bonus_picture_box_list.Count; j++)
                    {
                        if (bonus_picture_box_list[j].Visible == true)
                        {
                            int x2 = bonus_picture_box_list[j].Location.X + bonus_picture_box_list[j].Width / 2, y2 = bonus_picture_box_list[j].Location.Y + bonus_picture_box_list[j].Height / 2, r2 = bonus_picture_box_list[j].Height / 2;
                            if (Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) <= r1 + r2)
                            {
                                ball_picture_box_list[i].Height += 10;
                                ball_picture_box_list[i].Width += 10;
                                bonus_picture_box_list[j].Visible = false;                                
                            }
                        }
                    }
                }
            }

            //player and player
            for (int i = 0; i < ball_picture_box_list.Count; i++)
            {
                if (ball_picture_box_list[i].Visible == true)
                {
                    int x1 = ball_picture_box_list[i].Location.X + ball_picture_box_list[i].Width / 2, y1 = ball_picture_box_list[i].Location.Y + ball_picture_box_list[i].Height / 2, r1 = ball_picture_box_list[i].Height / 2;
                    for (int j = 0; j < ball_picture_box_list.Count; j++)
                    {
                        if (i != j && ball_picture_box_list[j].Visible == true)
                        {
                            int x2 = ball_picture_box_list[j].Location.X + ball_picture_box_list[j].Width / 2, y2 = ball_picture_box_list[j].Location.Y + ball_picture_box_list[j].Height / 2, r2 = ball_picture_box_list[j].Height / 2;
                            if (Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) <= r1 + r2)
                            {
                                if (r1 >= r2)
                                {                                   
                                    ball_picture_box_list[i].Width += ball_picture_box_list[j].Width / 2;
                                    ball_picture_box_list[i].Height += ball_picture_box_list[j].Height / 2;
                                    ball_picture_box_list[j].Height = initial_size;
                                    ball_picture_box_list[j].Width = initial_size;
                                    PictureBox temp_picture = new PictureBox();
                                    Random SetRandomX = new Random(), SetRandomY = new Random();
                                    int LocationRandomX = SetRandomX.Next(0, panel1.Width), LocationRandomY = SetRandomY.Next(0, panel1.Height);
                                    ball_picture_box_list[j].Location = new Point(LocationRandomX, LocationRandomY);
                                    
                                }
                                if (r1 < r2)
                                {                                    
                                    ball_picture_box_list[j].Width += ball_picture_box_list[i].Width / 2;
                                    ball_picture_box_list[j].Height += ball_picture_box_list[i].Height / 2;
                                    ball_picture_box_list[i].Width = initial_size;
                                    ball_picture_box_list[i].Height = initial_size;
                                    PictureBox temp_picture = new PictureBox();
                                    Random SetRandomX = new Random(), SetRandomY = new Random();
                                    int LocationRandomX = SetRandomX.Next(0, panel1.Width), LocationRandomY = SetRandomY.Next(0, panel1.Height);
                                    ball_picture_box_list[i].Location = new Point(LocationRandomX, LocationRandomY);
                                }
                            }
                        }
                    }
                }
            }
        }

        //更新leader board
        private void update_leader_board()
        {
            score.Text = "Leader Board\n";
            score.Height = score_high;
            for(int i = 0; i < ball_picture_box_list.Count; i++)
            {
                score.Text += (ball_picture_box_list[i].Name + " " + (ball_picture_box_list[i].Height / 10).ToString() + "\n");
                score.Height += score_high;
            }
        }

        //傳送所有物件的訊息
        private void Send_Ball_pos()
        {
            for(int i = 0; i < user_list.Count; i++)
            {
                string str = "@";
                //player
                for(int j = 0; j < ball_picture_box_list.Count; j++)
                {
                    string visible_ = "0";
                    if (ball_picture_box_list[j].Visible)
                    {
                        visible_ = "1";
                    }
                        
                    str += ball_picture_box_list[j].Name + "_" + ball_picture_box_list[j].Location.X + "_" + ball_picture_box_list[j].Location.Y + "_" + ball_picture_box_list[j].Height + "_" + visible_  + "|";
                }
                
                //bonus
                for(int j = 0; j < bonus_picture_box_list.Count; j++)
                {
                    string visible_ = "0";
                    if (bonus_picture_box_list[j].Visible)
                    {
                        visible_ = "1";
                    }
                        
                    str += bonus_picture_box_list[j].Name + "_" + bonus_picture_box_list[j].Location.X + "_" + bonus_picture_box_list[j].Location.Y + "_" + bonus_picture_box_list[j].Height + "_" + visible_ + "|";
                }
                try
                {
                    user_list[i].Send(Encoding.Default.GetBytes(str));
                }
                catch (Exception ex)
                {

                }
            }
        }
        
        

        //刪除不需要的物件
        private void delete_ball()
        {
            List<PictureBox> bonus_delete_idx = new List<PictureBox>();
            for(int i = 0; i < bonus_picture_box_list.Count; i++)
            {
                if (!bonus_picture_box_list[i].Visible)
                {
                    bonus_delete_idx.Add(bonus_picture_box_list[i]);
                }
            }
            for(int i = 0; i < bonus_delete_idx.Count; i++)
            {
                
                bonus_picture_box_list.Remove(bonus_delete_idx[i]);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //更新leader board
            
            update_leader_board();
            
            //隨機生成bonus
            Random SetRandom = new Random();
            int IntRandom = SetRandom.Next(0, 10);
            if (IntRandom > 5 && bonus_picture_box_list.Count <= 5)
            {
                for (int i = 0; i < IntRandom; i++)
                {
                    Random SetRandomX = new Random(), SetRandomY = new Random();
                    int LocationRandomX = SetRandomX.Next(0, panel1.Width), LocationRandomY = SetRandomY.Next(0, panel1.Height);
                    PictureBox temp_bonus = new PictureBox();                    
                    temp_bonus.Name = "bonus" + bonus_name.ToString();
                    temp_bonus.Image = Image.FromFile(@"skin\bonus.png");
                    temp_bonus.Location = new Point(LocationRandomX, LocationRandomY);
                    temp_bonus.SizeMode = PictureBoxSizeMode.AutoSize;
                    temp_bonus.BorderStyle = BorderStyle.None;
                    bonus_picture_box_list.Add(temp_bonus);
                    panel1.Controls.Add(bonus_picture_box_list[bonus_picture_box_list.Count - 1]);
                    bonus_picture_box_list[bonus_picture_box_list.Count - 1].BringToFront();
                    bonus_picture_box_list[bonus_picture_box_list.Count - 1].BackColor = Color.Transparent;
                    bonus_name++;
                }
            }
        }



        private void timer1_Tick_1(object sender, EventArgs e)
        {
            /*
            ball_count_label.Text = (ball_picture_box_list.Count).ToString();
            //msg_label.Text = "";
            if (box_count != msg_box.Count)
            {   
                box_count = msg_box.Count;
                for (int i = 0; i < msg_box.Count; i++)
                {
                    msg_label.Text += (msg_box[i] + "\n");
                }
            }*/

            //生成球
            
            for(int i=0; i < ball_picture_box_list.Count; i++)
            {
                panel1.Controls.Add(ball_picture_box_list[i]);
                ball_picture_box_list[i].BringToFront();
            }
            
            

            
            //移動球and判斷碰撞
            if (ball_picture_box_list.Count > 0)
            {                
                collision();
            }

            //傳送球的位置
            if (ball_picture_box_list.Count>0 && user_list.Count > 0)
            {
                Send_Ball_pos();
                delete_ball();
            }
        }        
    }
}
