using ExchangeCurrency.BL;
using System.Linq;

namespace ExchangeCurrency.AppCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Any())
            {
                var cmd = new CmdProcess();
                cmd.CmdArgsProcessAsync(args).GetAwaiter().GetResult();
                return;
            }
        }
    }
}
