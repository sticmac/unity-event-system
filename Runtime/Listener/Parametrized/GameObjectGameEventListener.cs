using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class GameObjectGameEventListener : ParametrizedGameEventListener<GameObject>
    {
        [Serializable]
        private class UnityEvent : UnityEvent<GameObject> {}

        [SerializeField] UnityEvent _unityEventResponse;

        private void Awake() {
            if (_unityEventResponse == null) _unityEventResponse = new UnityEvent();
        }

        protected override void AddListener(UnityAction<GameObject> action) => _unityEventResponse.AddListener(action);
        protected override void RemoveListener(UnityAction<GameObject> action) => _unityEventResponse.RemoveListener(action);

        protected override void InvokeUnityEventResponse(GameObject value) => _unityEventResponse.Invoke(value);
    }
}