using UnityEngine;
using System.Collections;
using System;

public class Oscillator : Osc {
	public float max;
	public float min;
	public float speed; //seconds

	private float theta;
	private DateTime _lastTime;

	private float deltaMultiplier = 0.005f;

	private static System.Random random = new System.Random();

	private float piThing;
	// Use this for initialization
	void Start () {
		theta = (float)random.NextDouble()*Mathf.PI;
		_lastTime = DateTime.Now;
		piThing = Mathf.PI * 2f / 1000f; 
	}

	public override float GetValue(){
		return (Mathf.Sin(theta*piThing)*(max - min) + max + min ) / 2f;
	}

	// Update is called once per frame
	void Update () {
		var delta = GetDelta();
		theta += (delta / speed);

		_lastTime = DateTime.Now;
	}

	float GetDelta(){
		var now = DateTime.Now;
		return (float)(now - _lastTime).TotalMilliseconds;
	}
}

public class Osc : MonoBehaviour{
	public virtual float GetValue(){
		return 1f;
	}
}