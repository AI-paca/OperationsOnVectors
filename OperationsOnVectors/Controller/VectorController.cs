using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OperationsOnVectors.Model;
using OperationsOnVectors.View;

namespace OperationsOnVectors.Controller
{
    class VectorController
    {
            private VectorModel model = new VectorModel();
            //private VectorForm view = new VectorForm();       
            public void OnExit(){ model.Exit();}
            public string OnGetNorm(string str){return model.GetNorm(str).ToString();}
            public string OnGetLenght(string str) { return model.GetLenght(str).ToString(); }
            public string OnChangeByIndex(int index, double x, string str) { return model.ChangeByIndex(index, x, str); }
            public string OnGetByIndex(int index, string str) { return model.GetByIndex(index, str).ToString(); }
            public string OnNewVector(string str) { return model.NewVector(str); }

            public string OnAppendEndListVector(double x, string str)
            {
               return  model.AppendEndListVector(x, str);
            }
            public string OnAppendStartListVector(double x, string str)
            {
               return  model.AppendStartListVector(x, str);
            }
            public string OnAppendPointListVector(int index, double x, string str)
            {
               return  model.AppendPointListVector(index, x, str);
            }
            public string OnDelPointListVector(int index, string str)
            {
               return  model.DelPointListVector(index, str);
            }
            public string OnDelEndListVector(string str)
            {
               return  model.DelEndListVector(str);
            }
            public string OnDelStartListVector(string str)
            {
               return  model.DelStartListVector(str);
            }

            public string OnListVectorPrint()
            {
                return model.ListVectorPrint();
            }
            public string OnArrayVectorPrint()
            {
                return model.ArrayVectorPrint();
            }
            public string[] OnArrIVectorPrint()
            {
                return model.ArrIVectorPrint();
            }

            public void OnArrayVector() {
                model.FlagArrayVector();
            }
            public void OnListVector()
            {
                model.FlagListVector();
            }
            public string OnVectorSum(string v1, string v2)
            {
                return model.VectorSum(v1,v2);
            }
            public string OnVectorScalar(string v1, string v2)
            {
                return model.VectorScalar(v1, v2);
            }
            public string OnVectorEquals(string v1, string v2)
            {
                return model.VectorEquals(v1, v2);
            }
            public string OnLenEquals(string v1, string v2)
            {
                return model.LenEquals(v1, v2);
            }
            public string OnNornEquals(string v1, string v2)
            {
                return model.NornEquals(v1, v2);
            }
            public void OnAddVectorInList(string v)
            {
                model.AddVectorInList(v);
            }
           
            public string OnFind(){
                return model.Find();
            }
            public void OnFindFlag() {  model.FindFlag();}
            public void OnFindFlagFalse() {  model.FindFlagFalse();}
            public void OnMinFlag() {  model.MinFlag();}
            public void OnMinFlagFalse() {  model.MinFlagFalse(); }

            public void OnSortFlag()
            {
                model.SortFlag();
            }
            public void OnSortFlagFalse()
            {
                model.SortFlagFalse();
            }
            public void OnSort()
            {
                model.Sorting();
            }
    }
}
