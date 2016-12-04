using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class StarsController : MonoBehaviour {

    public Color enabledColor;
    public Color disabledColor;

    public Image[] stars;

    public void setStars(int numStars) {
        if (numStars < 0 || numStars > stars.Length) {
            throw new ArgumentException("Invalid numStars: " + numStars);
        }
        for (int i = 0; i < numStars; i++) {
            stars[i].color = enabledColor;
        }
        for (int i = numStars; i < stars.Length; i++) {
            stars[i].color = disabledColor;
        }
    }
}
