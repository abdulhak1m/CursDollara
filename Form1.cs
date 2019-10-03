using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deadline06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string line = "";
                using (WebClient wc = new WebClient())
                    line = wc.DownloadString($"http://free.ipwhois.io/json/{textBox1.Text}");
                Match match = Regex.Match(line, "\"country\"\\:\"(.*?)\",(.*?)\"timezone_gmt\":\"(.*?)\",");
                label1.Text = match.Groups[1].Value + "\n" + match.Groups[3].Value;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if(Regex.IsMatch(textBox1.Text, "[^0-9-.]"))
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.SelectionStart = textBox1.TextLength;
            }
        }
    }
}
