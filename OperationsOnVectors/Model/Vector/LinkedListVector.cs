using System;

namespace OperationsOnVectors
{
    //class LinkListVector
    class LinkedListVector : IVectorable, IComparable, ICloneable
    {              
        public int Length { get { return _len; } } // свойство для чтения числа координат вектора
        public double this[int index]// индексатор для организации доступа к элементам массива, выбрасывающий исключения при некорректном индексе;
        {
            get
            {
                if (index < 0)
                    throw new IndexOutOfRangeException();
                else if (index > _len)
                    return 0;
                Node end = _start;
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
        Node _start;
        int _len;

        public LinkedListVector (int n)
        // конструктор с параметром – длиной массива;
        {   _len = 1;
            _start = new Node();
            Console.WriteLine("{0}",_start.el);
            Console.WriteLine("{0}",_start.nextEl);
            for (int i = 0; i < n-1; i++)
                AppendEnd(0);}
        public LinkedListVector()
        // конструктор без параметра, задающий длину списка 5;
        {
            _len = 1;
            _start = new Node();
            Console.WriteLine("{0}", _start.el);
            Console.WriteLine("{0}", _start.nextEl);
            for (int i = 0; i < 5 - 1; i++)
                AppendEnd(0);
        }
        public LinkedListVector(String str)
        {
            _len = 1;
            _start = new Node();
            String[] _parts = str.Split(' ');
            for (int i = 0; i < _parts.Length; i++)
            {
                AppendEnd(double.Parse(_parts[i]));
            }
            DelStart();
        }

        public double GetNorm()
        //метод получения модуля (длины, нормы) вектора ;
        {
            double _norm = 0;
            Node _end = _start;
            _norm = _end.el * _end.el + _norm;
            do{ _end = _end.nextEl;
                if (_end!=null)
                    _norm = _end.el * _end.el + _norm;
            } while (_end!=null && _end.nextEl != null);
            return Math.Sqrt(_norm);
        }        

        public void AppendEnd(double data)
        //методы добавления элемента в конец;
        {   Node _newEnd = new Node();
            _newEnd.el = data;
            Node _end = _start;
            while ( _end.nextEl != null){
                _end = _end.nextEl;}
            _end.nextEl = _newEnd;
            _len++; }
        public void AppendStart(double data)
        //методы добавления элемента в начало;
        {   Node _new_start = new Node();
            _new_start.el=data;
            _new_start.nextEl = _start;
            _start = _new_start;
            _len++;}
        public void AppendPoint(double data, int point)
        //методы добавления элемента в заданную позицию.
        {
            if (point <= 1)
                AppendStart(data);
            else if (point <= _len)
            {
                Node _newPoint = new Node();
                _newPoint.el = data;
                Node _end = _start;
                for (int i = 1; i < point - 1; i++)
                    _end = _end.nextEl;
                _newPoint.nextEl = _end.nextEl;
                _end.nextEl = _newPoint;
                _len++;
            }
            else
                AppendEnd(data);
        }
        public void DelEnd()
        //методы удаления элемента в конец;
        {   Node _end = _start;
            while (_end.nextEl != null)
                _end = _end.nextEl;
            _end.nextEl = null;
            _len--; }
        public void DelStart()
        //методы удаления элемента в начало;
        {   _start = _start.nextEl;
            _len--; }        
        public void DelPoint(int point)
        //методы удаления элемента в заданную позицию.
        {
            if (point <= 1)
                DelStart();
            else if (point <= _len)
            {
                Node _end = _start;
                for (int i = 1; i < point - 1; i++)
                    _end = _end.nextEl;
                _end.nextEl = (_end.nextEl).nextEl;
                _len--;
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
            if (v1.Length != _len)
                return false;
            for (int i = 0; i < _len; i++)
            {
                if (v1[i] != this[i])
                    return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            int hash = 17;//17 - простое число
            for (int i = 0; i < _len; i++)
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