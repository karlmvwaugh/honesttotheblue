using UnityEngine;
using System; 
using System.Collections;

public class OpacityAndSwap : MonoBehaviour {
	public Sprite[] theSprites;
	public TheRandom random; 
	public float opacityMultiplier = 1f;
	private SpriteRenderer renderer; 

	private float time = 1000f; //10 seconds. 
	private DateTime _beginTime; 

	private float _startingOpacity = 0f;
	private float _endingOpacity = 0f;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<SpriteRenderer>();
		_beginTime = DateTime.Now; 
		_startingOpacity = 0.5f + 0.5f*random.NextDouble(); 
		_endingOpacity = 0f; 
		time = random.NextDouble()*    2*60*1000;
		NextSprite();
		UpdateOpacity(0f); 
		//NewValues();
	}
	
	// Update is called once per frame
	void Update () {
		var newOpacity = getNextOpacity();
		UpdateOpacity(newOpacity);
		NextRound();
	}

	float getNextOpacity(){
		var now = DateTime.Now;
		var fractionDone = (float)(now - _beginTime).TotalMilliseconds / time;

		return _startingOpacity + fractionDone*(_endingOpacity - _startingOpacity);
	}

	void UpdateOpacity(float newOpacity){
		Color c = renderer.material.color;
		c.a = opacityMultiplier*newOpacity ;
		renderer.material.color = c; 
	}

	void NextRound(){
		var now = DateTime.Now;
		if ((now - _beginTime).TotalMilliseconds >= time){
			NewValues();
		}
	}

	void NewValues(){
		_beginTime = DateTime.Now;
		time = random.NextDouble()*    2*60*1000;
		
		NextOpacityRanges();
		if (_startingOpacity == 0f){
			NextSprite(); 
		}
	}

	void NextOpacityRanges(){
		if (_endingOpacity == 0f){
			_startingOpacity = 0f;
			_endingOpacity = 0.5f + 0.5f*random.NextDouble(); 
		} else {
			_startingOpacity = _endingOpacity;
			_endingOpacity = 0f; 
		}
	}

	void NextSprite(){
		var nextSprite = theSprites[random.Next(0, theSprites.Length)];
		renderer.sprite = nextSprite; 
	}
}
