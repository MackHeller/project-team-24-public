using UnityEngine;
using System;
using System.Collections.Generic;

/// <summary>
/// A LogicObject is a wire or a module, and every LogicObject has an ID.
/// </summary>
public class LogicObject {

    int id;

    public int getId() {
        return id;
    }

    public void setId(int objectId) {
        id = objectId;
    }
}
