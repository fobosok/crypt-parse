using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        WebBrowser wb = new WebBrowser();
        string urlAddress = @"https://maanimo.com/cryptocurrency/bitcoin";
        string s1;
        string s2 = @"<span class=""number text-bold"" data-number=";
        public Form1()
        {
            InitializeComponent();
            s1 = GetCode(urlAddress);
            bool b = s1.Contains(s2);
            if (b)
            {
                int index = s1.IndexOf(s2);
                for(int i=index+67;i<index+75;i++)
                {
                    richTextBox1.Text = richTextBox1.Text + s1[i];
                }
            }
        }   
        public static String GetCode(string urlAddress)
        {
            string data = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;
                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                data = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
            }
            return data;
        }
    }
}
