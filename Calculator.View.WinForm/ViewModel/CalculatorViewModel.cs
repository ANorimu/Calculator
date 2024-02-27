using Calculator.View.WinForm.Configuration;
using Calculator.View.WinForm.ViewModel.State;
using Calculator.View.WinForm.ViewModel.State.State;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using Model.App.Calculator;
using Model.App.Calculator.Command;

namespace Calculator.View.WinForm.ViewModel;

internal partial class CalculatorViewModel : ObservableObject
{
    public const string Period = ".";
    public const string Minus = "-";
    public const string InitText = "0";

    private static readonly ILog logger = LogManager.GetLogger(
        System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);
    private const string LogStart = "Start Calculater";
    private const string LogEnd = "End Calculater";
    private const string LogOperation = "Pushed [{0}]";

    public decimal Result { get; set; }  = decimal.Zero;
    public decimal? LeftNum { get; set; } = null;
    public decimal? RightNum { get; set; } = null;
    public string? Sign { get; set; } = null;
    public string Stack { get; set; } = InitText;

    private IState state;
    private readonly ICalculateService service;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public CalculatorViewModel()
    {
        logger.Info(LogStart);

        IServiceCollection services = new ServiceCollection();
        getDISetupper().Setup(services);
        var provider = services.BuildServiceProvider();

        state = new StateInput(this);
        service = provider.GetRequiredService<ICalculateService>();
    }

    /// <summary>
    /// State変更(Stateクラスからの変更用のIF)
    /// </summary>
    /// <param name="state"></param>
    public void ChangeState(IState state) => this.state = state;

    /// <summary>
    /// 終了処理
    /// </summary>
    public void Exit()
    {
        logger.Info(LogEnd);
    }

    private IDISetupper getDISetupper()
    {
        return new DISetUpper();
    }

    /// <summary>
    /// メインディスプレイ表示文字
    /// </summary>
    [ObservableProperty]
    private string mainDisplayText = InitText;

    /// <summary>
    /// サブディスプレイ表示文字
    /// </summary>
    [ObservableProperty]
    private string subDisplayText = string.Empty;
    
    /// <summary>
    /// Del
    /// </summary>
    /// <param name="Label"></param>
    [RelayCommand]
    private void BackSpace(string Label)
    {
        logger.InfoFormat(LogOperation, Label);

        state.OnBackSpace();
    }

    /// <summary>
    /// C
    /// </summary>
    /// <param name="Label"></param>
    [RelayCommand]
    private void Clear(string Label)
    {
        logger.InfoFormat(LogOperation, Label);

        state.OnClear();
    }

    /// <summary>
    /// CE
    /// </summary>
    /// <param name="Label"></param>
    [RelayCommand]
    private void ClearEntry(string Label)
    {
        logger.InfoFormat(LogOperation, Label);

        state.OnClearEntry();
    }

    /// <summary>
    /// 数字追加
    /// </summary>
    /// <param name="inputNum"></param>
    [RelayCommand]
    private void AppendNumber(string inputNum)
    {
        logger.InfoFormat(LogOperation, inputNum);

        if (16 <= Stack.Replace("'", string.Empty).Replace(Period, string.Empty).Length)
            // 整数＋小数点以下最大16
            return;
        else if (-1 < Stack.IndexOf('.') && 6 <= Stack.Length - Stack.LastIndexOf('.'))
            // 小数点以下5桁
            return;

        state.OnInput(inputNum);
    }

    /// <summary>
    /// .追加
    /// </summary>
    [RelayCommand]
    private void AppendPeriod()
    {
        logger.InfoFormat(LogOperation, Period);

        if (Stack.Contains(Period))
            return;

        state.OnInput(Period);
    }

    /// <summary>
    /// +/-切替
    /// </summary>
    /// <param name="inputSign"></param>
    [RelayCommand]
    private void ChangePlusMinus(string inputSign)
    {
        logger.InfoFormat(LogOperation, inputSign);

        state.OnPlusMinus();
    }

    /// <summary>
    /// 演算子
    /// </summary>
    /// <param name="inputSign"></param>
    [RelayCommand]
    private void InputSign(string inputSign)
    {
        logger.InfoFormat(LogOperation, inputSign);

        state.OnSign(inputSign);
    }

    /// <summary>
    /// =
    /// </summary>
    [RelayCommand]
    private void InputEqual()
    {
        logger.InfoFormat(LogOperation, "=");

        state.OnEqual();
    }

    /// <summary>
    /// 計算実行
    /// </summary>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public CalculateResponse Calculate()
    {
        // 計算
        var reqSign = CalculateRequest.OperatorSign.None;
        if (Sign != null)
            reqSign = Sign switch
            {
                "+" => CalculateRequest.OperatorSign.Plus,
                "-" => CalculateRequest.OperatorSign.Minus,
                "×" => CalculateRequest.OperatorSign.Multiply,
                "÷" => CalculateRequest.OperatorSign.Devide,
                _ => throw new NotImplementedException(),
            };
        logger.Debug($"LeftNum:{LeftNum},RightNum:{RightNum},Sign:{reqSign}");
        var res = service.Calculate(new CalculateRequest
        {
            LeftNumber = LeftNum ?? decimal.Zero,
            RightNumber = RightNum,
            Sign = reqSign
        });
        logger.Debug($"計算:{res.Formula}{res.Result}");

        Result = res.Result.HasValue ? res.Result.Value : decimal.Zero;

        // メインディスプレイに計算結果を表示
        MainDisplayText = Result.ToString("0.#####");

        // 式をサブディスプレイに表示
        SubDisplayText = res.Formula;

        return res;
    }
}
