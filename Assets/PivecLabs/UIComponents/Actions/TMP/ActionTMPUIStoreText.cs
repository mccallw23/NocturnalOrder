namespace GameCreator.UIComponents
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.Events;
	using GameCreator.Core;
	using GameCreator.Variables;
	using TMPro;

#if UNITY_EDITOR
	using UnityEditor;
	#endif

	[AddComponentMenu("")]
	public class ActionTMPUIStoreText : IAction
	{
    
		[VariableFilter(Variable.DataType.String)]
		public VariableProperty targetVariable = new VariableProperty(Variable.VarType.GlobalVariable);
		public TMP_Text tmptext;
		public string content = "{0}";


		// EXECUTABLE: ----------------------------------------------------------------------------
		public override bool InstantExecute(GameObject target, IAction[] actions, int index)
		{
			if (this.tmptext != null)  
			{
              
				this.targetVariable.Set(this.tmptext.text, target);

               
			}


			return true;
		}


      
		// +--------------------------------------------------------------------------------------+
		// | EDITOR                                                                               |
		// +--------------------------------------------------------------------------------------+

#if UNITY_EDITOR

		public const string CUSTOM_ICON_PATH = "Assets/PivecLabs/UIComponents/Icons/";

		public static new string NAME = "UI/TMP/Store TMP Text";
		private const string NODE_TITLE = "Store TMP Text";

		// PROPERTIES: ----------------------------------------------------------------------------

		private SerializedProperty sptext;
		private SerializedProperty sptargetVariable;
   
		// INSPECTOR METHODS: ---------------------------------------------------------------------

		public override string GetNodeTitle()
		{
			return string.Format(NODE_TITLE);
		}

		protected override void OnEnableEditorChild()
		{
			this.sptext = this.serializedObject.FindProperty("tmptext");
			this.sptargetVariable = this.serializedObject.FindProperty("targetVariable");
		}

		protected override void OnDisableEditorChild()
		{
			this.sptext = null;
			this.sptargetVariable = null;
		}

		public override void OnInspectorGUI()
		{
			this.serializedObject.Update();
			EditorGUILayout.PropertyField(this.sptext, new GUIContent("TMP UI Text Field"));

			EditorGUILayout.Space();
			EditorGUILayout.PropertyField(this.sptargetVariable, new GUIContent("Target Variable"));
     
			EditorGUILayout.Space();

			this.serializedObject.ApplyModifiedProperties();
		}

#endif
	}
}