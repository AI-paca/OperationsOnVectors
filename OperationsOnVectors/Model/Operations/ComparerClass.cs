using System;

namespace OperationsOnVectors
{
    class ComparerClass: IComparer
    {
        public double Compare(IVectorable v1, IVectorable v2)
        {
            return v1.GetNorm() - v2.GetNorm();
        }
    }
}
