using System;
using System.Reflection;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace Sticmac.EventSystem {
    [CustomEditor(typeof(ParametrizedGameEventListener<>), true)]
    public class ParametrizedGameEventListenerEditor : AbstractGameEventListenerEditor {
        protected SerializedProperty _serializedEventProperty;

        /// <summary>
        /// Event the listener listens to, stored as an Object
        /// </summary>
        protected UnityEngine.Object _event = null;

        protected Type _eventType;

        protected override void OnEnable() {
            base.OnEnable();
            _serializedEventProperty = _so.FindProperty("_serializedEvent");

            // Reflection monstuosity to fetch the event's type
            Type type = _so.targetObject.GetType().GetField("_event", BindingFlags.NonPublic | BindingFlags.Instance).FieldType;
            _eventType = Assembly.GetAssembly(type).GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(type)).First();

            // Fetching asset from serialized GUID
            _event = _serializedEventProperty.objectReferenceValue;
        }

        public override void DrawEventEditor()
        {
            // Field for ScriptableObject event
            _event = EditorGUILayout.ObjectField("Event", _event == null ? new UnityEngine.Object() : _event, _eventType, true);

            // Updates the listener's event serialization field
            _serializedEventProperty.objectReferenceValue = _event;
        }
    }
}