using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {

    [CreateAssetMenu(fileName = "Float Event", menuName = "Event System/Float Event", order = 1)]
    public class FloatGameEvent : ParametrizedGameEvent<ParametrizedGameEventListener<float>, float> {}
}
