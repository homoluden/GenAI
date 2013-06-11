using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenAI.Core.Interfaces;

namespace GenAI.Core
{
    using GenAI.Core.Enums;
    using GenAI.Core.Utils;

    public abstract class BaseStateMachine<T> where T : class, IAmAlive, IHavePosition
    {
        #region Fields

        protected readonly T _owner;

        #endregion


        protected BaseStateMachine(T owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException("Owner cannot be null.");
            }
            _owner = owner;
        }

        public abstract EndState GetEndState();

        public abstract void UpdateState(IEnumerable<IAmVisible> visibleObjects, IEnumerable<IAmNoizy> noizyObjects, IEnumerable<IAmSmelling> smellingObjects);
    }
}
