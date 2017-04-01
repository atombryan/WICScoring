using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WICScoring
{
    public class Program
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Please enter in the desired listening URI");
            var enteredURI = UniversalProperties.connectionURI;
            var appHost = new Global.WicSelfStart()
                .Init()
                .Start(enteredURI);

            Console.WriteLine("Started at {0}, listening on {1}", DateTime.Now, enteredURI);
            bool quit = false;
            while (!quit)
            {
                if (Console.ReadLine().Equals("quit")) quit = true;
            }





        }
    }
}