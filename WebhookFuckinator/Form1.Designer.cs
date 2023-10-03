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
            contentBox = new RichTextBox();
            webhookurl = new TextBox();
            label1 = new Label();
            nameLabel = new Label();
            errorBox = new TextBox();
            label4 = new Label();
            button1 = new Button();
            uploadButton = new Button();
            darkToggle = new RadioButton();
            lightToggle = new RadioButton();
            SuspendLayout();
            // 
            // sendButton
            // 
            sendButton.Location = new Point(60, 374);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(125, 23);
            sendButton.TabIndex = 0;
            sendButton.Text = "Send Text";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += SendButton_Click;
            // 
            // contentBox
            // 
            contentBox.Location = new Point(60, 272);
            contentBox.Name = "contentBox";
            contentBox.Size = new Size(242, 96);
            contentBox.TabIndex = 1;
            contentBox.Text = "";
            // 
            // webhookurl
            // 
            webhookurl.Location = new Point(60, 78);
            webhookurl.Name = "webhookurl";
            webhookurl.Size = new Size(242, 23);
            webhookurl.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(123, 54);
            label1.Name = "label1";
            label1.Size = new Size(109, 21);
            label1.TabIndex = 3;
            label1.Text = "Webhook URL";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.ForeColor = Color.Purple;
            nameLabel.Location = new Point(12, 9);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(449, 45);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "The Webhook Fuckinator MK2";
            // 
            // errorBox
            // 
            errorBox.Location = new Point(543, 272);
            errorBox.Multiline = true;
            errorBox.Name = "errorBox";
            errorBox.Size = new Size(163, 96);
            errorBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(543, 251);
            label4.Name = "label4";
            label4.Size = new Size(37, 15);
            label4.TabIndex = 8;
            label4.Text = "Errors";
            // 
            // button1
            // 
            button1.Location = new Point(60, 403);
            button1.Name = "button1";
            button1.Size = new Size(242, 23);
            button1.TabIndex = 9;
            button1.Text = "Send Text + Upload File";
            button1.UseVisualStyleBackColor = true;
            // 
            // uploadButton
            // 
            uploadButton.Location = new Point(191, 374);
            uploadButton.Name = "uploadButton";
            uploadButton.Size = new Size(111, 23);
            uploadButton.TabIndex = 10;
            uploadButton.Text = "Upload File";
            uploadButton.UseVisualStyleBackColor = true;
            uploadButton.Click += uploadButton_Click;
            // 
            // darkToggle
            // 
            darkToggle.AutoSize = true;
            darkToggle.Location = new Point(568, 419);
            darkToggle.Name = "darkToggle";
            darkToggle.Size = new Size(83, 19);
            darkToggle.TabIndex = 11;
            darkToggle.TabStop = true;
            darkToggle.Text = "Dark Mode";
            darkToggle.UseVisualStyleBackColor = true;
            darkToggle.CheckedChanged += darkToggle_CheckedChanged;
            // 
            // lightToggle
            // 
            lightToggle.AutoSize = true;
            lightToggle.Location = new Point(568, 394);
            lightToggle.Name = "lightToggle";
            lightToggle.Size = new Size(86, 19);
            lightToggle.TabIndex = 12;
            lightToggle.TabStop = true;
            lightToggle.Text = "Light Mode";
            lightToggle.UseVisualStyleBackColor = true;
            lightToggle.CheckedChanged += lightToggle_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(250, 249, 246);
            ClientSize = new Size(800, 450);
            Controls.Add(lightToggle);
            Controls.Add(darkToggle);
            Controls.Add(uploadButton);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(errorBox);
            Controls.Add(nameLabel);
            Controls.Add(label1);
            Controls.Add(webhookurl);
            Controls.Add(contentBox);
            Controls.Add(sendButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Webhook Fuckinator MK2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sendButton;
        private RichTextBox contentBox;
        private TextBox webhookurl;
        private Label label1;
        private Label nameLabel;
        private TextBox errorBox;
        private Label label4;
        private Button button1;
        private Button uploadButton;
        private RadioButton darkToggle;
        private RadioButton lightToggle;
    }
}