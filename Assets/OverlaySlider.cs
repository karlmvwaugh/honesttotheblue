using UnityEngine;
using System;
using System.Collections;

public class OverlaySlider : MonoBehaviour {
	public TheRandom random; 

	public float minX = -11.0f;
	public float maxX = 11.0f;
	public float minY = -11.0f;
	public float maxY = 11.0f;

	public float minSizeX = 1f;
	public float maxSizeX = 2f;

	public float minSizeY = 1f;
	public float maxSizeY = 2f;

	private float minTime = 1.5f*60*1000f;
	private float maxTime = 4*60*1000f;

	private float lerpAmount; 
	
	private DateTime lastTime; 
	private float timeToNext = 100.0f;

	private SpriteRenderer renderer;
	private bool flipflop;
	
	private bool started = false; 

	private Vector3 oldScale;
	private Vector3 newScale;

	private Vector3 oldPosition;
	private Vector3 newPosition;

	// Use this for initialization
	void Start () {
		oldScale = new Vector3((minSizeX + maxSizeX)/2f, (minSizeY + maxSizeY)/2f, 0f);
		newScale = oldScale;
		oldPosition = new Vector3((minX + maxX)/2f, (minY + maxY)/2f, 0f);
		newPosition = oldPosition;

		lastTime = DateTime.Now;
		flipflop = true;
		renderer = GetComponent<SpriteRenderer>();
		timeToNext = rand (100.0f, 500.0f); 
		started = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(!started) return;
		
		if (IsTime()){
			
			SetPosition();
			SetSize();
			
			flop();
		} else {
			LerpPosition(lerpAmount);
			LerpScale (lerpAmount);
		}
	}
	
	
	void LerpPosition(float amount){
		transform.position = new Vector2(lerp (oldPosition.x, newPosition.x, amount), lerp (oldPosition.y, newPosition.y, amount));
	}
	
	void LerpScale(float amount){
		
		transform.localScale =new Vector2(lerp (oldScale.x, newScale.x, amount), lerp (oldScale.y, newScale.y, amount));
	}
	
	
	void SetPosition(){
		oldPosition = newPosition;
		newPosition = new Vector2(rand (minX, maxX), rand (minY, maxY));
	}
	
	void SetSize(){
		oldScale = newScale;
		newScale = new Vector2(rand (minSizeX, maxSizeX), rand (minSizeY, maxSizeY));
	}
	
	float lerp(float first, float second, float amount){
		return (second - first)*amount + first; 
	}
	
	void flop(){
		flipflop = !flipflop;
		
	}
	
	float rand(float first, float second){
		return random.NextDouble()*(second - first) + first;
	}
	
	bool IsTime(){
		var now = DateTime.Now;
		var difference = (now - lastTime);
		if (difference.TotalMilliseconds > timeToNext){
			lastTime = now;
			if (flipflop) timeToNext = rand (minTime, maxTime); 
			return true;
		}
		
		lerpAmount = ((float)difference.TotalMilliseconds) / timeToNext;
		
		return false; 
	}

}
