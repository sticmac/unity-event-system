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

        public UnityEvent UnityEventResponse;

        private void OnEnable() {
            Event?.RegisterListener(this);
            if (UnityEventResponse == null) {
                UnityEventResponse = new UnityEvent();
            }
        }

        private void OnDisable() {
            Event?.UnregisterListener(this);
        }

        public void OnEventRaised() {
            switch (_responseActivationMode) {
                case ResponseMode.InvokeUnityEvents:
                    UnityEventResponse.Invoke();
                    break;
                case ResponseMode.InvokeCSharpEvents:
                    Response?.Invoke();
                    break;
            }
        }
    }
}