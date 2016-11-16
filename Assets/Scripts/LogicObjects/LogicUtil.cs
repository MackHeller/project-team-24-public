using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Class containing utility function for LogicObjects.
/// </summary>
public class LogicUtil {

    public static void initializeNullList(IList<bool?> ls, int size) {
        for (int i = 0; i < size; i++) {
            bool? item = null;
            ls.Add(item);
        }
    }

    public static void initializeNullWireList(IList<Wire> ls, int size) {
        for (int i = 0; i < size; i++) {
            Wire item = null;
            ls.Add(item);
        }
    }

    public static void initializeWireList(IList<Wire> ls, int size) {
        for (int i = 0; i < size; i++) {
            Wire item = new Wire();
            ls.Add(item);
        }
    }

    public static IList<bool?> oneBoolList(bool? boolean) {
        IList<bool?> ls = new List<bool?>();
        ls.Add(boolean);
        return ls;
    }
}