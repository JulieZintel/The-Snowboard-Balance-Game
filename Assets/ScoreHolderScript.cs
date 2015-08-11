using UnityEngine;
using System.Collections;

public class ScoreHolderScript : MonoBehaviour {

	private float score =0;
	private int fontSize = 30;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad (transform.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {

		score = snowbob.GetFinalScore();
	
	}
	void OnGUI()
	{
		GUIStyle myButtonStyle = new GUIStyle(GUI.skin.box);
		myButtonStyle.fontSize = 100;


		if (snowbob.GetHasGameEnded() == true){
			GUI.Box(new Rect(Screen.width/2, Screen.height/1.5f,200,150), "" + score, myButtonStyle); //(x,y widen, højden)
		}
	}

}
