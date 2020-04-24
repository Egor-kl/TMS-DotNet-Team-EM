using NbrbAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeCurrencyDisplay
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
        public async Task GetCurrencyAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://www.nbrb.by/api/exrates/currencies");
                string responseMessage = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();

                var currency_list = JsonConvert.DeserializeObject<Currency[]>(responseMessage);
                foreach (Currency cur in currency_list)
                {
                    Console.WriteLine($"{cur.Cur_Name} ID: {cur.Cur_ID}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Получить данные о конкретном курсе
        /// </summary>
        /// <param name="cur_id">ID курса</param>
        public async Task GetRateAsync(int cur_id)
        {
            HttpResponseMessage response = await client.GetAsync($"https://www.nbrb.by/api/exrates/rates/ {cur_id}");
            string responseMessage = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            Rate currency = JsonConvert.DeserializeObject<Rate>(responseMessage);
            Console.WriteLine($"{currency.Cur_Name} \t Количество у.е - {currency.Cur_Scale} \t Курс по НБРБ - {currency.Cur_OfficialRate} \t Дата обновления - {currency.Date.ToLongDateString()}\n");

            SaveData(currency);
        }
        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <param name="currency">Текущая валюта</param>
        public async void SaveData(Rate currency)
        {
            var path = @"convert.txt";

            Console.WriteLine("Желаете сохранить информацию в блокнот? Нажмите Y для подтверждения, любую клавишу для отмены.\n");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Y)
            {
                using (StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                {
                    await sw.WriteLineAsync($"{currency.Cur_Scale} {currency.Cur_Abbreviation} = {currency.Cur_OfficialRate} BYN - такой курс на {currency.Date.ToLongDateString()}");
                }
                Console.WriteLine("\nДанные успешно сохранены в папку приложения. Путь: bin/Debug/netcoreapp3.1/convert.txt");
            }
        }
    }
}
