namespace PivecLabs.ActionPack
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
	using GameCreator.Core;

	#if UNITY_EDITOR
	using UnityEditor;
	#endif

	[AddComponentMenu("")]
	public class Action3DTextMeshClockStop : IAction
	{
    
         public Actions actions;


        // EXECUTABLE: ----------------------------------------------------------------------------

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {

            var references = this.actions.gameObject.GetComponents<Action3DTextMeshClock>();

            foreach (var reference in references)
            {
                reference.StopRepeating();
            }




            return true;
        }

        public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
        {
            return base.Execute(target, actions, index);
        }



        // +--------------------------------------------------------------------------------------+
        // | EDITOR                                                                               |
        // +--------------------------------------------------------------------------------------+

#if UNITY_EDITOR

        public static new string NAME = "ActionPack1/TMP/3D TextMesh Clock Stop";
		private const string NODE_TITLE = "Stop Display of System Time";
        public const string CUSTOM_ICON_PATH = "Assets/PivecLabs/ActionPack1/Icons/";

        // PROPERTIES: ----------------------------------------------------------------------------

        private SerializedProperty sptextmesh;
  
        // INSPECTOR METHODS: ---------------------------------------------------------------------

        public override string GetNodeTitle()
		{
			return string.Format(NODE_TITLE);
		}

		protected override void OnEnableEditorChild ()
		{
			this.sptextmesh = this.serializedObject.FindProperty("actions");
        }

        protected override void OnDisableEditorChild ()
		{
			this.sptextmesh = null;
          }
        public override void OnInspectorGUI()
		{
			this.serializedObject.Update();

	        EditorGUILayout.PropertyField(this.sptextmesh, new GUIContent("Display Clock Action"));
            

            this.serializedObject.ApplyModifiedProperties();
		}

#endif
    }
}
