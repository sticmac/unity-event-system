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
        protected HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

        public IReadOnlyCollection<GameEventListener> Listeners => _listeners;

        public bool RegisterListener(GameEventListener listener) {
            return _listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener) {
            _listeners.Remove(listener);
        }
        
        public void Raise() {
            foreach (GameEventListener listener in _listeners) {
                listener.OnEventRaised();
            }
        }
    }
}
