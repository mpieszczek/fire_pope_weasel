using UnityEngine;
using System.Collections;

public class keep_light : MonoBehaviour {
	//public bool sm_above;
	public bool occupied;
	public bool in_range;
	Ray ray;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		//sm_above = false;
		occupied = false;
		in_range = false;
	}
	
	// Update is called once per frame
	void Update () {
	//	if (sm_above == true) {
		if(1==1){
			this.GetComponent<Light> ().color = Color.red;
			ray = new Ray (transform.position, Vector3.up);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.rigidbody.gameObject != GameObject.Find("Main Camera").GetComponent<Picking_objects>().lifted) {   // Jeśli pionek jest nad kalelkiem to kafelek się świeci na czerwono,
					//sm_above = false;																					 // a następnie sprawdza czy pionek dalej tam jest, po czym odpowiednio ustawia warość zmiennej sm_above
					this.GetComponent<Light> ().color = Color.yellow;
					occupied = true;
				}
			} 
			else {										// Jeśli nic nie wisi ani leży na/nad hexem
				//sm_above = false;
				this.GetComponent<Light> ().color = Color.green;
				occupied = false;
			}
		}

	}
}
	