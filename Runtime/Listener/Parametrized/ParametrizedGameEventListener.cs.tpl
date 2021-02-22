using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class <%= Type %>GameEventListener : ParametrizedGameEventListener<<%= TypeGeneric %>>
    {
        [Serializable]
        public class UnityEvent : UnityEvent<<%= TypeGeneric %>> {}

        public UnityEvent UnityEventResponse;

        protected override void InvokeUnityEventResponse(<%= TypeGeneric %> value)
        {
            UnityEventResponse.Invoke(value);
        }
    }
}