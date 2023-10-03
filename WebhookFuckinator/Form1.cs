using Discord;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace WebhookFuckinator
{
    public partial class Form1 : Form
    {
        public static WebClient client = new WebClient();
        public Form1()
        {
            InitializeComponent();
            lightToggle.Checked = true;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            send_Message(webhookurl.Text, contentBox.Text);
            contentBox.Clear();
        }
        private void uploadButton_Click(object sender, EventArgs e)
        {
            upload_File(webhookurl.Text);
        }
        private void lightToggle_CheckedChanged(object sender, EventArgs e)
        {
            change_Color();
        }

        private void darkToggle_CheckedChanged(object sender, EventArgs e)
        {
            change_Color();
        }

        private void send_Message(string webhook, string message)
        {
            if (message != "")
            {
                if (webhook != "")
                {
                    client.Headers.Add("Content-Type", "application/json");
                    string payload = "{\"content\": \"" + message + "\"}";
                    client.UploadData(webhook, Encoding.UTF8.GetBytes(payload));
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

        }

        private void upload_File(string webhook)
        {
            if (webhook != "")
            {
                OpenFileDialog openFile = new OpenFileDialog();
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    client.UploadFile(webhook, openFile.FileName);
                }
            }
            else
            {
                errorBox.Text = "No Webhook Entered";
            }
        }

        private void change_Color()
        {
            if (lightToggle.Checked)
            {
                this.BackColor = System.Drawing.Color.FromArgb(255, 250, 249, 246);
                label1.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                label4.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                lightToggle.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
                darkToggle.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);
            }
            else if (darkToggle.Checked)
            {
                this.BackColor = System.Drawing.Color.FromArgb(255, 47, 49, 54);
                label1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                label4.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                lightToggle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                darkToggle.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
            }
        }

    }

}