using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    public class GameObjectEventTests : ParametrizedEventTests<GameObject>
    {
        protected override void SetupTestParameters(
          out ParametrizedGameEvent<ParametrizedGameEventListener<GameObject>, GameObject> gameEvent,
          out ParametrizedGameEventListener<GameObject> listener,
          out GameObject value) {
            gameEvent = ScriptableObject.CreateInstance<GameObjectGameEvent>();
            GameObject go = new GameObject();
            listener = go.AddComponent<GameObjectGameEventListener>();
            listener.Event = gameEvent;
            value = new GameObject();
        }
    }
}
