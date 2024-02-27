namespace Calculator.View.WinForm.ViewModel.State.State;

internal abstract class StateBase(CalculatorViewModel viewModel) : IState
{
    protected readonly CalculatorViewModel ViewModel = viewModel;
    public void OnClear()
    {
        ViewModel.Stack = CalculatorViewModel.InitText;
        ViewModel.LeftNum = null;
        ViewModel.RightNum = null;
        ViewModel.MainDisplayText = ViewModel.Stack;
        ViewModel.SubDisplayText = string.Empty;
    }
    public void OnClearEntry()
    {
        ViewModel.Stack = CalculatorViewModel.InitText;
        ViewModel.RightNum = null;
        ViewModel.MainDisplayText = ViewModel.Stack;
    }
    public virtual void OnBackSpace() { }
    public void OnPlusMinus()
    {
        ViewModel.Stack = ViewModel.Stack[0] == CalculatorViewModel.Minus.ToCharArray()[0] ?
            ViewModel.Stack.Replace(CalculatorViewModel.Minus, string.Empty) :
            ViewModel.Stack.Insert(0, "-");
        ViewModel.MainDisplayText = ViewModel.Stack;
    }
    public virtual void OnInput(string input)
    {
        if (ViewModel.Stack == CalculatorViewModel.InitText) ViewModel.Stack = string.Empty;
        ViewModel.Stack += input;
    }
    public virtual void OnSign(string sign)
    {
        // 末尾の「.」除去
        if (0 < ViewModel.MainDisplayText.Length && ViewModel.MainDisplayText[^1] == CalculatorViewModel.Period.ToCharArray()[0])
            ViewModel.MainDisplayText = ViewModel.MainDisplayText.Replace(CalculatorViewModel.Period, string.Empty);

        ViewModel.Sign = sign;
    }
    public virtual void OnEqual() { }
}
