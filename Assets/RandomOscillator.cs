using UnityEngine;
using System.Collections;

public class RandomOscillator : Osc {


	private static System.Random random = new System.Random();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override float GetValue(){
		return 1f;
	}
}
