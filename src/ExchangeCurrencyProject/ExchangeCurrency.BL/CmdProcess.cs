using System;
using System.Threading.Tasks;

namespace ExchangeCurrency.BL
{
    /// <summary>
    /// Класс работы с CMD
    /// </summary>
    public class CmdProcess
    {
        /// <summary>
        /// Команды для CMD
        /// </summary>
        /// <param name="args"></param>
        public async Task CmdArgsProcessAsync(string[] args)
        {
            var controller = new ExchangeCurrencyController();

            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "-a":
                    case "--all":
                        await controller.GetCurrencyListAsync();
                        break;

                    case "-r":
                    case "--rate":
                        Console.WriteLine(Constants.POPULAR_RATES);
                        Console.Write(Constants.INPUT_ID_RATE);
                        int input = Convert.ToInt32(Console.ReadLine());
                        await controller.GetRateAsync(input);
                        break;

                    case "-h":
                    case "--help":
                        Console.WriteLine("-a , --all   :Получить список доступных валют");
                        Console.WriteLine("-r , --rate  :Получить данные о конкретном курсе");
                        Console.WriteLine("-h, --help   :Получить список доступных команд");
                        break;

                    default:
                        Console.WriteLine($"Некорректный ввод команды {arg} ");
                        break;
                }
            }
        }
    }
}
