using UnityEngine;
using System.Collections.Generic;
using System;

public class LogicUtil : LogicObject {
	/*
	 * Class containing utility function for LogicObjects.
	 */

	public static IList<bool> oneBoolList(bool boolean) {
		return new IList<bool> (boolean);
	}
}