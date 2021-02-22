using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class StringGameEventListener : ParametrizedGameEventListener<string>
    {
        [Serializable]
        public class UnityEvent : UnityEvent<string> {}

        public UnityEvent UnityEventResponse;

        protected override void InvokeUnityEventResponse(string value)
        {
            UnityEventResponse.Invoke(value);
        }
    }
}