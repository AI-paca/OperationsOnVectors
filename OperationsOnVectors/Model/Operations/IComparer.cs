using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OperationsOnVectors
{
    interface IComparer
    {
        double Compare(IVectorable vector1, IVectorable vector2);
    }
}
