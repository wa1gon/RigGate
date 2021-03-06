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
namespace Wa1gon.Models
{
    public class RadioComConnConfig
    {
        public RadioComConnConfig()
        {
            AdditionSetting = new Dictionary<string, string>();
        }
        public string ConnectionName { get; set; }
        public string RadioType { get; set; }
        public int? Bps { get; set; }
        public string Port { get; set; }
        public string Parity { get; set; }
        public string StopBits { get; set; }
        public int? DataBits { get; set; }
        public bool Rts { get; set; }
        public bool Dtr { get; set; }
        public bool Default { get; set; }
        public bool IsConnected { get; set; }
        public string Command { get; set; }
        public Dictionary<string,string> AdditionSetting { get; set; }

        public string Status { get; set; }
    }  
}
