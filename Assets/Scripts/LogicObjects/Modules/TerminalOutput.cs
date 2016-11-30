using System.Collections.Generic;

class TerminalOutput : LogicModule {

    public TerminalOutput() : base(1, 0) {

    }

    public bool? getValue() {
        return inputValues[0];
    }

    protected override IList<bool?> applyLogic(IList<bool?> inputs) {
        return new List<bool?>(0);
    }

    public void setInput(bool? value) {
        setInputAt(0, value);
    }

    public Junction getInputJunction() {
        return getInputJunction(0);
    }

    public void setInputJunction(Junction inputJunction) {
        setInputJunction(0, inputJunction);
    }
    public override string getName()
    {
        return "Output";
    }
}
