using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class StringEventTests : ParametrizedEventTests<string>
    {
        protected override void SetupTestParameters(
          out ParametrizedGameEvent<ParametrizedGameEventListener<string>, string> gameEvent,
          out ParametrizedGameEventListener<string> listener,
          out string value) {
            gameEvent = ScriptableObject.CreateInstance<StringGameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<StringGameEventListener>();
            listener.Event = gameEvent;
            value = "42";
        }
    }
}
