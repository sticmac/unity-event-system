using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class IntEventTests : ParametrizedEventTests<int>
    {
        protected override void SetupEventAndListener(
          out ParametrizedGameEvent<ParametrizedGameEventListener<int>, int> gameEvent,
          out ParametrizedGameEventListener<int> listener) {
            gameEvent = ScriptableObject.CreateInstance<IntGameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<IntGameEventListener>();
            listener.Event = gameEvent;
        }
    }
}
