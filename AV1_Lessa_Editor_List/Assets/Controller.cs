using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Controller : MonoBehaviour {
	public List<Entry> lista = new List<Entry>();
}

public class Entry {
	public string aluno;
	public int nota1;
	public int nota2;

	public Entry( string a, int b, int c){
		aluno = a;
		nota1 = b;
		nota2 = c;
	}
}