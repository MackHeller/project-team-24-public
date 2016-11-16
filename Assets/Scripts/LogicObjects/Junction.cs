using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Junctions are used to provide a value to multiple observing LogicModules.
/// </summary>
public class Junction : LogicObject {

    private bool? value;
    private LogicModule inputModule;

    /// <summary>
    /// Dictionary of Module to module input index. Each of the observing modules
    /// have their inputs updated when the value of this junction changes.
    /// 
    /// Note: Using HashSet of KeyValuePair instead of Dictionary to allow for multiple
    /// inputs from the same module to observe.
    /// </summary>
    private ICollection<KeyValuePair<LogicModule, int>> observers = new HashSet<KeyValuePair<LogicModule, int>>();

    public void addObserver(LogicModule observingModule, int moduleInputIndex) {
        observers.Add(new KeyValuePair<LogicModule, int>(observingModule, moduleInputIndex));
    }

    public void removeObserver(LogicModule observingModule, int moduleInputIndex) {
        observers.Remove(new KeyValuePair<LogicModule, int>(observingModule, moduleInputIndex));
    }

    protected void notifyObservers() {
        foreach (KeyValuePair<LogicModule, int> observingModuleInputs in observers) {
            LogicModule module = observingModuleInputs.Key;
            int moduleInputIndex = observingModuleInputs.Value;
            module.setInputAt(moduleInputIndex, value);
        }
    }

    public void setValue(bool? newValue) {
        if (newValue != value) {
            value = newValue;
            notifyObservers();
        }
    }

    public bool? getValue() {
        return value;
    }

    public void setInputModule(LogicModule inputModule) {
        this.inputModule = inputModule;
    }

    /// <returns>true if this junction has a module providing the input value</returns>
    public bool hasInputModule() {
        return inputModule != null;
    }
}
