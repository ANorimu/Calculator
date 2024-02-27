namespace Calculator.View.WinForm.ViewModel.State.State;

/// <summary>
/// 演算子入力後の状態
/// </summary>
/// <param name="viewModel"></param>
internal class StateSign(CalculatorViewModel viewModel) : StateBase(viewModel)
{
    public override void OnInput(string input)
    {
        base.OnInput(input);

        ViewModel.ChangeState(new StateInput(ViewModel));

        // スタック文字列を入力値で上書き
        ViewModel.Stack = input;

        // メインディスプレイにスタック文字列を表示
        ViewModel.MainDisplayText = ViewModel.Stack;
    }

    public override void OnSign(string sign)
    {
        base.OnSign(sign);

        // 右辺をクリア
        ViewModel.RightNum = null;

        // 計算実行(履歴保存はしない)
        var res = ViewModel.Calculate();

        // 式をサブディスプレイに表示
        ViewModel.SubDisplayText = res.Formula;

        // メインディスプレイに計算結果を表示
        ViewModel.MainDisplayText = res.Result.HasValue ? res.Result.Value.ToString("0.#####") : string.Empty;
    }
    public override void OnEqual()
    {
        ViewModel.ChangeState(new StateEqual(ViewModel));

        // スタック文字列を数値化して右辺に代入
        ViewModel.RightNum = decimal.Parse(ViewModel.Stack);

        // 計算実行
        var res = ViewModel.Calculate();

        // 左辺に計算結果を代入
        ViewModel.LeftNum = res.Result;

        // 式をサブディスプレイに表示
        ViewModel.SubDisplayText = res.Formula;

        // メインディスプレイに計算結果を表示
        ViewModel.MainDisplayText = res.Result.HasValue ? res.Result.Value.ToString("0.#####") : string.Empty;
    }
}
