namespace Calculator.View.WinForm.ViewModel.State;

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
            ViewModel.Stack = ViewModel.Stack[..^1];

        if (string.IsNullOrEmpty(ViewModel.Stack))
            ViewModel.Stack = CalculatorViewModel.InitText;

        ViewModel.MainDisplayText = ViewModel.Stack;
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
            // スタック値を左辺に代入
            ViewModel.LeftNum = decimal.Parse(ViewModel.Stack);

            // 計算実行
            var res = ViewModel.Calculate();

            // 計算結果をスタックに代入
            ViewModel.Stack = res.Result.HasValue ? res.Result.Value.ToString("0.#####") : CalculatorViewModel.InitText;
        }
        else
        {
            // スタック値を右辺に代入
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
            // スタック値を左辺に代入
            ViewModel.LeftNum = decimal.Parse(ViewModel.Stack);

            // 計算実行
            ViewModel.Calculate();
        }
        else
        {
            // スタック値を右辺に代入
            ViewModel.RightNum = decimal.Parse(ViewModel.Stack);

            // スタック値をクリア
            ViewModel.Stack = CalculatorViewModel.InitText;

            // 計算実行
            var res = ViewModel.Calculate();

            // 左辺に計算結果を代入
            ViewModel.LeftNum = res.Result;
        }
    }
}
