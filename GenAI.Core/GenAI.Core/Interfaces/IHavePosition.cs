using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core.Interfaces
{
    public interface IHavePosition
    {
        double X { get; set; }
        double Y { get; set; }

        double Angle { get; set; }
    }
}
