using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {

    [CreateAssetMenu(fileName = "Vector2 Event", menuName = "Event System/Vector2 Event", order = 15)]
    public class Vector2GameEvent : ParametrizedGameEvent<ParametrizedGameEventListener<Vector2>, Vector2> {}
}
