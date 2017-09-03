#region assemblies
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System;
using UnityEditor.AnimatedValues;
using UnityEngine.UI;
using System.Reflection;
using Type = System.Type;
using UnityEditorInternal;
#endregion
public class BuzzDrops : EditorWindow {


	#region var
	AnimBool m_ShowExtraFields;
	AnimBool m_ShowExtraFields2;
	public string[] options = new string[] {"rigidbody", "sphere collider", "mesh collider","light"};
	public string[] options2 = new string[] {"cube", "sphere", "plane"};
	public string[] options3 = InternalEditorUtility.tags;
	public static int index = 0;
	public static int index2 = 0;
	public static int index3 = 0;
	string hour;
	bool change; 
	public string Folder;
	int index_screenshot;
	#endregion
		
	
	#region location of the Editor drop
	[MenuItem("Buzz/Drops #Q")]
	static void Init(){
		EditorWindow window = GetWindow(typeof(BuzzDrops));

	}
	#endregion

	#region Enable
	void OnEnable()
	{
		m_ShowExtraFields = new AnimBool(false);
		m_ShowExtraFields.valueChanged.AddListener(Repaint);
		m_ShowExtraFields2 = new AnimBool(false);
		m_ShowExtraFields2.valueChanged.AddListener(Repaint);
	}
	#endregion
	#region GUI and buttons


	void OnGUI(){
		//GUILayout.BeginHorizontal();

		GUIStyle gs = new GUIStyle();
		/*Color cl =  EditorGUILayout.ColorField();
		GUI.color = cl;*/
		m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Mostrar opçoes", m_ShowExtraFields.target);
		m_ShowExtraFields2.target = EditorGUILayout.ToggleLeft("nao aperte", m_ShowExtraFields2.target);

		if (EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
		{
		index = EditorGUILayout.Popup(index, options);
		if (GUILayout.Button("Colocar componente",GUILayout.Width(150),GUILayout.Height(20)))
			Execute();
			GUILayout.Space(10);

		index2 = EditorGUILayout.Popup(index2, options2);
		if (GUILayout.Button("Criar objeto",GUILayout.Width(150),GUILayout.Height(20)))
				InstantiatePrimitive();
			GUILayout.Space(10);

		index3 = EditorGUILayout.Popup(index3,options3);
		if (GUILayout.Button("Colocar tag",GUILayout.Width(150),GUILayout.Height(20)))
				TheTag();
			GUILayout.Space(10);


		foreach(GameObject obj in Selection.gameObjects){
			string name = obj.name;
			EditorGUILayout.TextArea("Objetos selecionados");
			EditorGUILayout.TextField(name);
			}
		if (GUILayout.Button("Destruir objetos",GUILayout.Width(150),GUILayout.Height(20)))
			Destruir();
			GUILayout.Space(20);
		
	}
		EditorGUILayout.EndFadeGroup();

		GUILayout.Label("Relogio " + System.DateTime.Now.ToString());	
		GUILayout.Label("Computador do : " + System.Environment.UserName);
		EditorGUILayout.HelpBox("Buzz drops @Copyright 2017. All rights reserved.", MessageType.Error);
		if(EditorGUILayout.BeginFadeGroup(m_ShowExtraFields2.faded)){
			EditorGUILayout.LabelField("Programei e sai correndo, pau no cu de quem ta lendo");
		}
		EditorGUILayout.EndFadeGroup();

	}
	#endregion

	#region Voids

	static void Execute(){
		foreach (GameObject obj in Selection.gameObjects) {
			switch(index) {
			case 0:
			obj.AddComponent(typeof(Rigidbody));
				break;
			
			case 1:
			obj.AddComponent(typeof(SphereCollider));
			break;
			
			case 2:
			obj.AddComponent(typeof(MeshCollider));
			break;

			case 3:
				obj.AddComponent(typeof(Light));
				break;
			}

		}
	}
	void InstantiatePrimitive(){
		switch (index2){
		case 0:
			GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
			cube.transform.position = Vector3.zero;
			break;
		case 1:
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.transform.position = Vector3.zero;
			break;
		case 2:
			GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
			plane.transform.position = Vector3.zero;
			break;
		
	}
}
	void Destruir(){

		foreach(GameObject obj in Selection.gameObjects){
			GameObject.DestroyImmediate(obj);
		}

	}
	void TheTag(){
		foreach(GameObject obj in Selection.gameObjects){
			switch(index3){
			case 0 : 
				obj.tag = InternalEditorUtility.tags[index3];
				break;
			case 1 : 
				obj.tag = InternalEditorUtility.tags[index3];
				break;
			case 2 : 
				obj.tag = InternalEditorUtility.tags[index3];
				break;
			case 3 : 
				obj.tag = InternalEditorUtility.tags[index3];
				break;
			case 4 : 
				obj.tag = InternalEditorUtility.tags[index3];
				break;
			case 5 : 
				obj.tag = InternalEditorUtility.tags[index3];
				break;
			case 6 : 
				obj.tag = InternalEditorUtility.tags[index3];
				break;
			}
		}
	}
	#endregion

}
