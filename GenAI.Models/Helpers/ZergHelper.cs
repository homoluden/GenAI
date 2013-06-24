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
        public static void ConfigureStates(this ZergCharacter character, State initialState)
        {
            character.MainGoal = new StateMachine<State, Trigger>(State.ServeGoal);

            character.MainGoal.ConfigureServeGoal();

            character.MainGoal.Configure(State.FeedGoal).
                PermitReentry(Trigger.Feed).
                Permit(Trigger.FleeAway, State.RetreatGoal).
                Permit(Trigger.Fight, State.AttackGoal).
                Permit(Trigger.Work, State.ServeGoal).

                PermitDynamic(Trigger.DoSomething, () => ZergCharacter.GOALS_LOOKUP_TABLE[ZergCharacter.RND.Sample()]);

            character.MainGoal.Configure(State.RetreatGoal).
                PermitReentry(Trigger.FleeAway).
                Permit(Trigger.Feed, State.FeedGoal).
                Permit(Trigger.Fight, State.AttackGoal).
                Permit(Trigger.Work, State.ServeGoal).

                PermitDynamic(Trigger.DoSomething, () => ZergCharacter.GOALS_LOOKUP_TABLE[ZergCharacter.RND.Sample()]);

            character.MainGoal.Configure(State.AttackGoal).
                PermitReentry(Trigger.Fight).
                Permit(Trigger.Feed, State.FeedGoal).
                Permit(Trigger.FleeAway, State.RetreatGoal).
                Permit(Trigger.Work, State.ServeGoal).

                PermitDynamic(Trigger.DoSomething, () => ZergCharacter.GOALS_LOOKUP_TABLE[ZergCharacter.RND.Sample()]);
        }

        private static void ConfigureServeGoal(this StateMachine<State, Trigger> machine)
        { 
            machine.Configure(State.ServeGoal).
                PermitReentry(Trigger.Work).
                Permit(Trigger.Feed, State.FeedGoal).
                Permit(Trigger.FleeAway, State.RetreatGoal).
                Permit(Trigger.Fight, State.AttackGoal).

                PermitDynamic(Trigger.DoSomething, () => ZergCharacter.GOALS_LOOKUP_TABLE[ZergCharacter.RND.Sample()]);

            machine.Configure(State.SeekStrategy).SubstateOf(State.ServeGoal).
                PermitReentry();
        }
    }
}
