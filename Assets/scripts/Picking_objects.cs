using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Picking_objects : MonoBehaviour {
	Ray ray;
   	RaycastHit hit;
	bool turned_light;
	public GameObject lifted;  // aktualnie podniesionu pionek
	public int turn;
	public int move;
	public int teams_amount;
	public int[] max_moves;
	public Material[] materials;
	public GameObject gInfo;
	public int[] dead_teams;
	int teams_left;
	public string[] teams_names;

	// Use this for initialization
	bool Contains(int[] list, int element){
		foreach (int x in list) {
			if (x == element)
				return true;
		}
		return false;
	}
	public void IsAnybodyDead(){
		GameObject[] pawns = GameObject.FindGameObjectsWithTag("Player");
		bool alive;
		for(int i = 0; i<teams_amount; i++){
			alive = false;
			foreach (GameObject pawn in pawns) {
				if (pawn.GetComponent<Pawn_properties> ().team == i)
					alive = true;
			}
			if (alive == false && !Contains(dead_teams,i)){
				dead_teams [i] = i;
				teams_left--;
				if (teams_left <= 1) {
					print ("Wygrano");
					this.GetComponent<Start_menu> ().enabled = true;
					this.GetComponent<Start_menu> ().NewGamePreper ();
					this.enabled = false;
				}
			}
		}
	}
	void Start () {
		teams_amount = this.GetComponent<Start_menu> ().amount;
		this.GetComponent<Start_menu> ().enabled = false;
		print (dead_teams.Length);
		turn = 0;
		move = 0;
		max_moves =  new int[teams_amount];
		print (teams_amount);
		for (int i = 0; i < teams_amount; i++) {
			max_moves[i] = 3;
		}
		dead_teams = new int[teams_amount];
		teams_left = teams_amount;
		gInfo = GameObject.Find("Canvas").transform.Find("general_info").gameObject;
	}
	public void SetStage(){
		teams_amount = this.GetComponent<Start_menu> ().amount;
		this.GetComponent<Start_menu> ().enabled = false;
		print (dead_teams.Length);
		turn = 0;
		move = 0;
		max_moves =  new int[teams_amount];
		print (teams_amount);
		for (int i = 0; i < teams_amount; i++) {
			max_moves[i] = 3;
		}
		dead_teams = new int[teams_amount];
		teams_left = teams_amount;
		gInfo = GameObject.Find("Canvas").transform.Find("general_info").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (move >= max_moves [turn]) {
			do{
			turn = turn + 1;
			}while (Contains(dead_teams,turn) && turn < teams_amount);
			move = 0;								// Zmiana tury i kontrola ilości ruchów
		}
		if (turn >= teams_amount) {
			turn = 0;
		}
		gInfo.GetComponent<Text> ().text = "Turn of team: " + (teams_names[turn]) + " Moves left: " + (max_moves[turn]-move);




		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 		if(Physics.Raycast(ray, out hit))	{
			if(hit.transform.gameObject.tag == "Player"){
				if(hit.transform.gameObject.GetComponent<Pawn_properties>().team == turn){
					if (Input.GetMouseButton (0)) {	
						hit.transform.gameObject.GetComponent<following_mouse> ().follow = true;   // Jeśli wciskamy PPM to zmienna falow = true
						lifted = hit.transform.gameObject;
						if (turned_light == false) {
							foreach (Collider objekt in Physics.OverlapSphere(hit.transform.gameObject.GetComponent<following_mouse>().pick_position, hit.transform.gameObject.GetComponent<Pawn_properties>().range)) {
								if (objekt.gameObject.tag == "Hex") {
										objekt.gameObject.GetComponent<Light> ().enabled = true;					//Podświetlanie zasięgu
										objekt.gameObject.GetComponent<keep_light> ().in_range = true;
										turned_light = true;
								}
							}
						}


					} else {
				//	}else if(Input.GetMouseButtonUp (0)){
						hit.transform.gameObject.GetComponent<following_mouse> ().follow = false;
						hit.transform.gameObject.GetComponent<place_on_hex> ().DroppedPawn ();     //uruchomienie upuszczania na środek hexa poniżej

						if (turned_light == true) {
							foreach (Collider objekt in Physics.OverlapSphere(hit.transform.gameObject.GetComponent<following_mouse>().pick_position, hit.transform.gameObject.GetComponent<Pawn_properties>().range)) {
								if (objekt.gameObject.tag == "Hex") {
									objekt.gameObject.GetComponent<Light> ().enabled = false;
									objekt.gameObject.GetComponent<keep_light> ().in_range = false;					//wyłączenie podświetlenia
									turned_light = false;
								}
							}
						}
					}
				}
			}
   		 }
	}
}

