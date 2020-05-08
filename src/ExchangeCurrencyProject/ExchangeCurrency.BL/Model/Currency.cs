using System;
using System.ComponentModel.DataAnnotations;

namespace NbrbAPI.Models
{
    /// <summary>
    /// Валюта
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// ID Курса
        /// </summary>
        [Key]
        public int Cur_ID { get; set; }

        /// <summary>
        /// ID родительской валюты
        /// </summary>
        public Nullable<int> Cur_ParentID { get; set; }

        /// <summary>
        /// Код валюты
        /// </summary>
        public string Cur_Code { get; set; }

        /// <summary>
        /// Аббревиатура
        /// </summary>
        public string Cur_Abbreviation { get; set; }

        /// <summary>
        /// Название валюты
        /// </summary>
        public string Cur_Name { get; set; }

        /// <summary>
        /// Название валюты на белорусском
        /// </summary>
        public string Cur_Name_Bel { get; set; }

        /// <summary>
        /// Название валюты на английском
        /// </summary>
        public string Cur_Name_Eng { get; set; }

        /// <summary>
        /// Количество валюты
        /// </summary>
        public int Cur_Scale { get; set; }

        /// <summary>
        /// Периодичность установления курса
        /// </summary>
        public int Cur_Periodicity { get; set; }

        /// <summary>
        /// Дата включения валюты в перечень валют
        /// </summary>
        public DateTime Cur_DateStart { get; set; }

        /// <summary>
        /// Дата исключения валюты из перечня валют
        /// </summary>
        public DateTime Cur_DateEnd { get; set; }
    }
}