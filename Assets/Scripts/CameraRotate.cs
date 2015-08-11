using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {

	//Initialization
	private float NiceToHaveCounter = 0f;
	private float HowFastMayNTHCgrow = 0.1f;
	private float SpeedToTurnTheCamera = 0.5f;
	
	private bool IsHeadUpRight = true; //within the parametres of going forward (-0.05 & 0.05)

	private bool IamTURININGleft = false;
	private bool IamTURNINGright = false;

	private bool StopTurningLeft = false;
	private bool StopTurningRight = false;

	private bool MaxLeftValueReached = false;
	private bool MaxRightValueReached = false;
	//void Start () {}
	

	void Update () {

	//-------- turning camera view left, when position is left
	/*	if (snowbob.GetLeft() == true && MaxLeftValueReached == false){

			NiceToHaveCounter += HowFastMayNTHCgrow;
			transform.Rotate(new Vector3(0,0, SpeedToTurnTheCamera));
			IamTURININGleft = true;
			MaxRightValueReached = false;

			IsHeadUpRight = false;

			if (NiceToHaveCounter >= 5){
				MaxLeftValueReached = true;
			}

		}
	//-------- turning camera view right, when position is right
		if (snowbob.GetRight() == true && MaxRightValueReached == false){

			NiceToHaveCounter += HowFastMayNTHCgrow;
			transform.Rotate(new Vector3(0,0, -1 * SpeedToTurnTheCamera));
			IamTURNINGright = true;
			MaxLeftValueReached = false;

			IsHeadUpRight = false;


			if (NiceToHaveCounter >= 5){
				MaxRightValueReached = true;
			}

		}
*/
		//----fixing the camera to rotate back to start position-------------

		if (snowbob.GetLeft() == false && snowbob.GetRight() == false){
			if (IamTURININGleft == true ){
				transform.localEulerAngles = new Vector3 (0,0,0);
				IamTURININGleft = false;
				NiceToHaveCounter = 0;
			}
			if (IamTURNINGright == true){
				IamTURNINGright = false;
				transform.localEulerAngles = new Vector3 (0,0,0);
				NiceToHaveCounter = 0;
			}
		}
		//------------------------------------------------------------------
	
	}
}
