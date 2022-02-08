namespace GameCreator.UIComponents
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;
	using GameCreator.Core;
    using GameCreator.Core.Hooks;
	using GameCreator.Variables;

#if UNITY_EDITOR
    using UnityEditor;
	#endif

	[AddComponentMenu("")]
	public class ActionShakeElement : IAction
	{
		public GameObject shaker;
		public NumberProperty Duration = new NumberProperty(3.0f);
		public NumberProperty Amount = new NumberProperty(5.0f);
		public NumberProperty Repeat = new NumberProperty(0);
		public NumberProperty RepeatDelay = new NumberProperty(1.0f);

 		private Vector3 originalPos;
		
        // EXECUTABLE: ----------------------------------------------------------------------------

        public override bool InstantExecute(GameObject target, IAction[] actions, int index)
        {
        	originalPos = shaker.transform.parent.localPosition;
	        float duration = Duration.GetValue(target);
	        float amount = Amount.GetValue(target);
	        int repeat = Repeat.GetInt(target);
	        float delay = RepeatDelay.GetValue(target);

        	StopAllCoroutines();  
	        StartCoroutine(cShake(duration, amount, repeat, delay));
	        
            return true;
        }

        public override IEnumerator Execute(GameObject target, IAction[] actions, int index)
        {
          
            return base.Execute(target, actions, index);
        }


		public IEnumerator cShake (float duration, float amount, int repeat, float delay) {
			
			shaker.transform.localPosition = originalPos;

		for (int i = 0; i < repeat; ++i)
			{
			float endTime = Time.time + duration;

			while (Time.time < endTime) {
				shaker.transform.localPosition = originalPos + Random.insideUnitSphere * amount;
				yield return null;

				}
				yield return new WaitForSeconds(delay);
			}
			
				
			shaker.transform.localPosition = originalPos;

			
		}
        // +--------------------------------------------------------------------------------------+
        // | EDITOR                                                                               |
        // +--------------------------------------------------------------------------------------+

        #if UNITY_EDITOR

		public static new string NAME = "UI/Elements/Shake UI Element";
		private const string NODE_TITLE = "Shake UI Element";
		public const string CUSTOM_ICON_PATH = "Assets/PivecLabs/UIComponents/Icons/";

        // PROPERTIES: ----------------------------------------------------------------------------

        private SerializedProperty spFloatObjectShaker; 
		private SerializedProperty spFloatDuration;
		private SerializedProperty spFloatAmount;
		private SerializedProperty spIntRepeat;
		private SerializedProperty spFloatDelay;

        // INSPECTOR METHODS: ---------------------------------------------------------------------

        public override string GetNodeTitle()
		{
			return string.Format(NODE_TITLE);
		}

		protected override void OnEnableEditorChild ()
		{
            this.spFloatObjectShaker = this.serializedObject.FindProperty("shaker"); 
            this.spFloatDuration = this.serializedObject.FindProperty("Duration");
            this.spFloatAmount = this.serializedObject.FindProperty("Amount");
			this.spIntRepeat = this.serializedObject.FindProperty("Repeat");
			this.spFloatDelay = this.serializedObject.FindProperty("RepeatDelay");
		}

        protected override void OnDisableEditorChild ()
		{
            this.spFloatObjectShaker = null; 
            this.spFloatDuration = null;
            this.spFloatAmount = null;
			this.spIntRepeat = null;
			this.spFloatDelay = null;
		}

        public override void OnInspectorGUI()
		{
			this.serializedObject.Update();

			EditorGUILayout.PropertyField(this.spFloatObjectShaker, new GUIContent("Element")); 
			EditorGUI.indentLevel++;
			EditorGUILayout.PropertyField(this.spFloatDuration, new GUIContent("Duration"));
			EditorGUILayout.PropertyField(this.spFloatAmount, new GUIContent("Amount"));
			EditorGUILayout.PropertyField(this.spIntRepeat, new GUIContent("Count"));
			EditorGUILayout.PropertyField(this.spFloatDelay, new GUIContent("Delay"));
			EditorGUI.indentLevel--;
			
            this.serializedObject.ApplyModifiedProperties();
		}

		#endif
	}
}
