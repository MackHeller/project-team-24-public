using UnityEngine;
using System;
using System.Collections.Generic;

public class LogicObject {
	/*
	 * A logicObject is a wire or a module.
	 * 
	 * Each logicObject has an ID.
	 */

	int id;

	public int getId () {
		return id;
	}

	public void setId(int objectId) {
		id = objectId;
	}
}
