using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class Vector2GameEventListener : ParametrizedGameEventListener<Vector2>
    {
        [Serializable]
        public class UnityEvent : UnityEvent<Vector2> {}

        public UnityEvent UnityEventResponse;

        protected override void InvokeUnityEventResponse(Vector2 value)
        {
            UnityEventResponse.Invoke(value);
        }
    }
}