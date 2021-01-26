﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sticmac.EventSystem {
    /// <summary>
    /// Game Event without Parameter
    /// </summary>
    [CreateAssetMenu(fileName = "Game Event", menuName = "Event System/Game Event", order = 0)]
    public class GameEvent : AbstractGameEvent<GameEventListener>
    {
        public void Raise() {
            for(int i = _listeners.Count -1; i >= 0; i--)
                _listeners[i].OnEventRaised();
        }
    }
}
