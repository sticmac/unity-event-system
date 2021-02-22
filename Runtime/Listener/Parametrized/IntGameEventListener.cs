using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class IntGameEventListener : ParametrizedGameEventListener<int>
    {
        [Serializable]
        public class UnityEvent : UnityEvent<int> {}

        public UnityEvent UnityEventResponse;

        protected override void InvokeUnityEventResponse(int value)
        {
            UnityEventResponse.Invoke(value);
        }
    }
}