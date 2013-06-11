using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAI.Core.Interfaces
{
    using GenAI.Core.Enums;

    interface IHaveStates
    {
        EndState GetEndState();

        void UpdateState(IEnumerable<IAmVisible> visibleObjects, IEnumerable<IAmNoizy> noizyObjects, IEnumerable<IAmSmelling> smellingObjects);

        //void LookAt(IEnumerable<IAmVisible> visibleObjects);

        //void HearTo(IEnumerable<IAmNoizy> noizyObjects);

        //void SmellThat(IEnumerable<IAmSmelling> smellingObjects);
    }
}
