using UnityEngine;
using UnityEditor;

namespace Sticmac.EventSystem {
    [CustomEditor(typeof(AbstractListener), true)]
    public abstract class AbstractGameEventListenerEditor : Editor {
        protected SerializedObject _so;

        protected SerializedProperty _responseModeProperty;
        protected SerializedProperty _unityEventResponseProperty;

        protected virtual void OnEnable() {
            _so = serializedObject;

            _responseModeProperty = _so.FindProperty("_responseActivationMode");
            _unityEventResponseProperty = _so.FindProperty("_unityEventResponse");
        }


        public override void OnInspectorGUI() {
            _so.Update();

            DrawEventEditor();
            EditorGUILayout.Space(5);
            DrawResponseEditor();

            _so.ApplyModifiedProperties();            
        }

        public void DrawResponseEditor() {
            EditorGUILayout.LabelField("Response", EditorStyles.boldLabel);

            EditorGUILayout.PropertyField(_responseModeProperty);

            EditorGUILayout.Space(5);

            // Display Unity Event Response **only** if InvokeUnityEvents mode is selected
            if ((AbstractListener.ResponseMode)_responseModeProperty.enumValueIndex == AbstractListener.ResponseMode.InvokeUnityEvents) {
                EditorGUILayout.PropertyField(_unityEventResponseProperty, new GUIContent("Response"));
            }
        }

        public abstract void DrawEventEditor();
    }
}