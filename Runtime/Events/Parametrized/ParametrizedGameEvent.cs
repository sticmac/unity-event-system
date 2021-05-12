using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class ParametrizedGameEvent<T> : AbstractGameEvent
    {
        protected HashSet<ParametrizedGameEventListener<T>> _listeners = new HashSet<ParametrizedGameEventListener<T>>();

        public IReadOnlyCollection<ParametrizedGameEventListener<T>> Listeners => _listeners;

        public bool RegisterListener(ParametrizedGameEventListener<T> listener) {
            return _listeners.Add(listener);
        }

        public void UnregisterListener(ParametrizedGameEventListener<T> listener) {
            _listeners.Remove(listener);
        }
        
        public void Raise(T value) {
            foreach (ParametrizedGameEventListener<T> listener in _listeners) {
                listener.OnEventRaised(value);
            }
        }
    }
}