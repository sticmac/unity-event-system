using System;
using UnityEngine;

namespace Sticmac.EventSystem {
    /// <summary>
    /// Parent class for all game event listeners
    /// </summary>
    public abstract class AbstractListener : MonoBehaviour {
        [Serializable]
        public enum ResponseMode {
            InvokeUnityEvents,
            InvokeCSharpEvents
        }

        [SerializeField] protected ResponseMode _responseActivationMode;

        public ResponseMode ResponseActivationMode { get => _responseActivationMode; set => _responseActivationMode = value; }
    }
}
