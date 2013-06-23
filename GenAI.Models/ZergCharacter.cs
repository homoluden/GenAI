using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenAI.Core.Enums;
using GenAI.Core.Interfaces;
using Stateless;
using MathNet.Numerics.Distributions;

namespace GenAI.Models
{
    public class ZergCharacter : BaseCharacter, IAmAlive, IHavePosition, IAmVisible, IAmSmelling
    {
        #region Constants
        public static readonly Goal[] GOALS_LOOKUP_TABLE;
        public static readonly Dictionary<Goal, byte> GOAL_PRIORITIES;
        #endregion

        public static ZergCharacter()
        {
            GOAL_PRIORITIES = new Dictionary<Goal, byte> (){ 
                {Goal.Attack, 16},
                {Goal.Feed, 8},
                {Goal.Retreat, 1},
                {Goal.Serve, 2}
            };

            var goals = new Stack<Goal>();

            var goalEnums = (Goal[])Enum.GetValues(typeof(Goal));
            foreach (var enumValue in goalEnums)
            {
                for (int i = 0; i < GOAL_PRIORITIES[enumValue]; i++)
                {
                    goals.Push(enumValue);
                }
            }

            int count = goals.Count;
            GOALS_LOOKUP_TABLE = new Goal[count];

            var rnd = new ContinuousUniform(0.0, 1.0);

            while (goals.Any())
            {
                int idx = (int)Math.Round(rnd.Sample() * (--count), 0);
                GOALS_LOOKUP_TABLE[idx] = goals.Pop();
            }
        }

        public ZergCharacter(Dictionary<GeneKey, uint> genes) : base(genes)
        {
            X = Y = Angle = 0.0;

            MainGoal = new StateMachine<Goal, GoalTrigger>(Goal.Serve);

            MainGoal.Configure(Goal.Serve).
                PermitReentry(GoalTrigger.GoToWork).
                Permit(GoalTrigger.GoToFeed, Goal.Feed).
                Permit(GoalTrigger.FleeAway, Goal.Retreat).
                Permit(GoalTrigger.GoToFight, Goal.Attack);

            MainGoal.Configure(Goal.Feed).
                Permit(GoalTrigger.GoToFeed, Goal.Feed).
                Permit(GoalTrigger.FleeAway, Goal.Retreat).
                Permit(GoalTrigger.GoToFight, Goal.Attack).
                Permit(GoalTrigger.GoToWork, Goal.Serve).

                // TODO: Implement Roulette Wheel Selection here
                PermitDynamic(GoalTrigger.DoSomething,() => Goal.Feed);
        }
    }
}
