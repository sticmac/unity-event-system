using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class Vector2EventTests : ParametrizedEventTests<Vector2>
    {
        protected override void SetupTestParameters(
          out ParametrizedGameEvent<ParametrizedGameEventListener<Vector2>, Vector2> gameEvent,
          out ParametrizedGameEventListener<Vector2> listener,
          out Vector2 value) {
            gameEvent = ScriptableObject.CreateInstance<Vector2GameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<Vector2GameEventListener>();
            listener.Event = gameEvent;
            value = Vector2.one;
        }
    }
}
