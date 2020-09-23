using Photon.Realtime;
using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using TheBotUI.Core;
#if NET472
using System.Diagnostics;
#endif

namespace TheBotUI {

    public partial class Form1 : Form {
        public Bot selectedBot;

        public Form1() {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void Button2_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Button3_Click(object sender, EventArgs e) {
            this.WindowState = FormWindowState.Minimized;
        }

        private bool _dragging = false;
        private Point _offset;
        private Point _start_point = new Point(0, 0);

        private void panel2_MouseMove(object sender, MouseEventArgs e) {
            if (_dragging) {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - this._start_point.X, p.Y - this._start_point.Y);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e) {
            _dragging = false;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e) {
            _dragging = true;
            _start_point = new Point(e.X, e.Y);
        }

        private void button5_MouseDown(object sender, MouseEventArgs e) {
            passwordTextBox.PasswordChar = '\0';
        }

        private void button5_MouseUp(object sender, MouseEventArgs e) {
            passwordTextBox.PasswordChar = '*';
        }

        private void Button6_Click(object sender, EventArgs e) {
            new Thread(() => {
                Bot bot = new Bot(this.usernameTextBox.Text, this.passwordTextBox.Text);
                if (bot != null) {
                    if (bot.APIClient != null) {
                        Invoke(new MethodInvoker(() => {
                            ListViewItem item = new ListViewItem(bot.APIClient.Variables.UserSelfRES.displayName);
                            item.Tag = bot;
                            botInstancesList.Items.Add(item);
                            usernameTextBox.Clear();
                            passwordTextBox.Clear();
                        }));
                    }
                    else {
                        MessageBox.Show("API failed to initialize", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else {
                    MessageBox.Show("Bot failed to initialize", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }).Start();
        }

        private void listView1_itemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (e.Item.Tag != null) {
                selectedBot = (Bot)e.Item.Tag;
                new Thread(() => {
                    while (true) {
                        Invoke(new MethodInvoker(() => {
                            connectionStatusVarLabel.Text = selectedBot.PhotonClient.IsConnectedAndReady ? "Connected" : "Not connected";
                            pingVarLabel.Text = selectedBot.PhotonClient.LoadBalancingPeer.RoundTripTime.ToString();
                            inRoomVarLabel.Text = selectedBot.PhotonClient.InRoom ? "Yes" : "No";
                            playersVarLabel.Text = selectedBot.PhotonClient.CurrentRoom != null && selectedBot.PhotonClient.CurrentRoom.PlayerCount > 0 ? selectedBot.PhotonClient.CurrentRoom.PlayerCount.ToString() : "N/A";
                        }));
                        Thread.Sleep(1000);
                    }
                }).Start();
                new Thread(() => {
                    while (true) {
                        if (selectedBot.PhotonClient.InRoom) {
                            if (selectedBot.PhotonClient.CurrentRoom.Players != null) {
                                if (selectedBot.PhotonClient.CurrentRoom.Players.Count > 0) {
                                    Invoke(new MethodInvoker(() => { playerList.Items.Clear(); }));
                                    List<ListViewItem> players = new List<ListViewItem>();
                                    foreach (var player in selectedBot.PhotonClient.CurrentRoom.Players.Values) {
                                        ListViewItem p = new ListViewItem(player.NickName);
                                        p.Tag = player;
                                        p.SubItems.Add(player.ActorNumber.ToString());
                                        players.Add(p);
                                    }
                                    Invoke(new MethodInvoker(() => { playerList.Items.AddRange(players.ToArray()); }));
                                }
                            }
                        }
                        Thread.Sleep(2500);
                    }
                }).Start();
                new Thread(() => {
                    while (true) {
                        if (selectedBot.PhotonClient.logs.Count > 0 || selectedBot.PhotonClient.eventLogs.Count > 0) {
                            Invoke(new MethodInvoker(() => { logsList.Items.Clear(); }));
                            List<ListViewItem> logs = new List<ListViewItem>(225);
                            if (photonLogsRadioButton.Checked)
                                foreach (string log in selectedBot.PhotonClient.logs) {
                                    ListViewItem l = new ListViewItem(log);
                                    logs.Add(l);
                                }
                            if (eventLogsRadioButton.Checked)
                                foreach (string log in selectedBot.PhotonClient.eventLogs) {
                                    ListViewItem l = new ListViewItem(log);
                                    logs.Add(l);
                                }
                            Invoke(new MethodInvoker(() => { logsList.Items.AddRange(logs.ToArray()); }));
                            Thread.Sleep(5000);
                        }
                    }    
                }).Start();
            }
        }

        private void Button7_Click(object sender, EventArgs e) {
            string[] authdata = File.ReadAllLines("auth.txt");
            foreach(string login in authdata) {
                string[] userpass = login.Split(new char[] { ':' }, 2);
                new Thread(() => {
                    Bot bot = new Bot(userpass[0], userpass[1]);
                    if (bot != null) {
                        if (bot.APIClient != null) {
                            Invoke(new MethodInvoker(() => {
                                ListViewItem item = new ListViewItem(bot.APIClient.Variables.UserSelfRES.displayName);
                                item.Tag = bot;
                                botInstancesList.Items.Add(item);
                            }));
                        }
                        else {
                            MessageBox.Show("API failed to initialize", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else {
                        MessageBox.Show("Bot failed to initialize", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }).Start();
            }
        }

        private void JoinRoomButton_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(worldAInstanceIDTextBox.Text) || !worldAInstanceIDTextBox.Text.Contains("wrld")) {
                worldAInstanceIDTextBox.Text = "Incorrect format or empty!";
            }
            else {
                EnterRoomParams enterRoomParams = new EnterRoomParams() {
                    RoomName = worldAInstanceIDTextBox.Text,
                    CreateIfNotExists = true,
                    Lobby = new TypedLobby("", LobbyType.Default),
                    PlayerProperties = selectedBot.PhotonClient.LocalPlayer.CustomProperties
                };
                selectedBot.PhotonClient.OpJoinRoom(enterRoomParams);
                selectedBot.CachedRoomID = worldAInstanceIDTextBox.Text;
            }
        }

        private void LeaveRoomButton_Click(object sender, EventArgs e) {
            if (selectedBot.PhotonClient.InRoom)
                selectedBot.PhotonClient.OpLeaveRoom(false);
            else
                MessageBox.Show("Can't leave room when not in a room!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void JoinLastRoomButton_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(selectedBot.CachedRoomID)) {
                EnterRoomParams enterRoomParams = new EnterRoomParams() {
                    RoomName = selectedBot.CachedRoomID,
                    CreateIfNotExists = true,
                    Lobby = new TypedLobby("", LobbyType.Default),
                    PlayerProperties = selectedBot.PhotonClient.LocalPlayer.CustomProperties
                };
                selectedBot.PhotonClient.OpJoinRoom(enterRoomParams);
            }
            else {
                MessageBox.Show("Failed to rejoin last room!\nCachedRoomID was empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InstantiateButton_Click(object sender, EventArgs e) {
            if (selectedBot.PhotonClient.InRoom) {
                selectedBot.PhotonClient.InstantiateSelf();
            }
        }

        private void InstantiateInvisButton_Click(object sender, EventArgs e) {
            if (selectedBot.PhotonClient.InRoom) {
                selectedBot.PhotonClient.InstantiateSelfInvis();
            }
        }
    }
}