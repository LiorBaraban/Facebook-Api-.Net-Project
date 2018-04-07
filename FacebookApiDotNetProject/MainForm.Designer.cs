using System;

namespace FacebookApiDotNetProject
{
    public partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelCharCount = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labeUserName = new System.Windows.Forms.Label();
            this.panelUpLeft = new System.Windows.Forms.Panel();
            this.labelTagAFriend = new System.Windows.Forms.Label();
            this.buttonUnselectFriend = new System.Windows.Forms.Button();
            this.pictureBoxSelectedFriend = new System.Windows.Forms.PictureBox();
            this.friendListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.labelSelectedFriendName = new System.Windows.Forms.TextBox();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.buttonEndGame = new System.Windows.Forms.Button();
            this.labelMissionDescription = new System.Windows.Forms.Label();
            this.labelScore = new System.Windows.Forms.Label();
            this.buttonSkipMission = new System.Windows.Forms.Button();
            this.panelFeature1 = new System.Windows.Forms.Panel();
            this.radioButtonOnlyHardMissions = new System.Windows.Forms.RadioButton();
            this.radioButtonOrderFromEasyToHard = new System.Windows.Forms.RadioButton();
            this.radioButtonRandomMissionOrder = new System.Windows.Forms.RadioButton();
            this.labelFeature1 = new System.Windows.Forms.Label();
            this.labelPostText = new System.Windows.Forms.Label();
            this.radioButtonPostText = new System.Windows.Forms.RadioButton();
            this.labelAddress = new System.Windows.Forms.Label();
            this.radioButtonPicture = new System.Windows.Forms.RadioButton();
            this.radioButtonLink = new System.Windows.Forms.RadioButton();
            this.labelCounter = new System.Windows.Forms.TextBox();
            this.textBoxPost = new System.Windows.Forms.RichTextBox();
            this.buttonPublish = new System.Windows.Forms.Button();
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.buttonSelectPicture = new System.Windows.Forms.Button();
            this.panelFeature2 = new System.Windows.Forms.Panel();
            this.radioButtonMostViralPicture = new System.Windows.Forms.RadioButton();
            this.radioButtonMostViralLink = new System.Windows.Forms.RadioButton();
            this.radioButtonMostViralPost = new System.Windows.Forms.RadioButton();
            this.labelDesiredActivity = new System.Windows.Forms.Label();
            this.listBoxAlbums = new System.Windows.Forms.ListBox();
            this.albumsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.labelViralDesc = new System.Windows.Forms.Label();
            this.pictureBoxViralPic = new System.Windows.Forms.PictureBox();
            this.labelFeature2 = new System.Windows.Forms.Label();
            this.buttonFetchViralPhoto = new System.Windows.Forms.Button();
            this.albumsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.panelUpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingSource)).BeginInit();
            this.panelFeature1.SuspendLayout();
            this.panelFeature2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViralPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCharCount
            // 
            this.labelCharCount.AutoSize = true;
            this.labelCharCount.Location = new System.Drawing.Point(1693, 1278);
            this.labelCharCount.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelCharCount.Name = "labelCharCount";
            this.labelCharCount.Size = new System.Drawing.Size(161, 32);
            this.labelCharCount.TabIndex = 13;
            this.labelCharCount.Text = "Char count:";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(37, 48);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(216, 72);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.userBindingSource, "ImageNormal", true));
            this.pictureBoxProfile.Location = new System.Drawing.Point(349, 48);
            this.pictureBoxProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(229, 229);
            this.pictureBoxProfile.TabIndex = 1;
            this.pictureBoxProfile.TabStop = false;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.User);
            // 
            // labeUserName
            // 
            this.labeUserName.AutoSize = true;
            this.labeUserName.Location = new System.Drawing.Point(680, 222);
            this.labeUserName.Name = "labeUserName";
            this.labeUserName.Size = new System.Drawing.Size(149, 32);
            this.labeUserName.TabIndex = 3;
            this.labeUserName.Text = "UserName";
            // 
            // panelUpLeft
            // 
            this.panelUpLeft.Controls.Add(this.buttonLogin);
            this.panelUpLeft.Controls.Add(this.labeUserName);
            this.panelUpLeft.Controls.Add(this.pictureBoxProfile);
            this.panelUpLeft.Location = new System.Drawing.Point(0, 0);
            this.panelUpLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelUpLeft.Name = "panelUpLeft";
            this.panelUpLeft.Size = new System.Drawing.Size(1299, 310);
            this.panelUpLeft.TabIndex = 4;
            // 
            // labelTagAFriend
            // 
            this.labelTagAFriend.AutoSize = true;
            this.labelTagAFriend.Location = new System.Drawing.Point(101, 558);
            this.labelTagAFriend.Name = "labelTagAFriend";
            this.labelTagAFriend.Size = new System.Drawing.Size(283, 32);
            this.labelTagAFriend.TabIndex = 4;
            this.labelTagAFriend.Text = "Select a friend to tag:";
            // 
            // buttonUnselectFriend
            // 
            this.buttonUnselectFriend.Location = new System.Drawing.Point(107, 1004);
            this.buttonUnselectFriend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUnselectFriend.Name = "buttonUnselectFriend";
            this.buttonUnselectFriend.Size = new System.Drawing.Size(261, 72);
            this.buttonUnselectFriend.TabIndex = 4;
            this.buttonUnselectFriend.Text = "Unselect Friend";
            this.buttonUnselectFriend.UseVisualStyleBackColor = true;
            this.buttonUnselectFriend.Click += new System.EventHandler(this.buttonUnselectFriend_Click);
            // 
            // pictureBoxSelectedFriend
            // 
            this.pictureBoxSelectedFriend.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.friendListBindingSource, "ImageNormal", true));
            this.pictureBoxSelectedFriend.Location = new System.Drawing.Point(755, 620);
            this.pictureBoxSelectedFriend.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.pictureBoxSelectedFriend.Name = "pictureBoxSelectedFriend";
            this.pictureBoxSelectedFriend.Size = new System.Drawing.Size(400, 358);
            this.pictureBoxSelectedFriend.TabIndex = 6;
            this.pictureBoxSelectedFriend.TabStop = false;
            // 
            // friendListBindingSource
            // 
            this.friendListBindingSource.DataMember = "Members";
            this.friendListBindingSource.DataSource = typeof(FacebookWrapper.ObjectModel.FriendList);
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.DataSource = this.friendListBindingSource;
            this.listBoxFriends.DisplayMember = "Name";
            this.listBoxFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.ItemHeight = 37;
            this.listBoxFriends.Location = new System.Drawing.Point(107, 620);
            this.listBoxFriends.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(612, 337);
            this.listBoxFriends.TabIndex = 4;
            this.listBoxFriends.ValueMember = "Id";
            // 
            // labelSelectedFriendName
            // 
            this.labelSelectedFriendName.BackColor = System.Drawing.SystemColors.Control;
            this.labelSelectedFriendName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelSelectedFriendName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.friendListBindingSource, "Name", true));
            this.labelSelectedFriendName.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.friendListBindingSource, "Name", true));
            this.labelSelectedFriendName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSelectedFriendName.Location = new System.Drawing.Point(755, 992);
            this.labelSelectedFriendName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.labelSelectedFriendName.Name = "labelSelectedFriendName";
            this.labelSelectedFriendName.Size = new System.Drawing.Size(400, 37);
            this.labelSelectedFriendName.TabIndex = 3;
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.Location = new System.Drawing.Point(1877, 31);
            this.buttonStartGame.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(296, 55);
            this.buttonStartGame.TabIndex = 5;
            this.buttonStartGame.Text = "Start Game";
            this.buttonStartGame.UseVisualStyleBackColor = true;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // buttonEndGame
            // 
            this.buttonEndGame.Location = new System.Drawing.Point(1877, 222);
            this.buttonEndGame.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonEndGame.Name = "buttonEndGame";
            this.buttonEndGame.Size = new System.Drawing.Size(296, 55);
            this.buttonEndGame.TabIndex = 4;
            this.buttonEndGame.Text = "End Game";
            this.buttonEndGame.UseVisualStyleBackColor = true;
            this.buttonEndGame.Click += new System.EventHandler(this.buttonEndGame_Click);
            // 
            // labelMissionDescription
            // 
            this.labelMissionDescription.AutoSize = true;
            this.labelMissionDescription.Location = new System.Drawing.Point(32, 103);
            this.labelMissionDescription.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelMissionDescription.Name = "labelMissionDescription";
            this.labelMissionDescription.Size = new System.Drawing.Size(255, 32);
            this.labelMissionDescription.TabIndex = 3;
            this.labelMissionDescription.Text = "MissionDescription";
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Location = new System.Drawing.Point(1376, 143);
            this.labelScore.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(0, 32);
            this.labelScore.TabIndex = 2;
            // 
            // buttonSkipMission
            // 
            this.buttonSkipMission.Location = new System.Drawing.Point(1877, 124);
            this.buttonSkipMission.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonSkipMission.Name = "buttonSkipMission";
            this.buttonSkipMission.Size = new System.Drawing.Size(296, 55);
            this.buttonSkipMission.TabIndex = 1;
            this.buttonSkipMission.Text = "Skip Mission";
            this.buttonSkipMission.UseVisualStyleBackColor = true;
            this.buttonSkipMission.Click += new System.EventHandler(this.buttonSkipMission_Click);
            // 
            // panelFeature1
            // 
            this.panelFeature1.Controls.Add(this.radioButtonOnlyHardMissions);
            this.panelFeature1.Controls.Add(this.radioButtonOrderFromEasyToHard);
            this.panelFeature1.Controls.Add(this.radioButtonRandomMissionOrder);
            this.panelFeature1.Controls.Add(this.labelFeature1);
            this.panelFeature1.Controls.Add(this.buttonStartGame);
            this.panelFeature1.Controls.Add(this.labelTagAFriend);
            this.panelFeature1.Controls.Add(this.buttonEndGame);
            this.panelFeature1.Controls.Add(this.labelPostText);
            this.panelFeature1.Controls.Add(this.labelMissionDescription);
            this.panelFeature1.Controls.Add(this.buttonUnselectFriend);
            this.panelFeature1.Controls.Add(this.labelScore);
            this.panelFeature1.Controls.Add(this.radioButtonPostText);
            this.panelFeature1.Controls.Add(this.buttonSkipMission);
            this.panelFeature1.Controls.Add(this.pictureBoxSelectedFriend);
            this.panelFeature1.Controls.Add(this.labelAddress);
            this.panelFeature1.Controls.Add(this.listBoxFriends);
            this.panelFeature1.Controls.Add(this.labelSelectedFriendName);
            this.panelFeature1.Controls.Add(this.radioButtonPicture);
            this.panelFeature1.Controls.Add(this.radioButtonLink);
            this.panelFeature1.Controls.Add(this.labelCounter);
            this.panelFeature1.Controls.Add(this.labelCharCount);
            this.panelFeature1.Controls.Add(this.textBoxPost);
            this.panelFeature1.Controls.Add(this.buttonPublish);
            this.panelFeature1.Controls.Add(this.textBoxURL);
            this.panelFeature1.Controls.Add(this.buttonSelectPicture);
            this.panelFeature1.Location = new System.Drawing.Point(1304, 0);
            this.panelFeature1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelFeature1.Name = "panelFeature1";
            this.panelFeature1.Size = new System.Drawing.Size(2205, 1619);
            this.panelFeature1.TabIndex = 11;
            // 
            // radioButtonOnlyHardMissions
            // 
            this.radioButtonOnlyHardMissions.AutoSize = true;
            this.radioButtonOnlyHardMissions.Location = new System.Drawing.Point(1137, 219);
            this.radioButtonOnlyHardMissions.Name = "radioButtonOnlyHardMissions";
            this.radioButtonOnlyHardMissions.Size = new System.Drawing.Size(297, 36);
            this.radioButtonOnlyHardMissions.TabIndex = 20;
            this.radioButtonOnlyHardMissions.Text = "Only Hard Missions";
            this.radioButtonOnlyHardMissions.UseVisualStyleBackColor = true;
            this.radioButtonOnlyHardMissions.CheckedChanged += new System.EventHandler(this.radioButtonOnlyHardMissions_CheckedChanged);
            // 
            // radioButtonOrderFromEasyToHard
            // 
            this.radioButtonOrderFromEasyToHard.AutoSize = true;
            this.radioButtonOrderFromEasyToHard.Location = new System.Drawing.Point(1137, 161);
            this.radioButtonOrderFromEasyToHard.Name = "radioButtonOrderFromEasyToHard";
            this.radioButtonOrderFromEasyToHard.Size = new System.Drawing.Size(374, 36);
            this.radioButtonOrderFromEasyToHard.TabIndex = 20;
            this.radioButtonOrderFromEasyToHard.Text = "Order From Easy To Hard";
            this.radioButtonOrderFromEasyToHard.UseVisualStyleBackColor = true;
            this.radioButtonOrderFromEasyToHard.CheckedChanged += new System.EventHandler(this.radioButtonOrderFromEasyToHard_CheckedChanged);
            // 
            // radioButtonRandomMissionOrder
            // 
            this.radioButtonRandomMissionOrder.AutoSize = true;
            this.radioButtonRandomMissionOrder.Checked = true;
            this.radioButtonRandomMissionOrder.Location = new System.Drawing.Point(1138, 99);
            this.radioButtonRandomMissionOrder.Name = "radioButtonRandomMissionOrder";
            this.radioButtonRandomMissionOrder.Size = new System.Drawing.Size(342, 36);
            this.radioButtonRandomMissionOrder.TabIndex = 19;
            this.radioButtonRandomMissionOrder.TabStop = true;
            this.radioButtonRandomMissionOrder.Text = "Random Mission Order";
            this.radioButtonRandomMissionOrder.UseVisualStyleBackColor = true;
            this.radioButtonRandomMissionOrder.CheckedChanged += new System.EventHandler(this.radioButtonRandomMissionOrder_CheckedChanged);
            // 
            // labelFeature1
            // 
            this.labelFeature1.AutoSize = true;
            this.labelFeature1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFeature1.Location = new System.Drawing.Point(32, 29);
            this.labelFeature1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelFeature1.Name = "labelFeature1";
            this.labelFeature1.Size = new System.Drawing.Size(646, 46);
            this.labelFeature1.TabIndex = 6;
            this.labelFeature1.Text = "Feature #1 - BeMoreSocial Game";
            // 
            // labelPostText
            // 
            this.labelPostText.AutoSize = true;
            this.labelPostText.Location = new System.Drawing.Point(101, 1123);
            this.labelPostText.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelPostText.Name = "labelPostText";
            this.labelPostText.Size = new System.Drawing.Size(142, 32);
            this.labelPostText.TabIndex = 18;
            this.labelPostText.Text = "Post Text:";
            // 
            // radioButtonPostText
            // 
            this.radioButtonPostText.AutoSize = true;
            this.radioButtonPostText.Location = new System.Drawing.Point(107, 341);
            this.radioButtonPostText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPostText.Name = "radioButtonPostText";
            this.radioButtonPostText.Size = new System.Drawing.Size(237, 36);
            this.radioButtonPostText.TabIndex = 17;
            this.radioButtonPostText.Text = "Post Text Only";
            this.radioButtonPostText.UseVisualStyleBackColor = true;
            this.radioButtonPostText.CheckedChanged += new System.EventHandler(this.radioButtonPostText_CheckedChanged);
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(787, 329);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(0, 32);
            this.labelAddress.TabIndex = 6;
            // 
            // radioButtonPicture
            // 
            this.radioButtonPicture.AutoSize = true;
            this.radioButtonPicture.Location = new System.Drawing.Point(107, 458);
            this.radioButtonPicture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonPicture.Name = "radioButtonPicture";
            this.radioButtonPicture.Size = new System.Drawing.Size(315, 36);
            this.radioButtonPicture.TabIndex = 16;
            this.radioButtonPicture.Text = "Upload Local Picture";
            this.radioButtonPicture.UseVisualStyleBackColor = true;
            this.radioButtonPicture.CheckedChanged += new System.EventHandler(this.radioButtonPicture_CheckedChanged);
            // 
            // radioButtonLink
            // 
            this.radioButtonLink.AutoSize = true;
            this.radioButtonLink.Location = new System.Drawing.Point(107, 401);
            this.radioButtonLink.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonLink.Name = "radioButtonLink";
            this.radioButtonLink.Size = new System.Drawing.Size(390, 36);
            this.radioButtonLink.TabIndex = 15;
            this.radioButtonLink.Text = "Share Online Picture / Link";
            this.radioButtonLink.UseVisualStyleBackColor = true;
            this.radioButtonLink.CheckedChanged += new System.EventHandler(this.radioButtonLink_CheckedChanged);
            // 
            // labelCounter
            // 
            this.labelCounter.BackColor = System.Drawing.SystemColors.Control;
            this.labelCounter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.labelCounter.Location = new System.Drawing.Point(1888, 1278);
            this.labelCounter.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.labelCounter.Name = "labelCounter";
            this.labelCounter.Size = new System.Drawing.Size(109, 31);
            this.labelCounter.TabIndex = 14;
            // 
            // textBoxPost
            // 
            this.textBoxPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxPost.Location = new System.Drawing.Point(107, 1173);
            this.textBoxPost.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxPost.Name = "textBoxPost";
            this.textBoxPost.Size = new System.Drawing.Size(1436, 309);
            this.textBoxPost.TabIndex = 4;
            this.textBoxPost.Text = "";
            this.textBoxPost.TextChanged += new System.EventHandler(this.textBoxPost_TextChanged);
            // 
            // buttonPublish
            // 
            this.buttonPublish.Location = new System.Drawing.Point(1701, 1340);
            this.buttonPublish.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonPublish.Name = "buttonPublish";
            this.buttonPublish.Size = new System.Drawing.Size(296, 55);
            this.buttonPublish.TabIndex = 3;
            this.buttonPublish.Text = "Publish";
            this.buttonPublish.UseVisualStyleBackColor = true;
            this.buttonPublish.Click += new System.EventHandler(this.buttonPublish_Click);
            // 
            // textBoxURL
            // 
            this.textBoxURL.Enabled = false;
            this.textBoxURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.textBoxURL.Location = new System.Drawing.Point(792, 377);
            this.textBoxURL.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(1204, 44);
            this.textBoxURL.TabIndex = 7;
            this.textBoxURL.TextChanged += new System.EventHandler(this.textBoxURL_TextChanged);
            // 
            // buttonSelectPicture
            // 
            this.buttonSelectPicture.Enabled = false;
            this.buttonSelectPicture.Location = new System.Drawing.Point(1701, 444);
            this.buttonSelectPicture.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonSelectPicture.Name = "buttonSelectPicture";
            this.buttonSelectPicture.Size = new System.Drawing.Size(296, 55);
            this.buttonSelectPicture.TabIndex = 4;
            this.buttonSelectPicture.Text = "Select Picture";
            this.buttonSelectPicture.UseVisualStyleBackColor = true;
            this.buttonSelectPicture.Click += new System.EventHandler(this.buttonSelectPicture_Click);
            // 
            // panelFeature2
            // 
            this.panelFeature2.Controls.Add(this.radioButtonMostViralPicture);
            this.panelFeature2.Controls.Add(this.radioButtonMostViralLink);
            this.panelFeature2.Controls.Add(this.radioButtonMostViralPost);
            this.panelFeature2.Controls.Add(this.labelDesiredActivity);
            this.panelFeature2.Controls.Add(this.listBoxAlbums);
            this.panelFeature2.Controls.Add(this.labelViralDesc);
            this.panelFeature2.Controls.Add(this.pictureBoxViralPic);
            this.panelFeature2.Controls.Add(this.labelFeature2);
            this.panelFeature2.Controls.Add(this.buttonFetchViralPhoto);
            this.panelFeature2.Location = new System.Drawing.Point(0, 594);
            this.panelFeature2.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.panelFeature2.Name = "panelFeature2";
            this.panelFeature2.Size = new System.Drawing.Size(1299, 2189);
            this.panelFeature2.TabIndex = 10;
            // 
            // radioButtonMostViralPicture
            // 
            this.radioButtonMostViralPicture.AutoSize = true;
            this.radioButtonMostViralPicture.Location = new System.Drawing.Point(38, 413);
            this.radioButtonMostViralPicture.Name = "radioButtonMostViralPicture";
            this.radioButtonMostViralPicture.Size = new System.Drawing.Size(728, 36);
            this.radioButtonMostViralPicture.TabIndex = 28;
            this.radioButtonMostViralPicture.TabStop = true;
            this.radioButtonMostViralPicture.Text = "Most Viral Picture (you have to choose an album also)";
            this.radioButtonMostViralPicture.UseVisualStyleBackColor = true;
            this.radioButtonMostViralPicture.CheckedChanged += new System.EventHandler(this.radioButtonMostViralPicture_CheckedChanged);
            // 
            // radioButtonMostViralLink
            // 
            this.radioButtonMostViralLink.AutoSize = true;
            this.radioButtonMostViralLink.Location = new System.Drawing.Point(38, 362);
            this.radioButtonMostViralLink.Name = "radioButtonMostViralLink";
            this.radioButtonMostViralLink.Size = new System.Drawing.Size(238, 36);
            this.radioButtonMostViralLink.TabIndex = 27;
            this.radioButtonMostViralLink.TabStop = true;
            this.radioButtonMostViralLink.Text = "Most Viral Link";
            this.radioButtonMostViralLink.UseVisualStyleBackColor = true;
            this.radioButtonMostViralLink.CheckedChanged += new System.EventHandler(this.radioButtonMostViralLink_CheckedChanged);
            // 
            // radioButtonMostViralPost
            // 
            this.radioButtonMostViralPost.AutoSize = true;
            this.radioButtonMostViralPost.Checked = true;
            this.radioButtonMostViralPost.Location = new System.Drawing.Point(37, 308);
            this.radioButtonMostViralPost.Name = "radioButtonMostViralPost";
            this.radioButtonMostViralPost.Size = new System.Drawing.Size(242, 36);
            this.radioButtonMostViralPost.TabIndex = 26;
            this.radioButtonMostViralPost.TabStop = true;
            this.radioButtonMostViralPost.Text = "Most Viral Post";
            this.radioButtonMostViralPost.UseVisualStyleBackColor = true;
            this.radioButtonMostViralPost.CheckedChanged += new System.EventHandler(this.radioButtonMostViralPost_CheckedChanged);
            // 
            // labelDesiredActivity
            // 
            this.labelDesiredActivity.AutoSize = true;
            this.labelDesiredActivity.Location = new System.Drawing.Point(31, 241);
            this.labelDesiredActivity.Name = "labelDesiredActivity";
            this.labelDesiredActivity.Size = new System.Drawing.Size(364, 32);
            this.labelDesiredActivity.TabIndex = 19;
            this.labelDesiredActivity.Text = "Choose the desired activity:";
            // 
            // listBoxAlbums
            // 
            this.listBoxAlbums.DataSource = this.albumsBindingSource1;
            this.listBoxAlbums.DisplayMember = "Name";
            this.listBoxAlbums.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listBoxAlbums.FormattingEnabled = true;
            this.listBoxAlbums.ItemHeight = 37;
            this.listBoxAlbums.Location = new System.Drawing.Point(35, 459);
            this.listBoxAlbums.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.listBoxAlbums.Name = "listBoxAlbums";
            this.listBoxAlbums.Size = new System.Drawing.Size(391, 226);
            this.listBoxAlbums.TabIndex = 19;
            this.listBoxAlbums.ValueMember = "Albums";
            this.listBoxAlbums.Visible = false;
            // 
            // albumsBindingSource1
            // 
            this.albumsBindingSource1.DataMember = "Albums";
            this.albumsBindingSource1.DataSource = this.userBindingSource;
            // 
            // labelViralDesc
            // 
            this.labelViralDesc.AutoSize = true;
            this.labelViralDesc.Location = new System.Drawing.Point(756, 841);
            this.labelViralDesc.Name = "labelViralDesc";
            this.labelViralDesc.Size = new System.Drawing.Size(0, 32);
            this.labelViralDesc.TabIndex = 4;
            // 
            // pictureBoxViralPic
            // 
            this.pictureBoxViralPic.Location = new System.Drawing.Point(761, 521);
            this.pictureBoxViralPic.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxViralPic.Name = "pictureBoxViralPic";
            this.pictureBoxViralPic.Size = new System.Drawing.Size(333, 284);
            this.pictureBoxViralPic.TabIndex = 4;
            this.pictureBoxViralPic.TabStop = false;
            this.pictureBoxViralPic.Visible = false;
            // 
            // labelFeature2
            // 
            this.labelFeature2.AutoSize = true;
            this.labelFeature2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFeature2.Location = new System.Drawing.Point(27, 141);
            this.labelFeature2.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.labelFeature2.Name = "labelFeature2";
            this.labelFeature2.Size = new System.Drawing.Size(945, 46);
            this.labelFeature2.TabIndex = 20;
            this.labelFeature2.Text = "Feature #2 - Find and Share my most viral activity";
            // 
            // buttonFetchViralPhoto
            // 
            this.buttonFetchViralPhoto.Location = new System.Drawing.Point(35, 788);
            this.buttonFetchViralPhoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFetchViralPhoto.Name = "buttonFetchViralPhoto";
            this.buttonFetchViralPhoto.Size = new System.Drawing.Size(392, 72);
            this.buttonFetchViralPhoto.TabIndex = 25;
            this.buttonFetchViralPhoto.Text = "Get my viral Activity";
            this.buttonFetchViralPhoto.UseVisualStyleBackColor = true;
            this.buttonFetchViralPhoto.Click += new System.EventHandler(this.buttonFetchViralActivity_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2928, 1140);
            this.Controls.Add(this.panelFeature2);
            this.Controls.Add(this.panelFeature1);
            this.Controls.Add(this.panelUpLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.panelUpLeft.ResumeLayout(false);
            this.panelUpLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectedFriend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.friendListBindingSource)).EndInit();
            this.panelFeature1.ResumeLayout(false);
            this.panelFeature1.PerformLayout();
            this.panelFeature2.ResumeLayout(false);
            this.panelFeature2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxViralPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.albumsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Label labeUserName;
        private System.Windows.Forms.Panel panelUpLeft;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Button buttonSkipMission;
        private System.Windows.Forms.PictureBox pictureBoxSelectedFriend;
        private System.Windows.Forms.ListBox listBoxFriends;
        private System.Windows.Forms.TextBox labelSelectedFriendName;
        private System.Windows.Forms.Panel panelFeature1;
        private System.Windows.Forms.Button buttonPublish;
        private System.Windows.Forms.Panel panelFeature2;
        private System.Windows.Forms.Button buttonSelectPicture;
        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.RichTextBox textBoxPost;
        private System.Windows.Forms.TextBox labelCounter;
        private System.Windows.Forms.Label labelMissionDescription;
        private System.Windows.Forms.Button buttonEndGame;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.RadioButton radioButtonPicture;
        private System.Windows.Forms.RadioButton radioButtonLink;
        private System.Windows.Forms.RadioButton radioButtonPostText;
        private System.Windows.Forms.Label labelPostText;
        private System.Windows.Forms.Button buttonUnselectFriend;
        private System.Windows.Forms.Label labelCharCount;
        private System.Windows.Forms.Label labelTagAFriend;
        private System.Windows.Forms.Button buttonFetchViralPhoto;
        private System.Windows.Forms.Label labelFeature1;
        private System.Windows.Forms.Label labelFeature2;
        private System.Windows.Forms.BindingSource albumsBindingSource;
        private System.Windows.Forms.Label labelViralDesc;
        private System.Windows.Forms.PictureBox pictureBoxViralPic;
        private System.Windows.Forms.ListBox listBoxAlbums;
        private System.Windows.Forms.BindingSource friendListBindingSource;
        private System.Windows.Forms.BindingSource albumsBindingSource1;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.RadioButton radioButtonMostViralPicture;
        private System.Windows.Forms.RadioButton radioButtonMostViralLink;
        private System.Windows.Forms.RadioButton radioButtonMostViralPost;
        private System.Windows.Forms.Label labelDesiredActivity;
        private System.Windows.Forms.RadioButton radioButtonOnlyHardMissions;
        private System.Windows.Forms.RadioButton radioButtonOrderFromEasyToHard;
        private System.Windows.Forms.RadioButton radioButtonRandomMissionOrder;
    }
}