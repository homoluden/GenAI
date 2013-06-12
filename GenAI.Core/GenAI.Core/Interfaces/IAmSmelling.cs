using GenAI.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core.Interfaces
{
    public interface IAmSmelling
    {
        Scent Scent { get; }
        uint ScentStrength { get; }
        double GetDirection(IHavePosition fromOther);
    }
}
