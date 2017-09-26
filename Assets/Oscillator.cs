using UnityEngine;
using System.Collections;
using System;

public class Oscillator : MonoBehaviour {
	public float max;
	public float min;
	public float speed;

	private float theta;
	private DateTime _lastTime;

	private float deltaMultiplier = 0.005f;
	// Use this for initialization
	void Start () {
		theta = 0f;
		_lastTime = DateTime.Now;
	}

	public float GetValue(){
		return (Mathf.Sin(theta)*(max - min) + max + min ) / 2f;
	}

	// Update is called once per frame
	void Update () {
		var delta = GetDelta();
		theta += (delta * speed * deltaMultiplier);

		_lastTime = DateTime.Now;
	}

	float GetDelta(){
		var now = DateTime.Now;
		return (float)(now - _lastTime).TotalMilliseconds;
	}
}
