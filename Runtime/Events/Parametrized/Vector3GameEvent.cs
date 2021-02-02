using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {

    [CreateAssetMenu(fileName = "Vector3 Event", menuName = "Event System/Vector3 Event", order = 15)]
    public class Vector3GameEvent : ParametrizedGameEvent<ParametrizedGameEventListener<Vector3>, Vector3> {}
}
