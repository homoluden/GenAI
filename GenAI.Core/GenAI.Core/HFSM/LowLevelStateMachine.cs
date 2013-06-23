namespace GenAI.Core
{
    using System;
    using System.Collections.Generic;

    using GenAI.Core.Enums;
    using GenAI.Core.Interfaces;

    public class LowLevelStateMachine<T> : BaseStateMachine<T>, IHaveStates
        where T : class, IAmAlive, IHavePosition
    {
        #region Fields

        private Action _state = Action.Idle;

        #endregion

        #region Properties

        public Action State { get; set; }

        #endregion

        #region Ctors

        public LowLevelStateMachine(T owner) : base(owner)
        {
        }

        #endregion

        public override Action GetEndState()
        {
            return _state;
        }

        public override void UpdateState(IEnumerable<IAmVisible> visibleObjects, IEnumerable<IAmNoizy> noizyObjects, IEnumerable<IAmSmelling> smellingObjects)
        {
            // Do nothing here
        }

        //public override void LookAt(IEnumerable<IAmVisible> visibleObjects)
        //{
        //    // Do nothing here
        //}

        //public override void HearTo(IEnumerable<IAmNoizy> noizyObjects)
        //{
        //    // Do nothing here
        //}

        //public override void SmellThat(IEnumerable<IAmSmelling> smellingObjects)
        //{
        //    // Do nothing here
        //}
    }
}
