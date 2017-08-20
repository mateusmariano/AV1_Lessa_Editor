using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System;
using UnityEditor.AnimatedValues;

public class AdicionarElementos : EditorWindow {
	AnimBool m_ShowExtraFields;
	AnimBool m_ShowExtraFields2;

	public string[] options = new string[] {"rigidbody", "sphere collider", "mesh collider"};
	public string[] options2 = new string[] {"cube", "sphere", "plane"};
	public static int index = 0;
	public static int index2 = 0;
	[MenuItem("Buzz/Drops")]
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
		m_ShowExtraFields.target = EditorGUILayout.ToggleLeft("Mostrar opçoes", m_ShowExtraFields.target);
		m_ShowExtraFields2.target = EditorGUILayout.ToggleLeft("nao aperte", m_ShowExtraFields2.target);
		if (EditorGUILayout.BeginFadeGroup(m_ShowExtraFields.faded))
		{
		index = EditorGUILayout.Popup(index, options);

		if (GUILayout.Button("Colocar componente"))
			Execute();
		index2 = EditorGUILayout.Popup(index2, options2);
			
		if (GUILayout.Button("Criar objeto"))
			InstantiatePrimitive();
		if (GUILayout.Button("Destruir objeto"))
			Destruir();
		}
		EditorGUILayout.EndFadeGroup();
		if(EditorGUILayout.BeginFadeGroup(m_ShowExtraFields2.faded)){
			EditorGUILayout.LabelField("Programei e sai correndo, pau no cu de quem ta lendo");
		}
		EditorGUILayout.EndFadeGroup();
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
