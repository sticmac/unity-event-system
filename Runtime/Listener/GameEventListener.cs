﻿using System;
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

        // C# Event
        public event Action Response;

        // Unity Event
        public event UnityAction UnityEventResponse {
            add => _unityEventResponse.AddListener(value);
            remove => _unityEventResponse.RemoveListener(value);
        }
        [SerializeField] UnityEvent _unityEventResponse;

        private void Awake() {
            if (_unityEventResponse == null) _unityEventResponse = new UnityEvent();
        }

        private void OnEnable() {
            Event?.RegisterListener(this);
        }

        private void OnDisable() {
            Event?.UnregisterListener(this);
        }

        public void OnEventRaised() {
            switch (_responseActivationMode) {
                case ResponseMode.InvokeUnityEvents:
                    _unityEventResponse.Invoke();
                    break;
                case ResponseMode.InvokeCSharpEvents:
                    Response?.Invoke();
                    break;
            }
        }
    }
}