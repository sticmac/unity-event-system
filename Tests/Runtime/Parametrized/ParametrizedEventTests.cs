using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sticmac.EventSystem
{
    public abstract class ParametrizedEventTests<T>
    {
        protected ParametrizedGameEvent<ParametrizedGameEventListener<T>, T> _gameEvent;
        protected ParametrizedGameEventListener<T> _listener;
        protected T _v;

        [SetUp]
        public void Setup() {
            SetupTestParameters(out _gameEvent, out _listener, out _v);
        }

        protected abstract void SetupTestParameters(
            out ParametrizedGameEvent<ParametrizedGameEventListener<T>, T> gameEvent,
            out ParametrizedGameEventListener<T> listener,
            out T value);

        [Test]
        public void EventIsRaised() {
            bool called = false;
            _listener.Response += (T param) => called = true;

            _gameEvent.Raise(_v);

            Assert.True(called);
        }

        [Test]
        public void EventIsRaisedWithGoodValue() {
            T val = default(T);
            _listener.Response += (T param) => val = param;

            _gameEvent.Raise(_v);

            Assert.AreEqual(_v, val);
        }
    }
}
