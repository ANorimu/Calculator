namespace Calculator.View.WinForm.ViewModel.State.State;

/// <summary>
/// 値入力後の状態
/// <para>C,CE,DEL押下後もこの状態</para>
/// </summary>
/// <param name="viewModel"></param>
internal class StateInput(CalculatorViewModel viewModel) : StateBase(viewModel)
{
    public override void OnBackSpace()
    {
        base.OnBackSpace();

        if (0 < ViewModel.Stack.Length)
            ViewModel.Stack = ViewModel.Stack.Remove(ViewModel.Stack.Length - 1, 1);

        if (string.IsNullOrEmpty(ViewModel.Stack))
            ViewModel.Stack = "0";
    }
    public override void OnInput(string input)
    {
        base.OnInput(input);

        // メインディスプレイにスタック文字列を表示
        ViewModel.MainDisplayText = ViewModel.Stack;
    }
    public override void OnSign(string sign)
    {
        base.OnSign(sign);

        ViewModel.ChangeState(new StateSign(ViewModel));

        if (!ViewModel.LeftNum.HasValue)
        {
            // 左辺にスタック文字列を数値化して代入
            ViewModel.LeftNum = decimal.Parse(ViewModel.Stack);

            // 計算実行
            var res = ViewModel.Calculate();

            // 式をサブディスプレイに表示
            ViewModel.SubDisplayText = res.Formula;
        }
        else
        {
            // スタック文字列を数値化して右辺に代入
            ViewModel.RightNum = decimal.Parse(ViewModel.Stack);

            // 計算実行
            var res = ViewModel.Calculate();

            // 左辺に計算結果を代入
            ViewModel.LeftNum = res.Result;
        }
    }
    public override void OnEqual()
    {
        ViewModel.ChangeState(new StateEqual(ViewModel));

        if (!ViewModel.LeftNum.HasValue)
        {
            // 左辺にスタック文字列を数値化して代入
            ViewModel.LeftNum = decimal.Parse(ViewModel.Stack);

            // 計算実行
            ViewModel.Calculate();
        }
        else
        {
            // 右辺にスタック文字列を数値化して代入
            ViewModel.RightNum = decimal.Parse(ViewModel.Stack);

            // 計算実行
            var res = ViewModel.Calculate();

            // 左辺に計算結果を代入
            ViewModel.LeftNum = res.Result;
        }
    }
}
