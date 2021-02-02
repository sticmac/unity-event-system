﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {

    [CreateAssetMenu(fileName = "GameObject Event", menuName = "Event System/GameObject Event", order = 1)]
    public class GameObjectGameEvent : ParametrizedGameEvent<ParametrizedGameEventListener<GameObject>, GameObject> {}
}
