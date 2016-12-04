using UnityEngine;
using System.Collections;

public class SubmitPanel : MonoBehaviour {

	void OnEnable(){
		GameManager gm = GameManager.getInstance ();
		Level lvl = gm.getLevel ();
		string lvlname = lvl.getLevelName ();
		string lvlcreator = lvl.getCreator ();
		gm.setName (lvlname);
		gm.setCreator (lvlcreator);
		//TODO:get score for completed level and
		//get stars for completed level
		gm.setScore (0); //to be changed
		gm.setStars (0); //to be changed
	}
}
