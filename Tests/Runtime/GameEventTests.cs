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
        public void ListenerShouldSubscribeOnlyOnceTest() {
            _gameEvent.RegisterListener(_listener);

            Assert.That(_gameEvent.Listeners, Is.Unique);
        }

        [Test]
        public void GameEventShouldRaiseListenerWithCSharpEvents()
        {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeCSharpEvents;
            int calledCount = 0;
            _listener.Response += () => calledCount++;

            _gameEvent.Raise();

            Assert.That(calledCount, Is.EqualTo(1));
        }

        [Test]
        public void GameEventShouldRaiseListenerWithUnityEvents()
        {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeUnityEvents;
            int calledCount = 0;
            _listener.UnityEventResponse += () => calledCount++;

            _gameEvent.Raise();

            Assert.That(calledCount, Is.EqualTo(1));
        }

        [Test]
        public void GameEventShouldNotRaiseListenerWithCSharpEventsWhenWrongModeIsSelected()
        {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeCSharpEvents;
            int calledCount = 0;
            _listener.UnityEventResponse += () => calledCount++;

            _gameEvent.Raise();

            Assert.That(calledCount, Is.EqualTo(0));
        }

        [Test]
        public void GameEventShouldNotRaiseListenerWithUnityEventsWhenWrongModeIsSelected()
        {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeUnityEvents;
            int calledCount = 0;
            _listener.Response += () => calledCount++;

            _gameEvent.Raise();

            Assert.That(calledCount, Is.EqualTo(0));
        }
    }
}
