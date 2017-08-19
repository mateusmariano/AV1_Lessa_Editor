using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Controller))]
[CanEditMultipleObjects]

public class ControllerEditor : Editor {
	int media;
	public override void OnInspectorGUI () 
	{
		Controller Controller = target as Controller;
		for (int i = 0; i < Controller.lista.Count; i++) {
			Controller.lista [i].aluno = EditorGUILayout.TextField ("Nome do Aluno " + i.ToString(), Controller.lista[i].aluno);
			EditorGUILayout.LabelField ("Coloque a 1° e a 2° nota do Aluno abaixo");
			Controller.lista[i].nota1 = EditorGUILayout.IntField (Controller.lista[i].nota1);
			Controller.lista[i].nota2 = EditorGUILayout.IntField (Controller.lista[i].nota2);
			EditorGUILayout.LabelField ("Aluno: " + Controller.lista[i].aluno);
			EditorGUILayout.LabelField ("Nota 1: " + Controller.lista [i].nota1);
			EditorGUILayout.LabelField ("Nota 2: " + Controller.lista [i].nota2);
			media = (Controller.lista[i].nota1 + Controller.lista[i].nota2)/2;
			if(media >= 10){
			EditorGUILayout.LabelField("O aluno foi aprovado.Ele obteve nota: " + media);
			}else{
			EditorGUILayout.LabelField("O aluno foi reprovado.Ele obteve nota: " + media);
			}
		}
		if (GUILayout.Button ("Adicionar aluno")) {
			Controller.lista.Add (new Entry("Aluno " + Controller.lista.Count.ToString(), Controller.lista.Count, Controller.lista.Count));
		}
	}
}	
