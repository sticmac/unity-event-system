using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class Vector3EventTests : ParametrizedEventTests<Vector3>
    {
        protected override void SetupEventAndListener(
          out ParametrizedGameEvent<ParametrizedGameEventListener<Vector3>, Vector3> gameEvent,
          out ParametrizedGameEventListener<Vector3> listener) {
            gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<Vector3GameEventListener>();
            listener.Event = gameEvent;
        }
    }
}
