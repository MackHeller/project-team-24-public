using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	public void LoadScene(int level){
		Application.LoadLevel (level);

	}
}
