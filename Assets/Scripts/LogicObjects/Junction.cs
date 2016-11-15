using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Junction {

    protected HashSet<LogicObject> attached = new HashSet<LogicObject>();

    public void attachLogicObject(LogicObject objectToAttach) {
        attached.Add(objectToAttach);
    }



}
