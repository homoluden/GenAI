using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core.Interfaces
{
    public interface IAmAlive
    {
        uint Health { get; set; }
        uint MaxHealth { get; set; }
        uint Fatigue { get; set; }
        uint Strength { get; set; }
        uint MaxSpeed { get; set; }
        uint MeleeAttack { get; set; }
        uint RangedAttack { get; set; }
        uint RangedAttackDistance { get; set; }
        uint MeleeDefence { get; set; }
        uint RangedDefence { get; set; }
    }
}
