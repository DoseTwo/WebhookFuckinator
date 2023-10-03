using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Runtime;
using System.Text;
using System.Windows.Forms;

namespace WebhookFuckinator
{
    public partial class Form1 : Form
    {
        public readonly WebClient client = new WebClient();
        private static NameValueCollection values = new NameValueCollection();
        public string WebHook { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public static bool defaultpfp = false;
        public Form1()
        {
            InitializeComponent();
            theme_Init();
            lightToggle.Checked = true;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            send_Message(webhookurl.Text, contentBox.Text, pfpurlBox.Text, userBox.Text);
        }
        private void uploadButton_Click(object sender, EventArgs e)
        {
            upload_File(webhookurl.Text, false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            upload_File(webhookurl.Text, true);
        }

        private void savehookButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog directory = new FolderBrowserDialog();
            if (directory.ShowDialog() == DialogResult.OK)
            {
                save_Entry(webhookurl.Text, directory.SelectedPath, "/hook.txt");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                load_Text(openFile.FileName, webhookurl);
            }

        }
        private void avatarButton_Click(object sender, EventArgs e)
        {
            botPicture.Image = fetch_Image(pfpurlBox.Text);
        }
        private void lightToggle_CheckedChanged(object sender, EventArgs e)
        {
            change_Color();
        }

        private void darkToggle_CheckedChanged(object sender, EventArgs e)
        {
            change_Color();
        }

        private void send_Message(string webhook, string message, string pfp_url, string username)
        {
            if (message != "")
            {
                if (webhook != "")
                {
                    if (pfp_url == "")
                    {
                        pfp_url = "https://cdn.discordapp.com/attachments/1158191845084504084/1158815974523416707/Untitled.png?ex=651d9efa&is=651c4d7a&hm=f2522fe1ac8b222c8c77e9801f2bd42a910abd7ae3b643c854856e3ff3942621&";
                        errorBox.Text += "\nNo Avatar Detected, rollback to default";
                    }
                    if (username == "")
                    {
                        username = "User";
                        errorBox.Text += "\nNo Username Detected, rollback to default";
                    }

                    values.Add("username", username);
                    values.Add("avatar_url", pfp_url);
                    values.Add("content", message);
                    client.UploadValues(webhook, values);
                }
                else
                {
                    errorBox.Text = "No Webhook Entered";
                }
            }
            else
            {
                errorBox.Text = "No Message In Box";
            }
            values.Clear();
            contentBox.Clear();

        }

        private void upload_File(string webhook, bool message)
        {
            if (webhook != "")
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (message == true)
                        send_Message(webhook, contentBox.Text, pfpurlBox.Text, userBox.Text);
                    client.UploadFile(webhook, openFile.FileName);
                }
            }
            else
            {
                errorBox.Text = "No Webhook Entered";
            }
        }

        private Image fetch_Image(string url)
        {
            //making sure
            if (File.Exists("resources/avatarraw.png"))
            {
                File.Delete("resources/avatarraw.png");
            }
            //fetch the image online
            using WebClient imgcli = new WebClient();
            {

                imgcli.DownloadFile(new Uri(url), "resources/avatarraw.png");
                Aspose.Imaging.Image avatar = Aspose.Imaging.Image.Load("resources/avatarraw.png");
                avatar.Resize(256, 256);
                if (File.Exists("resources/avatar.png"))
                {
                    File.Delete("resources/avatar.png");
                }
                avatar.Save("resources/avatar.png");
            }
            Image image = Image.FromFile("resources/avatar.png");
            return image;
        }
        private void save_Entry(string entry, string path, string file)
        {
            string promptvalue;

            if (file == "/hook.txt" && entry == "")
                promptvalue = Prompt.ShowDialog("Error! No Webhook Inserted", "Error");
            else
            {
                if (!File.Exists(path + file))
                {
                    File.Create(path + file).Close();
                }
                File.WriteAllText(path + file, entry);
                promptvalue = Prompt.ShowDialog("Done!", "Saved");
            }
        }

        private void load_Text(string file, TextBox location)
        {
            location.Text = File.ReadAllText(file);
            string promptvalue = Prompt.ShowDialog("Done!", "Loaded");
        }

        private void theme_Init()
        {
            themeList.Items.Clear();
            themeList.BeginUpdate();
            DirectoryInfo themeName = new DirectoryInfo("themes/");

            foreach (var d in themeName.GetDirectories("*", SearchOption.AllDirectories))
            {
                themeList.Items.Add(d.Name);
            }

            themeList.EndUpdate();
        }
        private void change_Color()
        {
            if (lightToggle.Checked)
            {
                this.BackColor = System.Drawing.Color.FromArgb(255, 250, 249, 246);
                label1.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                label2.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                label3.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                label4.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                label5.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                label6.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                label7.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                label8.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                label9.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                lightToggle.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                darkToggle.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                customToggle.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                contentBox.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                contentBox.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                errorBox.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                errorBox.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                webhookurl.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                webhookurl.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                userBox.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                userBox.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                pfpurlBox.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                pfpurlBox.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                sendButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                sendButton.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                uploadButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                uploadButton.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                avatarButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                avatarButton.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                button1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                button1.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                loadButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                loadButton.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                savehookButton.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                savehookButton.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                themeList.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                themeList.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);

            }
            else if (darkToggle.Checked)
            {
                this.BackColor = System.Drawing.Color.FromArgb(255, 47, 49, 54);
                label1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                label3.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                label4.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                label2.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                label5.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                label6.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                label7.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                label8.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                label9.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                lightToggle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                darkToggle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                customToggle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                contentBox.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                contentBox.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                errorBox.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                errorBox.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                webhookurl.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                webhookurl.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                userBox.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                userBox.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                pfpurlBox.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                pfpurlBox.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                sendButton.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                sendButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                uploadButton.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                uploadButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                avatarButton.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                avatarButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                button1.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                button1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                savehookButton.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                savehookButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                loadButton.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                loadButton.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                themeList.BackColor = System.Drawing.Color.FromArgb(255, 40, 42, 47);
                themeList.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            }
        }

        private void themeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


    public static class Prompt
    {
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { TextAlign = ContentAlignment.MiddleCenter, Left = 150, Width = 200, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Height = 30, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        public static string ShowPrompt(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { TextAlign = ContentAlignment.MiddleCenter, Left = 50, Width = 500, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button deny = new Button() { Text = "No", Left = 350, Width = 100, Height = 30, Top = 70, DialogResult = DialogResult.OK };
            Button confirmation = new Button() { Text = "Yes", Left = 150, Width = 100, Height = 30, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { Form1.defaultpfp = true; prompt.Close(); };
            confirmation.Click += (sender, e) => { Form1.defaultpfp = false; prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(deny);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.AcceptButton = deny;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}