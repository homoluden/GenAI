namespace GenAI.Core
{
    using GenAI.Core.Enums;
    using GenAI.Core.Interfaces;

    public class AttackStateMachine<T> : HighLevelStateMachine<T>
        where T : class, IAmAlive, IHavePosition
    {
        #region Ctors

        public AttackStateMachine(T owner) : base(owner)
        {
            _subMachine = new LowLevelStateMachine<T>(owner){State = EndState.AggressiveAttack};
        }

        #endregion
    }
}
