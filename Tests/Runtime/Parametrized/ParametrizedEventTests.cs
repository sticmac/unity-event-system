using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Sticmac.EventSystem
{
    public abstract class ParametrizedEventTests<T>
        where T : struct
    {
        protected ParametrizedGameEvent<ParametrizedGameEventListener<T>, T> _gameEvent;
        protected ParametrizedGameEventListener<T> _listener;
        protected T _v;

        [SetUp]
        public void Setup() {
            SetupEventAndListener(out _gameEvent, out _listener);
        }

        protected abstract void SetupEventAndListener(
            out ParametrizedGameEvent<ParametrizedGameEventListener<T>, T> gameEvent,
            out ParametrizedGameEventListener<T> listener);

        [Test]
        public void EventIsRaised() {
            bool called = false;
            _listener.Response += (T param) => called = true;

            _gameEvent.Raise(_v);

            Assert.True(called);
        }

        [Test]
        public void EventIsRaisedWithGoodValue() {
            T val = default;
            _listener.Response += (T param) => val = param;

            _gameEvent.Raise(_v);

            Assert.AreEqual(_v, val);
        }
    }
}
