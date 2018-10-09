using McMaster.Extensions.CommandLineUtils;
using System;

namespace msgbox
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            try
            {
                return CommandLineApplication.Execute<MessageBoxCommand>(args);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message + " " + e.InnerException?.Message);
                return -1;
            }
        }
    }
}
