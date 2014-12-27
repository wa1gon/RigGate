﻿using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RigControlConsole
{
    class Program
    {
        static void Main() 
        { 
            string baseAddress = "http://localhost:9000/"; 

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress)) 
            { 
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient();

                string request = baseAddress + "api/Radio";
                Console.WriteLine("Request address: " + request);
                var response = client.GetAsync(request).Result; 

                Console.WriteLine(response); 
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.ReadLine(); 
            } 

            Console.ReadLine(); 
        } 
    } 
}