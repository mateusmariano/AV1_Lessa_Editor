using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class AlunosEditorWindow : EditorWindow
{
	const int topad = 2;
	const string help = "Erro";
	static Vector2 s_WindowsMinSize = Vector2.one * 300.0f;
	static Rect s_HelpRect = new Rect(0.0f, 0.0f, 300.0f, 100.0f);
	static Rect s_ListRect = new Rect(Vector2.zero, s_WindowsMinSize);
	
	[MenuItem("Window/Alunos/Open Window")]
	static void Initialize(){
		AlunosEditorWindow window = EditorWindow.GetWindow<AlunosEditorWindow>(true, "Make Animal List");
		window.minSize = s_WindowsMinSize;
		window.name = ("Alunos");
		
	}
	SerializedObject m_AlunosSO = null;
	ReorderableList m_ReorderableList = null;
	
	void OnEnable(){
		Alunos alunos = FindObjectOfType<Alunos>();
		if(alunos){
			m_AlunosSO = new SerializedObject(alunos);
			m_ReorderableList = new ReorderableList(m_AlunosSO, m_AlunosSO.FindProperty("names"), true, true, true, true);
			
			m_ReorderableList.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "NOmes dos alunos");
			m_ReorderableList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
			{
				rect.y += topad;
				rect.height = EditorGUIUtility.singleLineHeight;
				EditorGUI.PropertyField(rect, m_ReorderableList.serializedProperty.GetArrayElementAtIndex(index));
			};
		}
	}
	
	void OnInspectorUpdate(){
		Repaint();
	}
	
	void OnGUI(){      
		if(m_AlunosSO != null){
			m_AlunosSO.Update();
			m_ReorderableList.DoList(s_ListRect);
			m_AlunosSO.ApplyModifiedProperties();
		}else
		{
			EditorGUI.HelpBox(s_HelpRect, help, MessageType.Warning);
		}
	}
}