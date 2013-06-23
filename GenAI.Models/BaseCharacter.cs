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
using Stateless;

    public abstract class BaseCharacter
    {
        #region Constants
        public abstract static readonly Goal[] GOALS_LOOKUP_TABLE;
        public abstract static readonly Dictionary<Goal, byte> GOAL_PRIORITIES;
        #endregion


        #region Fields

        uint _health;
        uint _stamina;
        uint _speed;

        #endregion


        #region Properties
        
        public Dictionary<GeneKey, uint> Genes { get; private set; }

        public abstract StateMachine<Goal, GoalTrigger> MainGoal { get; set; }
        
        #region Base Specs

        public uint Size
        {
            get
            {
                return Genes[GeneKey.Size];
            }
        }

        public uint Health 
        {
            get { return _health; }
            set { _health = Math.Min(value, MaxHealth); }
        }
        public uint MaxHealth 
        { 
            get
            {
                return Genes[GeneKey.Health];
            } 
        }

        public uint Stamina
        {
            get { return _stamina; }
            set { _stamina = Math.Min(value, MaxHealth); }
        }
        public uint MaxStamina
        {
            get
            {
                return Genes[GeneKey.Stamina];
            }
        }
        
        public uint Strength { get; set; }
        public uint Speed
        {
            get { return _speed; }
            set { _speed = Math.Min(value, MaxSpeed); }
        }
        public uint MaxSpeed
        {
            get
            {
                return Genes[GeneKey.Speed];
            }
        }

        public uint MeleeAttack { get; set; }
        public uint MeleeAttackDistance { get; set; }
        public uint RangedAttack { get; set; }
        public uint RangedAttackDistance { get; set; }
        public uint MeleeDefence { get; set; }
        public uint RangedDefence { get; set; }


        #endregion // Base Specs
        
        #region IAmVisible

        public virtual uint Food { get { return (uint)(2 * Size + Health); } }
        public virtual uint Danger { get { return (uint)(2 * Size + Strength + Speed + MeleeAttack + 2*RangedAttack + 2*RangedAttackDistance); } }
        public virtual uint Visibility { get { return (uint)(2 * Size + Genes[GeneKey.Cloaking]); } }

        #endregion //IAmVisible

        #region IHavePosition

        public double X { get; set; }
        public double Y { get; set; }
        public double Angle { get; set; }

        #endregion // IHavePosition

        #region IAmSmelling

        public virtual Scent Scent { get { return GenAI.Core.Enums.Scent.Neutral; } }

        public virtual uint ScentStrength { get { return (uint)((2 * Size + Strength) / Genes[GeneKey.Cloaking]); } }

        public virtual double GetDirection(IHavePosition fromOther) {
            throw new NotImplementedException("BaseCharacter -> GetDirection is not implemented yet.");
        }

        #endregion // IAmSmelling

        #endregion // Properties


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

        #endregion // Ctors
    }
}
