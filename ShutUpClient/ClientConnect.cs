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
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShutUpClient
{

    internal class ClientConnect
    {
        private TcpListener _server;
        private readonly IPAddress _ip;
        private readonly int _port;

        public static List<string> GetLocalIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ips = (from ip in host.AddressList where ip.AddressFamily == AddressFamily.InterNetwork select ip.ToString()).ToList();
            return ips;
        }

        public ClientConnect(string ip, int port)
        {
            _ip = IPAddress.Parse(ip);
            _port = port;
        }

        public void Connect(IProgress<string> progress)
        {
            _server = new TcpListener(_ip, _port);
            _server.Start();
            StartListener(progress);
        }

        async Task Accept(TcpClient client, IProgress<string> progress)
        {
            await Task.Yield();
            try
            {
                using (client)
                await using (var n = client.GetStream())
                {
                    var data = new byte[256];
                    var bytesRead = 0;
                    var chunkSize = 1;

                    while (bytesRead < data.Length && chunkSize > 0)
                        bytesRead += chunkSize =
                            await n.ReadAsync(data, bytesRead, data.Length - bytesRead);

                    var str = Encoding.Default.GetString(data);
                    Console.WriteLine(@"[server] received : {0}", str);
                    progress.Report(str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void StartListener(IProgress<string> progress)
        {
            try
            {
                Console.WriteLine(@"Waiting for a connection...");
                while (true)
                    await Accept(await _server.AcceptTcpClientAsync(), progress);
            }
            catch (SocketException e)
            {
                Console.WriteLine(@"SocketException: {0}", e);
                _server.Stop();
            }
            finally
            {
                _server.Stop();
            }
        }
    }
}
