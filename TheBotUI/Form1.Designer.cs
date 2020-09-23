using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using TheBotUI.CustomComponents;

namespace TheBotUI {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.maximizeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.settingsButton = new System.Windows.Forms.Button();
            this.botInstancesLabel = new System.Windows.Forms.Label();
            this.playerlistLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.logsLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordVisibilityButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginViaTXTButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.loginToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.connectionStatusVarLabel = new System.Windows.Forms.Label();
            this.statsLabel = new System.Windows.Forms.Label();
            this.pingVarLabel = new System.Windows.Forms.Label();
            this.pingLabel = new System.Windows.Forms.Label();
            this.inRoomVarLabel = new System.Windows.Forms.Label();
            this.inRoomLabel = new System.Windows.Forms.Label();
            this.playersVarLabel = new System.Windows.Forms.Label();
            this.playersLabel = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.roomsLabel = new System.Windows.Forms.Label();
            this.worldAInstanceIDLabel = new System.Windows.Forms.Label();
            this.worldAInstanceIDTextBox = new System.Windows.Forms.TextBox();
            this.joinRoomButton = new System.Windows.Forms.Button();
            this.leaveRoomButton = new System.Windows.Forms.Button();
            this.joinLastRoomButton = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.inRoomActions = new System.Windows.Forms.Label();
            this.instantiateButton = new System.Windows.Forms.Button();
            this.instantiateInvisButton = new System.Windows.Forms.Button();
            this.eventLogsRadioButton = new System.Windows.Forms.RadioButton();
            this.photonLogsRadioButton = new System.Windows.Forms.RadioButton();
            this.logsList = new TheBotUI.CustomComponents.CustomListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playerList = new TheBotUI.CustomComponents.CustomListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.botInstancesList = new TheBotUI.CustomComponents.CustomListView();
            this.botInstances = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.minimizeButton);
            this.panel1.Controls.Add(this.maximizeButton);
            this.panel1.Controls.Add(this.exitButton);
            this.panel1.Location = new System.Drawing.Point(1154, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(126, 32);
            this.panel1.TabIndex = 0;
            // 
            // minimizeButton
            // 
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Image = global::TheBotUI.Properties.Resources.minimize;
            this.minimizeButton.Location = new System.Drawing.Point(0, 0);
            this.minimizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(42, 32);
            this.minimizeButton.TabIndex = 3;
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.Button3_Click);
            // 
            // maximizeButton
            // 
            this.maximizeButton.FlatAppearance.BorderSize = 0;
            this.maximizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.maximizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maximizeButton.ForeColor = System.Drawing.Color.White;
            this.maximizeButton.Image = global::TheBotUI.Properties.Resources.maximize;
            this.maximizeButton.Location = new System.Drawing.Point(42, 0);
            this.maximizeButton.Margin = new System.Windows.Forms.Padding(0);
            this.maximizeButton.Name = "maximizeButton";
            this.maximizeButton.Size = new System.Drawing.Size(42, 32);
            this.maximizeButton.TabIndex = 2;
            this.maximizeButton.UseVisualStyleBackColor = true;
            this.maximizeButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // exitButton
            // 
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.White;
            this.exitButton.Image = global::TheBotUI.Properties.Resources.close;
            this.exitButton.Location = new System.Drawing.Point(84, 0);
            this.exitButton.Margin = new System.Windows.Forms.Padding(0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(42, 32);
            this.exitButton.TabIndex = 1;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.settingsButton);
            this.panel2.Controls.Add(this.botInstancesLabel);
            this.panel2.Controls.Add(this.playerlistLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1280, 64);
            this.panel2.TabIndex = 2;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // settingsButton
            // 
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.ForeColor = System.Drawing.Color.White;
            this.settingsButton.Image = global::TheBotUI.Properties.Resources.settings;
            this.settingsButton.Location = new System.Drawing.Point(0, 0);
            this.settingsButton.Margin = new System.Windows.Forms.Padding(0);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(42, 32);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.UseVisualStyleBackColor = true;
            // 
            // botInstancesLabel
            // 
            this.botInstancesLabel.AutoSize = true;
            this.botInstancesLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botInstancesLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.botInstancesLabel.Location = new System.Drawing.Point(12, 42);
            this.botInstancesLabel.Name = "botInstancesLabel";
            this.botInstancesLabel.Size = new System.Drawing.Size(137, 22);
            this.botInstancesLabel.TabIndex = 1;
            this.botInstancesLabel.Text = "Bot Instances";
            // 
            // playerlistLabel
            // 
            this.playerlistLabel.AutoSize = true;
            this.playerlistLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerlistLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playerlistLabel.Location = new System.Drawing.Point(224, 42);
            this.playerlistLabel.Name = "playerlistLabel";
            this.playerlistLabel.Size = new System.Drawing.Size(96, 22);
            this.playerlistLabel.TabIndex = 0;
            this.playerlistLabel.Text = "Playerlist";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel4.Location = new System.Drawing.Point(434, 38);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(4, 676);
            this.panel4.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel8.Location = new System.Drawing.Point(448, 151);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(825, 2);
            this.panel8.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel3.Location = new System.Drawing.Point(214, 37);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(4, 677);
            this.panel3.TabIndex = 3;
            // 
            // logsLabel
            // 
            this.logsLabel.AutoSize = true;
            this.logsLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logsLabel.Location = new System.Drawing.Point(444, 563);
            this.logsLabel.Name = "logsLabel";
            this.logsLabel.Size = new System.Drawing.Size(57, 22);
            this.logsLabel.TabIndex = 2;
            this.logsLabel.Text = "Logs";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel5.Location = new System.Drawing.Point(437, 556);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(843, 4);
            this.panel5.TabIndex = 5;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.usernameTextBox.Location = new System.Drawing.Point(547, 69);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(150, 26);
            this.usernameTextBox.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel6.Location = new System.Drawing.Point(8, 36);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1270, 4);
            this.panel6.TabIndex = 6;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.usernameLabel.Location = new System.Drawing.Point(444, 70);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(97, 22);
            this.usernameLabel.TabIndex = 10;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.passwordLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.passwordLabel.Location = new System.Drawing.Point(714, 70);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(94, 22);
            this.passwordLabel.TabIndex = 12;
            this.passwordLabel.Text = "Password";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.passwordTextBox.Location = new System.Drawing.Point(814, 69);
            this.passwordTextBox.MaxLength = 32;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(150, 26);
            this.passwordTextBox.TabIndex = 11;
            // 
            // passwordVisibilityButton
            // 
            this.passwordVisibilityButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.passwordVisibilityButton.FlatAppearance.BorderSize = 0;
            this.passwordVisibilityButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.passwordVisibilityButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passwordVisibilityButton.Image = global::TheBotUI.Properties.Resources.viewable;
            this.passwordVisibilityButton.Location = new System.Drawing.Point(967, 67);
            this.passwordVisibilityButton.Margin = new System.Windows.Forms.Padding(0);
            this.passwordVisibilityButton.Name = "passwordVisibilityButton";
            this.passwordVisibilityButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.passwordVisibilityButton.Size = new System.Drawing.Size(32, 30);
            this.passwordVisibilityButton.TabIndex = 13;
            this.passwordVisibilityButton.UseVisualStyleBackColor = false;
            this.passwordVisibilityButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button5_MouseDown);
            this.passwordVisibilityButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button5_MouseUp);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.loginButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginButton.Location = new System.Drawing.Point(1018, 70);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(63, 26);
            this.loginButton.TabIndex = 14;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.Button6_Click);
            // 
            // loginViaTXTButton
            // 
            this.loginViaTXTButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.loginViaTXTButton.FlatAppearance.BorderSize = 0;
            this.loginViaTXTButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.loginViaTXTButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginViaTXTButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.loginViaTXTButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginViaTXTButton.Location = new System.Drawing.Point(1087, 70);
            this.loginViaTXTButton.Name = "loginViaTXTButton";
            this.loginViaTXTButton.Size = new System.Drawing.Size(167, 26);
            this.loginViaTXTButton.TabIndex = 15;
            this.loginViaTXTButton.Text = "Login via auth.txt";
            this.loginViaTXTButton.UseVisualStyleBackColor = false;
            this.loginViaTXTButton.Click += new System.EventHandler(this.Button7_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Arial", 12F);
            this.infoLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.infoLabel.Location = new System.Drawing.Point(1258, 74);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(17, 18);
            this.infoLabel.TabIndex = 16;
            this.infoLabel.Text = "?";
            this.loginToolTip.SetToolTip(this.infoLabel, "Leave Username and Password empty, goes through each line in auth.txt\nand will ma" +
        "ke a new instance. Separate Username and Password with \':\'");
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.panel7.Location = new System.Drawing.Point(437, 120);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(843, 4);
            this.panel7.TabIndex = 6;
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.connectionStatusLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectionStatusLabel.Location = new System.Drawing.Point(446, 155);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(169, 22);
            this.connectionStatusLabel.TabIndex = 17;
            this.connectionStatusLabel.Text = "Connection Status:";
            // 
            // connectionStatusVarLabel
            // 
            this.connectionStatusVarLabel.AutoSize = true;
            this.connectionStatusVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.connectionStatusVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.connectionStatusVarLabel.Location = new System.Drawing.Point(621, 155);
            this.connectionStatusVarLabel.Name = "connectionStatusVarLabel";
            this.connectionStatusVarLabel.Size = new System.Drawing.Size(41, 22);
            this.connectionStatusVarLabel.TabIndex = 18;
            this.connectionStatusVarLabel.Text = "N/A";
            // 
            // statsLabel
            // 
            this.statsLabel.AutoSize = true;
            this.statsLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.statsLabel.Location = new System.Drawing.Point(445, 127);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.Size = new System.Drawing.Size(57, 22);
            this.statsLabel.TabIndex = 5;
            this.statsLabel.Text = "Stats";
            // 
            // pingVarLabel
            // 
            this.pingVarLabel.AutoSize = true;
            this.pingVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.pingVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pingVarLabel.Location = new System.Drawing.Point(869, 155);
            this.pingVarLabel.Name = "pingVarLabel";
            this.pingVarLabel.Size = new System.Drawing.Size(41, 22);
            this.pingVarLabel.TabIndex = 20;
            this.pingVarLabel.Text = "N/A";
            // 
            // pingLabel
            // 
            this.pingLabel.AutoSize = true;
            this.pingLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.pingLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.pingLabel.Location = new System.Drawing.Point(810, 155);
            this.pingLabel.Name = "pingLabel";
            this.pingLabel.Size = new System.Drawing.Size(53, 22);
            this.pingLabel.TabIndex = 19;
            this.pingLabel.Text = "Ping:";
            // 
            // inRoomVarLabel
            // 
            this.inRoomVarLabel.AutoSize = true;
            this.inRoomVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.inRoomVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.inRoomVarLabel.Location = new System.Drawing.Point(1050, 155);
            this.inRoomVarLabel.Name = "inRoomVarLabel";
            this.inRoomVarLabel.Size = new System.Drawing.Size(41, 22);
            this.inRoomVarLabel.TabIndex = 22;
            this.inRoomVarLabel.Text = "N/A";
            // 
            // inRoomLabel
            // 
            this.inRoomLabel.AutoSize = true;
            this.inRoomLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.inRoomLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.inRoomLabel.Location = new System.Drawing.Point(956, 155);
            this.inRoomLabel.Name = "inRoomLabel";
            this.inRoomLabel.Size = new System.Drawing.Size(88, 22);
            this.inRoomLabel.TabIndex = 21;
            this.inRoomLabel.Text = "In Room:";
            // 
            // playersVarLabel
            // 
            this.playersVarLabel.AutoSize = true;
            this.playersVarLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.playersVarLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playersVarLabel.Location = new System.Drawing.Point(1222, 155);
            this.playersVarLabel.Name = "playersVarLabel";
            this.playersVarLabel.Size = new System.Drawing.Size(41, 22);
            this.playersVarLabel.TabIndex = 24;
            this.playersVarLabel.Text = "N/A";
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.playersLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playersLabel.Location = new System.Drawing.Point(1138, 155);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(78, 22);
            this.playersLabel.TabIndex = 23;
            this.playersLabel.Text = "Players:";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel9.Location = new System.Drawing.Point(448, 216);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(825, 2);
            this.panel9.TabIndex = 26;
            // 
            // roomsLabel
            // 
            this.roomsLabel.AutoSize = true;
            this.roomsLabel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roomsLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.roomsLabel.Location = new System.Drawing.Point(445, 192);
            this.roomsLabel.Name = "roomsLabel";
            this.roomsLabel.Size = new System.Drawing.Size(138, 22);
            this.roomsLabel.TabIndex = 25;
            this.roomsLabel.Text = "Room Actions";
            // 
            // worldAInstanceIDLabel
            // 
            this.worldAInstanceIDLabel.AutoSize = true;
            this.worldAInstanceIDLabel.Font = new System.Drawing.Font("Arial", 14F);
            this.worldAInstanceIDLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.worldAInstanceIDLabel.Location = new System.Drawing.Point(447, 223);
            this.worldAInstanceIDLabel.Name = "worldAInstanceIDLabel";
            this.worldAInstanceIDLabel.Size = new System.Drawing.Size(186, 22);
            this.worldAInstanceIDLabel.TabIndex = 28;
            this.worldAInstanceIDLabel.Text = "World && Instance ID:";
            // 
            // worldAInstanceIDTextBox
            // 
            this.worldAInstanceIDTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.worldAInstanceIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.worldAInstanceIDTextBox.Font = new System.Drawing.Font("Arial", 12F);
            this.worldAInstanceIDTextBox.Location = new System.Drawing.Point(639, 221);
            this.worldAInstanceIDTextBox.Name = "worldAInstanceIDTextBox";
            this.worldAInstanceIDTextBox.Size = new System.Drawing.Size(629, 26);
            this.worldAInstanceIDTextBox.TabIndex = 27;
            // 
            // joinRoomButton
            // 
            this.joinRoomButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.joinRoomButton.FlatAppearance.BorderSize = 0;
            this.joinRoomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.joinRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinRoomButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.joinRoomButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.joinRoomButton.Location = new System.Drawing.Point(451, 252);
            this.joinRoomButton.Name = "joinRoomButton";
            this.joinRoomButton.Size = new System.Drawing.Size(211, 26);
            this.joinRoomButton.TabIndex = 29;
            this.joinRoomButton.Text = "Join";
            this.joinRoomButton.UseVisualStyleBackColor = false;
            this.joinRoomButton.Click += new System.EventHandler(this.JoinRoomButton_Click);
            // 
            // leaveRoomButton
            // 
            this.leaveRoomButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.leaveRoomButton.FlatAppearance.BorderSize = 0;
            this.leaveRoomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.leaveRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.leaveRoomButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.leaveRoomButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.leaveRoomButton.Location = new System.Drawing.Point(668, 253);
            this.leaveRoomButton.Name = "leaveRoomButton";
            this.leaveRoomButton.Size = new System.Drawing.Size(211, 26);
            this.leaveRoomButton.TabIndex = 30;
            this.leaveRoomButton.Text = "Leave";
            this.leaveRoomButton.UseVisualStyleBackColor = false;
            this.leaveRoomButton.Click += new System.EventHandler(this.LeaveRoomButton_Click);
            // 
            // joinLastRoomButton
            // 
            this.joinLastRoomButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.joinLastRoomButton.FlatAppearance.BorderSize = 0;
            this.joinLastRoomButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.joinLastRoomButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.joinLastRoomButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.joinLastRoomButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.joinLastRoomButton.Location = new System.Drawing.Point(885, 253);
            this.joinLastRoomButton.Name = "joinLastRoomButton";
            this.joinLastRoomButton.Size = new System.Drawing.Size(383, 26);
            this.joinLastRoomButton.TabIndex = 31;
            this.joinLastRoomButton.Text = "Join last room";
            this.joinLastRoomButton.UseVisualStyleBackColor = false;
            this.joinLastRoomButton.Click += new System.EventHandler(this.JoinLastRoomButton_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.panel10.Location = new System.Drawing.Point(448, 313);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(825, 2);
            this.panel10.TabIndex = 33;
            // 
            // inRoomActions
            // 
            this.inRoomActions.AutoSize = true;
            this.inRoomActions.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inRoomActions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.inRoomActions.Location = new System.Drawing.Point(445, 289);
            this.inRoomActions.Name = "inRoomActions";
            this.inRoomActions.Size = new System.Drawing.Size(160, 22);
            this.inRoomActions.TabIndex = 32;
            this.inRoomActions.Text = "In Room Actions";
            // 
            // instantiateButton
            // 
            this.instantiateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.instantiateButton.FlatAppearance.BorderSize = 0;
            this.instantiateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.instantiateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instantiateButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.instantiateButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.instantiateButton.Location = new System.Drawing.Point(451, 321);
            this.instantiateButton.Name = "instantiateButton";
            this.instantiateButton.Size = new System.Drawing.Size(399, 26);
            this.instantiateButton.TabIndex = 34;
            this.instantiateButton.Text = "Instantiate";
            this.instantiateButton.UseVisualStyleBackColor = false;
            this.instantiateButton.Click += new System.EventHandler(this.InstantiateButton_Click);
            // 
            // instantiateInvisButton
            // 
            this.instantiateInvisButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.instantiateInvisButton.FlatAppearance.BorderSize = 0;
            this.instantiateInvisButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(86)))), ((int)(((byte)(86)))));
            this.instantiateInvisButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.instantiateInvisButton.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.instantiateInvisButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.instantiateInvisButton.Location = new System.Drawing.Point(856, 321);
            this.instantiateInvisButton.Name = "instantiateInvisButton";
            this.instantiateInvisButton.Size = new System.Drawing.Size(412, 26);
            this.instantiateInvisButton.TabIndex = 35;
            this.instantiateInvisButton.Text = "Instantiate invisible";
            this.instantiateInvisButton.UseVisualStyleBackColor = false;
            this.instantiateInvisButton.Click += new System.EventHandler(this.InstantiateInvisButton_Click);
            // 
            // eventLogsRadioButton
            // 
            this.eventLogsRadioButton.AutoSize = true;
            this.eventLogsRadioButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.eventLogsRadioButton.Location = new System.Drawing.Point(598, 566);
            this.eventLogsRadioButton.Name = "eventLogsRadioButton";
            this.eventLogsRadioButton.Size = new System.Drawing.Size(79, 17);
            this.eventLogsRadioButton.TabIndex = 36;
            this.eventLogsRadioButton.Text = "Event Logs";
            this.eventLogsRadioButton.UseVisualStyleBackColor = true;
            // 
            // photonLogsRadioButton
            // 
            this.photonLogsRadioButton.AutoSize = true;
            this.photonLogsRadioButton.Checked = true;
            this.photonLogsRadioButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.photonLogsRadioButton.Location = new System.Drawing.Point(507, 566);
            this.photonLogsRadioButton.Name = "photonLogsRadioButton";
            this.photonLogsRadioButton.Size = new System.Drawing.Size(85, 17);
            this.photonLogsRadioButton.TabIndex = 37;
            this.photonLogsRadioButton.TabStop = true;
            this.photonLogsRadioButton.Text = "Photon Logs";
            this.photonLogsRadioButton.UseVisualStyleBackColor = true;
            // 
            // logsList
            // 
            this.logsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.logsList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.logsList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.logsList.FullRowSelect = true;
            this.logsList.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.logsList.GridLines = true;
            this.logsList.HideSelection = false;
            this.logsList.Location = new System.Drawing.Point(448, 589);
            this.logsList.Name = "logsList";
            this.logsList.Size = new System.Drawing.Size(820, 119);
            this.logsList.TabIndex = 8;
            this.logsList.UseCompatibleStateImageBehavior = false;
            this.logsList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Log";
            this.columnHeader3.Width = 815;
            // 
            // playerList
            // 
            this.playerList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.playerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.playerList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.playerList.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.playerList.GridLines = true;
            this.playerList.HideSelection = false;
            this.playerList.Location = new System.Drawing.Point(224, 70);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(200, 638);
            this.playerList.TabIndex = 7;
            this.playerList.UseCompatibleStateImageBehavior = false;
            this.playerList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Player";
            this.columnHeader1.Width = 155;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 45;
            // 
            // botInstancesList
            // 
            this.botInstancesList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.botInstancesList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.botInstancesList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.botInstances});
            this.botInstancesList.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botInstancesList.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.botInstancesList.FullRowSelect = true;
            this.botInstancesList.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(56)))));
            this.botInstancesList.GridLines = true;
            this.botInstancesList.HideSelection = false;
            this.botInstancesList.Location = new System.Drawing.Point(8, 70);
            this.botInstancesList.Margin = new System.Windows.Forms.Padding(0);
            this.botInstancesList.Name = "botInstancesList";
            this.botInstancesList.Size = new System.Drawing.Size(200, 638);
            this.botInstancesList.TabIndex = 6;
            this.botInstancesList.UseCompatibleStateImageBehavior = false;
            this.botInstancesList.View = System.Windows.Forms.View.Details;
            this.botInstancesList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_itemSelectionChanged);
            // 
            // botInstances
            // 
            this.botInstances.Text = "Bot Instance";
            this.botInstances.Width = 197;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.photonLogsRadioButton);
            this.Controls.Add(this.eventLogsRadioButton);
            this.Controls.Add(this.instantiateInvisButton);
            this.Controls.Add(this.instantiateButton);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.inRoomActions);
            this.Controls.Add(this.joinLastRoomButton);
            this.Controls.Add(this.leaveRoomButton);
            this.Controls.Add(this.joinRoomButton);
            this.Controls.Add(this.worldAInstanceIDLabel);
            this.Controls.Add(this.worldAInstanceIDTextBox);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.roomsLabel);
            this.Controls.Add(this.playersVarLabel);
            this.Controls.Add(this.playersLabel);
            this.Controls.Add(this.inRoomVarLabel);
            this.Controls.Add(this.inRoomLabel);
            this.Controls.Add(this.pingVarLabel);
            this.Controls.Add(this.pingLabel);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.statsLabel);
            this.Controls.Add(this.connectionStatusVarLabel);
            this.Controls.Add(this.connectionStatusLabel);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.loginViaTXTButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordVisibilityButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.logsList);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.botInstancesList);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.logsLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "TheBot UI";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Panel panel1;
        public Button exitButton;
        public Button minimizeButton;
        public Button maximizeButton;
        public Panel panel2;
        public Panel panel3;
        public Label botInstancesLabel;
        public Label playerlistLabel;
        public Panel panel4;
        public Label logsLabel;
        public Panel panel5;
        public ColumnHeader botInstances;
        public ColumnHeader columnHeader1;
        public ColumnHeader columnHeader2;
        public ColumnHeader columnHeader3;
        public CustomListView botInstancesList;
        public CustomListView playerList;
        public CustomListView logsList;
        public Button settingsButton;
        public TextBox usernameTextBox;
        public Panel panel6;
        public Label usernameLabel;
        public Label passwordLabel;
        public TextBox passwordTextBox;
        public Button passwordVisibilityButton;
        public Button loginButton;
        public Button loginViaTXTButton;
        public Label infoLabel;
        public ToolTip loginToolTip;
        public Panel panel7;
        public Label connectionStatusLabel;
        public Label connectionStatusVarLabel;
        public Panel panel8;
        public Label statsLabel;
        public Label pingVarLabel;
        public Label pingLabel;
        public Label inRoomVarLabel;
        public Label inRoomLabel;
        public Label playersVarLabel;
        public Label playersLabel;
        public Panel panel9;
        public Label roomsLabel;
        public Label worldAInstanceIDLabel;
        public TextBox worldAInstanceIDTextBox;
        public Button joinRoomButton;
        public Button leaveRoomButton;
        public Button joinLastRoomButton;
        public Panel panel10;
        public Label inRoomActions;
        public Button instantiateButton;
        public Button instantiateInvisButton;
        private RadioButton eventLogsRadioButton;
        private RadioButton photonLogsRadioButton;
    }
}

