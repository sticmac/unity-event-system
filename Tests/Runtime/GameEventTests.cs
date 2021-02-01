using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sticmac.EventSystem
{
    public class GameEventTests
    {
        private GameEvent _gameEvent;
        private GameEventListener _listener;

        [SetUp]
        public void Setup() {
            _gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            GameObject go = new GameObject();
            _listener = go.AddComponent<GameEventListener>();
            _listener.Event = _gameEvent;
        }

        [Test]
        public void GameEventIsRaisedTest()
        {
            bool called = false;
            _listener.Response += () => called = true;

            _gameEvent.Raise();

            Assert.True(called);
        }
    }
}
