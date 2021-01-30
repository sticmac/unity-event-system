using System;
using UnityEngine;

namespace Sticmac.EventSystem {
    public abstract class ParametrizedGameEventListener<T> : AbstractListener, ISerializationCallbackReceiver
        where T : struct
    {
        protected ParametrizedGameEvent<ParametrizedGameEventListener<T>, T> Event;

        #region Event Serialization
        [SerializeField, HideInInspector] ScriptableObject _serializedEvent;

        public void OnBeforeSerialize()
        {
            // Nothing to do before serialization
            // (because _serializedEvent acts already as our serialization)
        }

        public void OnAfterDeserialize()
        {
            // Assign Event value from serialized event
            Event = _serializedEvent as ParametrizedGameEvent<ParametrizedGameEventListener<T>, T>;
        }
        #endregion

        public event Action<T> OnRaised;

        private void OnEnable() {
            Event.RegisterListener(this);
        }

        private void OnDisable() {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised(T value) {
            OnRaised?.Invoke(value);
        }
    }
}