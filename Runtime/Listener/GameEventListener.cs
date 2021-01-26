using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    /// <summary>
    /// Listener for GameEvent
    /// </summary>
    public class GameEventListener : AbstractListener 
    {
        [SerializeField] GameEvent Event;

        public UnityEvent Response;

        private void OnEnable() {
            Event.RegisterListener(this);
        }

        private void OnDisable() {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised() {
            Response?.Invoke();
        }
    }
}