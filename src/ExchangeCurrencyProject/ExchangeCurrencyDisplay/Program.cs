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
            Console.WriteLine("Вас приветствует справочник валют\n");

            while (alive)
            {
                try
                {
                    Console.WriteLine("\nДоступные команды:");
                    Console.WriteLine("1.Получить список доступных валют 2.Посмотреть курс 3.Выход");
                    Console.WriteLine("\nВведите цифрой желаемое действие:");
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
                            Console.WriteLine("Неккоректный ввод");
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
                Console.WriteLine("Популярные курсы:\n");
                Console.WriteLine("Доллар США ID: 145");
                Console.WriteLine("Eвро ID: 292");
                Console.WriteLine("Российский рубль ID:298\n");
                Console.WriteLine("Введите ID желаемого курса, информацию которого хотите отобразить:");

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
