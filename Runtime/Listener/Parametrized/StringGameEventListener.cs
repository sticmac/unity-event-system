using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class StringGameEventListener : ParametrizedGameEventListener<string>
    {
        [Serializable]
        private class UnityEvent : UnityEvent<string> {}

        [SerializeField] UnityEvent _unityEventResponse;

        private void Awake() {
            if (_unityEventResponse == null) _unityEventResponse = new UnityEvent();
        }

        protected override void AddListener(UnityAction<string> action) => _unityEventResponse.AddListener(action);
        protected override void RemoveListener(UnityAction<string> action) => _unityEventResponse.RemoveListener(action);

        protected override void InvokeUnityEventResponse(string value) => _unityEventResponse.Invoke(value);
    }
}