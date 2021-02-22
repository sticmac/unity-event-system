using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sticmac.EventSystem {
    public class GameObjectGameEventListener : ParametrizedGameEventListener<GameObject>
    {
        [Serializable]
        public class UnityEvent : UnityEvent<GameObject> {}

        public UnityEvent UnityEventResponse;

        protected override void InvokeUnityEventResponse(GameObject value)
        {
            UnityEventResponse.Invoke(value);
        }
    }
}