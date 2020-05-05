using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeCurrency.BL
{
    /// <summary>
    /// Класс работы с CMD
    /// </summary>
    public class CmdProcess
    {
        readonly ExchangeCurrencyController controller = new ExchangeCurrencyController();
        /// <summary>
        /// Команды для CMD
        /// </summary>
        /// <param name="args"></param>
        public void CmdArgsProcess(string[] args)
        {
            foreach(string arg in args)
            {
                switch(arg)
                {
                    case "-a":
                    case "--all":
                        controller.GetCurrencyListAsync().GetAwaiter().GetResult();
                        break;

                    case "-r":
                    case "--rate":
                        Console.WriteLine("Популярные курсы:\n");
                        Console.WriteLine("Доллар США ID: 145");
                        Console.WriteLine("Eвро ID: 292");
                        Console.WriteLine("Российский рубль ID:298\n");
                        Console.WriteLine("Введите ID желаемого курса, информацию которого хотите отобразить:");
                        int input = Convert.ToInt32(Console.ReadLine());
                        controller.GetRateAsync(input).GetAwaiter().GetResult();
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
