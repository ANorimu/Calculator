﻿using Calculator.View.WinForm.Configuration;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using Model.App.Calculator;
using Model.App.Calculator.Command;

namespace Calculator.View.WinForm.ViewModel;

internal partial class CalculatorViewModel : ObservableObject
{
    private static readonly ILog logger = LogManager.GetLogger(
        System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

    private const string LogStart = "Start Calculater";
    private const string LogEnd = "End Calculater";
    private const string LogOperation = "Pushed [{0}]";
    private const string Period = ".";
    private const string InitText = "0";
    private enum Mode
    {
        Input,
        Sign,
        Calculated
    }
    private Mode mode = Mode.Input;
    private const decimal initValue = decimal.Zero;
    private decimal inputNumber = initValue;
    private decimal leftNum = initValue;
    private decimal? rightNum = null;
    private decimal? result = null;
    private string? sign = null;

    private ICalculateService service;

    public CalculatorViewModel()
    {
        logger.Info(LogStart);

        IServiceCollection services = new ServiceCollection();
        getDISetupper().Setup(services);
        var provider = services.BuildServiceProvider();
        service = provider.GetRequiredService<ICalculateService>();
    }
    private IDISetupper getDISetupper()
    {
        return new DISetUpper();
    }
    public void Exit()
    {
        logger.Info(LogEnd);
    }

    [ObservableProperty]
    private string mainDisplayText = initValue.ToString("0");
    [ObservableProperty]
    private string subDisplayText = string.Empty;
    [RelayCommand]
    private void BackSpace(string Label)
    {
        logger.InfoFormat(LogOperation, Label);

        switch (mode)
        {
            case Mode.Input:
                if (0 < MainDisplayText.Length)
                    MainDisplayText = MainDisplayText.Remove(MainDisplayText.Length - 1, 1);

                if (string.IsNullOrEmpty(MainDisplayText))
                    MainDisplayText = InitText;
                break;
            case Mode.Sign:
                break;
            case Mode.Calculated:
                SubDisplayText = string.Empty;
                break;
        }
    }
    [RelayCommand]
    private void Clear(string Label)
    {
        logger.InfoFormat(LogOperation, Label);

        inputNumber = decimal.Zero;
        leftNum = decimal.Zero;
        rightNum = null;
        MainDisplayText = InitText;
        SubDisplayText = string.Empty;

        mode = Mode.Input;
    }
    [RelayCommand]
    private void ClearEntry(string Label)
    {
        logger.InfoFormat(LogOperation, Label);

        inputNumber = 0;
        rightNum = null;
        MainDisplayText = InitText;

        mode = Mode.Input;
    }
    [RelayCommand]
    private void InputNumber(string inputNum)
    {
        logger.InfoFormat(LogOperation, inputNum);
        
        switch (mode)
        {
            case Mode.Input:
                if (MainDisplayText == InitText)
                    MainDisplayText = string.Empty;

                if (16 <= MainDisplayText.Replace("'", string.Empty).Replace(Period, string.Empty).Length) // 整数＋小数点以下最大16                
                    return;
                else if (-1 < MainDisplayText.IndexOf('.') && 6 <= MainDisplayText.Length - MainDisplayText.LastIndexOf('.')) // 小数点以下5桁                
                    return;
                else
                    MainDisplayText += inputNum;
                break;
            case Mode.Sign:
                MainDisplayText = string.Empty;
                MainDisplayText += inputNum;
                break;
            case Mode.Calculated:
                SubDisplayText = string.Empty;
                MainDisplayText = string.Empty;
                MainDisplayText += inputNum;
                break;
        }
        if (!decimal.TryParse(MainDisplayText, out var tmp))
        {
            MainDisplayText = InitText;
            inputNumber = decimal.Zero;
        }
        inputNumber = tmp;
        mode = Mode.Input;
    }
    [RelayCommand]
    private void AppendPeriod()
    {
        logger.InfoFormat(LogOperation, Period);

        if (MainDisplayText.Contains(Period))
            return;

        switch (mode)
        {
            case Mode.Input:
                MainDisplayText += Period;
                break;
            case Mode.Sign:
                MainDisplayText = InitText + Period;
                break;
            case Mode.Calculated:
                SubDisplayText = string.Empty;
                MainDisplayText = InitText + Period;
                break;
        }
        mode = Mode.Input;
    }
    [RelayCommand]
    private void ChangePlusMinus(string inputSign)
    {
        logger.InfoFormat(LogOperation, inputSign);

        inputNumber *= -1;
        MainDisplayText = inputNumber < 0 ?
            MainDisplayText.Insert(0, "+") :
            MainDisplayText.Replace("-", "");

        mode = Mode.Input;
    }
    [RelayCommand]
    private void InputSign(string inputSign)
    {
        logger.InfoFormat(LogOperation, inputSign);

        // 末尾の「.」除去
        if (MainDisplayText[^1] == '.')
            MainDisplayText = MainDisplayText.Replace(Period, string.Empty);

        sign = inputSign;
        switch (mode)
        {
            case Mode.Input:
                leftNum = inputNumber;
                rightNum = inputNumber;
                Calculate();
                break;
            case Mode.Calculated:
                leftNum = result ?? decimal.Zero;
                rightNum = inputNumber;
                Calculate();
                break;
            case Mode.Sign:
                break;
        }
        mode = Mode.Sign;
    }
    [RelayCommand]
    private void InputEqual()
    {
        logger.InfoFormat(LogOperation, "=");

        Calculate();

        mode = Mode.Calculated;
    }
    /// <summary>
    /// 計算実行＆結果を反映
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void Calculate()
    {
        var reqSign = CalculateRequest.OperatorSign.None;
        if (sign == null)
            reqSign = sign switch
            {
                "+" => CalculateRequest.OperatorSign.Plus,
                "-" => CalculateRequest.OperatorSign.Minus,
                "×" => CalculateRequest.OperatorSign.Multiply,
                "÷" => CalculateRequest.OperatorSign.Devide,
                _ => throw new NotImplementedException(),
            };
        var calculateHistory = service.Calculate(new CalculateRequest
        {
            LeftNumber = leftNum,
            RightNumber = rightNum,
            Sign = reqSign
        });
        result = calculateHistory.Result;
        SubDisplayText = calculateHistory.Formula;
        MainDisplayText = result == null ?
            "" :
            result.Value.ToString("0.#####");
    }
}
