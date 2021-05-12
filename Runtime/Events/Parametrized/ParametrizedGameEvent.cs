using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class ParametrizedGameEvent<T> : AbstractGameEvent
    {
        protected List<ParametrizedGameEventListener<T>> _listeners = new List<ParametrizedGameEventListener<T>>();

        public ReadOnlyCollection<ParametrizedGameEventListener<T>> Listeners => _listeners.AsReadOnly();

        public void RegisterListener(ParametrizedGameEventListener<T> listener) {
            if (!_listeners.Contains(listener)) {
                _listeners.Add(listener);
            }
        }

        public void UnregisterListener(ParametrizedGameEventListener<T> listener) {
            _listeners.Remove(listener);
        }
        
        public void Raise(T value) {
            for(int i = _listeners.Count -1; i >= 0; i--)
                _listeners[i].OnEventRaised(value);
        }
    }
}