using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenAI.Core.Enums;
using GenAI.Core.Interfaces;
using GenAI.Models.Helpers;
using Stateless;
using MathNet.Numerics.Distributions;

namespace GenAI.Models
{
    public class ZergCharacter : BaseCharacter, IAmAlive, IHavePosition, IAmVisible, IAmSmelling
    {
        #region Constants

        public static readonly State[] GOALS_LOOKUP_TABLE;
        public static readonly Dictionary<State, byte> GOAL_PRIORITIES;
        public static readonly DiscreteUniform RND;

        #endregion

        #region Properties
        
        #endregion

        #region Ctors

        static ZergCharacter()
        {
            GOAL_PRIORITIES = new Dictionary<State, byte>(){ 
                {State.AttackGoal, 16},
                {State.FeedGoal, 8},
                {State.RetreatGoal, 1},
                {State.ServeGoal, 2}
            };

            var goals = new Stack<State>();

            var goalEnums = (State[])Enum.GetValues(typeof(State));
            foreach (var enumValue in goalEnums)
            {
                for (int i = 0; i < GOAL_PRIORITIES[enumValue]; i++)
                {
                    goals.Push(enumValue);
                }
            }

            int count = goals.Count;
            RND = new DiscreteUniform(0, count - 1);
            GOALS_LOOKUP_TABLE = new State[count];

            var rnd = new ContinuousUniform(0.0, 1.0);

            while (goals.Any())
            {
                int idx = (int)Math.Round(rnd.Sample() * (--count), 0);
                GOALS_LOOKUP_TABLE[idx] = goals.Pop();
            }
        }

        public ZergCharacter(Dictionary<GeneKey, uint> genes)
            : base(genes)
        {
            X = Y = Angle = 0.0;

            this.ConfigureStates(State.ServeGoal);
        }

        #endregion


        #region Private Methods

        #endregion


        #region Public Methods

        public override void Update(float dt)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
