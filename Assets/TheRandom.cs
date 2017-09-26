using UnityEngine;
using System; 
using System.Collections;

public class TheRandom : MonoBehaviour {
	private static System.Random random = new System.Random();
	// Use this for initialization
	void Start () {
	}

	public int Next(int min, int max){
		return random.Next(min, max);
	}

	public float NextDouble(){
		return (float)random.NextDouble();
	}


	// Update is called once per frame
	void Update () {
	
	}
}
