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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShutUpClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            var ip = ConfigurationManager.AppSettings.Get("IP");
            lbAllIPs.Items.AddRange(ClientConnect.GetLocalIpAddress().ToArray());
            if (lbAllIPs.Items.Count > 0)
                lbAllIPs.SelectedIndex = 0;
            if (ip != null && lbAllIPs.Items.Count >= int.Parse(ip))
                lbAllIPs.SelectedIndex = int.Parse(ip);
        }

        private async void bConnect_Click(object sender, EventArgs e)
        {
            var client = new ClientConnect(lbAllIPs.SelectedItem.ToString(), 13000);
            var progress = new Progress<string>(ShutUp);
            WindowState = FormWindowState.Minimized;
            lShutUp.Visible = false;
            bACK.Visible = false;
            await Task.Factory.StartNew(() => client.Connect(progress),
                TaskCreationOptions.LongRunning);
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // AllocConsole();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        private void bACK_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            lShutUp.Visible = false;
            bACK.Visible = false;
        }

        public void ShutUp(string message)
        {
            lShutUp.Text = message;
            lShutUp.Visible = true;
            bACK.Visible = true;
            WindowState = FormWindowState.Normal;
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

        private void lbAllIPs_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddUpdateAppSettings("IP", lbAllIPs.SelectedIndex.ToString());
        }
    }
}
