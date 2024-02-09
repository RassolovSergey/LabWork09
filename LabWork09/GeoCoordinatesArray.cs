using System;

namespace LabWork09
{
    internal class GeoCoordinatesArray
    {
        private GeoCoordinates[] coordinatesArray;

        // Конструктор без параметров
        public GeoCoordinatesArray()
        {
            coordinatesArray = new GeoCoordinates[0];
        }

        // Конструктор с параметрами, принимающий массив GeoCoordinates
        public GeoCoordinatesArray(int count, Random rnd)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Количество элементов должно быть больше нуля.", nameof(count));
            }

            coordinatesArray = new GeoCoordinates[count];

            for (int i = 0; i < count; i++)
            {
                double latitude = rnd.NextDouble() * (90 - (-90)) + (-90); // Генерация случайной широты в диапазоне [-90, 90)
                double longitude = rnd.NextDouble() * (180 - (-180)) + (-180); // Генерация случайной долготы в диапазоне [-180, 180)
                coordinatesArray[i] = new GeoCoordinates(latitude, longitude);
            }
        }


        // Конструктор копирования
        public GeoCoordinatesArray(GeoCoordinatesArray original)
        {
            // Глубокое копирование массива
            coordinatesArray = new GeoCoordinates[original.coordinatesArray.Length];
            for (int i = 0; i < original.coordinatesArray.Length; i++)
            {
                coordinatesArray[i] = new GeoCoordinates(original.coordinatesArray[i].Latitude, original.coordinatesArray[i].Longitude);
            }
        }

        // Конструктор с параметрами, заполняющий массив элементами
        public GeoCoordinatesArray(uint count)
        {
            coordinatesArray = new GeoCoordinates[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите координаты для {i + 1} локации:");
                coordinatesArray[i] = new GeoCoordinates();
                bool flagLat = false;
                bool flagLon = false;
                while (flagLat != true)
                {
                    if (coordinatesArray[i].Latitude == 0.01) { coordinatesArray[i].Latitude = InputDoubleNumber("Широта: "); }
                    else flagLat = true;
                }
                while (flagLon != true)
                {
                    if (coordinatesArray[i].Longitude== 0.01) { coordinatesArray[i].Longitude = InputDoubleNumber("Долгота: "); }
                    else flagLon = true;
                }
            }
        }

        // Метод для просмотра элементов массива
        public void PrintLocations()
        {
            if (coordinatesArray.Length <= 0)
            {
                Console.WriteLine("Массив пуст.");
            }
            foreach (var coord in coordinatesArray)
            {
                Console.WriteLine($"Долгота: {coord.Latitude}, Широта: {coord.Longitude}");
            }
        }

        // Вспомогательный метод для ввода числа с клавиатуры
        private double InputDoubleNumber(string prompt)
        {
            double number;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка: Введите корректное число.");
                Console.Write(prompt);
            }
            return number;
        }
        // Индексатор для доступа к элементам коллекции
        public GeoCoordinates this[int index]
        {
            get
            {
                // Проверяем, не выходит ли индекс за пределы массива
                if (index < 0 || index >= coordinatesArray.Length)
                {
                    throw new IndexOutOfRangeException("Индекс находится вне диапазона допустимых значений.");
                }
                return coordinatesArray[index];
            }
            set
            {
                // Проверяем, не выходит ли индекс за пределы массива
                if (index < 0 || index >= coordinatesArray.Length)
                {
                    throw new IndexOutOfRangeException("Индекс находится вне диапазона допустимых значений.");
                }
                coordinatesArray[index] = value;
            }
        }
    }
}
