namespace GenAI.Core
{
    using System;
using System.Collections.Generic;
using GenAI.Core.Enums;
using GenAI.Core.Interfaces;

    public class HighLevelStateMachine<T> : BaseStateMachine<T>, IHaveStates
        where T : class, IAmAlive, IHavePosition
    {
        #region Fields

        protected IHaveStates _subMachine;

        #endregion

        #region Ctors

        public HighLevelStateMachine(T owner) : base(owner)
        {
            _subMachine = new LowLevelStateMachine<T>(owner);
        }

        #endregion

        public override EndState GetEndState()
        {
            return _subMachine.GetEndState();
        }

        public override void UpdateState(IEnumerable<IAmVisible> visibleObjects, IEnumerable<IAmNoizy> noizyObjects, IEnumerable<IAmSmelling> smellingObjects)
        {
            // TODO: Check detected objects and change the sub-machine if needed

            _subMachine.UpdateState(visibleObjects, noizyObjects, smellingObjects);
        }
    }
}
