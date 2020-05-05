using System;
using System.Threading.Tasks;
using ExchangeCurrency.BL;

namespace ExchangeCurrencyDisplay
{
    class Program
    {
        static bool alive = true;
        static int input;
        static readonly ExchangeCurrencyController controller = new ExchangeCurrencyController();

        static async Task Main()
        {
            Console.WriteLine(Constants.GREETING);

            while (alive)
            {
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
                            await GetCurrencyRateAsync();
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
        static async Task GetCurrencyRateAsync()
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
