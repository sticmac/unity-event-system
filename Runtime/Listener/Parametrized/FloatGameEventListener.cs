using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class FloatGameEventListener : ParametrizedGameEventListener<float>
    {
        [Serializable]
        public class UnityEvent : UnityEvent<float> {}

        public UnityEvent UnityEventResponse;

        protected override void InvokeUnityEventResponse(float value)
        {
            UnityEventResponse.Invoke(value);
        }
    }
}