using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class FloatEventTests : ParametrizedEventTests<float>
    {
        protected override void SetupEventAndListener(
          out ParametrizedGameEvent<ParametrizedGameEventListener<float>, float> gameEvent,
          out ParametrizedGameEventListener<float> listener) {
            gameEvent = ScriptableObject.CreateInstance<FloatGameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<FloatGameEventListener>();
            listener.Event = gameEvent;
        }
    }
}
