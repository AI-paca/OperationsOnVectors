﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperationsOnVectors
{
    interface ICloneable
    {
        void Clone(IVectorable v2);
    }
}
//Сделать классы ArrayVector и LinkListVector реализующими интерфейс ICloneable и
//реализовать в них метод Clone(), выполняющий глубокое клонирование объектов. В
//методе Main() класса Program выбрать один из векторов в массиве, выполнить его
//клонирование, продемонстрировать результат клонирования (например, изменив один из
//векторов – клонируемый или клон – и вывести на экран оба вектора для сравнения,
//возможно также использование метода Equals()).