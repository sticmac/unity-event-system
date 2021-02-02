using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {

    [CreateAssetMenu(fileName = "String Event", menuName = "Event System/String Event", order = 15)]
    public class StringGameEvent : ParametrizedGameEvent<ParametrizedGameEventListener<string>, string> {}
}
