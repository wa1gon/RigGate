﻿#region -- Copyright
/*
   Copyright {2014} {Darryl Wagoner DE WA1GON}

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Wa1gon.Models;

namespace Wa1gon.RigClientLib
{
    public class RigControl
    {
        static public ServerInfo GetCommPortList(Server server)
        {
            HttpClient client = new HttpClient();
            
            ServerInfo info;
            string baseUrl;

            try
            {

                baseUrl = string.Format("http://{0}:{1}/api/Info", server.HostName,
                    server.Port);
                HttpResponseMessage response = client.GetAsync(baseUrl).Result;

                var res = response.Content.ReadAsAsync<ServerInfo>().Result;
                info = res as ServerInfo;
                return info;
            } catch (Exception e)
            {
                var ex = StaticUtils.GetInnerMostException(e);
                throw ex;
            }
        }
        static public List<CommPortConfig> GetConnectionList(Server server)
        {
            HttpClient client = new HttpClient();

            List<CommPortConfig> info;
            string baseUrl;

            try
            {

                baseUrl = string.Format("http://{0}:{1}/api/Radio", server.HostName,
                    server.Port);
                HttpResponseMessage response = client.GetAsync(baseUrl).Result;

                var res = response.Content.ReadAsAsync<List<CommPortConfig>>().Result;
                info = res as List<CommPortConfig>;
                return info;
            }
            catch (Exception e)
            {
                var ex = StaticUtils.GetInnerMostException(e);
                throw ex;
            }
        }
        static public CommPortConfig GetDefaultConnection(Server serv)
        {
            List<CommPortConfig> conn = GetConnectionList(serv);
            CommPortConfig conf = conn.Find(c => c.Default == true);
            if (conf == null && conn != null && conn.Count > 0)
            {
                conf = conn[0];
            }
            if (conf == null)
            {
                conf = new CommPortConfig();
            }
            return conf;
        }
        static public bool SendCommConf(CommPortConfig config, Server server)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(
                 new MediaTypeWithQualityHeaderValue("application/json"));

            string baseUrl = string.Format("http://{0}:{1}/api/Radio", server.HostName,
                server.Port);
            var response = client.PostAsJsonAsync(baseUrl, config).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
