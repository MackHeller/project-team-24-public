using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

	// Use this for initialization
	public GameObject button;
	void Start () {
		string[] levels = LevelReader.getAllLevelNames ();
		Vector3 pos = this.transform.position;
		foreach (string s in levels) {
			pos.y = pos.y - 40;
			GameObject pref = (GameObject) Instantiate (button, pos ,this.transform.rotation, this.transform);
			pref.GetComponentInChildren<Text>().text = s;
			Button b = pref.GetComponent<Button> ();

		}
	}

}