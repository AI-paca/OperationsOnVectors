using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperationsOnVectors
{
    //class LinkListVector
    class LinkedListVector : IVectorable, IComparable, ICloneable
    {              
        public int Length { get { return len; } } // свойство для чтения числа координат вектора
        public double this[int index]// индексатор для организации доступа к элементам массива, выбрасывающий исключения при некорректном индексе;
        {
            get
            {
                if (index < 0 || index > len)
                    throw new IndexOutOfRangeException();
                Node end = start;
                for (int i = 0; i < index; i++)
                    end = end.nextEl;
                return end.el;
            }
            set { AppendPoint(value, index); }

        }
        class Node  
        //динамический список
        { 
            internal double el = 0;//поле – элемент вещественного типа (по умолчанию = 0);
            internal Node nextEl = null;//поле – ссылка на элемент класса Node (по умолчанию = null);
        }
        Node start;
        int len;
        public LinkedListVector (int n)
        // конструктор с параметром – длиной массива;
        {   len = 1;
            start = new Node();
            Console.WriteLine("{0}",start.el);
            Console.WriteLine("{0}",start.nextEl);
            for (int i = 0; i < n-1; i++)
                AppendEnd(0);}
        public LinkedListVector()
        // конструктор без параметра, задающий длину списка 5;
        {
            len = 1;
            start = new Node();
            Console.WriteLine("{0}", start.el);
            Console.WriteLine("{0}", start.nextEl);
            for (int i = 0; i < 5 - 1; i++)
                AppendEnd(0);
        }
        public double GetNorm()
        //метод получения модуля (длины, нормы) вектора ;
        {
            double norm = 0;
            Node end = start;
            norm = end.el * end.el + norm;
            do{ end = end.nextEl;
                if (end!=null)
                    norm = end.el * end.el + norm;
            } while (end!=null && end.nextEl != null);
            return Math.Sqrt(norm);
        }        
        public void AppendEnd(double data)
        //методы добавления элемента в конец;
        {   Node newEnd = new Node();
            newEnd.el = data;
            Node end = start;
            while ( end.nextEl != null){
                end = end.nextEl;}
            end.nextEl = newEnd;
            len++; }
        public void AppendStart(double data)
        //методы добавления элемента в начало;
        {   Node new_start = new Node();
            new_start.el=data;
            new_start.nextEl = start;
            start = new_start;
            len++;}
        public void DelEnd()
        //методы удаления элемента в конец;
        {   Node end = start;
            while (end.nextEl != null)
                end = end.nextEl;
            end.nextEl = null;
            len--; }
        public void DelStart()
        //методы удаления элемента в начало;
        {   start = start.nextEl;
            len--; }
        public void AppendPoint(double data, int point)
        //методы добавления элемента в заданную позицию.
        {
            if (point <= 1)
                AppendStart(data);
            else if (point <= len)
            {
                Node newPoint = new Node();
                newPoint.el = data;
                Node end = start;
                for (int i = 1; i < point - 1; i++)
                    end = end.nextEl;
                newPoint.nextEl = end.nextEl;
                end.nextEl = newPoint;
                len++;
            }
            else
                AppendEnd(data);
        }
        public void DelPoint(int point)
        //методы удаления элемента в заданную позицию.
        {
            if (point <= 1)
                DelStart();
            else if (point <= len)
            {
                Node end = start;
                for (int i = 1; i < point - 1; i++)
                    end = end.nextEl;
                end.nextEl = (end.nextEl).nextEl;
                len--;
            }
            else
                DelEnd();
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
            if (v1.Length != len)
                return false;
            for (int i = 0; i < len; i++)
            {
                if (v1[i] != this[i])
                    return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 17;//17 - простое число
            for (int i = 0; i < len; i++)
                hash = hash * 23 + this[i].GetHashCode(); //23 - простое число
            return hash;
        }
        public int CompareTo(IVectorable v1)  //метод сравнивает вектора типа IVectorable по числу их координат
        {
            return v1.Length - Length;
        }
        public void Clone(IVectorable v2)  //метод выполняющий глубокое клонирование объектов
        {
            for (int i = 0; i < v2.Length; i++)
            {
                this[i] = v2[i];
            }
        }
        public LinkedListVector(String str)
        {
            len = 1;
            start = new Node();
            String[] parts = str.Split(' ');
            for (int i = 0; i < parts.Length; i++)
            {
                AppendEnd(double.Parse(parts[i])); 
            }
            DelStart();
        }
    }
}   