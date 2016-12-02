using System;
using System.Collections.Generic;

public class TerminalInput : LogicModule {

    private bool? value;

    public TerminalInput() : base(0, 1) {

    }

    public void setValue(bool? value) {
        this.value = value;
        notifyOutputs();
    }

    protected override IList<bool?> applyLogic(IList<bool?> inputs) {
        return new List<bool?>(1) { value };
    }

    public bool? getOutput() {
        return value;
    }

    public Junction getOutputJunction() {
        return getOutputJunction(0);
    }

    public void setOutputJunction(Junction outputJunction) {
        setOutputJunction(0, outputJunction);
    }

    public override string getName()
    {
        return "Input";
    }
}
