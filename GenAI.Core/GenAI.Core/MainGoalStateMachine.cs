using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core
{
    public class MainGoalStateMachine : HighLevelStateMachine
    {
        #region Ctors

        public MainGoalStateMachine()
        {
            _subMachine = new IdleStateMachine();
        }

        #endregion

        #region Overrides

        public override void UpdateState(IEnumerable<Interfaces.IAmVisible> visibleObjects, IEnumerable<Interfaces.IAmNoizy> noizyObjects, IEnumerable<Interfaces.IAmSmelling> smellingObjects)
        {
            // TODO: Check detected objects and select main goal

            base.UpdateState(visibleObjects, noizyObjects, smellingObjects);
        }

        #endregion
    }
}
