using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class StringEventTests : ParametrizedEventTests<string>
    {
        protected override void SetupEventAndListener(
          out ParametrizedGameEvent<ParametrizedGameEventListener<string>, string> gameEvent,
          out ParametrizedGameEventListener<string> listener) {
            gameEvent = ScriptableObject.CreateInstance<StringGameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<StringGameEventListener>();
            listener.Event = gameEvent;
        }
    }
}
