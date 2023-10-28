namespace WebhookFuckinator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            sendButton = new Button();
            webhookurl = new TextBox();
            label1 = new Label();
            errorBox = new TextBox();
            label4 = new Label();
            button1 = new Button();
            uploadButton = new Button();
            botPicture = new PictureBox();
            label2 = new Label();
            avatarButton = new Button();
            contentBox = new TextBox();
            pfpurlBox = new TextBox();
            label3 = new Label();
            userBox = new TextBox();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            logo = new PictureBox();
            label9 = new Label();
            themeList = new ListBox();
            themeapplyButton = new Button();
            saveprofileButton = new Button();
            loadprofileButton = new Button();
            ((System.ComponentModel.ISupportInitialize)botPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logo).BeginInit();
            SuspendLayout();
            // 
            // sendButton
            // 
            sendButton.Location = new Point(470, 543);
            sendButton.Margin = new Padding(3, 4, 3, 4);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(143, 31);
            sendButton.TabIndex = 0;
            sendButton.Text = "Send Text";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += SendButton_Click;
            // 
            // webhookurl
            // 
            webhookurl.Location = new Point(470, 72);
            webhookurl.Margin = new Padding(3, 4, 3, 4);
            webhookurl.Name = "webhookurl";
            webhookurl.Size = new Size(276, 23);
            webhookurl.TabIndex = 2;
            webhookurl.TextChanged += webhookurl_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(549, 47);
            label1.Name = "label1";
            label1.Size = new Size(109, 21);
            label1.TabIndex = 3;
            label1.Text = "Webhook URL";
            // 
            // errorBox
            // 
            errorBox.ForeColor = Color.Red;
            errorBox.Location = new Point(937, 488);
            errorBox.Margin = new Padding(3, 4, 3, 4);
            errorBox.Multiline = true;
            errorBox.Name = "errorBox";
            errorBox.ReadOnly = true;
            errorBox.ShortcutsEnabled = false;
            errorBox.Size = new Size(186, 127);
            errorBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(937, 456);
            label4.Name = "label4";
            label4.Size = new Size(52, 21);
            label4.TabIndex = 8;
            label4.Text = "Errors";
            // 
            // button1
            // 
            button1.Location = new Point(470, 584);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(277, 31);
            button1.TabIndex = 9;
            button1.Text = "Send Text + Upload File";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // uploadButton
            // 
            uploadButton.Location = new Point(620, 543);
            uploadButton.Margin = new Padding(3, 4, 3, 4);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(127, 31);
            uploadButton.TabIndex = 10;
            uploadButton.Text = "Upload File";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += uploadButton_Click;
            // 
            // botPicture
            // 
            botPicture.Location = new Point(898, 47);
            botPicture.Name = "botPicture";
            botPicture.Size = new Size(256, 256);
            botPicture.TabIndex = 13;
            botPicture.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(898, 17);
            label2.Name = "label2";
            label2.Size = new Size(114, 21);
            label2.TabIndex = 14;
            label2.Text = "Avatar Preview";
            // 
            // avatarButton
            // 
            avatarButton.Location = new Point(898, 366);
            avatarButton.Name = "avatarButton";
            avatarButton.Size = new Size(256, 23);
            avatarButton.TabIndex = 15;
            avatarButton.Text = "Preview Avatar";
            avatarButton.UseVisualStyleBackColor = true;
            avatarButton.Click += avatarButton_Click;
            // 
            // contentBox
            // 
            contentBox.Location = new Point(470, 360);
            contentBox.Multiline = true;
            contentBox.Name = "contentBox";
            contentBox.Size = new Size(276, 176);
            contentBox.TabIndex = 17;
            // 
            // pfpurlBox
            // 
            pfpurlBox.Location = new Point(898, 337);
            pfpurlBox.Name = "pfpurlBox";
            pfpurlBox.Size = new Size(256, 23);
            pfpurlBox.TabIndex = 21;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(898, 307);
            label3.Name = "label3";
            label3.Size = new Size(88, 21);
            label3.TabIndex = 22;
            label3.Text = "Avatar URL";
            // 
            // userBox
            // 
            userBox.Location = new Point(470, 327);
            userBox.Name = "userBox";
            userBox.Size = new Size(276, 23);
            userBox.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(470, 288);
            label5.Name = "label5";
            label5.Size = new Size(81, 21);
            label5.TabIndex = 24;
            label5.Text = "Username";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(64, 644);
            label6.Name = "label6";
            label6.Size = new Size(105, 15);
            label6.TabIndex = 25;
            label6.Text = "Made by MeliaDev";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(9, 143);
            label7.Name = "label7";
            label7.Size = new Size(64, 21);
            label7.TabIndex = 26;
            label7.Text = "Themes";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(9, 311);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(62, 21);
            label8.TabIndex = 28;
            label8.Text = "Utilities";
            // 
            // logo
            // 
            logo.Image = (Image)resources.GetObject("logo.Image");
            logo.Location = new Point(9, 12);
            logo.Name = "logo";
            logo.Size = new Size(359, 128);
            logo.TabIndex = 29;
            logo.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1215, 644);
            label9.Name = "label9";
            label9.Size = new Size(28, 15);
            label9.TabIndex = 30;
            label9.Text = "v1.0";
            // 
            // themeList
            // 
            themeList.FormattingEnabled = true;
            themeList.ItemHeight = 15;
            themeList.Location = new Point(21, 165);
            themeList.Name = "themeList";
            themeList.Size = new Size(120, 94);
            themeList.TabIndex = 31;
            // 
            // themeapplyButton
            // 
            themeapplyButton.Location = new Point(21, 265);
            themeapplyButton.Name = "themeapplyButton";
            themeapplyButton.Size = new Size(120, 23);
            themeapplyButton.TabIndex = 32;
            themeapplyButton.Text = "Apply";
            themeapplyButton.UseVisualStyleBackColor = true;
            themeapplyButton.Click += themeapplyButton_Click;
            // 
            // saveprofileButton
            // 
            saveprofileButton.Location = new Point(12, 337);
            saveprofileButton.Name = "saveprofileButton";
            saveprofileButton.Size = new Size(172, 29);
            saveprofileButton.TabIndex = 33;
            saveprofileButton.Text = "Save Profile to .txt";
            saveprofileButton.UseVisualStyleBackColor = true;
            saveprofileButton.Click += saveprofileButton_Click;
            // 
            // loadprofileButton
            // 
            loadprofileButton.Location = new Point(12, 372);
            loadprofileButton.Name = "loadprofileButton";
            loadprofileButton.Size = new Size(172, 29);
            loadprofileButton.TabIndex = 34;
            loadprofileButton.Text = "Load Profile to .txt";
            loadprofileButton.UseVisualStyleBackColor = true;
            loadprofileButton.Click += loadprofileButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 249, 246);
            ClientSize = new Size(1262, 673);
            Controls.Add(loadprofileButton);
            Controls.Add(saveprofileButton);
            Controls.Add(themeapplyButton);
            Controls.Add(themeList);
            Controls.Add(label9);
            Controls.Add(logo);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(userBox);
            Controls.Add(label3);
            Controls.Add(pfpurlBox);
            Controls.Add(contentBox);
            Controls.Add(avatarButton);
            Controls.Add(label2);
            Controls.Add(botPicture);
            Controls.Add(uploadButton);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(errorBox);
            Controls.Add(label1);
            Controls.Add(webhookurl);
            Controls.Add(sendButton);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Webhook Fuckinator MK2";
            ((System.ComponentModel.ISupportInitialize)botPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendButton;
        private TextBox webhookurl;
        private Label label1;
        private TextBox errorBox;
        private Label label4;
        private Button button1;
        private Button uploadButton;
        private PictureBox botPicture;
        private Label label2;
        private Button avatarButton;
        private TextBox contentBox;
        private TextBox pfpurlBox;
        private Label label3;
        private TextBox userBox;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private PictureBox logo;
        private Label label9;
        private ListBox themeList;
        private Button themeapplyButton;
        private Button saveprofileButton;
        private Button loadprofileButton;
    }
}