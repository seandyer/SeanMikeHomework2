using UnityEngine;
using System.Collections;

// Notes:
// Attach to any GameObject

public class GazeSteering : MonoBehaviour {

	public int travelButton = 0;
	public int moveButton = 1;

	public float baseTravelSpeed = 1.0f;
	public int maxMagnitude = 1;

	public int aggregateMagnitude = 0;

	public Vector3 directionVector = Vector3.zero;
	public bool moving = false;

	// Update is called once per frame
	void Update () {
	
		// Get the current gaze direction from the Main Camera 
		//Quaternion gazeDirection = GameObject.Find("Main Camera").transform.localRotation;
		
		// If the travel button is pressed
		if (Input.GetMouseButton (travelButton)) {
			aggregateMagnitude = 0;
			//directionVector = Vector3.zero;

//			// Determine the travel vector based on the gaze direction and provided speed
//			Vector3 travelVector = gazeDirection * Vector3.forward * travelSpeed;
//			
//			// Move the Navigation GameObject based on the travel vector
//			GameObject.Find("Navigation").transform.Translate(travelVector)
		
		

			//if (moving) {
			directionVector = Vector3.zero;
			//Get the current acceleration
			Vector3 accelerationVector = Input.acceleration;
			//Flip the z-axis
			accelerationVector.z = -accelerationVector.z;
			accelerationVector.y = 0;
			//Use the time since the last frame to determine the distance traveled. Instead of
			//an acceleration vector, this is now a distance vector.
			accelerationVector *= Time.deltaTime;
			//We use just magnitude because we want this to be negative if we're
			//moving back towards the origin.
			//aggregateMagnitude += accelerationVector.magnitude; 
			
			if (directionVector.sqrMagnitude < 1) { //Here, we need the magnitude, regardless of positive or negative
				directionVector += accelerationVector;
//
//				int finalMagnitude = 0; 
//				if (aggregateMagnitude > 5) {
//					finalMagnitude = 5;
//				} else {
//					finalMagnitude = aggregateMagnitude;
//				}
//				if(offset != Vector3.zero)
//					offset = Vector3.zero;
				//offset += accelerationVector;
				//transform.Translate (offset * 1.0f);
				
			}
			GameObject.Find ("Navigation").transform.Translate (directionVector.normalized * baseTravelSpeed /* finalMagnitude*/);
			//}
		}
	}
}
