using System;
using System.Threading.Tasks;

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
            while(alive)
            {
                try
                {
                    Console.WriteLine("\nВведите цифрой желаемое действие\n");
                    Console.WriteLine("1.Посмотреть курс 2.Получить список доступных валют 3.Выход");
                    input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            await GetCurrencyRateAsync();
                            break;
                        case 2:
                            await controller.GetCurrencyAsync();
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
                Console.WriteLine("Введите ID желаемого курса, информацию которого хотите отобразить");
                Console.WriteLine("Популярные курсы:\n");
                Console.WriteLine("Доллар США ID: 145");
                Console.WriteLine("Eвро ID: 292");
                Console.WriteLine("Российский рубль ID:298\n");

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
