using UnityEngine;
using System.Collections;

public class place_on_hex : MonoBehaviour {
	Ray ray;
	RaycastHit hit;
	GameObject main_camera;
	public GameObject blueprint;
	// Use this for initialization
	void Start () {
		main_camera = GameObject.Find ("Main Camera");
	}
	// upuszczanie na środek dostępnego hex ponizej upadającego pionka bądź przywrócenie go do pozycji wejściowej
	public void DroppedPawn(){
		ray = new Ray (transform.position, Vector3.down);
		//ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.tag == "Hex") {
				if (hit.transform.gameObject.GetComponent<keep_light> ().in_range == true) {                   /// << DO POPRAWY( DO 1 IFa) lub nie :)
					if(hit.transform.gameObject.GetComponent<keep_light> ().occupied == false && !(hit.transform.position.x == this.GetComponent<following_mouse> ().pick_position.x && hit.transform.position.z == this.GetComponent<following_mouse> ().pick_position.z)){
						if(this.GetComponent<Pawn_properties>().stack < 3) {
							Instantiate(blueprint, this.GetComponent<following_mouse> ().pick_position, Quaternion.identity);
						}
						this.transform.position = hit.transform.position;    											 //Jeśli HEX JEST POD TRZYMANYM PIONKIEM i jeśli HEX NIE JEST OKUPOWANY to zmienia pozycje pionka na pozycje hexa po upuszczeniu
						hit.transform.gameObject.GetComponent<keep_light> ().occupied = true;
						main_camera.GetComponent<Picking_objects> ().move ++;
						main_camera.GetComponent<Picking_objects> ().IsAnybodyDead ();
					} else {
						this.transform.position = this.GetComponent<following_mouse> ().pick_position;
					}
				} else {
					this.transform.position = this.GetComponent<following_mouse> ().pick_position;
					//print ("Poza Zasięgiem");
				}
			}
			else if(hit.transform.gameObject.tag == "Player") {
				//print ("Inny pionek");
				if (hit.transform.gameObject.GetComponent<Pawn_properties> ().team != this.GetComponent<Pawn_properties> ().team) {
					if((this.GetComponent<Pawn_properties> ().type == "fire"&& hit.transform.gameObject.GetComponent<Pawn_properties> ().type == "pope") || (this.GetComponent<Pawn_properties> ().type == "wesel" && hit.transform.gameObject.GetComponent<Pawn_properties> ().type == "fire") || (this.GetComponent<Pawn_properties> ().type == "pope" && hit.transform.gameObject.GetComponent<Pawn_properties> ().type == "wesel")){
						if(this.GetComponent<Pawn_properties>().stack >= 9){
							this.transform.position = this.GetComponent<following_mouse> ().pick_position;
							hit.transform.gameObject.GetComponent<Pawn_properties> ().team = this.GetComponent<Pawn_properties> ().team;	//nawracanie
							hit.transform.Find ("podium").gameObject.GetComponent<Renderer> ().material = main_camera.GetComponent<Picking_objects>().materials[main_camera.GetComponent<Picking_objects>().turn];
							main_camera.GetComponent<Picking_objects> ().move ++;
							main_camera.GetComponent<Picking_objects> ().IsAnybodyDead ();
						}else{
							if(this.GetComponent<Pawn_properties>().stack < 3) {
								int t = hit.transform.gameObject.GetComponent<Pawn_properties> ().team;
								main_camera.GetComponent<Picking_objects> ().max_moves [t] --;			//zbijanie papieża
								Instantiate(blueprint, this.GetComponent<following_mouse> ().pick_position, Quaternion.identity);
							}
							Destroy (hit.transform.gameObject);
							this.transform.position = hit.transform.position;   //Zbijanie pionków innego gracza
							main_camera.GetComponent<Picking_objects> ().move ++;
							main_camera.GetComponent<Picking_objects> ().IsAnybodyDead ();
						}
					}else{
						this.transform.position = this.GetComponent<following_mouse> ().pick_position;
					}
				} else if (hit.transform.gameObject.GetComponent<Pawn_properties> ().team == this.GetComponent<Pawn_properties> ().team && hit.transform.gameObject.GetComponent<Pawn_properties> ().type == this.GetComponent<Pawn_properties> ().type && hit.transform.gameObject.GetComponent<Pawn_properties> ().type != "pope" && this.GetComponent<Pawn_properties> ().type != "pope") {
					//print ("To twój pionszek");
					this.GetComponent<Pawn_properties> ().stack = this.GetComponent<Pawn_properties> ().stack + hit.transform.gameObject.GetComponent<Pawn_properties> ().stack;
					if (this.GetComponent<Pawn_properties> ().stack >= 9) {
						int t = this.GetComponent<Pawn_properties> ().team;
						main_camera.GetComponent<Picking_objects> ().max_moves [t] ++;
					}
					Destroy (hit.transform.gameObject);
					this.transform.position = hit.transform.position;
					main_camera.GetComponent<Picking_objects> ().move ++;
					main_camera.GetComponent<Picking_objects> ().IsAnybodyDead ();

				} else {
					this.transform.position = this.GetComponent<following_mouse> ().pick_position;
				}
			}
			else {
				this.transform.position = this.GetComponent<following_mouse> ().pick_position;
			}
		}
	}
}
