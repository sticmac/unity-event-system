﻿using System;
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

        private SerializedProperty _eventGuidProperty;

        private void OnEnable() {
            _so = serializedObject;
            _eventGuidProperty = _so.FindProperty("_eventGuid");

            // Reflection monstuosity to fetch the event's type
            _eventType = _so.targetObject.GetType().GetField("Event", BindingFlags.NonPublic | BindingFlags.Instance).FieldType;

            // Fetching asset from serialized GUID
            string path = AssetDatabase.GUIDToAssetPath(_eventGuidProperty.stringValue);
            _event = AssetDatabase.LoadAssetAtPath(path, _eventType);
        }

        public override void OnInspectorGUI() {
            base.OnInspectorGUI();

            // Field for ScriptableObject event
            var e = EditorGUILayout.ObjectField("Event", _event, _eventType, true);

            if (e != _event) { // New value was put in the field, we need to update everything
                _event = e;

                // Begin serialized object update
                _so.Update();

                // Fetching event's asset GUID
                string path = AssetDatabase.GetAssetPath(_event);
                string assetGuid = AssetDatabase.AssetPathToGUID(path);

                // Updates the listener's serialization assetGuid field
                _eventGuidProperty.stringValue = assetGuid;

                _so.ApplyModifiedProperties();
            }
        }
    }
}