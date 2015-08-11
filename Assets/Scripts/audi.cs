using UnityEngine;
using System.Collections;

public class audi : MonoBehaviour {

	private AudioSource soundsource; //makes the object an audio source emitting sound
	public AudioClip slidin; //the clip, which can be applied inside the inspector

	private float Xposition =0f;
	private float ChangeFactor = 0.25f;

	private float MaxLeftPosition = -24f;
	private float MinLeftPosition = -20f;

	private float MaxRigthPosition = -16f;
	private float MinRigthPosition = -12f;

	void Start () {
		
		soundsource = (AudioSource)gameObject.AddComponent<AudioSource>();
		soundsource.loop = true;
		soundsource.clip = slidin;
		soundsource.Play();
		
	}
	
	// Update is called once per frame
	void Update () {

		Xposition = transform.position.x;

		if (Xposition <= MinLeftPosition && Xposition >= MaxLeftPosition){
			soundsource.panStereo = -1 * (1- (((-1 * MaxLeftPosition) + Xposition) * ChangeFactor));
		}

		if (Xposition <= MinRigthPosition && Xposition >= MaxRigthPosition){
			soundsource.panStereo = (((-1 * MaxRigthPosition) + Xposition) * ChangeFactor);
		}


		if (Xposition < -16 && Xposition > -20){
			soundsource.panStereo = 0f;
		}

		if (snowbob.GetHasGameEnded() == true){
			soundsource.Stop();
		}
		
	}
}