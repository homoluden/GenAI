namespace GenAI.Core
{
    using GenAI.Core.Enums;

    public class KamikazeStrategyStateMachine : HighLevelStateMachine
    {
        #region Ctors

        public KamikazeStrategyStateMachine()
        {
            _subMachine = new LowLevelStateMachine{State = EndState.AggressiveAttack};
        }

        #endregion
    }
}
