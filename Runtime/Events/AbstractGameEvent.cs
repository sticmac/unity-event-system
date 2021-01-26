using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    /// <summary>
    /// Parent class for all game events
    /// </summary>
    /// <typeparam name="T">Listener associated with the event</typeparam>
    public abstract class AbstractGameEvent<T> : ScriptableObject where T : AbstractListener
    {
        protected List<T> _listeners = new List<T>();

        public void RegisterListener(T listener) {
            _listeners.Add(listener);
        }

        public void UnregisterListener(T listener) {
            _listeners.Remove(listener);
        }
    }
}