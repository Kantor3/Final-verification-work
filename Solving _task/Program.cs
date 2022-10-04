/* =========================================================================================
Студент: Ахметзянов рустам Владимирович.
Специализация: Программирование
Блок 1. "Разработчик"
Итоговая работа.Задача: 
Написать программу, которая из имеющегося массива строк формирует новый массив из строк, 
длина которых меньше, либо равна 3 символам. Первоначальный массив можно ввести с клавиатуры, 
либо задать на старте выполнения алгоритма
Примеры:
["hello]", "2", world", ":-"] -> ["2", ":-"]
["1234". "1567", "-2", computer science"- -> ["-2"]
["Russian". "Denmark". "Kazan"] -> []
=============================================================================================
*/

// Организация завершения работы с модулем
bool CheckExit(dynamic num)
{
    if (num == 0)
    {
        Console.WriteLine("\nРабота с программой завершена, До встречи!\n");
        return true;
    }
    return false;
}


// Ввод числа в заданном диапозоне с контролем корректности ввода
int InputNumber(int numberFrom = 0, int numberTo = 1)
{
    //-------------------------------
    int CheckNumber(string str)
    //-------------------------------
    {
        if (!Int32.TryParse(str, out int number))
        {
            number = -1;
            Console.WriteLine($"Введенная строка '{str}' не являются числом\nПопробуйте еще раз, или '0' для выхода");
        }
        return number;
    }

    while (true)
    {
        string? str_number = Convert.ToString(Console.ReadLine());
        int number = CheckNumber(str_number);
        if (number < 0) continue;
        if (number == 0) return number;
        if (number >= numberFrom & numberFrom <= numberTo) return number;
        Console.WriteLine($@"Введенное число не в заданном диапазоне.
                             Повторите ввод.");
    }
}


// Подготовка данных для выполнения задания
//
// 1. Формирование текста по умолчанию
string Get_DefaulText()
{
    string text = @"Хожу,
                    гляжу в окно ли я —
                    цветы
                    да небо синее,
                    то в нос тебе
                    магнолия,
                    то в глаз тебе
                    глициния.
                    На молоко
                    сменил
                    чаи́
                    в сияньи
                    лунных чар.
                    И днем
                    и ночью
                    на Чаир";
    return text;
} 

// 2. Ввод данных с клавиатуры по заданию
string InputString(string text = "")
{
    Console.Write("Введите произвольный текст или '0' для отказа");
    while (true)
    {
        Console.Write("\n-> ");
        text = Convert.ToString(Console.ReadLine());
        if (text.Length < 1) continue;
        else break;
    }
   return text;
}

// 3. Загрузка строк текста в массив
string[] LoadTextInArray(string text, char sep = (char)32)
{
    string[] arrStrings = text.Split(sep);
    return arrStrings;
}


// Вывод содержимого массива
void ShowArr(dynamic[] array, string txt = "", string last_txt = "")
{
    if (txt.Length > 0) Console.WriteLine(txt);
    bool one_item = true;
    string sep;
    foreach (var item in array)
    {
        sep = one_item ? "[" : ", ";
        one_item = false;
        Console.Write($"{sep}{item}");
    }
    Console.Write($"]{last_txt}"); 
}


// Основное тело программы.
//-------------------------------------------------------------------------------------------------
Console.WriteLine(@"Задача. На вход подается массив строк, 
                    на выходе получить массив строк длиной не более 3-х сиволов: ");
Console.WriteLine("---");

string text = String.Empty;
string str_accumulator = String.Empty;
char sep = (char)32;
int minSizeText = 1000; int maxSizeText = 1000;

while (true)
{
    Console.Write("\nВведите число символов в строке для фильтрации текста (0 - для выхода): ");
    int countChar = InputNumber(minSizeText, maxSizeText);
    if (CheckExit(countChar)) break;

    while (true)
    {
        Console.WriteLine(@"Использовать строки: 0 - 'заданные по умолчанию'; '1 - ввести с клаыиатуры'");
        int inputMethod = InputNumber();
        if (inputMethod == 0)   text = Get_DefaulText();
        else                    text = InputString();

        string[] arr_source = LoadTextInArray(text);
        if (arr_source.Length == 0) continue;

        for (int i = 0; i < arr_source.Length; i++)
        {
            string str_curr = arr_source[i];
            if (str_curr.Length <= 3) 
                str_accumulator += $"{(str_accumulator.Length == 0 ? String.Empty : sep)} {str_curr}";
        }

        string[] arr_result = LoadTextInArray(str_accumulator, sep);
        if (arr_result.Length == 0) continue;

        ShowArr(arr_source, last_txt: " -> "); 
        ShowArr(arr_result); 
    }
}
