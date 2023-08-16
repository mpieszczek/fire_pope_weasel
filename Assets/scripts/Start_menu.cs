using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Start_menu : MonoBehaviour {
	public GameObject[] corrners;
	public GameObject[] pawns_blueprints;
	GameObject gInfo;
	public int amount;
	GameObject[] buttons;
	GameObject[] pawns;
	// Use this for initialization
	void Start () {
		gInfo = GameObject.Find("Canvas").transform.Find("general_info").gameObject;
		gInfo.GetComponent<Text> ().text = "How many players?";
	}
	public void NewGamePreper(){
		GameObject canv = GameObject.Find ("Canvas");
		print(canv.transform.childCount);
		for (int i = 0; i < canv.transform.childCount; i++) {
			canv.transform.GetChild (i).gameObject.SetActive (true);
		}
		pawns = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject pawn in pawns) {
			Destroy (pawn);
		}
	}
	void Update(){
		gInfo = GameObject.Find("Canvas").transform.Find("general_info").gameObject;
		gInfo.GetComponent<Text> ().text = "How many players?";
	}
	
	// Update is called once per frame
	public void When_clicked (int which_button) {
		if (which_button == 2) {
			Instantiate (pawns_blueprints[0],corrners[0].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[1],corrners[3].transform.position,new Quaternion(0,0,0,0));
			this.GetComponent<Picking_objects> ().enabled = true;
			this.GetComponent<Picking_objects> ().SetStage ();
			amount = 2;
		}
		if (which_button == 3) {
			Instantiate (pawns_blueprints[0],corrners[0].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[1],corrners[2].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[2],corrners[4].transform.position,new Quaternion(0,0,0,0));
			this.GetComponent<Picking_objects> ().enabled = true;
			this.GetComponent<Picking_objects> ().SetStage ();
			amount = 3;
		}
		if (which_button == 4) {
			Instantiate (pawns_blueprints[0],corrners[0].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[1],corrners[1].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[2],corrners[3].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[3],corrners[4].transform.position,new Quaternion(0,0,0,0));
			this.GetComponent<Picking_objects> ().enabled = true;
			this.GetComponent<Picking_objects> ().SetStage ();
			amount = 4;
		}
		if (which_button == 6) {
			Instantiate (pawns_blueprints[0],corrners[0].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[1],corrners[1].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[2],corrners[2].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[3],corrners[3].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[4],corrners[4].transform.position,new Quaternion(0,0,0,0));
			Instantiate (pawns_blueprints[5],corrners[5].transform.position,new Quaternion(0,0,0,0));
			this.GetComponent<Picking_objects> ().enabled = true;
			this.GetComponent<Picking_objects> ().SetStage ();
			amount = 6;
		}
	}
}
