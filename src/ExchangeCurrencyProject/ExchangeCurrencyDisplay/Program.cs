using System;
using System.Linq;
using System.Threading.Tasks;
using ExchangeCurrency.BL;

namespace ExchangeCurrencyDisplay
{
    class Program
    {
        private static async Task Main(string[] args)
        {
            if (args.Any())
            {
                var cmd = new CmdProcess();
                await cmd.CmdArgsProcessAsync(args);

                return;
            }

            ConsoleProcess();
        }

        private async static void ConsoleProcess()
        {
            var controller = new ExchangeCurrencyController();
            bool alive = true;
            Console.WriteLine(Constants.GREETING);

            while (alive)
            {
                int input;

                try
                {
                    Console.WriteLine(Constants.AVAILABLE_COMMANDS);
                    Console.WriteLine(Constants.COMMAND_LIST);
                    Console.Write(Constants.CHOICE_MAKE);
                    input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            await controller.GetCurrencyListAsync();
                            break;
                        case 2:
                            await GetCurrencyRateAsync(controller, input);
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

        /// <summary>
        /// Интерфейс получения данных о курсе
        /// </summary>
        /// <returns></returns>
        private static async Task GetCurrencyRateAsync(ExchangeCurrencyController controller, int input)
        {
            try
            {
                Console.WriteLine(Constants.POPULAR_RATES);
                Console.Write(Constants.INPUT_ID_RATE);

                input = Convert.ToInt32(Console.ReadLine());
                await controller.GetRateAsync(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
