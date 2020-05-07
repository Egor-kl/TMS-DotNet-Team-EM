using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NbrbAPI.Models
{
    /// <summary>
    /// Данные курса
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// ID Курса
        /// </summary>
        [Key]
        public int Cur_ID { get; set; }

        /// <summary>
        /// Время обновления курса
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Аббревиатура
        /// </summary>
        public string Cur_Abbreviation { get; set; }

        /// <summary>
        /// Количество условных едениц
        /// </summary>
        public int Cur_Scale { get; set; }

        /// <summary>
        /// Название валюты
        /// </summary>
        public string Cur_Name { get; set; }

        /// <summary>
        /// Оффициальный курс
        /// </summary>
        public decimal? Cur_OfficialRate { get; set; }
    }

    /// <summary>
    /// Сокращенные данные курса
    /// </summary>
    public class RateShort
    {
        /// <summary>
        /// ID Курса
        /// </summary>
        public int Cur_ID { get; set; }

        /// <summary>
        /// Время обновления курса
        /// </summary>
        [Key]
        public DateTime Date { get; set; }

        /// <summary>
        /// Оффициальный курс
        /// </summary>
        public decimal? Cur_OfficialRate { get; set; }
    }

}