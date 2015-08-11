using UnityEngine;
using System.Collections;

public class audi2 : MonoBehaviour {

	private AudioSource soundsource; //makes the object an audio source emitting sound
	public AudioClip slidin; //the clip, which can be applied inside the inspector
	public AudioClip Finish;

	// Use this for initialization
	void Start () {

		soundsource = (AudioSource)gameObject.AddComponent<AudioSource>();
		soundsource.loop = true;
		soundsource.clip = slidin;
		soundsource.Play();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (snowbob.GetHasGameEnded() == true){
			soundsource.clip = Finish;
			soundsource.loop = false;
		}
	
	}


}
