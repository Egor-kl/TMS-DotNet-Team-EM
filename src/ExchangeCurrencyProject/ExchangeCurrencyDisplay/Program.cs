using System;
using System.Linq;
using System.Threading.Tasks;
using ExchangeCurrency.BL;

namespace ExchangeCurrencyDisplay
{
    class Program
    {
       private static readonly ExchangeCurrencyController controller = new ExchangeCurrencyController();

        private static async Task Main()
        {
            bool alive = true;
            Console.WriteLine(Constants.GREETING);

            while (alive)
            {
                try
                {
                    Console.WriteLine(Constants.AVAILABLE_COMMANDS);
                    Console.WriteLine(Constants.COMMAND_LIST);
                    Console.Write(Constants.CHOICE);
                    var input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            await controller.GetCurrencyListAsync();
                            break;
                        case 2:
                            await controller.GetRateAsync();
                            break;
                        case 3:
                            alive = false;
                            break;
                        default:
                            Console.WriteLine(Constants.INCORRECT_INPUT);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
