using System;

namespace OperationsOnVectors
{
    //class ArrayVector      
    class ArrayVector : IVectorable, IComparable, ICloneable
    {
        public int Length { get { return arr.Length; } } // свойство для чтения числа координат вектора
        public double[] arr; // поле – массив элементов целого типа (координаты вектора в пространстве);
        public double this[int index]
        // индексатор для организации доступа к элементам массива, выбрасывающий исключения при некорректном индексе;
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException();
                else if (index >= arr.Length)
                    return 0;
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }

        }        

        public double GetNorm()
        //метод получения модуля (длины, нормы) вектора ;
        {
            double _norm = 0;
            for (int i = 0; i < arr.Length; i++)
                _norm = arr[i] * arr[i] + _norm;
            return Math.Sqrt(_norm);
        }

        public ArrayVector(int n)
        // конструктор с параметром – длиной массива;
        {
            arr = new double[n];
        }
        public ArrayVector()
        //конструктор без параметров, создающий массив из 5 элементов;
        {
            arr = new double[5];
        }
        public ArrayVector(string str)
        {
            String[] _arr_str = str.Split(' ');
            arr = new double[_arr_str.Length];
            for (int i = 0; i < _arr_str.Length; i++)
            {
                arr[i] = double.Parse(_arr_str[i]);
            }
        }

        public override string ToString() //override - переопределить метод ToString(), который преобразует вектор в строку формата «<число координат вектора><пробел> <координаты вектора через пробел>»
        //public new string ToString() //создать  новой версии метода ToString() 
        {
            string split = "";
            //string split = Length.ToString();
            for (int i = 0; i < Length; i++)
            {
                if (i == 0)
                    split += this[i].ToString();
                else
                    split += " " + this[i].ToString();
            }
            return split;
        }
        public override bool Equals(object obj)//метод Equals() сравнение на равенство любой объект интерфейса IVectorable
        {
            IVectorable v1 = (IVectorable)obj;
            if (v1.Length != arr.Length)
                return false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (v1[i] != arr[i])
                    return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 17;//17 - простое число
            for (int i = 0; i < arr.Length; i++)
                hash = hash * 23 + arr[i].GetHashCode(); //23 - простое число
            return hash;
        }
        public int CompareTo(IVectorable v1)  //метод сравнивает вектора типа IVectorable по числу их координат
        {
            return v1.Length - Length;
        }
        public void Clone(IVectorable v2)  //метод выполняющий глубокое клонирование объектов
        {
            arr = new double[v2.Length];
            for (int i = 0; i < v2.Length; i++)
            {
                arr[i] = v2[i];
            }
        }
    }
}

 
