using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class quiting : MonoBehaviour {
	public Button but;
	void Start(){
		but.onClick.AddListener (() => QuitButt ());
	}
	void Update () {
	
	}
	void QuitButt(){
		Application.Quit();
	}
}
