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
        /// Вопрос о сохранении данных
        /// </summary>
        public const string QUESTION_SAVE = "Желаете сохранить информацию в блокнот? Нажмите Y для подтверждения, любую клавишу для отмены.\n";
        /// <summary>
        /// Сообщение об успешном сохранении 
        /// </summary>
        public const string SUCCESFUL_SAVE = "\nДанные успешно сохранены в папку приложения. Путь: bin/Debug/netcoreapp3.1/convert.txt";
        /// <summary>
        /// Исключение об сохранении
        /// </summary>
        public const string EXCEPTION_SAVE = "Не удалось записать в файл пустой обьект";
        /// <summary>
        /// Приветствие
        /// </summary>
        public const string GREETING = "Вас приветствует справочник валют\n";
        /// <summary>
        /// Список команд
        /// </summary>
        public const string COMMAND_LIST = "1.Получить список доступных валют 2.Посмотреть курс 3.Выход";
        /// <summary>
        /// Выбор действия
        /// </summary>
        public const string CHOICE_MAKE = "\nВведите цифрой желаемое действие: ";
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
