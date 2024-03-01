namespace Calculator.View.WinForm.ViewModel.State;

/// <summary>
/// =押下後の状態
/// </summary>
/// <param name="viewModel"></param>
internal class StateEqual(CalculatorViewModel viewModel) : StateBase(viewModel)
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

        // 左辺・右辺・記号をクリア
        ViewModel.LeftNum = null;
        ViewModel.RightNum = null;
        ViewModel.Sign = null;

        // スタックを入力値に置換
        ViewModel.Stack = input;

        // サブディスプレイをクリアする
        ViewModel.SubDisplayText = string.Empty;

        // 入力値をメインディスプレイに表示
        ViewModel.MainDisplayText = ViewModel.Stack;
    }

    public override void OnSign(string sign)
    {
        base.OnSign(sign);

        ViewModel.ChangeState(new StateSign(ViewModel));

        // 前回の計算結果を左辺に代入
        ViewModel.LeftNum =  ViewModel.Result;

        // 右辺をクリア
        ViewModel.RightNum = null;

        // 計算実行
        ViewModel.Calculate();
    }
    public override void OnEqual()
    {
        // 前回の計算結果を左辺に代入
        ViewModel.LeftNum = ViewModel.Result;

        // 計算実行(右辺は変えない)
        ViewModel.Calculate();
    }
}
