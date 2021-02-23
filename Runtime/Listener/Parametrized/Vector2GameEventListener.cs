using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class Vector2GameEventListener : ParametrizedGameEventListener<Vector2>
    {
        [Serializable]
        private class UnityEvent : UnityEvent<Vector2> {}

        [SerializeField] UnityEvent _unityEventResponse;

        private void Awake() {
            if (_unityEventResponse == null) _unityEventResponse = new UnityEvent();
        }

        protected override void AddListener(UnityAction<Vector2> action) => _unityEventResponse.AddListener(action);
        protected override void RemoveListener(UnityAction<Vector2> action) => _unityEventResponse.RemoveListener(action);

        protected override void InvokeUnityEventResponse(Vector2 value) => _unityEventResponse.Invoke(value);
    }
}