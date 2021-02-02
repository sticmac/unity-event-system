using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {

    [CreateAssetMenu(fileName = "Int Event", menuName = "Event System/Int Event", order = 15)]
    public class IntGameEvent : ParametrizedGameEvent<ParametrizedGameEventListener<int>, int> {}
}
