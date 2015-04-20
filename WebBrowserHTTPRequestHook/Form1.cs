using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//NEED TO IMPORTANT WINDOWS\SYSTEM32\SHDOCVW.DLL OR IMPORTANT INTERNET EXPLORER CONTROL COM.
using SHDocVw;

namespace WebBrowserHTTPRequestHook
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
    

        private void Form1_Load(object sender, EventArgs e)
        {
            SHDocVw.WebBrowser wb = (SHDocVw.WebBrowser)webBrowser1.ActiveXInstance;
            wb.BeforeNavigate2 += new DWebBrowserEvents2_BeforeNavigate2EventHandler(
                (object pDisp, 
                 ref object URL, 
                 ref object Flags, 
                 ref object TargetFrameName, 
                 ref object PostData, 
                 ref object Headers, 
                 ref bool Cancel) => 
                 {
                     
                     if (PostData == null)
                     {
                         this.listBox.Items.Add("[GET] " + URL);
                         this.listBox.Items.Add("");
                     }
                     else
                     {
                         string PostDATAStr = System.Text.Encoding.ASCII.GetString((Byte[])PostData);
                         this.listBox.Items.Add("[POST] " + URL);
                         this.listBox.Items.Add("[POST DATA] " + PostDATAStr);
                         this.listBox.Items.Add("");
                     }
                 });
        }

    }
}
