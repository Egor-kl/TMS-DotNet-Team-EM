using System;
using System.Collections.Generic;
using System.Text;

namespace ExchangeCurrency.BL
{
    /// <summary>
    /// Константы
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public const string  FILE_PATH = @"convert.txt";
        /// <summary>
        /// Путь ко списку всех валют
        /// </summary>
        public const string CURRENCIES = "https://www.nbrb.by/api/exrates/currencies";
        /// <summary>
        /// Путь к конкретному курсу
        /// </summary>
        public const string RATE = "https://www.nbrb.by/api/exrates/rates/";
    }
}
