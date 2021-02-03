using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class Vector3EventTests : ParametrizedEventTests<Vector3>
    {
        protected override void SetupTestParameters(
          out ParametrizedGameEvent<ParametrizedGameEventListener<Vector3>, Vector3> gameEvent,
          out ParametrizedGameEventListener<Vector3> listener,
          out Vector3 value) {
            gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<Vector3GameEventListener>();
            listener.Event = gameEvent;
            value = Vector3.one;
        }
    }
}
