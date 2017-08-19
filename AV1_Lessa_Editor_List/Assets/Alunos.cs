using System;
using UnityEngine;

public class Alunos : MonoBehaviour 
{ public  string[] names;
	
	void Start() { Array.Sort(names);
	}
	
}