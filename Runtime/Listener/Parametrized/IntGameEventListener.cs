using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class IntGameEventListener : ParametrizedGameEventListener<int>
    {
        [Serializable]
        private class UnityEvent : UnityEvent<int> {}

        [SerializeField] UnityEvent _unityEventResponse;

        private void Awake() {
            if (_unityEventResponse == null) _unityEventResponse = new UnityEvent();
        }

        protected override void AddListener(UnityAction<int> action) => _unityEventResponse.AddListener(action);
        protected override void RemoveListener(UnityAction<int> action) => _unityEventResponse.RemoveListener(action);

        protected override void InvokeUnityEventResponse(int value) => _unityEventResponse.Invoke(value);
    }
}