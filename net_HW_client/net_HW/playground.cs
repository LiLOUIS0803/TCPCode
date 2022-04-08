using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace net_HW
{
    public partial class playground : Form
    {
        bool connect = false;
        Socket client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        List<string> msg_box = new List<string>();
        List<PictureBox> ball_picture_box_list = new List<PictureBox>();
        List<PictureBox> bonus_picture_box_list = new List<PictureBox>();    
        float pre_size = 0, now_size = 0;
        string set_str = "", set_str_="";
        public playground()
        {
            InitializeComponent();
            connect_buttom.Enabled = true;
        }
        /*
        private void playground_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) state_label.Text="1";
            if (e.KeyCode == Keys.Left) ball1.Location = new Point(ball1.Location.X - stepX, ball1.Location.Y);
            if (e.KeyCode == Keys.Right) ball1.Location = new Point(ball1.Location.X + stepX, ball1.Location.Y);
            if (e.KeyCode == Keys.Up) ball1.Location = new Point(ball1.Location.X, ball1.Location.Y - stepY);
            if (e.KeyCode == Keys.Down) ball1.Location = new Point(ball1.Location.X, ball1.Location.Y + stepY);
        }
        */

        //讀取鍵盤
        private void playground_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Left)
            {                
                Send2server("Left");
            }
            if (e.KeyCode == Keys.Right)
            {
                Send2server("Right");
            }
            if (e.KeyCode == Keys.Up)
            {
                Send2server("Up");
            }
            if (e.KeyCode == Keys.Down)
            {
                Send2server("Down");
            }
        }            

        //連線server
        private void connect_buttom_Click(object sender, EventArgs e)
        {
            string get_ip = text_ip.Text, get_port = text_port.Text;            
            if(text_name.Text == "")
            {
                state_label.Text = "No name";
                return;
            }
                try
            {
                if (!connect)
                {
                    client_socket.Connect(get_ip, Int32.Parse(get_port));
                }
                state_label.Text = "Connected";
                text_name.Enabled = false;
                connect = true;
                connect_buttom.Enabled = false;
                Send2server("name");
                Thread receive_thread = new Thread(Receive_Msg);
                receive_thread.IsBackground = true;
                receive_thread.Start(client_socket);
            }
            catch (Exception ex)
            {
                msg_label.Text = ex.Message;
                text_name.Enabled = true;
            }
        }

        //顯示畫布
        private void set_ball(string str)
        {
            List<string> bonus_name_list = new List<string>(), player_name_list = new List<string>();
            string temp_str = "";
            int ball_size = 0, ball_posx = 0, ball_posy = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '|')
                {
                    string ball_name = "", ball_posx_ = "", ball_posy_ = "", ball_size_ = "", ball_visible_ = "";
                    bool ball_visible = true;
                    string[] Arr = temp_str.Split('_');                    
                    try
                    {
                        ball_name = Arr[0];
                        ball_posx_ = Arr[1];
                        ball_posy_ = Arr[2];
                        ball_size_ = Arr[3];
                        ball_visible_ = Arr[4];
                        ball_visible = true;
                        if (ball_visible_ == "0")
                        {
                            ball_visible = false;
                        }
                        ball_size = Int32.Parse(ball_size_);
                        ball_posx = Int32.Parse(ball_posx_);
                        ball_posy = Int32.Parse(ball_posy_);
                        //msg_label2.Text += "\n" + ball_posx + "\n" + ball_posy + "\n";
                        //ball_size = ball_size_.ToString();
                    }
                    catch (Exception e)
                    {

                    }

                    //bonus
                    if (ball_name != "")
                    {
                        if (ball_name.Contains("bonus"))
                        {
                            bonus_name_list.Add(ball_name);
                            bool check_name = false;
                            for (int j = 0; j < bonus_picture_box_list.Count; j++)
                            {
                                if (bonus_picture_box_list[j].Name == ball_name)
                                {
                                    check_name = true;
                                    bonus_picture_box_list[j].Visible = ball_visible;
                                }
                            }
                            if (!check_name)
                            {
                                PictureBox temp_bonus = new PictureBox();

                                temp_bonus.Name = ball_name;
                                temp_bonus.Image = Image.FromFile(@"skin\bonus.png");
                                temp_bonus.Location = new Point(ball_posx, ball_posy);
                                temp_bonus.SizeMode = PictureBoxSizeMode.AutoSize;
                                temp_bonus.BorderStyle = BorderStyle.None;
                                bonus_picture_box_list.Add(temp_bonus);
                                //panel1.Controls.Add(bonus_picture_box_list[bonus_picture_box_list.Count - 1]);
                                bonus_picture_box_list[bonus_picture_box_list.Count - 1].BringToFront();
                                bonus_picture_box_list[bonus_picture_box_list.Count - 1].BackColor = Color.Transparent;
                            }
                        }

                        //ball
                        else
                        {
                            player_name_list.Add(ball_name);
                            int ball_idx = -1;
                            bool check_name = false;
                            for (int j = 0; j < ball_picture_box_list.Count; j++)
                            {
                                if (ball_picture_box_list[j].Name == ball_name)
                                {
                                    check_name = true;
                                    ball_idx = j;
                                }
                            }

                            if (check_name && ball_idx != -1 && (ball_picture_box_list[ball_idx].Location.X != ball_posx || ball_picture_box_list[ball_idx].Location.Y != ball_posy))
                            {
                                ball_picture_box_list[ball_idx].Location = new Point(ball_posx, ball_posy);
                                ball_picture_box_list[ball_idx].Height = ball_size;
                                ball_picture_box_list[ball_idx].Width = ball_size;
                                ball_picture_box_list[ball_idx].Visible = ball_visible;
                                if (ball_name == text_name.Text)
                                {
                                    now_size = ball_size;
                                }
                            }
                            else if (!check_name)
                            {
                                PictureBox temp_picture = new PictureBox();
                                temp_picture.Name = ball_name;
                                temp_picture.Image = Image.FromFile(@"skin\circle.png");
                                if (ball_name == text_name.Text)
                                {
                                    temp_picture.Image = Image.FromFile(@"skin\player.png");
                                }
                                temp_picture.SizeMode = PictureBoxSizeMode.AutoSize;
                                temp_picture.SizeMode = PictureBoxSizeMode.Zoom;
                                temp_picture.Location = new Point(ball_posx, ball_posy);
                                temp_picture.Height = ball_size;
                                temp_picture.Width = ball_size;
                                temp_picture.Visible = ball_visible;
                                if(ball_name == text_name.Text)
                                {
                                    now_size = ball_size;
                                }
                                ball_picture_box_list.Add(temp_picture);
                                //panel1.Controls.Add(ball_picture_box_list[ball_picture_box_list.Count - 1]);
                                ball_picture_box_list[ball_picture_box_list.Count - 1].BringToFront();
                            }
                        }
                    }
                    temp_str = "";
                }
                else
                {
                    temp_str += str[i]; ;
                }                
            }

            //刪除不用的bonus
            List<PictureBox> delete_idx = new List<PictureBox>();
            for (int i = 0; i < bonus_picture_box_list.Count; i++)
            {
                bool check_name = false;
                for (int j = 0; j < bonus_name_list.Count; j++)
                {
                    if (bonus_name_list[j] == bonus_picture_box_list[i].Name)
                    {
                        check_name = true;
                    }
                }
                if (!check_name)
                {
                    bonus_picture_box_list[i].Visible = false;
                    delete_idx.Add(bonus_picture_box_list[i]);
                }
                else if (!bonus_picture_box_list[i].Visible)
                {
                    delete_idx.Add(bonus_picture_box_list[i]);
                }

            }

            for (int i = 0; i < delete_idx.Count; i++)
            {                
                bonus_picture_box_list.Remove(delete_idx[i]);
            }
            //刪除不用的player
            
            List<PictureBox> delete_player_idx = new List<PictureBox>();
            for(int i = 0; i < ball_picture_box_list.Count; i++)
            {                
                bool check_name = false;
                for(int j = 0; j < player_name_list.Count; j++)
                {
                    if(ball_picture_box_list[i].Name == player_name_list[j])
                    {
                        check_name = true;
                    }
                }
                if (!check_name)
                {                    
                    ball_picture_box_list[i].Visible = false;
                    delete_player_idx.Add(ball_picture_box_list[i]);
                }
            }
            for(int i=0;i< delete_player_idx.Count; i++)
            {
                ball_picture_box_list.Remove(delete_player_idx[i]);
            }
            if (pre_size != now_size)
            {

                if (pre_size != 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"music\short_punch1.wav");
                    player.Play();
                }
                pre_size = now_size;
            }
            display();
        }

        //接收訊息
        private void Receive_Msg(Object obj)
        {
            Socket client = obj as Socket;
            while (true)
            {                
                byte[] str_byte = new byte[1024];
                string str = "";
                try
                {
                    str = Encoding.Default.GetString(str_byte, 0, client.Receive(str_byte));
                    msg_label.Text = str;
                    if (str[0] == '#')
                    {
                        text_name.Enabled = true;
                        connect_buttom.Enabled = true;
                        state_label.Text = "name error";                        
                        break;
                    }
                    else if (str[0] == '@')
                    {
                        str = str.Remove(0, 1);                        
                        set_str = str;
                    }                    
                    //Send_Msg(str);
                }
                catch (Exception ex)
                {
                    msg_box.Add("error1");
                    text_name.Enabled = true;
                    break;
                }
            }
        }

        

        //傳送訊息
        private void Send2server(string msg)
        {
            //msg_label.Text = msg;
            if (!connect)
            {
                //msg_label.Text += "0";
                return;
            }
            try
            {
                if (msg == "name")
                {
                    client_socket.Send(Encoding.Default.GetBytes("0" + text_name.Text));
                }
                else if (msg == "Left")
                {
                    client_socket.Send(Encoding.Default.GetBytes("1" + text_name.Text + "_L"));
                }
                else if (msg == "Right")
                {
                    client_socket.Send(Encoding.Default.GetBytes("1" + text_name.Text + "_R"));
                }
                else if (msg == "Down")
                {
                    client_socket.Send(Encoding.Default.GetBytes("1" + text_name.Text + "_D"));
                }
                else if (msg == "Up")
                {
                    client_socket.Send(Encoding.Default.GetBytes("1" + text_name.Text + "_U"));
                }
            }
            catch {
                connect = false;
                text_name.Enabled = true;
                connect_buttom.Enabled = true;
                state_label.Text = "Unconnect";
            }
        }

        
        //更新score board
        private void update_leader_board()
        {
            score.Text = "Score Board\n";
            score.Height = 21;
            for (int i = 0; i < ball_picture_box_list.Count; i++)
            {
                score.Text += (ball_picture_box_list[i].Name + " " + (ball_picture_box_list[i].Height / 10).ToString() + "\n");
                score.Height += 21;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //更新score board
            if (ball_picture_box_list.Count > 0)
            {
                update_leader_board();
            }
        }

        //顯示
        private void display()
        {
            for (int i = 0; i < ball_picture_box_list.Count; i++)
            {
                panel1.Controls.Add(ball_picture_box_list[i]);
            }
            for (int i = 0; i < bonus_picture_box_list.Count; i++)
            {
                panel1.Controls.Add(bonus_picture_box_list[i]);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
            bonus_count.Text = ball_picture_box_list.Count.ToString();
            if (ball_picture_box_list.Count > 0)
                bonus_count.Text += ball_picture_box_list[0].Name + " " + ball_picture_box_list[0].Visible.ToString();*/
            if (set_str != set_str_)
            {
                set_str_ = set_str;
                set_ball(set_str);
                
            }
            //msg_label2.Text = pre_size.ToString() + " " + now_size.ToString();
            //msg_label.Text = set_str;
        }

    }
}
