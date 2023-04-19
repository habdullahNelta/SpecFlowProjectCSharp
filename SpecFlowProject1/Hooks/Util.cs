using FluentAssertions.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using Microsoft.Extensions.Logging;

namespace SpecFlowProject1.Hooks
{
    internal class Util
    {

      
        public class BrowserArt
        {
            public  string Browser { get; set; }
        }
        public static string ReadJsonFile()
        {
            DirectoryInfo di = new("../../../");
            string text = File.ReadAllText(di.FullName+ "BrowserConfig.json");
            var browserArt = JsonSerializer.Deserialize<BrowserArt>(text);
           
            //Console.WriteLine($"browserArt: {browserArt.Browser}");
            return browserArt.Browser;
        }
    }
}
