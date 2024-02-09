using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LabWork09
{
    internal class Program
    {
        // 1) Функция Проверка ввода числа (Double)
        static double InputDoubleNumber(string msg)
        {
            Console.Write(msg);
            bool isConvert;
            double number;
            do
            {
                isConvert = double.TryParse(Console.ReadLine(), out number);
                Console.ForegroundColor = ConsoleColor.Red;
                if (!isConvert) Console.WriteLine("Ошибка: Введите число!");
                Console.ForegroundColor = ConsoleColor.White;
            } while (!isConvert);
            return number;
        }
        // 2) Функция Проверка ввода числа (Int)
        static uint InputUintNumber(string msg)
        {
            Console.Write(msg);
            bool isConvert;
            uint number;
            do
            {
                isConvert = uint.TryParse(Console.ReadLine(), out number);
                Console.ForegroundColor = ConsoleColor.Red;
                if (!isConvert) Console.WriteLine("Ошибка! Введите целое положительное число.");
                Console.ForegroundColor = ConsoleColor.White;
            } while (!isConvert);
            return number;
        }
        // 3) Интерфейс
        public static uint Menu()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Создать локацию (объект класса)");
            Console.WriteLine("2. Создать Список Локаций (массив из объектов класса)");
            Console.WriteLine("3. Узнать координаты локации (вывести информацию об объекте)");
            Console.WriteLine("4. Узнать координаты всех локаций в списке (вывести информацию обо всех объектах)");
            Console.WriteLine("5. Найти растояния между локациями");
            Console.WriteLine("6. Унарные операции с объектом");
            Console.WriteLine("7. Операции приведения типа");
            Console.WriteLine("8. Бинарные операции");
            Console.WriteLine("9. Количество созданных локаций (лбъектов класса)");
            Console.WriteLine("10. Выйти \n");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu1()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("   1. Создание объекта конструктором без параметра");
            Console.WriteLine("   2. Создание объекта с помощью ДСЧ (конструктором с параметром)");
            Console.WriteLine("   3. Создание объекта, ручной ввод данных (конструктором с параметром)");
            Console.WriteLine("   4. Копирование объекта (конструктор копирования)");
            Console.WriteLine("   5. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu2()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("    1. Создание массива объектов конструктором без параметра");
            Console.WriteLine("    2. Создание массива объектов с помощью ДСЧ (конструктором с параметром)");
            Console.WriteLine("    3. Создание массива объектов, ручной ввод данных (конструктором с параметром)");
            Console.WriteLine("    4. Создание копии коллекции (глубокое кланирование)");
            Console.WriteLine("    5. Узнать данные эллементов массива");
            Console.WriteLine("    6. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu5()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("    1. Реализовать методом класса");
            Console.WriteLine("    2. реализовать статичной функцией");
            Console.WriteLine("    3. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu6()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("    1. Увеличить широту и долготу объекта на 0,01");
            Console.WriteLine("    2. Инвертировать знаки широты и долготы");
            Console.WriteLine("    3. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu7()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Распологется ли точка на экваторе?");
            Console.WriteLine("2. Определение расположения точки(«Восточная долгота» / «Западная долгота» / «Нулевой меридиан»)");
            Console.WriteLine("3. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        public static uint Menu8()
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Определить: Находятся ли точки на одной параллели?");
            Console.WriteLine("2. Определить: Находятся ли точки на разных меридинах?");
            Console.WriteLine("3. Назад");
            uint numberMenu = InputUintNumber("Ваш выбор: \t");
            return numberMenu;
        }
        static void Main(string[] args)
        {
            /* Тестирование 1-2
            {
                // Создание Локаций
                uint count = 0;
                GeoCoordinates[] objects = new GeoCoordinates[count];

                //CreatLoc(ref count, ref objects); // Создание Локаций вручную
                CreatLocRnd(ref count, ref objects); // Создание Локаций с помощью ДСЧ
                Print(count, objects);// Вывод  всех данных


                // Поиск растояния между объектами
                Console.WriteLine("Выберите две локации");
                uint loc1 = InputUintNumber($"Номер Первой локации:\t");
                uint loc2 = InputUintNumber($"Номер Второй локации:\t");
                GeoCoordinates CoordinatesLoc1 = objects[loc1 - 1];
                GeoCoordinates CoordinatesLoc2 = objects[loc2 - 1];
                double distanceSt = GeoCoordinates.DistanceSt(CoordinatesLoc1, CoordinatesLoc2);
                double distance = CoordinatesLoc1.Distance(CoordinatesLoc2);
                Console.WriteLine("Расстояние между точками: " + distanceSt + " км \t (Cтатическая функция)");
                Console.WriteLine("Расстояние между точками: " + distance + " км \t (Метод класса)");

                // Кол-во созданных в программе объектов
                Console.WriteLine($"Количество созданых объектов: {GeoCoordinates.GetObjectCount()}");

                // Задание 2 Проверка на различность меридиан
                Console.WriteLine("Проверка на различность меридиан");
            }*/
            GeoCoordinates locationMain = new GeoCoordinates(); // Создаём объект класса GeoCoordinates
            GeoCoordinatesArray locationArrMain = new GeoCoordinatesArray(); // Создаем массив из объектов класса
            Random rnd = new Random(); // Объект Random, созданный вне конструктора
            bool flag = false;
            bool flag1, flag2, flag5, flag6, flag7, flag8;

            while (flag != true)
            {
                switch (Menu())
                {
                    case 1:
                        flag1 = false;
                        while (flag1 != true)
                        {
                            switch (Menu1())
                            {
                                case 1:
                                    locationMain = new GeoCoordinates();
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.PrintCoordinates();
                                    break;
                                case 2:
                                    locationMain = new GeoCoordinates(rnd);
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.PrintCoordinates();
                                    break;
                                case 3:
                                    locationMain = new GeoCoordinates();
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.CreateFromUserInput();
                                    locationMain.PrintCoordinates();
                                    break;
                                case 4:
                                    locationMain = new GeoCoordinates(rnd);
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.PrintCoordinates();
                                    Console.WriteLine("Копия объекта:");
                                    locationMain.Clone();
                                    locationMain.PrintCoordinates();
                                    break;
                                case 5:
                                    flag1 = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        flag2 = false;
                        while (flag2 != true)
                        {
                            switch (Menu2())
                            {
                                case 1:
                                    locationArrMain = new GeoCoordinatesArray();
                                    locationArrMain.PrintLocations();
                                    break;
                                case 2:
                                    uint countRnd = InputUintNumber("Кол-во объектов: \t");
                                    locationArrMain = new GeoCoordinatesArray((int)countRnd, rnd);
                                    locationArrMain.PrintLocations();
                                    break;
                                case 3:
                                    uint countKey = InputUintNumber("Кол-во объектов: \t");
                                    locationArrMain = new GeoCoordinatesArray(countKey);
                                    Console.WriteLine("Выши объекты: ");
                                    locationArrMain.PrintLocations();
                                    break;
                                case 4:
                                    Console.WriteLine("Массив для копирования: ");
                                    locationArrMain.PrintLocations();
                                    GeoCoordinatesArray cloneArray = new GeoCoordinatesArray(locationArrMain);
                                    Console.WriteLine("Копия массива: ");
                                    cloneArray.PrintLocations();
                                    break;
                                case 5:
                                    locationArrMain.PrintLocations();
                                    break;
                                case 6:
                                    flag2 = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                    break;
                            }
                        }
                        break;
                    case 3:
                        locationMain.PrintCoordinates();
                        break;
                    case 4:
                        locationArrMain.PrintLocations();
                        break;
                    case 5:
                        flag5 = false;
                        while (flag5 != true)
                        {
                            switch (Menu5())
                            {
                                case 1:
                                    Console.WriteLine("Задайте объекты для сравнения: ");
                                    GeoCoordinatesArray locations1 = new GeoCoordinatesArray(2);
                                    double dist1 = locations1[0].Distance(locations1[1]);
                                    Console.WriteLine($"Растояние между точками равно {dist1}");
                                    break;
                                case 2:
                                    Console.WriteLine("Задайте объекты для сравнения: ");
                                    GeoCoordinatesArray locations2 = new GeoCoordinatesArray(2);
                                    double dist2 = GeoCoordinates.DistanceSt(locations2[0], locations2[1]);
                                    Console.WriteLine($"Растояние между точками равно {dist2}");
                                    break;
                                case 3:
                                    flag5 = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                    break;
                            }
                        }
                        break;
                    case 6:
                        flag6 = false;
                        while (flag6 != true)
                        {
                            switch (Menu6())
                            {
                                case 1:
                                    Console.WriteLine("Задайте объект для изменения: ");
                                    locationMain = new GeoCoordinates();
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.CreateFromUserInput();
                                    locationMain.PrintCoordinates();
                                    Console.WriteLine("Результат: ");
                                    locationMain++.PrintCoordinates();
                                    break;
                                case 2:
                                    Console.WriteLine("Задайте объект для изменения: ");
                                    locationMain = new GeoCoordinates();
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.CreateFromUserInput();
                                    locationMain.PrintCoordinates();
                                    Console.WriteLine("Результат: ");
                                    (-locationMain).PrintCoordinates();
                                    break;
                                case 3:
                                    flag6 = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                    break;
                            }
                        }
                        break;
                    case 7:
                        flag7 = false;
                        while (flag7 != true)
                        {
                            switch (Menu7())
                            {
                                case 1:
                                    Console.WriteLine("Задайте объект для изменения: ");
                                    locationMain = new GeoCoordinates();
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.CreateFromUserInput();
                                    Console.WriteLine((bool)locationMain);
                                    break;
                                case 2:
                                    Console.WriteLine("Задайте объект для изменения: ");
                                    locationMain = new GeoCoordinates();
                                    Console.WriteLine("Созданный объект:");
                                    locationMain.CreateFromUserInput();
                                    Console.WriteLine(locationMain);
                                    break;
                                case 3:
                                    flag7 = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                    break;
                            }
                        }
                        break;
                    case 8:
                        flag8 = false;
                        while (flag8 != true)
                        {
                            switch (Menu8())
                            {
                                case 1:
                                    Console.WriteLine("Задайте объекты для сравнения: ");
                                    GeoCoordinatesArray locations1 = new GeoCoordinatesArray(2);
                                    Console.WriteLine(locations1[0] == locations1[1]);
                                    break;
                                case 2:
                                    Console.WriteLine("Задайте объекты для сравнения: ");
                                    GeoCoordinatesArray locations2 = new GeoCoordinatesArray(2);
                                    Console.WriteLine(locations2[0] != locations2[1]);
                                    break;
                                case 3:
                                    flag8 = true;
                                    break;
                                default:
                                    Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                                    break;
                            }
                        }
                        break;
                    case 9:

                        break;
                    case 10:
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Ошибка! Вы ввели несуществующий номер.");
                        break;
                }
            }
        }
    }
}