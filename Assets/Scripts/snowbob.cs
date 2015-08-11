using UnityEngine;
using System;
using System.Collections;
using System.IO.Ports;

public class snowbob : MonoBehaviour {

	//Initialization

	private float Z; //fremad eller tilbage i forhold til unitys z linie
	private float X; //position i forhold til unitys x linie

	private float NiceToHaveCounter = 0; // counts the array to max and min in position
		
	SerialPort stream = new SerialPort ("/dev/cu.usbmodem1421", 9600); //streams the informations from usb with baud rate 9600
		
	public float speed = 0.0f;

	public static bool Rigth = false; 	//for camera position Right
	public static bool Left = false;	//for camera position Left

	public static bool GetRight(){		//getters to check if the position is held to the 'right' 
		return Rigth;
	}
	public static bool GetLeft(){		//getters to check if the position is held to the 'left' 
		return Left;
	}
	//----score count---------------------
	public static float score = 0f;
	public static void AddToScore(float x){
		score += x;
	}
	public static float GetFinalScore(){
		return score;
	}
	//------------------------------------
	//--Ending game stuff-----------------
	public static bool HasGameEnded = false;
	public static bool GetHasGameEnded(){
		return HasGameEnded;
	}
	//------------------------------------
	

	void Start() {

		stream.Open(); //opens the data information from Arduino
	}

		void Update () {

		string value = stream.ReadLine(); 		//Read the information
		string[] vec3 = value.Split('\t');		//Returns a 4 part value of a string into an array x,y,z,M

		Z = float.Parse(vec3[0]); 				//Arduino accelerometer X
		X = float.Parse(vec3[1]); 				//Arduino accelerometer Y

		//---------Forward function--------------------------------------------------------------
		if (Z > 0.0f){
			speed += 0.1f+Z; //arduino værdi Z is put with speed to go faster
			transform.position = transform.position + transform.forward * speed * Time.deltaTime;
			if (speed >= 10.0f){
				speed = 10.0f;
			}
		}
		if (Z < 0f){
			speed -= 0.1f+(Z*-1); //arduino værdi Z is put with speed to go slower
			transform.position = transform.position + transform.forward * speed * Time.deltaTime;
			if (speed <= 0.0f){
				speed = 0.0f;
			}
		}
		//---------------------------------------------------------------------------------------
		//------Left-----------------------------------------------------------------------------
		if (X > 0.05f){												//arduino værdi X is put with the counter to go left in a dynamic movement
			NiceToHaveCounter -= X*0.5f;
			transform.Rotate(new Vector3(0,NiceToHaveCounter,0));
			if (NiceToHaveCounter <= -0.3f){
				NiceToHaveCounter = -0.3f;
			}
			Left = true;
			Rigth = false;
		}
		//---------------------------------------------------------------------------------------
		//------Right----------------------------------------------------------------------------
		if (X < -0.05f){		//arduino værdi X is put with the counter to go right in a dynamic movement
			NiceToHaveCounter += (X*-1.0f)*0.5f; //since the axis is in minus, we ned to multiply with -1 to get positive values
			transform.Rotate(new Vector3(0,NiceToHaveCounter,0));
			if (NiceToHaveCounter >= 0.3f){
				NiceToHaveCounter = 0.3f;
			}
			Rigth = true;
			Left = false;
		}
		if (X > -0.051f && X < 0.051f){
			Rigth = false;
			Left = false;
		}
		//---------------------------------------------------------------------------------------
	
	}

		//--------GUI----------------------------------------------------------------------------
		void OnGUI()
		{
			string newString = "Connected: " + transform.rotation.x +
			", " + transform.rotation.y + ", " + transform.rotation.z;
			GUI.Label(new Rect(10,10,300,100), newString); 										//Display new values
																					// Though, it seems that it outputs the value in percentage O-o I don't know why.
																					// Creates one with game over and the player's score:
			if (HasGameEnded == false){
				GUI.Box(new Rect(100,50,100,50), "\n" + "Score:" + score);
			}
		}
		//---------------------------------------------------------------------------------------

		//-----Trigger function for end game-----------------------------------------------------
	void OnTriggerEnter(Collider Finish) {//this function runs when the an object named ThePlayer collides with the object which this script is palced upon.
		HasGameEnded = true;
		Application.LoadLevel("endscene");
	}
	//---------------------------------------------------------------------------------------
	

}
		