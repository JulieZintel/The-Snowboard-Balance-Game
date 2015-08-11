using UnityEngine;
using System.Collections;

public class pole : MonoBehaviour {
	private AudioSource flagpole;
	public AudioClip pling;
	//public Transform exp;

	// Use this for initialization
	void Start () {

		flagpole =(AudioSource)gameObject.AddComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other){
		if(other.gameObject.name == "snowbob")
		{
			Destroy(gameObject);
			flagpole.Play ();
			snowbob.AddToScore(10);
		}
	}
}


//Instantiate (exp, transform.position, Quaternion.identity);

// A funtion which makes the flagpole dissapear when it hits, while it also adds one point to the final score. 