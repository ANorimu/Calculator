namespace Calculator.View.WinForm.ViewModel.State;

internal class StatePlusMinus(CalculatorViewModel viewModel) : StateInput(viewModel)
{
    public override void OnBackSpace()
    {
        base.OnBackSpace();

        var isMinus = !string.IsNullOrEmpty(ViewModel.Stack) && ViewModel.Stack[0] == '-';
        var absoluteValue = isMinus ? ViewModel.Stack[1..] : ViewModel.Stack;

        if (0 < absoluteValue.Length)
            ViewModel.Stack = isMinus ? "-" : "" + absoluteValue[..^1];

        if (string.IsNullOrEmpty(ViewModel.Stack))
            ViewModel.Stack = CalculatorViewModel.InitText;

        ViewModel.MainDisplayText = ViewModel.Stack;
    }
    public override void OnInput(string input)
    {
        ViewModel.ChangeState(new StateInput(ViewModel));

        if (ViewModel.Stack == CalculatorViewModel.InitText &&
            input != CalculatorViewModel.Period)
            ViewModel.Stack = string.Empty;
        ViewModel.Stack += input;

        ViewModel.MainDisplayText = ViewModel.Stack;
    }
}
