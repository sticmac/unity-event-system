using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class FloatEventTests : ParametrizedEventTests<float>
    {
        protected override void SetupTestParameters(
          out ParametrizedGameEvent<float> gameEvent,
          out ParametrizedGameEventListener<float> listener,
          out float value) {
            gameEvent = ScriptableObject.CreateInstance<FloatGameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<FloatGameEventListener>();
            listener.Event = gameEvent;
            value = 42f;
        }
    }
}
