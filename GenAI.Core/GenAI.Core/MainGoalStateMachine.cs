using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core
{
    using GenAI.Core.Enums;
    using GenAI.Core.Interfaces;

    public class MainGoalStateMachine<T> : HighLevelStateMachine<T>
        where T : class, IAmAlive, IHavePosition
    {
        #region Fields

        protected Goal _goal;

        protected readonly Tuple<int, Goal>[] _goalSelectionTable;

        #endregion

        #region Ctors

        public MainGoalStateMachine(T owner) : base(owner)
        {
            _goal = Goal.Feed;
            _goalSelectionTable = new Tuple<int, Goal>[4];

            _subMachine = new FeedStateMachine<T>(owner);
        }

        #endregion

        #region Overrides

        public override void UpdateState(IEnumerable<Interfaces.IAmVisible> visibleObjects, IEnumerable<Interfaces.IAmNoizy> noizyObjects, IEnumerable<Interfaces.IAmSmelling> smellingObjects)
        {
            // TODO: Check detected objects and select main goal
            switch (_goal)
            {
                    case Goal.Attack:
                        if (!(_subMachine is AttackStateMachine<T>))
                        {
                            _subMachine = new AttackStateMachine<T>(_owner);
                        }
                    break;
                    case Goal.Feed:
                    default:
                        if (!(_subMachine is FeedStateMachine<T>))
                        {
                            _subMachine = new FeedStateMachine<T>(_owner);
                        }
                        break;
            }

            base.UpdateState(visibleObjects, noizyObjects, smellingObjects);
        }

        #endregion
    }
}
