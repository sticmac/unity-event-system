using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sticmac.EventSystem
{
    public abstract class ParametrizedEventTests<T>
    {
        protected ParametrizedGameEvent<T> _gameEvent;
        protected ParametrizedGameEventListener<T> _listener;
        protected T _v;

        [SetUp]
        public void Setup() {
            SetupTestParameters(out _gameEvent, out _listener, out _v);
        }

        protected abstract void SetupTestParameters(
            out ParametrizedGameEvent<T> gameEvent,
            out ParametrizedGameEventListener<T> listener,
            out T value);

        [Test]
        public void GameEventShouldRaiseListenerWithCSharpEvents() {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeCSharpEvents;
            int calledCount = 0;
            _listener.Response += (T param) => calledCount++;

            _gameEvent.Raise(_v);

            Assert.That(calledCount, Is.EqualTo(1));
        }

        [Test]
        public void GaeEventShouldRaiseListenerWithGoodValueWithCSharpEvents() {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeCSharpEvents;
            T val = default(T);
            _listener.Response += (T param) => val = param;

            _gameEvent.Raise(_v);

            Assert.That(val, Is.EqualTo(_v));
        }

        [Test]
        public void GameEventShouldRaiseListenerWithUnityEvents() {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeUnityEvents;
            int calledCount = 0;
            _listener.UnityEventResponse += (T param) => calledCount++;

            _gameEvent.Raise(_v);

            Assert.That(calledCount, Is.EqualTo(1));
        }

        [Test]
        public void GameEventShouldRaiseListenerWithGoodValueWithUnityEvents() {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeUnityEvents;
            T val = default(T);
            _listener.UnityEventResponse += (T param) => val = param;

            _gameEvent.Raise(_v);

            Assert.That(val, Is.EqualTo(_v));
        }

        [Test]
        public void GameEventShouldNotRaiseListenerWithUnityEventsWhenWrongModeIsUsed() {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeCSharpEvents;
            int calledCount = 0;
            _listener.UnityEventResponse += (T param) => calledCount++;

            _gameEvent.Raise(_v);

            Assert.That(calledCount, Is.EqualTo(0));
        }
        
        [Test]
        public void GameEventShouldNotRaiseListenerWithCSharpEventsWhenWrongModeIsUsed() {
            _listener.ResponseActivationMode = AbstractListener.ResponseMode.InvokeUnityEvents;
            int calledCount = 0;
            _listener.Response += (T param) => calledCount++;

            _gameEvent.Raise(_v);

            Assert.That(calledCount, Is.EqualTo(0));
        }
    }
}
