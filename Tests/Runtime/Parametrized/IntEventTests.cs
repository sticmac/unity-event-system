using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class IntEventTests : ParametrizedEventTests<int>
    {
        protected override void SetupTestParameters(
          out ParametrizedGameEvent<ParametrizedGameEventListener<int>, int> gameEvent,
          out ParametrizedGameEventListener<int> listener,
          out int value) {
            gameEvent = ScriptableObject.CreateInstance<IntGameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<IntGameEventListener>();
            listener.Event = gameEvent;
            value = 42;
        }
    }
}
