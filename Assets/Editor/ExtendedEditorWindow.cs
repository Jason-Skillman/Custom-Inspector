using System;
using UnityEditor;
using UnityEngine;

public class ExtendedEditorWindow : EditorWindow {

	protected SerializedObject serializedObject;
	protected SerializedProperty currentProperty;

	protected void DrawProperties(SerializedProperty property, bool drawChildren) {
		string lastPropertyPath = string.Empty;

		foreach(SerializedProperty sp in property) {
			if(sp.isArray && sp.propertyType.Equals(SerializedPropertyType.Generic)) {
				
				EditorGUILayout.BeginHorizontal();
				sp.isExpanded = EditorGUILayout.Foldout(sp.isExpanded, sp.displayName);
				EditorGUILayout.EndHorizontal();

				if(sp.isExpanded) {
					EditorGUI.indentLevel++;
					DrawProperties(sp, drawChildren);
					EditorGUI.indentLevel--;
				} else {
					if(!string.IsNullOrEmpty(lastPropertyPath) && sp.propertyPath.Contains(lastPropertyPath))
						continue;
					lastPropertyPath = sp.propertyPath;
					EditorGUILayout.PropertyField(sp, drawChildren);
				}
				
			}
		}
	}

}