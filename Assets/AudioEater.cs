using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class AudioEater : MonoBehaviour {

	public float initialVolume;
	public float initalPitch;
	public List<Osc> volumeAdjusters;
	public List<Osc> pitchAdjusters;

	private AudioSource sauce;
	private static System.Random random = new System.Random();
	private DateTime startTime;
	private bool fadedIn = false;
	// Use this for initialization
	void Start () {
		startTime = DateTime.Now;
		sauce = GetComponent<AudioSource>();
		sauce.time = (float)(random.NextDouble())*(sauce.clip.length);
		setVolume();
		setPitch();
		sauce.Play();

	}
	
	// Update is called once per frame
	void Update () {
		setVolume();
		setPitch();
	}

	void setVolume(){
		if (fadedIn){
			sauce.volume = initialVolume * getMultiplier(volumeAdjusters);
		} else {
			var fade = getFadeIn();
			sauce.volume = fade * initialVolume * getMultiplier(volumeAdjusters);
			if (fade >= 1.0f){
				fadedIn = true;
			}
		}
	}

	void setPitch(){
		sauce.pitch = initalPitch * getMultiplier(pitchAdjusters); 
	}

	float getFadeIn(){
		var now = DateTime.Now;
		return ((float)(now - startTime).TotalMilliseconds)/3000f;
	}


	float getMultiplier(List<Osc> inList){
		var total = 1f;
		foreach(var osc in inList){
			total *= osc.GetValue();
		}
		
		return total;
	}

}
