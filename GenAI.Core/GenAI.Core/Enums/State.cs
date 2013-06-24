using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core.Enums
{
    public enum State
    {
        #region Goals
        
        FeedGoal,
        AttackGoal,
        RetreatGoal,
        ServeGoal,

        #endregion


        #region Strategies

        SeekStrategy,
        GuerrillaStrategy,
        InfantryStrategy,
        KamikazeStrategy,

        EatClosestStrategy,
        EatBestStrategy,

        HideStrategy,
        SlowStrategy,
        FleeStrategy,

        RepareStrategy,
        HarvestStrategy,
        SacrificeStrategy,

        #endregion


        #region Actions

        #region Common Actions

        IdleAction,
        LookAround,
        MoveRandom,
        MoveToBest,
        MoveToClosest,
        Eat,
        StepBack,
        Repare,
        AttackShortRange,
        AttackLongRange,
        
        #endregion // Common Actions


        #region Attack Goal - Find Enemy
        // + "Common Actions":
        // IdleAction, LookAround, MoveRandom
        #endregion // Attack Goal - Find Enemy

        #region Attack Goal - BeCareful
        // + "Common Actions":
        // MoveToClosest, StepBack, Repare, AttackLongRange
        #endregion // Attack Goal - BeCareful

        #region Attack Goal - JustFight
        // + "Common Actions":
        // MoveToBest, StepBack, Repare, AttackShortRange, AttackLongRange
        #endregion // Attack Goal - JustFight

        #region Attack Goal - BlowItUp
        // + "Common Actions":
        // MoveToBest, AttackShortRange
        #endregion // Attack Goal - BlowItUp


        #region Feed Goal - FindFood
        // + "Common Actions":
        // IdleAction, LookAround, MoveRandom
        #endregion // Feed Goal - FindFood

        #region Feed Goal - EatClosest
        // + "Common Actions":
        // MoveToClosest, Eat
        #endregion // Feed Goal - EatClosest

        #region Feed Goal - EatBest
        // + "Common Actions":
        // MoveToBest, Eat
        #endregion // Feed Goal - EatBest


        #region Retreat Goal - Hide

        #endregion // Retreat Goal - Hide

        #region Retreat Goal - RetreatSlowly

        #endregion // Retreat Goal - RetreatSlowly

        #region Retreat Goal - RunAway

        #endregion // Retreat Goal - RunAway


        #endregion
    }

    public enum Trigger
    {
        #region Common Triggers        
        
        DoSomething,

        #endregion

        #region GoalTriggers
        
        Feed,    
        Fight,
        FleeAway,
        Work,

        #endregion


        #region Strategy Triggers

        #region Attack Goal
        
        FindEnemy,
        BeCareful,
        JustFight,
        BlowItUp,

        #endregion // Attack Goal

        #region Feed Goal

        FindFood,
        EatClosest,
        EatBest,

        #endregion // Feed Goal

        #region Retreat Goal

        Hide,
        RetreatSlowly,
        RunAway,

        #endregion // Retreat Goal

        #region Serve Goal

        FindWork,
        RepareClosest,
        RepareMostDamaged,
        HarvestResources,
        SacrificeYourself

        #endregion // Serve Goal

        #endregion
    }

    public static class GoalHelper
    {

    }
}
