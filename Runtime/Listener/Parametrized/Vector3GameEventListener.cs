using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class Vector3GameEventListener : ParametrizedGameEventListener<Vector3>
    {
        [Serializable]
        private class UnityEvent : UnityEvent<Vector3> {}

        [SerializeField] UnityEvent _unityEventResponse;

        private void Awake() {
            if (_unityEventResponse == null) _unityEventResponse = new UnityEvent();
        }

        protected override void AddListener(UnityAction<Vector3> action) => _unityEventResponse.AddListener(action);
        protected override void RemoveListener(UnityAction<Vector3> action) => _unityEventResponse.RemoveListener(action);

        protected override void InvokeUnityEventResponse(Vector3 value) => _unityEventResponse.Invoke(value);
    }
}