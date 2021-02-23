using System;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public abstract class ParametrizedGameEventListener<T> : AbstractListener, ISerializationCallbackReceiver
    {
        protected ParametrizedGameEvent<T> _event;
        public ParametrizedGameEvent<T> Event { get => _event;
            set {
                _event?.UnregisterListener(this);
                _event = value;
                _event?.RegisterListener(this);
            }
        }

        // C# Event
        public event Action<T> Response;

        // Unity Event
        public event UnityAction<T> UnityEventResponse {
            add => AddListener(value);
            remove => RemoveListener(value);
        }

        #region Event Serialization
        [SerializeField, HideInInspector] ScriptableObject _serializedEvent = null;

        public void OnBeforeSerialize()
        {
            // Nothing to do before serialization
            // (because _serializedEvent acts already as our serialization)
        }

        public void OnAfterDeserialize()
        {
            // Assign Event value from serialized event
            Event = _serializedEvent as ParametrizedGameEvent<T>;
        }
        #endregion

        protected virtual void OnEnable() {
            Event?.RegisterListener(this);
        }

        protected virtual void OnDisable() {
            Event?.UnregisterListener(this);
        }

        public void OnEventRaised(T value) {
            switch (_responseActivationMode) {
                case ResponseMode.InvokeUnityEvents:
                    InvokeUnityEventResponse(value);
                    break;
                case ResponseMode.InvokeCSharpEvents:
                    Response?.Invoke(value);
                    break;
            }
        }

        protected abstract void InvokeUnityEventResponse(T value);
        protected abstract void AddListener(UnityAction<T> action);
        protected abstract void RemoveListener(UnityAction<T> action);
    }
}