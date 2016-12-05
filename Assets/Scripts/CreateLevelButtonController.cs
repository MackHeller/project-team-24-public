using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CreateLevelButtonController : MonoBehaviour {

    public void OnClick() {
        SceneManager.LoadScene("LevelCreator");
    }
}
