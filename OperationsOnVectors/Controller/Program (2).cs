using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperationsOnVectors
{
    class Program2
    {
        delegate void ReturnVoid();//делегат без параметров, возвращающий void;
        delegate void MenuDelegate(ref ArrayVector vectorArr, ref LinkedListVector vectorList);
        static void Main(string[] args)
        {
            ReturnVoid rvoid = null;
            rvoid += PrintString;
            if (rvoid != null)
                rvoid.Invoke();

            LinkedListVector vectorList = new LinkedListVector();
            ArrayVector vectorArr = new ArrayVector();
            Console.WriteLine("\n1)Класс LinkedListVector\n2)Класс ArrayVector~\n3)Класс «Vectors»~\n4)Стандартные интерфейсы~\n");
            Console.WriteLine("Введите номера пунктов меню через запятую:");
            MenuDelegate menuDelegate = null;
            string[] menuItems = Console.ReadLine().Split(',');
            foreach (string menuItem in menuItems)
            {
                switch (menuItem.Trim())
                {
                    case "1":
                        menuDelegate += ClassLinkedListVector;
                        break;
                    case "2":
                        menuDelegate += ClassArrayVector;
                        break;
                    case "3":
                        menuDelegate += ClassVectors;
                        break;
                    case "4":
                        menuDelegate += StandardInterfaces;
                        break;
                }
            }
            if (menuDelegate != null)
                menuDelegate.Invoke(ref vectorArr,ref  vectorList);
        }
        static void ClassLinkedListVector(ref ArrayVector vectorArr,ref LinkedListVector vectorList)
            {
            string[] menuItems1 = new string[] {"~Класс LinkedListVector~", "LinkedListVector()",
                "LinkedListVector (n)", "GetNorm for List","SetElemen on List","GetElement on List", "Length for List","SetAllElements", "AppendEnd", "AppendStart", "DelEnd", "DelStart"};
            
            while (true)
            {
                switch (Menu.Case(menuItems1))
                {
                    case 0: return;
                    case 1: vectorList = new LinkedListVector();break;
                    case 2: Console.WriteLine("Введите размерность пространства"); vectorList = new LinkedListVector(int.Parse(Console.ReadLine())); break;
                    case 3: Console.WriteLine(vectorList.GetNorm()); break;
                    case 4: Console.WriteLine("Введите номер редактируемого измерения"); int d = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите координату {0}-го измерения", d); vectorList[d] = double.Parse(Console.ReadLine()); break;
                    case 5: Console.WriteLine("Введите номер искомого измерения");
                        try { Console.WriteLine("Координата вектора\n{0}", vectorList[int.Parse(Console.ReadLine())]); }
                        catch (IndexOutOfRangeException) { Console.WriteLine("Ошибка, данного измерения не существует"); }; break;
                    case 6: Console.WriteLine(vectorList.Length); break;
                    case 7: vectorList = new LinkedListVector(0); Console.Clear(); Console.WriteLine("Введите координаты вектора");
                        string str = Console.ReadLine(); do { try { vectorList.AppendEnd(double.Parse(str)); } catch { break; } str = Console.ReadLine(); } while (true);
                        vectorList.DelStart(); break;
                    case 8: Console.WriteLine("Введите координату вектора"); vectorList.AppendEnd(double.Parse(Console.ReadLine())); break;
                    case 9: Console.WriteLine("Введите координату вектора"); vectorList.AppendStart(double.Parse(Console.ReadLine())); break;
                    case 10: vectorList.DelEnd();break;
                    case 11: vectorList.DelStart();break;
                }
                Console.WriteLine("VectorList: " + vectorList.ToString());
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void ClassArrayVector(ref ArrayVector vectorArr, ref LinkedListVector vectorList)
            {
            string[] menuItems2 = new string[] {"~Класс ArrayVector~", "ArrayVector()", "ArrayVector(n)", "GetNorm", "SetElemen","GetElement",  "Length","SetAllElements"};
            while (true)
                    {
                    switch (Menu.Case(menuItems2))
                    {
                        case 0: return;
                        case 1: vectorArr = new ArrayVector(); break;
                        case 2: Console.WriteLine("Введите размерность пространства"); vectorArr = new ArrayVector(int.Parse(Console.ReadLine())); break;
                        case 3: Console.WriteLine(vectorArr.GetNorm()); break;
                        case 4: Console.WriteLine("Введите номер редактируемого измерения"); int c = int.Parse(Console.ReadLine()); Console.WriteLine("Введите координату вектора");
                            try { vectorArr[c - 1] = double.Parse(Console.ReadLine()); }
                            catch (IndexOutOfRangeException) { Console.WriteLine("Ошибка, данного измерения не существует");} break;
                        case 5: Console.WriteLine("Введите номер искомого измерения");
                            try { Console.WriteLine("Координата вектора\n{0}", vectorArr[int.Parse(Console.ReadLine()) - 1]); }
                            catch (IndexOutOfRangeException) { Console.WriteLine("Ошибка, данного измерения не существует"); }; break;
                        case 6: Console.WriteLine(vectorArr.Length); break;
                        case 7: Console.WriteLine("Введите размерность пространства вектора");
                            vectorArr = new ArrayVector(int.Parse(Console.ReadLine())); Console.Clear();
                            for (int i = 0; i < vectorArr.Length; i++) { Console.WriteLine("Введите координату {0}-го измерения", i + 1); vectorArr[i] = double.Parse(Console.ReadLine()); } break;
                    }
                    Console.WriteLine("VectorArr: " + vectorArr.ToString());
                    Console.WriteLine("\nPress any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        static void ClassVectors(ref ArrayVector vectorArr, ref LinkedListVector vectorList)
        {
            string[] menuItems3 = new string[] { "~Класс «Vectors»~", "Vectors Sum", "Vectors Scalar", "Vectors GetNorm"};
            while (true)
            {
                switch (Menu.Case(menuItems3))
                {
                    case 0: return;
                    //сложить массив и вектор
                    case 1: 
                        try { Console.WriteLine((Vectors.Sum(vectorArr, vectorList)).ToString()); break; }
                        catch (FormatException) { Console.WriteLine("Ошибка, размерность векторов различна", vectorArr.Length); break; };
                    case 2: Console.WriteLine(Vectors.Scalar(vectorArr, vectorList)); break;
                    case 3: Console.WriteLine(Vectors.GetNorm(vectorArr)); break;
                }
                Console.WriteLine("VectorList: " + vectorList.ToString());
                Console.WriteLine("VectorArr: " + vectorArr.ToString());
                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void StandardInterfaces(ref ArrayVector vectorArr, ref LinkedListVector vectorList)
    {
        List<IVectorable> arrIVector = new List<IVectorable>();
        ComparerClass compareVector = new ComparerClass();
        ArrayVector newVector = new ArrayVector(0);
        bool flagIVectorList = false;
        string[] menuItems4 = new string[] { "~Стандартные интерфейсы~", "Equals", "CompareTo", "Compare", "IVectorable array", "min IVectorable by len", "max IVectorable by len", "Sort by norm (up)", "Clone", "Change clone vector"};
        while (true)
        {
            switch (Menu.Case(menuItems4))
            {
                case 0: return;
                case 1: //Equals
                    Console.WriteLine(vectorList.Equals(vectorArr)); 
                    Console.WriteLine("VectorList: " + vectorList.ToString());
                    Console.WriteLine("VectorArr: " + vectorArr.ToString());
                    break;
                case 2: //CompareTo
                    if (vectorArr.CompareTo(vectorList) < 0)
                        Console.WriteLine("MoreByLengthVector: " + vectorArr);
                    else
                        Console.WriteLine("MoreByLengthVector: " + vectorList);
                    Console.WriteLine("VectorList: " + vectorList.ToString());
                    Console.WriteLine("VectorArr: " + vectorArr.ToString());
                    break;
                case 3: //Compare() сравнивает два вектора типа IVectorable по их модулю
                    if (compareVector.Compare(vectorArr, vectorList) > 0)
                        Console.WriteLine("MoreByNormVector: " + vectorArr);
                    else
                        Console.WriteLine("MoreByNormVector: " + vectorList);
                    Console.WriteLine("VectorList: " + vectorList.ToString());
                    Console.WriteLine("VectorArr: " + vectorArr.ToString());
                    break;
                case 4://создать массив векторов (ссылок типа интерфейс)
                    arrIVector = IVectorAdd(arrIVector);
                    Console.Clear();
                    //flagIVectorList = true;
                    break;
                case 5: //min IVectorable by len
                    IVectorable min = arrIVector[arrIVector.Count - 1];
                    for (int i = 0; i < arrIVector.Count; i++)
                        if (min.CompareTo(arrIVector[i]) < 0)
                            min = arrIVector[i];
                    for (int i = 0; i < arrIVector.Count; i++)
                        if (min.Length == arrIVector[i].Length)
                            Console.WriteLine(arrIVector[i].ToString());
                    flagIVectorList = true; break;
                case 6: //max IVectorable by len
                    IVectorable max = arrIVector[arrIVector.Count - 1];
                    for (int i = 0; i < arrIVector.Count; i++)
                        if (max.CompareTo(arrIVector[i]) > 0)
                            max = arrIVector[i];
                    for (int i = 0; i < arrIVector.Count; i++)
                        if (max.Length == arrIVector[i].Length)
                            Console.WriteLine(arrIVector[i].ToString());
                    flagIVectorList = true; break;
                case 7: //Отсортировать массив векторов по возрастанию их модулей
                    for (int i = 1; i < arrIVector.Count; i++)
                    {
                        IVectorable temp = arrIVector[i];
                        int j = i - 1;
                        while (j >= 0 && (compareVector.Compare(arrIVector[j], temp) > 0))
                        {
                            arrIVector[j + 1] = arrIVector[j];
                            j -= 1;
                        }
                        arrIVector[j + 1] = temp;
                    }
                    flagIVectorList = true; break;
                case 8: //Clone
                    if (arrIVector.Count != 0)
                    {
                        Console.WriteLine("Укажите номер клонируемого вектора");
                        for (int i = 0; i < arrIVector.Count; i++)
                            Console.WriteLine(i + ". " + arrIVector[i].ToString());
                        newVector.Clone(arrIVector[int.Parse(Console.ReadLine())]);
                        Console.WriteLine(newVector.ToString());
                    }
                    else
                        Console.WriteLine("Массив векторов не найден");
                    break;
                case 9: //продемонстрировать результат клонирования 
                    Console.WriteLine(newVector.ToString());
                    Console.WriteLine("Введите номер редактируемого измерения");
                    int g = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите координату {0}-го измерения", g);
                    newVector[g] = double.Parse(Console.ReadLine());
                    Console.WriteLine("Измененный вектор:\n" + newVector.ToString());
                    flagIVectorList = true; break;
            }
            if (flagIVectorList)
            {
                Console.WriteLine("\nArrIVector:");
                for (int i = 0; i < arrIVector.Count; i++)
                    Console.WriteLine(arrIVector[i].ToString());
                flagIVectorList = false;
            }
            Console.WriteLine("\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
        static void PrintString(){ Console.WriteLine("делегат без параметров, метод возвращающий void был вызван");}
        static List<IVectorable> IVectorAdd(List<IVectorable> arrIVector)//ввод массива элементов типа IVectorable
        {
            string[] menuItems2 = new string[] { "Выберите тип вектора:","ArrayVector", "LinkedListVector"};
            while (true){
                switch (Menu.Case(menuItems2))
                {
                    case 0:
                        return arrIVector;
                    case 1:
                        Console.WriteLine("Введите размерность пространства вектора");
                        ArrayVector vectorArr = new ArrayVector(int.Parse(Console.ReadLine()));
                        Console.Clear();
                        for (int i = 0; i < vectorArr.Length; i++)
                        {
                            Console.WriteLine("Введите координату {0}-го измерения", i + 1);
                            vectorArr[i] = double.Parse(Console.ReadLine());
                        }
                        arrIVector.Add(vectorArr);
                        break;
                    case 2:
                        LinkedListVector vectorList = new LinkedListVector(0);
                        Console.Clear();
                        Console.WriteLine("Введите координаты вектора");
                        string str = Console.ReadLine();
                        do { try { vectorList.AppendEnd(double.Parse(str)); }
                        catch { break; } str = Console.ReadLine(); } while (true);
                        vectorList.DelStart();
                        arrIVector.Add(vectorList);
                        break;
                }
                Console.WriteLine("\nArrIVector:");
                for (int i = 0; i < arrIVector.Count; i++)
                    Console.WriteLine(arrIVector[i].ToString());
                Console.WriteLine("\nPress any key to continue");
                Console.WriteLine("Press ESC to return to the menu");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
    class Menu
{
    private static void DrawMenu(string[] items, int index /*,int menu_width*/)
    //фронт
    {
        Console.Clear();Console.WriteLine("6104-020302 Аверкина В.О. ЛР03-Перечисления");
        for (int i = 0; i < items.Length; i++)
        {
            if (i == index)
            {
                Console.BackgroundColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.SetCursorPosition(/*menu_width,*/Console.WindowLeft, Console.WindowHeight / 2 + i - 4);
            Console.WriteLine(items[i]);
            Console.ResetColor();
        }
    }
    public static int Case(string[] menuItems)
    {
        int index = 1;
        while (true)
        {
            DrawMenu(menuItems, index);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.DownArrow:
                    if (index < menuItems.Length - 1)
                        index++;
                    break;
                case ConsoleKey.UpArrow:
                    if (index > 0)
                        index--;
                    break;
                case ConsoleKey.Escape:
                    return 0;
                case ConsoleKey.Enter:
                    switch (index)
                    {
                        default:
                            Console.Clear();
                            return index;
                    }
            }
        }
    }
}

}
