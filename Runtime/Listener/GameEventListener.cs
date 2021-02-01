using System;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    /// <summary>
    /// Listener for GameEvent
    /// </summary>
    public class GameEventListener : AbstractListener 
    {
        [SerializeField] GameEvent _event;

        public GameEvent Event { get => _event;
            set {
                _event?.UnregisterListener(this);
                _event = value;
                _event.RegisterListener(this);
            }
        }

        public event Action Response;

        private void OnEnable() {
            Event?.RegisterListener(this);
        }

        private void OnDisable() {
            Event?.UnregisterListener(this);
        }

        public void OnEventRaised() {
            Response?.Invoke();
        }
    }
}