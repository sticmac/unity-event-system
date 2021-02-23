using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class <%= Type %>GameEventListener : ParametrizedGameEventListener<<%= TypeGeneric %>>
    {
        [Serializable]
        private class UnityEvent : UnityEvent<<%= TypeGeneric %>> {}

        [SerializeField] UnityEvent _unityEventResponse;

        private void Awake() {
            if (_unityEventResponse == null) _unityEventResponse = new UnityEvent();
        }

        protected override void AddListener(UnityAction<<%= TypeGeneric %>> action) => _unityEventResponse.AddListener(action);
        protected override void RemoveListener(UnityAction<<%= TypeGeneric %>> action) => _unityEventResponse.RemoveListener(action);

        protected override void InvokeUnityEventResponse(<%= TypeGeneric %> value) => _unityEventResponse.Invoke(value);
    }
}