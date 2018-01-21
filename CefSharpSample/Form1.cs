using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.IO;
using System.Reflection;

namespace CefSharpSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitBrowser();
        }
        public ChromiumWebBrowser browser;
        public void InitBrowser() {


            var settings = new CefSettings();
            settings.BrowserSubprocessPath = (new List<string> { Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "CefSharp.BrowserSubprocess.exe" }).Aggregate(Path.Combine);

            //StreamReader file = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "cefSettings.txt");

            //var line = file.ReadLine();

            //while (line != null)
            //{
            //    settings.CefCommandLineArgs.Add(line, "1");
            //    line = file.ReadLine();
            //}
            settings.CefCommandLineArgs.Add("touch-events", "1");

            settings.RemoteDebuggingPort = 8088;
            settings.LogSeverity = LogSeverity.Verbose;
            settings.LogFile = AppDomain.CurrentDomain.BaseDirectory + "MyDebug.log";

            Cef.Initialize(settings);
            browser = new ChromiumWebBrowser("http://examples.sencha.com/extjs/6.5.1/examples/kitchensink/?classic#all");
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
        }
    }
}
