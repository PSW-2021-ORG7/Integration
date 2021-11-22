﻿using Integration_Class_Library.Tendering.Model;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Integration_Class_Library.Tendering.Service
{
    public class TimerService : BackgroundService
    {
        System.Timers.Timer collectTimer = new System.Timers.Timer();       // periodicly collects new messages from list and writes them to file
        System.Timers.Timer generatorTimer = new System.Timers.Timer();     // periodicly generates new messages and adds them to list

      
        public override Task StartAsync(CancellationToken cancellationToken)
        {
           // WriteToFile("Service is started at " + DateTime.Now);
            return base.StartAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            collectTimer.Elapsed += new ElapsedEventHandler(CollectMessage);
            collectTimer.Interval = 5000; //number in miliseconds  
            collectTimer.Enabled = true;

            generatorTimer.Elapsed += new ElapsedEventHandler(GenerateMessage);
            generatorTimer.Interval = 2200; //number in miliseconds  
            generatorTimer.Enabled = true;
            return Task.CompletedTask;
        }

          public override Task StopAsync(CancellationToken cancellationToken)
           {
               WriteToFile("Service is stopped at " + DateTime.Now);
               return base.StopAsync(cancellationToken);
           }

           private void GenerateMessage(object source, ElapsedEventArgs e)
           {
               WriteToFile("Generate message at " + DateTime.Now);
      //         Program.Offers.Add(new Offer("generated text: " + System.Guid.NewGuid().ToString(), DateTime.Now));
           }

           private void CollectMessage(object source, ElapsedEventArgs e)
           {
               WriteToFile("Collect messages at " + DateTime.Now);
       //        foreach (Offer offer in Program.Offers)
       //        {
       //            WriteToFile("Offer " + offer.Text + " sent at " + offer.Timestamp + " was read at " + DateTime.Now);
       //       }
       //       Program.Offers.Clear();
           }

           public void WriteToFile(string Message)
           {
               string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
               if (!Directory.Exists(path))
               {
                   Directory.CreateDirectory(path);
               }
               string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
               if (!File.Exists(filepath))
               {
                   // Create a file to write to.   
                   using (StreamWriter sw = File.CreateText(filepath))
                   {
                       sw.WriteLine(Message);
                   }
               }
               else
               {
                   try
                   {
                       using (StreamWriter sw = File.AppendText(filepath))
                       {
                           sw.WriteLine(Message);
                       }
                   }
                   catch (IOException e)
                   {
                       Console.WriteLine(e.ToString());
                   }
               }
           }
    }
}
