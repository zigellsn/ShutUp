// Copyright 2021 Simon Zigelli
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ShutUpServer
{
    public partial class ShutUpServer : Form
    {
        public ShutUpServer()
        {
            InitializeComponent();
            var ip = ConfigurationManager.AppSettings.Get("IP");
            if (ip != null)
                tUrl.Text = ip;
        }
        
        private void ShutUpServer_Load(object sender, EventArgs e)
        {
            // AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void bShutUp_Click(object sender, EventArgs e)
        {
            string message;
            message = sender == bPictureMute ? "Kamera aus!" : (sender == bShutUp ? "Mikrofon stummschalten!" : "Laut schalten!");

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                ServerConnect.Connect(tUrl.Text, message);
            }).Start();
        }

        private void tUrl_TextChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings("IP", tUrl.Text);
        }

        private static void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                Console.WriteLine(@"Error writing app settings");
            }
        }
    }
}
