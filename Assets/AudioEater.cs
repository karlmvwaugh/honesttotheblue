using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioEater : MonoBehaviour {

	public float initialVolume;
	public float initalPitch;
	public List<Oscillator> volumeAdjusters;
	public List<Oscillator> pitchAdjusters;

	private AudioSource sauce;


	// Use this for initialization
	void Start () {
		sauce = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		sauce.volume = initialVolume * getMultiplier(volumeAdjusters);
		sauce.pitch = initalPitch * getMultiplier(pitchAdjusters); 
	}


	float getMultiplier(List<Oscillator> inList){
		var total = 1f;
		foreach(var osc in inList){
			total *= osc.GetValue();
		}
		
		return total;
	}

}
