namespace ViewerInteractivity
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clearQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voteAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voteBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rewardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cheeranonymousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giftSubscriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.authTokenTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stopBotButton = new System.Windows.Forms.Button();
            this.startBotButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.browseDirButton = new System.Windows.Forms.Button();
            this.modsDirTextBox = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearQueueToolStripMenuItem,
            this.testToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(11, 4, 11, 4);
            this.menuStrip1.Size = new System.Drawing.Size(588, 38);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clearQueueToolStripMenuItem
            // 
            this.clearQueueToolStripMenuItem.Name = "clearQueueToolStripMenuItem";
            this.clearQueueToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.clearQueueToolStripMenuItem.Size = new System.Drawing.Size(105, 30);
            this.clearQueueToolStripMenuItem.Text = "Clear Queue";
            this.clearQueueToolStripMenuItem.Click += new System.EventHandler(this.clearQueueToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voteAToolStripMenuItem,
            this.voteBToolStripMenuItem,
            this.rewardToolStripMenuItem,
            this.cheerToolStripMenuItem,
            this.cheeranonymousToolStripMenuItem,
            this.subscriptionToolStripMenuItem,
            this.giftSubscriptionToolStripMenuItem,
            this.followerToolStripMenuItem});
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(44, 30);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // voteAToolStripMenuItem
            // 
            this.voteAToolStripMenuItem.Name = "voteAToolStripMenuItem";
            this.voteAToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.voteAToolStripMenuItem.Text = "Vote A";
            this.voteAToolStripMenuItem.Click += new System.EventHandler(this.voteAToolStripMenuItem_Click);
            // 
            // voteBToolStripMenuItem
            // 
            this.voteBToolStripMenuItem.Name = "voteBToolStripMenuItem";
            this.voteBToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.voteBToolStripMenuItem.Text = "Vote B";
            this.voteBToolStripMenuItem.Click += new System.EventHandler(this.voteBToolStripMenuItem_Click);
            // 
            // rewardToolStripMenuItem
            // 
            this.rewardToolStripMenuItem.Name = "rewardToolStripMenuItem";
            this.rewardToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.rewardToolStripMenuItem.Text = "Reward";
            this.rewardToolStripMenuItem.Click += new System.EventHandler(this.rewardToolStripMenuItem_Click);
            // 
            // cheerToolStripMenuItem
            // 
            this.cheerToolStripMenuItem.Name = "cheerToolStripMenuItem";
            this.cheerToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cheerToolStripMenuItem.Text = "Cheer";
            this.cheerToolStripMenuItem.Click += new System.EventHandler(this.cheerToolStripMenuItem_Click);
            // 
            // cheeranonymousToolStripMenuItem
            // 
            this.cheeranonymousToolStripMenuItem.Name = "cheeranonymousToolStripMenuItem";
            this.cheeranonymousToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.cheeranonymousToolStripMenuItem.Text = "Cheer (anonymous)";
            this.cheeranonymousToolStripMenuItem.Click += new System.EventHandler(this.cheeranonymousToolStripMenuItem_Click);
            // 
            // subscriptionToolStripMenuItem
            // 
            this.subscriptionToolStripMenuItem.Name = "subscriptionToolStripMenuItem";
            this.subscriptionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.subscriptionToolStripMenuItem.Text = "Subscription";
            this.subscriptionToolStripMenuItem.Click += new System.EventHandler(this.subscriptionToolStripMenuItem_Click);
            // 
            // giftSubscriptionToolStripMenuItem
            // 
            this.giftSubscriptionToolStripMenuItem.Name = "giftSubscriptionToolStripMenuItem";
            this.giftSubscriptionToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.giftSubscriptionToolStripMenuItem.Text = "Gift Subscription";
            this.giftSubscriptionToolStripMenuItem.Click += new System.EventHandler(this.giftSubscriptionToolStripMenuItem_Click);
            // 
            // followerToolStripMenuItem
            // 
            this.followerToolStripMenuItem.Name = "followerToolStripMenuItem";
            this.followerToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.followerToolStripMenuItem.Text = "Follower";
            this.followerToolStripMenuItem.Click += new System.EventHandler(this.followerToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(68, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.statusStrip1.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 301);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 15, 0);
            this.statusStrip1.Size = new System.Drawing.Size(588, 29);
            this.statusStrip1.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 4, 0, 3);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(146, 22);
            this.toolStripStatusLabel1.Text = "Status: No Connection";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(355, 24);
            this.toolStripStatusLabel3.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(61, 24);
            this.toolStripStatusLabel2.Text = "Queue: 0";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(334, 25);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(188, 16);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Get my authentication token...";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 16);
            this.label3.TabIndex = 56;
            this.label3.Text = "Authentication Token:";
            // 
            // authTokenTextBox
            // 
            this.authTokenTextBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authTokenTextBox.Location = new System.Drawing.Point(17, 45);
            this.authTokenTextBox.Margin = new System.Windows.Forms.Padding(14, 4, 14, 4);
            this.authTokenTextBox.Name = "authTokenTextBox";
            this.authTokenTextBox.PasswordChar = '*';
            this.authTokenTextBox.Size = new System.Drawing.Size(512, 26);
            this.authTokenTextBox.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.stopBotButton);
            this.groupBox1.Controls.Add(this.startBotButton);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.authTokenTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(21, 141);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 142);
            this.groupBox1.TabIndex = 58;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Twitch Login";
            // 
            // stopBotButton
            // 
            this.stopBotButton.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopBotButton.Location = new System.Drawing.Point(401, 86);
            this.stopBotButton.Margin = new System.Windows.Forms.Padding(4, 14, 4, 14);
            this.stopBotButton.Name = "stopBotButton";
            this.stopBotButton.Size = new System.Drawing.Size(128, 40);
            this.stopBotButton.TabIndex = 4;
            this.stopBotButton.Text = "Disconnect";
            this.stopBotButton.UseVisualStyleBackColor = true;
            this.stopBotButton.Click += new System.EventHandler(this.stopBotButton_Click);
            // 
            // startBotButton
            // 
            this.startBotButton.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBotButton.Location = new System.Drawing.Point(265, 86);
            this.startBotButton.Margin = new System.Windows.Forms.Padding(4, 14, 4, 14);
            this.startBotButton.Name = "startBotButton";
            this.startBotButton.Size = new System.Drawing.Size(128, 40);
            this.startBotButton.TabIndex = 3;
            this.startBotButton.Text = "Connect";
            this.startBotButton.UseVisualStyleBackColor = true;
            this.startBotButton.Click += new System.EventHandler(this.startBotButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.browseDirButton);
            this.groupBox2.Controls.Add(this.modsDirTextBox);
            this.groupBox2.Location = new System.Drawing.Point(21, 54);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 64);
            this.groupBox2.TabIndex = 59;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mods Directory";
            // 
            // browseDirButton
            // 
            this.browseDirButton.Location = new System.Drawing.Point(432, 21);
            this.browseDirButton.Margin = new System.Windows.Forms.Padding(0, 4, 14, 4);
            this.browseDirButton.Name = "browseDirButton";
            this.browseDirButton.Size = new System.Drawing.Size(97, 31);
            this.browseDirButton.TabIndex = 5;
            this.browseDirButton.Text = "Browse...";
            this.browseDirButton.UseVisualStyleBackColor = true;
            this.browseDirButton.Click += new System.EventHandler(this.browseDirButton_Click);
            // 
            // modsDirTextBox
            // 
            this.modsDirTextBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modsDirTextBox.Location = new System.Drawing.Point(17, 23);
            this.modsDirTextBox.Margin = new System.Windows.Forms.Padding(14, 4, 14, 4);
            this.modsDirTextBox.Name = "modsDirTextBox";
            this.modsDirTextBox.ReadOnly = true;
            this.modsDirTextBox.Size = new System.Drawing.Size(401, 26);
            this.modsDirTextBox.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(588, 330);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Cambria", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Twitch Companion App 2.6 - Deep Rock Galactic";
            this.Load += new System.EventHandler(this.Form1_LoadAsync);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem clearQueueToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox authTokenTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button startBotButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button browseDirButton;
        private System.Windows.Forms.TextBox modsDirTextBox;
        private System.Windows.Forms.Button stopBotButton;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voteAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voteBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cheerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rewardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giftSubscriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cheeranonymousToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followerToolStripMenuItem;
    }
}

