using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core.Enums
{
    public enum Goal
    {
        Feed,
        Attack,
        Retreat,
        Serve
    }

    public enum GoalTrigger 
    { 
        GoToFeed,
        GoToFight,
        FleeAway,
        GoToWork,
        DoSomething
    }

    public static class GoalHelper
    {

    }
}
