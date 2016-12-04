using UnityEngine;
using System.Collections;

public class SubmitPanelButton : MonoBehaviour {

	public void openPanel (GameObject panel){
		//TODO: check to see if level is completed
		panel.SetActive (!panel.activeSelf);
	}
}
