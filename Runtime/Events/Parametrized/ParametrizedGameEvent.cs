using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class ParametrizedGameEvent<T, U> : AbstractGameEvent<T>
        where T : ParametrizedGameEventListener<U>
    {
        public void Raise(U value) {
            for(int i = _listeners.Count -1; i >= 0; i--)
                _listeners[i].OnEventRaised(value);
        }
    }
}