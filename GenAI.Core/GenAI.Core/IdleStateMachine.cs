namespace GenAI.Core
{
    using GenAI.Core.Enums;

    public class IdleStateMachine : HighLevelStateMachine
    {
        #region Ctors

        public IdleStateMachine()
        {
            _subMachine = new LowLevelStateMachine{ State = EndState.Idle};
        }

        #endregion
    }
}
