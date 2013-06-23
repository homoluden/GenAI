namespace GenAI.Core
{
    using GenAI.Core.Enums;
    using GenAI.Core.Interfaces;

    public class FeedStateMachine<T> : HighLevelStateMachine<T>
        where T : class, IAmAlive, IHavePosition
    {
        #region Ctors

        public FeedStateMachine(T owner) : base(owner)
        {
            _subMachine = new LowLevelStateMachine<T>(owner){ State = SimpleAction.Feed};
        }

        #endregion
    }
}
