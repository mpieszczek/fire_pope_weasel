using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Pawn_properties : MonoBehaviour {
	public int team;
	public string type;
	public float range;
	public int stack;
	//public Mesh pope_bluprint;
	//public Mesh weasel_bluprint;
	public Material pope_material;
	public Material weasel_material;
	// Use this for initialization
	void Start () {
		stack = 1;
		type = "fire";
	}
	// Update is called once per frame
	void Update () {
		if (stack >= 3 && stack < 9 && type == "fire") {
			type = "wesel";
			//this.transform.Find ("statue").gameObject.GetComponent<MeshFilter> ().mesh = weasel_bluprint;
			this.transform.Find ("statue").gameObject.GetComponent<Renderer>().material = weasel_material;
		}
		if (stack >= 9 && type == "wesel") {
			type = "pope";
			//this.transform.Find ("statue").gameObject.GetComponent<MeshFilter> ().mesh = pope_bluprint;
			this.transform.Find ("statue").gameObject.GetComponent<Renderer>().material = pope_material;
		}
		this.transform.Find ("Text").gameObject.GetComponent<TextMesh> ().text = stack.ToString();
	}
}
