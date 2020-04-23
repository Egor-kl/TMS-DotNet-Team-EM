using NbrbAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeCurrencyDisplay
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static bool alive = true;
        static int input;
        static async Task Main()
        {
            Console.WriteLine("Вас приветствует справочник валют\n");
            while(alive)
            {
                try
                {
                    Console.WriteLine("Введите цифрой желаемое действие\n");
                    Console.WriteLine("1.Посмотреть курс 2.Получить список доступных валют 3.Выход");
                    input = Convert.ToInt32(Console.ReadLine());

                    switch (input)
                    {
                        case 1:
                            await GetCurrencyRateInfo();
                            break;
                        case 2:
                            await GetCurrencyAsync();
                            break;
                        case 3:
                            alive = false;
                            break;
                        default:
                            Console.WriteLine("Неккоректное значение");
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
        /// Интерфейс получения данных о курсах
        /// </summary>
        /// <returns></returns>
        static async Task GetCurrencyRateInfo()
        {
            try
            {
                Console.WriteLine("Введите ID желаемого курса, информацию которого хотите отобразить");
                Console.WriteLine("Популярные курсы:\n");
                Console.WriteLine("Доллар США ID: 145");
                Console.WriteLine("Eвро ID: 292");
                Console.WriteLine("Российский рубль ID:298");

                input = Convert.ToInt32(Console.ReadLine());

                await GetRateAsync(input);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Получить весь список доступных валют в API
        /// </summary>
        public static async Task GetCurrencyAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://www.nbrb.by/api/exrates/currencies");
                string responseMessage = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                var currency_list = JsonConvert.DeserializeObject<Currency[]>(responseMessage);
                foreach(Currency cur in currency_list)
                {
                    Console.WriteLine($"{cur.Cur_Name} ID: {cur.Cur_ID}");
                }
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }  
        }
        /// <summary>
        /// Получить данные о конкретном курсе
        /// </summary>
        /// <param name="cur_id">ID курса</param>
        public static async Task GetRateAsync(int cur_id)
        {
            var Path = @"convert.txt";

            HttpResponseMessage response = await client.GetAsync($"https://www.nbrb.by/api/exrates/rates/ {cur_id}");
            string responseMessage = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            Rate currency = JsonConvert.DeserializeObject<Rate>(responseMessage);
            Console.WriteLine($"{currency.Cur_Name} \t Количество у.е - {currency.Cur_Scale} \t Курс по НБРБ - {currency.Cur_OfficialRate} \t Дата обновления - {currency.Date.ToLongDateString()}");
            
            Console.WriteLine("Вы хотите это записать в блокнот? Если да, напишите 1, если нет напишите 2");
            var input = int.Parse(Console.ReadLine());

            if (input == 1)
            {
                using (StreamWriter sw = new StreamWriter(Path, true, System.Text.Encoding.UTF8))
                {
                    await sw.WriteLineAsync($"{currency.Cur_Scale} {currency.Cur_Abbreviation} = {currency.Cur_OfficialRate} BYN - такой курс на {currency.Date}");
                }
            }
        }
    }
}
