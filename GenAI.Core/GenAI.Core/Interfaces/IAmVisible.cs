using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core.Interfaces
{
    public interface IAmVisible
    {
        uint Speed { get; }
        uint Danger { get; }
        uint MeleeDefence { get; }
        uint RangedDefence { get; }
        uint Food { get; }
        uint Visibility { get; }        
    }
}
