using UnityEngine;
using System.Collections.Generic;
using System;

public class LogicUtil {
	/*
	 * Class containing utility function for LogicObjects.
	 */

	public static IList<bool> oneBoolList(bool boolean) {
		IList<bool> ls = new List<bool> ();
		ls.Add (boolean);
		return ls;
	}
}