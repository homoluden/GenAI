using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Models
{
    using GenAI.Core;
    using GenAI.Core.Enums;
    using GenAI.Core.Interfaces;

    public abstract class BaseCharacter
    {
        #region Fields

        #endregion


        #region Properties

        public uint Health { get; set; }
        public uint MaxHealth 
        { 
            get
            {
                return Genes[GeneKey.Health];
            } 
        }

        public uint Stamina { get; set; }
        public uint MaxStamina
        {
            get
            {
                return Genes[GeneKey.Stamina];
            }
        }
        
        public uint Strength { get; set; }
        public uint Speed { get; set; }
        public uint MaxSpeed
        {
            get
            {
                return Genes[GeneKey.Speed];
            }
        }
        public uint MeleeAttack { get; set; }
        public uint RangedAttack { get; set; }
        public uint RangedAttackDistance { get; set; }
        public uint MeleeDefence { get; set; }
        public uint RangedDefence { get; set; }
        public Dictionary<GeneKey, uint> Genes { get; private set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Angle { get; set; }

        #endregion


        #region Ctors

        protected BaseCharacter(Dictionary<GeneKey, uint> genes)
        {
            Genes = genes;
            Health = genes[GeneKey.Health];
            Stamina = genes[GeneKey.Stamina];
            Speed = genes[GeneKey.Speed];

            Strength = genes[GeneKey.Strength];
            MeleeAttack = genes[GeneKey.MeleeAttack];
            MeleeDefence = genes[GeneKey.MeleeDefence];
            RangedAttack = genes[GeneKey.RangedAttack];
            RangedAttackDistance = genes[GeneKey.RangedAttackDistance];
            RangedDefence = genes[GeneKey.RangedDefence];
        }

        #endregion
    }
}
