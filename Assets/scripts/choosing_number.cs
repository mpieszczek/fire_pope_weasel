using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class choosing_number : MonoBehaviour {
	public Button butt;
	public int number;
	GameObject[] buttons;
	// Use this for initialization
	void Start () {
		butt.onClick.AddListener (() => Clicking ());
		buttons = GameObject.FindGameObjectsWithTag("Button");
	}
	public void Clicking(){
		Camera.main.GetComponent<Start_menu> ().When_clicked (number);
		foreach (GameObject button in buttons) {
			button.SetActive(false);
		}
	}
}
