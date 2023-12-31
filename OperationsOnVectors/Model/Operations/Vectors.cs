﻿using System;

namespace OperationsOnVectors
{
    class Vectors
    {
        static public IVectorable Sum(IVectorable v1, IVectorable v2)
        //сложения двух векторов Sum
        {           
            IVectorable v3 = new ArrayVector(Math.Max(v1.Length, v2.Length));
            for (int i = 0; i < v3.Length; i++)
                v3[i] = v2[i] + v1[i];
            return v3;
        }
        static public IVectorable Sub(IVectorable v1, IVectorable v2)
        //разность двух векторов
        {
            IVectorable v3 = new ArrayVector(Math.Max(v1.Length, v2.Length));
            for (int i = 0; i < v3.Length; i++)
                v3[i] = v1[i] - v2[i];
            return v3;
        }
        static public double Scalar(IVectorable v1, IVectorable v2)
        //скалярное произведение двух векторов
        {
            if (v2.Length != v1.Length)
                throw new FormatException();
            double num = 0;
            for (int i = 0; i < v1.Length; i++)
                num = v2[i] * v1[i] + num;
            return num;
        }
        static public double GetNorm(IVectorable v1)
        //получения модуля (длины) вектора GetNorm (возвращает вещественное число);
        {
            double norm = 0;
            for (int i = 0; i < v1.Length; i++)
                norm = v1[i] * v1[i] + norm;
            return Math.Sqrt(norm);
        }
    }
}