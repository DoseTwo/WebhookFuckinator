using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.IO;
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
            defaultApply();
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

        private void saveprofileButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog directory = new FolderBrowserDialog();
            if (directory.ShowDialog() == DialogResult.OK)
            {
                string[] profile = { userBox.Text, pfpurlBox.Text, webhookurl.Text };
                save_Entry(profile, directory.SelectedPath, "/Profile.txt");
            }
        }
        private void loadprofileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string[] profile = File.ReadAllLines(openFile.FileName);
                if (profile.Length != 3)
                    errorBox.Text = "Invalid Profile Config!";
                else
                {
                    userBox.Text = profile[0];
                    pfpurlBox.Text = profile[1];
                    webhookurl.Text = profile[2];
                    string promptvalue = Prompt.ShowDialog("Done!", "Loaded");
                }
            }
        }
        private void themeapplyButton_Click(object sender, EventArgs e)
        {
            string themeName = Convert.ToString(themeList.SelectedItem);
            if (themeName != "")
                applyTheme(themeName, false);
            else
                errorBox.Text = "No Theme Selected!";
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
                        errorBox.Text += "\n\nNo Avatar Detected, rollback to default";
                    }
                    if (username == "")
                    {
                        username = "User";
                        errorBox.Text += "\n\nNo Username Detected, rollback to default";
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
            //contentBox.Clear();

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
        private void save_Entry(string[] entry, string path, string file)
        {
            string promptvalue;

            if (file == "/profile.txt" && entry[2] == "")
                promptvalue = Prompt.ShowDialog("Error! No Webhook Inserted", "Error");
            else
            {
                if (!File.Exists(path + file))
                {
                    File.Create(path + file).Close();
                }
                File.WriteAllLines(path + file, entry);
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
            if (!Directory.Exists("themes/"))
                Directory.CreateDirectory("themes/");
            if (!Directory.Exists("resources/applied theme"))
                Directory.CreateDirectory("resources/applied theme");
            DirectoryInfo themeName = new DirectoryInfo("themes/");

            foreach (var d in themeName.GetDirectories("*", SearchOption.AllDirectories))
            {
                themeList.Items.Add(d.Name);
            }

            themeList.EndUpdate();
        }
        private void defaultApply()
        {
            if (!Directory.EnumerateFileSystemEntries("resources/applied theme").Any())
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
                themeList.BackColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                themeList.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }
            else
            {
                applyTheme("", true);
            }
        }

        private void applyTheme(string Name, bool startup)
        {
            if (!startup)
            {
                //loading in everything
                string[] bg = File.ReadAllLines("themes/" + Name + "/background.txt");
                string[] font = File.ReadAllLines("themes/" + Name + "/font color.txt");
                string[] textbox = File.ReadAllLines("themes/" + Name + "/textbox color.txt");
                string[] button = File.ReadAllLines("themes/" + Name + "/button color.txt");

                //conversion to int cause the argb shit does that
                int[] bg1 = convertSArraytoIArray(bg);
                int[] font1 = convertSArraytoIArray(font);
                int[] textbox1 = convertSArraytoIArray(textbox);
                int[] buttonint = convertSArraytoIArray(button);

                //apply theme
                //background (yeah this is the only one)
                this.BackColor = System.Drawing.Color.FromArgb(255, bg1[0], bg1[1], bg1[2]);

                //text
                label1.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label3.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label4.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label2.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label5.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label6.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label7.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label8.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label9.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                contentBox.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                //errorBox.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                webhookurl.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                userBox.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                pfpurlBox.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                themeList.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                sendButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                uploadButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                avatarButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                button1.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                themeapplyButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                loadprofileButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                saveprofileButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);

                //textboxes
                contentBox.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                errorBox.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                webhookurl.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                userBox.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                pfpurlBox.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                themeList.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);

                //buttons
                sendButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                uploadButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                avatarButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                button1.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                themeapplyButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                saveprofileButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                loadprofileButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);

                //save everything into the resources folder
                string dir = "themes/";
                Directory.Delete("resources/applied theme", true);
                Directory.CreateDirectory("resources/applied theme");
                int i = 0;
                string[] copy = Directory.GetFiles("themes/" + Name, "*.txt");
                foreach (string file in copy)
                {
                    string fName = file.Substring(dir.Length);
                    string fileName = Path.GetFileName("themes/" + fName);
                    File.Copy(Path.Combine(dir, fName), Path.Combine("resources/applied theme", fileName), true);
                    i++;
                }
            }
            else
            {
                //loading in everything
                string[] bg = File.ReadAllLines("resources/applied theme/background.txt");
                string[] font = File.ReadAllLines("resources/applied theme/font color.txt");
                string[] textbox = File.ReadAllLines("resources/applied theme/textbox color.txt");
                string[] button = File.ReadAllLines("resources/applied theme/button color.txt");

                //conversion to int cause the argb shit does that
                int[] bg1 = convertSArraytoIArray(bg);
                int[] font1 = convertSArraytoIArray(font);
                int[] textbox1 = convertSArraytoIArray(textbox);
                int[] buttonint = convertSArraytoIArray(button);

                //apply theme
                //background (yeah this is the only one)
                this.BackColor = System.Drawing.Color.FromArgb(255, bg1[0], bg1[1], bg1[2]);

                //text
                label1.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label3.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label4.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label2.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label5.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label6.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label7.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label8.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                label9.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                contentBox.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                //errorBox.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                webhookurl.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                userBox.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                pfpurlBox.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                themeList.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                sendButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                uploadButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                avatarButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                button1.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                themeapplyButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                loadprofileButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);
                saveprofileButton.ForeColor = System.Drawing.Color.FromArgb(255, font1[0], font1[1], font1[2]);

                //textboxes
                contentBox.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                errorBox.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                webhookurl.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                userBox.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                pfpurlBox.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);
                themeList.BackColor = System.Drawing.Color.FromArgb(255, textbox1[0], textbox1[1], textbox1[2]);

                //buttons
                sendButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                uploadButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                avatarButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                button1.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                themeapplyButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                saveprofileButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
                loadprofileButton.BackColor = System.Drawing.Color.FromArgb(255, buttonint[0], buttonint[1], buttonint[2]);
            }
        }

        private int[] convertSArraytoIArray(string[] array)
        {
            int[] convert = { 0, 0, 0, 0, 0 };
            int i = 0;
            foreach (string s in array)
            {
                convert[i] = Convert.ToInt32(s);
                i++;
            }

            return convert;
        }

        private void webhookurl_TextChanged(object sender, EventArgs e)
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