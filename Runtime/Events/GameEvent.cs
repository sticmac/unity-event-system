using System.Linq;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    /// <summary>
    /// Game Event without Parameter
    /// </summary>
    [CreateAssetMenu(fileName = "Game Event", menuName = "Event System/Game Event", order = 0)]
    public class GameEvent : AbstractGameEvent
    {
        protected List<GameEventListener> _listeners = new List<GameEventListener>();

        public ReadOnlyCollection<GameEventListener> Listeners => _listeners.AsReadOnly();

        public void RegisterListener(GameEventListener listener) {
            if (!_listeners.Contains(listener)) {
                _listeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener) {
            _listeners.Remove(listener);
        }
        
        public void Raise() {
            for(int i = _listeners.Count -1; i >= 0; i--)
                _listeners[i].OnEventRaised();
        }
    }
}
