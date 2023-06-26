using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperationsOnVectors.Model
{
    class VectorModel
    {  
        LinkedListVector vectorList = new LinkedListVector();
        LinkedListVector temp = new LinkedListVector();
        ComparerClass compareVector = new ComparerClass();
        ArrayVector vectorArr = new ArrayVector();
        bool vector_arr = false;
        bool vector_list = false;
        List<LinkedListVector> arrIVector = new List<LinkedListVector>();
        int list_vectorable = -1;

        public delegate void VectorModelDelegate(VectorModel model);

        public void Exit()  {return;}
        public double GetNorm(string v){
            temp = new LinkedListVector(v);
            return  temp.GetNorm(); }
        public int GetLenght(string v){
            temp = new LinkedListVector(v);
            return temp.Length;}
        public string ChangeByIndex(int d, double x, string v){
            if (list_vectorable != -1 )
                arrIVector[list_vectorable][d] = x;
            else if (vector_arr)
                vectorArr[d] = x;
            else if (vector_list)
                vectorList[d] = x;
            temp = new LinkedListVector(v);
            temp[d] = x;
            return temp.ToString();
            //Console.WriteLine("Введите номер редактируемого измерения");
            //int d = int.Parse(Console.ReadLine());
            //Console.WriteLine("Введите координату {0}-го измерения", d);
            //vectorList[d] = double.Parse(Console.ReadLine());
        }
        public string GetByIndex(int d, string v){
            temp = new LinkedListVector(v);
            try { return "Координата вектора\n{0}" + temp[d]; }
            catch (IndexOutOfRangeException) { return "Ошибка, данного измерения не существует"; }}

        public string NewVector(string str){
            if (vector_arr){
                vectorArr = new ArrayVector(str);
                return vectorArr.ToString();}
            else if (vector_list){
                vectorList = new LinkedListVector(str);
                return vectorList.ToString();}
            else{
                temp = new LinkedListVector(str);
                return temp.ToString();
            }
        }
        public string AppendEndListVector(double x, string v){
            //Console.WriteLine("Введите координату вектора");
            if (list_vectorable != -1 )
                arrIVector[list_vectorable].AppendEnd(x);
            else if (vector_list)
                vectorList.AppendEnd(x);
            temp = new LinkedListVector(v);
            temp.AppendEnd(x);
            return temp.ToString();
        }
        public string AppendStartListVector(double x, string v){
            //Console.WriteLine("Введите координату вектора");
            if (list_vectorable != -1 )
                arrIVector[list_vectorable].AppendStart(x);
            else if (vector_list)
                vectorList.AppendStart(x);
            temp = new LinkedListVector(v);
            temp.AppendStart(x);
            return temp.ToString();}
        public string AppendPointListVector(int d, double x, string v){
            //Console.WriteLine("Введите координату вектора");
            if (list_vectorable != -1 )
                arrIVector[list_vectorable].AppendPoint(x, d);
            else if (vector_list)
                vectorList.AppendPoint(x, d);        
            temp = new LinkedListVector(v);
            temp.AppendPoint(x, d);
            return temp.ToString();}
        public string DelPointListVector(int d, string v){
            if (list_vectorable != -1 )
                arrIVector[list_vectorable].DelPoint(d);
            else if (vector_list)
                vectorList.DelPoint(d);
            temp = new LinkedListVector(v);
            temp.DelPoint(d); 
            return temp.ToString();
        }
        public string DelEndListVector(string v){
            if (list_vectorable != -1 )
                arrIVector[list_vectorable].DelEnd();
            else if (vector_list)
                vectorList.DelEnd();
            temp = new LinkedListVector(v);
            temp.DelEnd(); return temp.ToString();
        }
        public string DelStartListVector(string v){
            if (list_vectorable != -1 )
                arrIVector[list_vectorable].DelStart();
            else if (vector_list)
                vectorList.DelStart();
            temp = new LinkedListVector(v);
            temp.DelStart(); return temp.ToString();
        }

        public string ListVectorPrint()
        {
            return vectorList.ToString();
        }
        public string ArrayVectorPrint()
        {
            return vectorArr.ToString();
        }

        public void FlagArrayVector()
        { 
            vector_arr = true;
            vector_list = false;
        }
        public void FlagListVector()
        {
            vector_arr = false;
            vector_list = true;
        }

        public string VectorSum(string v1, string v2)
        {
            return Vectors.Sum(new ArrayVector(v1), new ArrayVector(v2)).ToString();
        }
        public string VectorScalar(string v1, string v2)
        {
            return Vectors.Scalar(new ArrayVector(v1), new ArrayVector(v2)).ToString();
        }
        public string VectorEquals(string v1, string v2)
        {
            return (new ArrayVector(v1)).Equals(new ArrayVector(v2)).ToString();
        }
        public string LenEquals(string v1, string v2)
        {
            return (new ArrayVector(v1)).CompareTo(new ArrayVector(v2)).ToString();
        }
        public string NornEquals(string v1, string v2)
        {
            if  (compareVector.Compare(new ArrayVector(v1), new ArrayVector(v2))>0)
                    return "MoreByNormVector: " + v1;
            else
                    return "MoreByNormVector: " + v2;
        }
        public void AddVectorInList(string v)
        {
           temp = new LinkedListVector(v);
           arrIVector.Add(temp);
        }
        public string[] ArrIVectorPrint()
        {
            string[] stringArray = new string[arrIVector.Count];
            for (int i = 0; i < stringArray.Length; i++)
                stringArray[i] += arrIVector[i].ToString();
            return stringArray;
        }

        bool find_len;
        public void FindFlag() { find_len = true; }
        public void FindFlagFalse() { find_len = false; }
        bool min_flag;
        public void MinFlag() { min_flag = true; }
        public void MinFlagFalse() { min_flag = false; }
        public string Find() {
            string split = "";
            if (find_len && min_flag)
            {
                IVectorable min = arrIVector[arrIVector.Count - 1];
                for (int i = 0; i < arrIVector.Count; i++)
                    if (min.CompareTo(arrIVector[i]) < 0)
                        min = arrIVector[i];
                for (int i = 0; i < arrIVector.Count; i++)
                    if (min.Length == arrIVector[i].Length)
                        split = split + "\n" + arrIVector[i].ToString();
            }
            else if (find_len && (min_flag == false))
            {
                IVectorable max = arrIVector[arrIVector.Count - 1];
                for (int i = 0; i < arrIVector.Count; i++)
                    if (max.CompareTo(arrIVector[i]) > 0)
                        max = arrIVector[i];
                for (int i = 0; i < arrIVector.Count; i++)
                    if (max.Length == arrIVector[i].Length)
                        split = split + "\n" + arrIVector[i].ToString();
            }
            else if ((find_len == false) && min_flag)
            {
                IVectorable min = arrIVector[arrIVector.Count - 1];
                for (int i = 0; i < arrIVector.Count; i++)
                    if (compareVector.Compare(min, arrIVector[i]) > 0)
                        min = arrIVector[i];
                for (int i = 0; i < arrIVector.Count; i++)
                    if (min.GetNorm() == arrIVector[i].GetNorm())
                        split = split + "\n" + arrIVector[i].ToString();
            }
            else if ((find_len == false) && (min_flag == false))
            {
                IVectorable max = arrIVector[arrIVector.Count - 1];
                for (int i = 0; i < arrIVector.Count; i++)
                    if (compareVector.Compare(max,arrIVector[i]) < 0)
                        max = arrIVector[i];
                for (int i = 0; i < arrIVector.Count; i++)
                    if (max.GetNorm() == arrIVector[i].GetNorm())
                        split = split + "\n" + arrIVector[i].ToString();
            }
        return split;
        }

        bool sort_len_flag;
        public void SortFlag()
        {
            sort_len_flag = true;
        }
        public void SortFlagFalse()
        {
            sort_len_flag = false;
        }
        public void Sorting()
        {
            if (sort_len_flag == false)
                for (int i = 1; i < arrIVector.Count; i++)
                {

                    LinkedListVector temp_v = arrIVector[i];
                    int j = i - 1;
                    while (j >= 0 && (compareVector.Compare(arrIVector[j], temp_v) > 0))
                    {
                        arrIVector[j + 1] = arrIVector[j];
                        j -= 1;
                    }
                    arrIVector[j + 1] = temp_v;
                }
            else
                for (int i = 1; i < arrIVector.Count; i++)
                {
                    LinkedListVector temp_v = arrIVector[i];
                    int j = i - 1;
                    while (j >= 0 && temp_v.CompareTo(arrIVector[j]) > 0)
                    {
                        arrIVector[j + 1] = arrIVector[j];
                        j -= 1;
                    }
                    arrIVector[j + 1] = temp_v;
                }
        }
    
    }
//все Console.WriteLine в контроллер 
}