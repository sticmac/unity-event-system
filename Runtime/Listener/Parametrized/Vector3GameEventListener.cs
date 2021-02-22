using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class Vector3GameEventListener : ParametrizedGameEventListener<Vector3>
    {
        [Serializable]
        public class UnityEvent : UnityEvent<Vector3> {}

        public UnityEvent UnityEventResponse;

        protected override void InvokeUnityEventResponse(Vector3 value)
        {
            UnityEventResponse.Invoke(value);
        }
    }
}