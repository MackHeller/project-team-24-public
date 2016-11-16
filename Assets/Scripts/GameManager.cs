using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private static bool _isCreatingWire = false;

    public static bool isCreatingWire() {
        return _isCreatingWire;
    }

    public static void setCreatingWire(bool isCreatingWire) {
        _isCreatingWire = isCreatingWire;
    }

}
