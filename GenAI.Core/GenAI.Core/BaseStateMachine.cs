using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenAI.Core.Interfaces;

namespace GenAI.Core
{
    using GenAI.Core.Enums;

    public abstract class BaseStateMachine
    {
        public abstract EndState GetEndState();

        public abstract void UpdateState(IEnumerable<IAmVisible> visibleObjects, IEnumerable<IAmNoizy> noizyObjects, IEnumerable<IAmSmelling> smellingObjects);

        //public abstract void LookAt(IEnumerable<IAmVisible> visibleObjects);

        //public abstract void HearTo(IEnumerable<IAmNoizy> noizyObjects);

        //public abstract void SmellThat(IEnumerable<IAmSmelling> smellingObjects);
    }
}
