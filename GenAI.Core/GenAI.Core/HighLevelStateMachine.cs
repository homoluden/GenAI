namespace GenAI.Core
{
    using System;
using System.Collections.Generic;
using GenAI.Core.Enums;
using GenAI.Core.Interfaces;

    public class HighLevelStateMachine : BaseStateMachine, IHaveStates
    {
        #region Fields

        private IHaveStates _subMachine;

        #endregion

        #region Ctors

        public HighLevelStateMachine()
        {
            _subMachine = new LowLevelStateMachine();
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

        //public override void LookAt(IEnumerable<Interfaces.IAmVisible> visibleObjects)
        //{
        //    // TODO: Check visible objects and update corresponding internal properties here
        //}

        //public override void HearTo(IEnumerable<Interfaces.IAmNoizy> noizyObjects)
        //{
        //    // TODO: Check objects which make some noise and update corresponding internal properties here

        //    throw new NotImplementedException();
        //}

        //public override void SmellThat(IEnumerable<Interfaces.IAmSmelling> smellingObjects)
        //{
        //    // TODO: Check smelling objects and update corresponding internal properties here

        //    throw new NotImplementedException();
        //}
    }
}
