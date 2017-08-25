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


public class AdicionarElementos : EditorWindow {
	
	AnimBool m_ShowExtraFields;
	AnimBool m_ShowExtraFields2;
	public string[] options = new string[] {"rigidbody", "sphere collider", "mesh collider","light"};
	public string[] options2 = new string[] {"cube", "sphere", "plane"};
	public static int index = 0;
	public static int index2 = 0;
	bool change; 

	[MenuItem("Buzz/Drops #k")]
	static void Init(){
		EditorWindow window = GetWindow(typeof(AdicionarElementos));
	}

	void OnEnable()
	{
		m_ShowExtraFields = new AnimBool(false);
		m_ShowExtraFields.valueChanged.AddListener(Repaint);
		m_ShowExtraFields2 = new AnimBool(false);
		m_ShowExtraFields2.valueChanged.AddListener(Repaint);
	}
	void OnGUI(){
		//GUILayout.BeginHorizontal();
		
		GUIStyle gs = new GUIStyle();
		/*Color cl =  EditorGUILayout.ColorField();
		GUI.color = cl;*/
		m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Mostrar opçoes", m_ShowExtraFields.target);
	//	m_ShowExtraFields2.target = EditorGUILayout.ToggleLeft("nao aperte", m_ShowExtraFields2.target);

		if (EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
		{
			index = EditorGUILayout.Popup(index, options,GUILayout.Width(100),GUILayout.Height(13));

			if (GUILayout.Button("Colocar componente", GUILayout.Width(140),GUILayout.Height(20)))
			Execute();
			index2 = EditorGUILayout.Popup(index2, options2,GUILayout.Width(100),GUILayout.Height(13));
			
			if (GUILayout.Button("Criar objeto", GUILayout.Width(100),GUILayout.Height(20)))
			InstantiatePrimitive();
			if (GUILayout.Button("Destruir objeto", GUILayout.Width(100),GUILayout.Height(20)))
			Destruir();
			GUILayout.Space(10);
			EditorGUILayout.HelpBox("Buzz drops @Copyright 2017. All rights reserved.", MessageType.Error);
		
		
	}
		EditorGUILayout.EndFadeGroup();
		GUILayout.Label("Relogio: " + System.DateTime.Now.ToString());
		GUILayout.Label("Computador do : " + System.Environment.UserName);


		if(EditorGUILayout.BeginFadeGroup(m_ShowExtraFields2.faded)){
		}
		EditorGUILayout.EndFadeGroup();
	//GUILayout.EndHorizontal();

	}

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

}
