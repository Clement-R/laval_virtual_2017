using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAnimRotation : MonoBehaviour {

	public bool firstCircle;
	public bool secondCircle;
	public bool thirdCircle;

	public bool ActivateFirstCircle;
	public bool ActivateSecondCircle;
	public bool ActivateThirdCircle;

	private Vector3 currentAngle;

	public float vitesseX = 0f;
	public float vitesseY = 15f;
	public float vitesseZ = 10;

	Vector3 rotate;

	void Start () {	
		//currentAngle = transform.eulerAngles;
		//rotate = new Vector3 (vitesseX, vitesseY, vitesseZ);
	}

	//public float minAngle = 0.0f;
	//public float maxAngle = vitesseX;


	// Update is called once per frame
	void Update () {
		if (firstCircle && ActivateFirstCircle) {

			/*float angle = Mathf.LerpAngle (minAngle, maxAngle, Time.time);
			transform.eulerAngles = new Vector3 (angle, angle, angle);

			//transform.Rotate (new Vector3(Mathf.LerpAngle(currentAngle.x, rotate.x, Time.deltaTime), Mathf.LerpAngle(currentAngle.y/360, rotate.y/360, Time.deltaTime), vitesseZ)*Time.deltaTime);
			//transform.eulerAngles = new Vector3(Mathf.LerpAngle(currentAngle.x, rotate.x, Time.deltaTime), Mathf.LerpAngle(currentAngle.y, rotate.y, Time.deltaTime), Time.deltaTime);

			Debug.Log (transform.localEulerAngles);
			/*currentAngle = new Vector3(
				Mathf.LerpAngle(currentAngle.x, rotate.x, Time.deltaTime),
				Mathf.LerpAngle(currentAngle.y, rotate.y, Time.deltaTime),
				Mathf.LerpAngle(currentAngle.z, rotate.z, Time.deltaTime));

			transform.eulerAngles = currentAngle;*/

			transform.Rotate (new Vector3(vitesseX, vitesseY, vitesseZ)*Time.deltaTime);	
		}

		if(secondCircle && ActivateSecondCircle)
			transform.Rotate (new Vector3(vitesseX, vitesseY, vitesseZ)*Time.deltaTime);	

		if(thirdCircle && ActivateThirdCircle)
			transform.Rotate (new Vector3(vitesseX, vitesseY, vitesseZ)*Time.deltaTime);	
	}
}
