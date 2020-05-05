using NbrbAPI.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeCurrency.BL
{
    /// <summary>
    /// Контроллер конвертации-записи валют
    /// </summary>
    public class ExchangeCurrencyController
    {
        static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Получить весь список доступных валют в API
        /// </summary>
        public async Task GetCurrencyListAsync()
        {
            // TODO: try..catch
            try
            {
                // TODO: refact it
                HttpResponseMessage response = await client.GetAsync(Constants.CURRENCIES);
                string responseMessage = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                var currency_list = JsonConvert.DeserializeObject<Currency[]>(responseMessage);
                var emptyRow = new string('-', 52);
                Console.WriteLine(emptyRow);
                foreach (Currency cur in currency_list)
                {
                    Console.WriteLine("| {0,5} | {1,40} |", cur.Cur_ID, cur.Cur_Name);
                    Console.WriteLine(emptyRow);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Получить данные о конкретном курсе
        /// </summary>
        /// <param name="cur_id">ID курса</param>
        public async Task GetRateAsync(int cur_id)
        {
            HttpResponseMessage response = await client.GetAsync($"{Constants.RATE}{cur_id}");
            string responseMessage = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            Rate currency = JsonConvert.DeserializeObject<Rate>(responseMessage);
            // TODO: Contants
            Console.WriteLine($"{currency.Cur_Name} \t Количество у.е - {currency.Cur_Scale} \t Курс по НБРБ - {currency.Cur_OfficialRate} \t Дата обновления - {currency.Date.ToLongDateString()}\n");
            SaveDataAsync(currency);
        }
        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <param name="rate">Текущая валюта</param>
        public async void SaveDataAsync(Rate rate)
        {
            rate = rate ?? throw new Exception(Constants.EXCEPTION_SAVE);

            Console.WriteLine(Constants.QUESTION_SAVE);
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Y)
            {
                using (StreamWriter sw = new StreamWriter(Constants.FILE_PATH, true, System.Text.Encoding.UTF8))
                {
                    await sw.WriteLineAsync($"{rate.Cur_Scale} {rate.Cur_Abbreviation} = {rate.Cur_OfficialRate} BYN - Курс на {rate.Date.ToLongDateString()}");
                }
                Console.WriteLine(Constants.SUCCESFUL_SAVE);
            }
        }
    }
}
