using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperationsOnVectors
{
    interface IComparable
    {
        int CompareTo(IVectorable vector);
    }
}
