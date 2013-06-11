using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core.Interfaces
{
    using GenAI.Core.Enums;

    public interface IAmAlive
    {
        uint Health { get; set; }
        uint MaxHealth { get; }
        uint Stamina { get; set; }
        uint MaxStamina { get; }
        uint Strength { get; set; }
        uint Speed { get; set; }
        uint MaxSpeed { get; }
        uint MeleeAttack { get; set; }
        uint RangedAttack { get; set; }
        uint RangedAttackDistance { get; set; }
        uint MeleeDefence { get; set; }
        uint RangedDefence { get; set; }
        Dictionary<GeneKey, uint> Genes { get; }
    }
}
