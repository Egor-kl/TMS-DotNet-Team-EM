using NbrbAPI.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeCurrency.BL
{
    /// <summary>
    /// Контроллер конвертации-записи валют.
    /// </summary>
    public class ExchangeCurrencyController
    {
        private readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Получить весь список доступных валют в API.
        /// </summary>
        public async Task GetCurrencyListAsync()
        {
            try
            {
                string responseMessage = await GetResponseAsync(Constants.CURRENCIES);

                var currency_list = JsonConvert.DeserializeObject<Currency[]>(responseMessage);
                var empty_row = new string('-', 52);
                Console.WriteLine(empty_row);
                foreach (Currency cur in currency_list)
                {
                    Console.WriteLine("| {0,5} | {1,40} |", cur.Cur_ID, cur.Cur_Name);
                    Console.WriteLine(empty_row);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Получить данные о конкретном курсе.
        /// </summary>
        public async Task GetRateAsync()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Constants.POPULAR_COURSES_FILE_PATH))
                {
                    Console.WriteLine(await sr.ReadToEndAsync());
                }

                Console.Write(Constants.INPUT_ID_RATE);
                var input = Convert.ToInt32(Console.ReadLine());

                string responseMessage = await GetResponseAsync($"{Constants.RATE}{input}");

                Rate currency = JsonConvert.DeserializeObject<Rate>(responseMessage);
                Console.WriteLine($"| {currency.Cur_Name} |\t {Constants.CU_AMOUNT} - {currency.Cur_Scale} |\t {Constants.RATE_BY_NBRB} - {currency.Cur_OfficialRate} |\t {Constants.UPDATE} - {currency.Date.ToLongDateString()} |\n");
                SaveDataAsync(currency);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Получение ответа на определенный запрос.
        /// </summary>
        /// <param name="link">Ссылка на API.</param>
        /// <returns>Ответ в виде строки.</returns>
        public async Task<string> GetResponseAsync(string link)
        {
            //Вопрос: как можно установить время ответа по истечении которого будет генерироваться исключение
            HttpResponseMessage response = await client.GetAsync(link);
            string responseMessage = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();

            return responseMessage;
        }

        /// <summary>
        /// Сохранение данных.
        /// </summary>
        /// <param name="rate">Текущая валюта.</param>
        public async void SaveDataAsync(Rate rate)
        {
            rate = rate ?? throw new Exception(Constants.EXCEPTION_SAVE);

            Console.WriteLine(Constants.QUESTION_SAVE);
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.Y)
            {
                using (StreamWriter sw = new StreamWriter(Constants.FILE_PATH, true, System.Text.Encoding.UTF8))
                {
                    await sw.WriteLineAsync($"{rate.Cur_Scale} {rate.Cur_Abbreviation} = {rate.Cur_OfficialRate} BYN - {Constants.RATE_FOR} {rate.Date.ToLongDateString()}");
                }

                Console.WriteLine(Constants.SUCCESFUL_SAVE);
            }
        }
    }
}
