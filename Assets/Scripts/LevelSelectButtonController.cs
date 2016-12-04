using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelectButtonController : MonoBehaviour {

    public Text nameText;
    public Text creatorText;
    public Text scoreText;
    public StarsController starController;

    public void setName(string name) {
        nameText.text = name;
    }

    public void setCreator(string creator) {
        creatorText.text = creator;
    }

    public void setScore(int score) {
        scoreText.text = score.ToString();
    }

    public void setStars(int numStars) {
        starController.setStars(numStars);
    }
}
