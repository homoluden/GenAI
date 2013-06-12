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

        protected Tuple<uint, Goal>[] _goalSelectionTable;
        protected Tuple<uint, AttackStrategy>[] _attackSelectionTable;
        protected Tuple<uint, FeedStrategy>[] _feedSelectionTable;
        protected Tuple<uint, RetreatStrategy>[] _retreatSelectionTable;
        protected Tuple<uint, ServeStrategy>[] _serveSelectionTable;

        #endregion

        #region Ctors

        public MainGoalStateMachine(T owner) : base(owner)
        {
            _goal = Goal.Feed;

            BuildGoalSelectionTable();
            BuildAttackSelectionTable();
            BuildFeedSelectionTable();
            BuildRetreatSelectionTable();
            BuildServeSelectionTable();

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

        #region Private Methods

        protected Dictionary<Goal, int> CheckProfits(IEnumerable<IAmVisible> visibleObjects, IEnumerable<IAmNoizy> noizyObjects, IEnumerable<IAmSmelling> smellingObjects)
        {
            var profits = new Dictionary<Goal, int>();



            return profits;
        }

        protected void BuildGoalSelectionTable()
        {
            _goalSelectionTable = new[]
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
        }

        protected void BuildAttackSelectionTable()
        {
            _attackSelectionTable = new[]
                                    {
                                        new Tuple<uint, AttackStrategy>(_owner.Genes[GeneKey.SeekPriority], AttackStrategy.Seek),
                                        new Tuple<uint, AttackStrategy>(_owner.Genes[GeneKey.GuerrillaAttackPriority], AttackStrategy.Guerrilla),
                                        new Tuple<uint, AttackStrategy>(_owner.Genes[GeneKey.InfantryAttackPriority], AttackStrategy.Infantry),
                                        new Tuple<uint, AttackStrategy>(_owner.Genes[GeneKey.KamikazeAttackPriority], AttackStrategy.Kamikaze)
                                    };
            uint commulativePriority = 0;

            for (int i = 0; i < _attackSelectionTable.Length; i++)
            {
                commulativePriority += _attackSelectionTable[i].Item1;

                _attackSelectionTable[i] = new Tuple<uint, AttackStrategy>(commulativePriority, _attackSelectionTable[i].Item2);
            }
        }

        protected void BuildFeedSelectionTable()
        {
            _feedSelectionTable = new[]
                                    {
                                        new Tuple<uint, FeedStrategy>(_owner.Genes[GeneKey.SeekPriority], FeedStrategy.Seek),
                                        new Tuple<uint, FeedStrategy>(_owner.Genes[GeneKey.EatClosestPriority], FeedStrategy.EatClosest),
                                        new Tuple<uint, FeedStrategy>(_owner.Genes[GeneKey.EatBestPriority], FeedStrategy.EatClosest)
                                    };
            uint commulativePriority = 0;

            for (int i = 0; i < _feedSelectionTable.Length; i++)
            {
                commulativePriority += _feedSelectionTable[i].Item1;

                _feedSelectionTable[i] = new Tuple<uint, FeedStrategy>(commulativePriority, _feedSelectionTable[i].Item2);
            }
        }

        protected void BuildRetreatSelectionTable()
        {
            _retreatSelectionTable = new[]
                                    {
                                        new Tuple<uint, RetreatStrategy>(_owner.Genes[GeneKey.SeekPriority], RetreatStrategy.Hide),
                                        new Tuple<uint, RetreatStrategy>(_owner.Genes[GeneKey.SlowRetreatPriority], RetreatStrategy.Slow),
                                        new Tuple<uint, RetreatStrategy>(_owner.Genes[GeneKey.FleeRetreatPriority], RetreatStrategy.Flee)
                                    };
            uint commulativePriority = 0;

            for (int i = 0; i < _retreatSelectionTable.Length; i++)
            {
                commulativePriority += _retreatSelectionTable[i].Item1;

                _retreatSelectionTable[i] = new Tuple<uint, RetreatStrategy>(commulativePriority, _retreatSelectionTable[i].Item2);
            }
        }

        protected void BuildServeSelectionTable()
        {
            _serveSelectionTable = new[]
                                    {
                                        new Tuple<uint, ServeStrategy>(_owner.Genes[GeneKey.SeekPriority], ServeStrategy.Seek),
                                        new Tuple<uint, ServeStrategy>(_owner.Genes[GeneKey.HarvestPriority], ServeStrategy.Harvest),
                                        new Tuple<uint, ServeStrategy>(_owner.Genes[GeneKey.ReparePriority], ServeStrategy.Repare),
                                        new Tuple<uint, ServeStrategy>(_owner.Genes[GeneKey.SacrificePriority], ServeStrategy.Sacrifice)
                                    };
            uint commulativePriority = 0;

            for (int i = 0; i < _serveSelectionTable.Length; i++)
            {
                commulativePriority += _serveSelectionTable[i].Item1;

                _serveSelectionTable[i] = new Tuple<uint, ServeStrategy>(commulativePriority, _serveSelectionTable[i].Item2);
            }
        }

        #endregion
    }
}
