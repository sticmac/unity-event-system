using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace Sticmac.EventSystem {
    [CustomEditor(typeof(ParametrizedGameEventListener<>), true)]
    public class ParametrizedGameEventListenerEditor : Editor {
        /// <summary>
        /// Event the listener listens to, stored as an Object
        /// </summary>
        private UnityEngine.Object _event = null;

        private Type _eventType;

        private SerializedObject _so;

        private SerializedProperty _serializedEventProperty;

        private void OnEnable() {
            _so = serializedObject;
            _serializedEventProperty = _so.FindProperty("_serializedEvent");

            // Reflection monstuosity to fetch the event's type
            _eventType = _so.targetObject.GetType().GetField("_event", BindingFlags.NonPublic | BindingFlags.Instance).FieldType;

            // Fetching asset from serialized GUID
            _event = _serializedEventProperty.objectReferenceValue;
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            // Field for ScriptableObject event
            var e = EditorGUILayout.ObjectField("Event", _event == null ? new UnityEngine.Object() : _event, _eventType, true);

            if (e != _event) { // New value was put in the field, we need to update everything
                _event = e;

                // Begin serialized object update
                _so.Update();

                // Updates the listener's event serialization field
                _serializedEventProperty.objectReferenceValue = _event;

                _so.ApplyModifiedProperties();
            }
        }
    }
}