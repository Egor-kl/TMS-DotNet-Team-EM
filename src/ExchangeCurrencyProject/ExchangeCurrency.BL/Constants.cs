using System;

namespace ExchangeCurrency.BL
{
    /// <summary>
    /// Константы
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Приветствие.
        /// </summary>
        public const string GREETING = "Вас приветствует справочник валют";

        /// <summary>
        /// Список доступных команд.
        /// </summary>
        public const string COMMAND_LIST = "\n1.Получить список доступных валют | 2.Посмотреть курс | 3.Выход";

        /// <summary>
        /// Доступные команды.
        /// </summary>
        public const string AVAILABLE_COMMANDS = "\nДоступные команды:";

        /// <summary>
        /// Выбор действия.
        /// </summary>
        public const string CHOICE = "\nВведите цифрой желаемое действие: ";

        /// <summary>
        /// Ввод ID.
        /// </summary>
        public const string INPUT_ID_RATE = "Введите ID желаемого курса, информацию которого хотите отобразить: ";

        /// <summary>
        /// Недействительный ввод.
        /// </summary>
        public const string INCORRECT_INPUT = "Неккоректный ввод";

        /// <summary>
        /// Количество у.е.
        /// </summary>
        public const string CU_AMOUNT = "Количество у.е";

        /// <summary>
        /// Курс по НБРБ.
        /// </summary>
        public const string RATE_BY_NBRB = "Курс по НБРБ";

        /// <summary>
        /// Дата обновления.
        /// </summary>
        public const string UPDATE = "Дата обновления";

        /// <summary>
        /// Курс на.
        /// </summary>
        public const string RATE_FOR = "Курс на";

        #region File_Saving
        /// <summary>
        /// Путь к файлу с данными определенных курсов
        /// </summary>
        public const string  FILE_PATH = @"convert.txt";

        /// <summary>
        /// Путь к файлу c популярными курсами
        /// </summary>
        public const string POPULAR_COURSES_FILE_PATH = @"popular_rates.txt";

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
        #endregion

        #region Links
        /// <summary>
        /// Путь ко списку всех валют
        /// </summary>
        public const string CURRENCIES = "https://www.nbrb.by/api/exrates/currencies";

        /// <summary>
        /// Путь к конкретному курсу
        /// </summary>
        public const string RATE = "https://www.nbrb.by/api/exrates/rates/";
        #endregion
    }
}
