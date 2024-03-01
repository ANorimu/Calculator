namespace Calculator.View.WinForm.ViewModel.State;

/// <summary>
/// 演算子入力後の状態
/// </summary>
/// <param name="viewModel"></param>
internal class StateSign(CalculatorViewModel viewModel) : StateBase(viewModel)
{
    public override void OnPlusMinus()
    {
        ViewModel.Stack = ViewModel.MainDisplayText;
        base.OnPlusMinus();
    }
    public override void OnInput(string input)
    {
        base.OnInput(input);

        ViewModel.ChangeState(new StateInput(ViewModel));

        if (ViewModel.RightNum.HasValue)
        {
            // スタック値を入力値で上書き
            ViewModel.Stack = input;
        }

        // メインディスプレイにスタック文字列を表示
        ViewModel.MainDisplayText = ViewModel.Stack;
    }

    public override void OnSign(string sign)
    {
        base.OnSign(sign);

        // 右辺をクリア
        ViewModel.RightNum = null;

        // 計算実行(履歴保存はしない)
        ViewModel.Calculate();
    }
    public override void OnEqual()
    {
        ViewModel.ChangeState(new StateEqual(ViewModel));

        // スタック値を右辺に代入
        ViewModel.RightNum = decimal.Parse(ViewModel.Stack);

        // 計算実行
        var res = ViewModel.Calculate();

        // 左辺に計算結果を代入
        ViewModel.LeftNum = res.Result;
    }
}
