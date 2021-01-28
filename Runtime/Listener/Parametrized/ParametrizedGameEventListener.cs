using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public abstract class ParametrizedGameEventListener<T> : AbstractListener
        where T : struct
    {
        protected ParametrizedGameEvent<ParametrizedGameEventListener<T>, T> Event;

        #region Event Serialization
        [SerializeField, HideInInspector] string _eventGuid;
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