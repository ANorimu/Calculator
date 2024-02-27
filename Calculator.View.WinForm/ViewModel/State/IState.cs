namespace Calculator.View.WinForm.ViewModel.State;

/// <summary>
/// ViewModelの状態
/// </summary>
internal interface IState
{
    /// <summary>
    /// C押下時の処理
    /// </summary>
    public void OnClear() { }

    /// <summary>
    /// CE押下時の処理
    /// </summary>
    public void OnClearEntry() { }

    /// <summary>
    /// DEL押下時の処理
    /// </summary>
    public void OnBackSpace() { }

    /// <summary>
    /// +/-押下時の処理
    /// </summary>
    public void OnPlusMinus() { }

    /// <summary>
    /// 計算値入力時の処理
    /// </summary>
    /// <param name="input"></param>
    public void OnInput(string input) { }

    /// <summary>
    /// 演算子入力時の処理
    /// </summary>
    /// <param name="sign"></param>
    public void OnSign(string sign) {}

    /// <summary>
    /// =入力時の処理
    /// </summary>
    public void OnEqual() { }
}
