using System;

namespace OperationsOnVectors
{
    // Интерфейс "IVectorable"
    interface IVectorable : IComparable
    {
        double this[int index] { get; set; } // Индексатор для организации доступа к элементам массива
        int Length { get; } // Свойство для чтения числа координат вектора
        double GetNorm(); // Метод получения модуля вектора
        string ToString();// используется для вывода суммы типа IVectorable(класс Vectors)
    }
}
