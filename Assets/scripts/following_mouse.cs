using UnityEngine;
using System.Collections;

public class following_mouse : MonoBehaviour {
	public bool follow;
	public Vector3 pick_position;
	// Use this for initialization
	void Start () {
	follow = false;
	pick_position = this.transform.position;
	this.GetComponent<place_on_hex> ().DroppedPawn ();
	}
	
	// Update is called once per frame
	void Update () {
		if (follow == true) {
			Vector3 temp = Input.mousePosition;
			temp.z = 4f; 									// Set this to be the distance you want the object to be placed in front of the camera.
			this.transform.position = Camera.main.ScreenToWorldPoint (temp);
		} else {
			pick_position = this.transform.position;     // ustawiamy pozycje z której pionek został zabrany jakby źle został upuszczony
		}
	}
}
