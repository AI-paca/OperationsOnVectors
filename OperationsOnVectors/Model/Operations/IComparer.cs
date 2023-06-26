using System;
namespace OperationsOnVectors
{
    interface IComparer
    {
        double Compare(IVectorable vector1, IVectorable vector2);
    }
}
