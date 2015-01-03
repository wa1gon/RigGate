﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wa1gon.Models;

namespace Wa1gon.ServerInfrastructure
{
    public class ServerState
    {
        static private ServerState instance;
        static private object lockobject = new object();
        public List<ActiveRadio> ActiveRadios { get; set; }
        public ServerInfo ServerInfo { get; set; }

        private ServerState()
        {
            ActiveRadios = new List<ActiveRadio>();
            ServerInfo = new ServerInfo();
        }
        public static ServerState Get()
        {

            lock (lockobject)
            {
                if (instance == null)
                {
                    instance = new ServerState();
                }
            }
            return instance;
        }
    }
}