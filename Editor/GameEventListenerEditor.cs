using UnityEngine;
using UnityEditor;

namespace Sticmac.EventSystem {
    [CustomEditor(typeof(GameEventListener))]
    public class GameEventListenerEditor : AbstractGameEventListenerEditor
    {
        private SerializedProperty _eventProperty;

        protected override void OnEnable() {
            base.OnEnable();

            _eventProperty = _so.FindProperty("_event");
        }

        public override void DrawEventEditor()
        {
            EditorGUILayout.PropertyField(_eventProperty);
        }
    }
}