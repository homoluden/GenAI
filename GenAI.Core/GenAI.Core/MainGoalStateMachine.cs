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

        protected readonly Tuple<uint, Goal>[] _goalSelectionTable;

        #endregion

        #region Ctors

        public MainGoalStateMachine(T owner) : base(owner)
        {
            _goal = Goal.Feed;

            _goalSelectionTable = new []
                                    {
                                        new Tuple<uint, Goal>(_owner.Genes[GeneKey.FeedGoalPriority], Goal.Feed),
                                        new Tuple<uint, Goal>(_owner.Genes[GeneKey.AttackGoalPriority], Goal.Attack),
                                        new Tuple<uint, Goal>(_owner.Genes[GeneKey.RetreatGoalPriority], Goal.Retreat),
                                        new Tuple<uint, Goal>(_owner.Genes[GeneKey.ServeGoalPriority], Goal.Serve)
                                    };
            uint commulativePriority = 0;
            
            for (int i = 0; i < _goalSelectionTable.Length; i++)
            {
                commulativePriority += _goalSelectionTable[i].Item1;

                _goalSelectionTable[i] = new Tuple<uint, Goal>(commulativePriority, _goalSelectionTable[i].Item2);
            }

            _subMachine = new FeedStateMachine<T>(owner);
        }

        #endregion

        #region Overrides

        public override void UpdateState(IEnumerable<IAmVisible> visibleObjects, IEnumerable<IAmNoizy> noizyObjects, IEnumerable<IAmSmelling> smellingObjects)
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
                    case Goal.Retreat:
                        // TODO: Create "Retreat" states machine
                        break;
                    case Goal.Serve:
                        // TODO: Create "Service" states machine
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
