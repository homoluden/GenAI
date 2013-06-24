using GenAI.Core.Enums;
using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Models.Helpers
{
    public static class ZergHelper
    {
        public static void ConfigureStates(this ZergCharacter character, Goal initialState)
        {
            character.MainGoal = new StateMachine<Goal, GoalTrigger>(Goal.Serve);

            character.MainGoal.Configure(Goal.Serve).
                PermitReentry(GoalTrigger.GoToWork).
                Permit(GoalTrigger.GoToFeed, Goal.Feed).
                Permit(GoalTrigger.FleeAway, Goal.Retreat).
                Permit(GoalTrigger.GoToFight, Goal.Attack).

                PermitDynamic(GoalTrigger.DoSomething, () => ZergCharacter.GOALS_LOOKUP_TABLE[ZergCharacter.RND.Sample()]);

            character.MainGoal.Configure(Goal.Feed).
                PermitReentry(GoalTrigger.GoToFeed).
                Permit(GoalTrigger.FleeAway, Goal.Retreat).
                Permit(GoalTrigger.GoToFight, Goal.Attack).
                Permit(GoalTrigger.GoToWork, Goal.Serve).

                PermitDynamic(GoalTrigger.DoSomething, () => ZergCharacter.GOALS_LOOKUP_TABLE[ZergCharacter.RND.Sample()]);

            character.MainGoal.Configure(Goal.Retreat).
                PermitReentry(GoalTrigger.FleeAway).
                Permit(GoalTrigger.GoToFeed, Goal.Feed).
                Permit(GoalTrigger.GoToFight, Goal.Attack).
                Permit(GoalTrigger.GoToWork, Goal.Serve).

                PermitDynamic(GoalTrigger.DoSomething, () => ZergCharacter.GOALS_LOOKUP_TABLE[ZergCharacter.RND.Sample()]);

            character.MainGoal.Configure(Goal.Attack).
                PermitReentry(GoalTrigger.GoToFight).
                Permit(GoalTrigger.GoToFeed, Goal.Feed).
                Permit(GoalTrigger.FleeAway, Goal.Retreat).
                Permit(GoalTrigger.GoToWork, Goal.Serve).

                PermitDynamic(GoalTrigger.DoSomething, () => ZergCharacter.GOALS_LOOKUP_TABLE[ZergCharacter.RND.Sample()]);
        }
    }
}
