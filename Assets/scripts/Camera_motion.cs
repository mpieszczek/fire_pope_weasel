using UnityEngine;
using System.Collections;

public class Camera_motion : MonoBehaviour {
	public GameObject centrum;
	public float rotate_speed;
	public float zoom_speed;

	void Update () {
		this.transform.LookAt (centrum.transform);
		if (Input.GetMouseButton (1)) {
			float xr = Input.GetAxis ("Mouse X");
			float yr = Input.GetAxis ("Mouse Y");
			this.transform.RotateAround (centrum.transform.position, Vector3.up, xr * rotate_speed);    //X axis
			Vector3 xp  = this.transform.position;
			this.transform.Translate(Vector3.down * yr);  //Y axis
			this.transform.position = new Vector3(xp.x,this.transform.position.y,xp.z);
		}
		if (Input.GetAxis ("Mouse ScrollWheel") != 0) {
			
			transform.position = Vector3.MoveTowards(this.transform.position, centrum.transform.position, zoom_speed * Input.GetAxis ("Mouse ScrollWheel"));
		}
	}
}
