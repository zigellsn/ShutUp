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
using System.Net.Sockets;
using System.Text;

namespace ShutUpServer
{
    internal class ServerConnect
    {
        public static void Connect(string server, string message)
        {
            try
            {
                var port = 13000;
                var client = new TcpClient(server, port);
                var stream = client.GetStream();
                var data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
                Console.WriteLine(@"Sent: {0}", message);
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(@"Exception: {0}", e);
            }

            Console.Read();
        }
    }
}

