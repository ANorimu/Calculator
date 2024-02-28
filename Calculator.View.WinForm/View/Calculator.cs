using Calculator.View.WinForm.ViewModel;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Windows.Forms;

namespace Calculator.View.WinForm;

public partial class Calculator : MaterialForm
{
    private readonly CalculatorViewModel viewModel;

    public Calculator()
    {
        InitializeComponent();

        SetMaterialDesign();

        viewModel = new CalculatorViewModel();
        BindViewModel(viewModel);
    }

    private void SetMaterialDesign()
    {
        SkinManager.EnforceBackcolorOnAllComponents = true;
        SkinManager.AddFormToManage(this);
        SkinManager.Theme =
            MaterialSkinManager.Themes.LIGHT;
        SkinManager.ColorScheme = new ColorScheme(
            Primary.Indigo500, Primary.Indigo700, Primary.Indigo100,
            Accent.LightBlue200,
            TextShade.WHITE);
    }

    private void BindViewModel(CalculatorViewModel viewModel)
    {
        Application.ApplicationExit += new EventHandler((object? sender, EventArgs e) =>
        {
            viewModel.Exit();
        });

        // ディスプレイ
        LabelSubDisplay.DataBindings.Add(
            nameof(LabelSubDisplay.Text), viewModel, nameof(viewModel.SubDisplayText))
            .FormattingEnabled = true;

        TextBoxMainDisplay.DataBindings.Add(
            nameof(TextBoxMainDisplay.Text), viewModel, nameof(viewModel.MainDisplayText))
            .FormattingEnabled = true;
        // 操作
        ButtonClearEntry.Command = viewModel.ClearEntryCommand;
        ButtonClearEntry.CommandParameter = ButtonClearEntry.Text;
        ButtonClear.Command = viewModel.ClearCommand;
        ButtonClear.CommandParameter = ButtonClear.Text;
        ButtonBack.Command = viewModel.BackSpaceCommand;
        ButtonBack.CommandParameter = ButtonBack.Text;
        // 数字
        Button0.Command = viewModel.AppendNumberCommand;
        Button0.CommandParameter = Button0.Text;
        Button1.Command = viewModel.AppendNumberCommand;
        Button1.CommandParameter = Button1.Text;
        Button2.Command = viewModel.AppendNumberCommand;
        Button2.CommandParameter = Button2.Text;
        Button3.Command = viewModel.AppendNumberCommand;
        Button3.CommandParameter = Button3.Text;
        Button4.Command = viewModel.AppendNumberCommand;
        Button4.CommandParameter = Button4.Text;
        Button5.Command = viewModel.AppendNumberCommand;
        Button5.CommandParameter = Button5.Text;
        Button6.Command = viewModel.AppendNumberCommand;
        Button6.CommandParameter = Button6.Text;
        Button7.Command = viewModel.AppendNumberCommand;
        Button7.CommandParameter = Button7.Text;
        Button8.Command = viewModel.AppendNumberCommand;
        Button8.CommandParameter = Button8.Text;
        Button9.Command = viewModel.AppendNumberCommand;
        Button9.CommandParameter = Button9.Text;
        ButtonPeriod.Command = viewModel.AppendPeriodCommand;
        ButtonPeriod.CommandParameter = ButtonPeriod.Text;
        ButtonPlusMinus.Command = viewModel.ChangePlusMinusCommand;
        ButtonPlusMinus.CommandParameter = ButtonPlusMinus.Text;
        // 演算子
        ButtonDivide.Command = viewModel.InputSignCommand;
        ButtonDivide.CommandParameter = ButtonDivide.Text;
        ButtonMultiply.Command = viewModel.InputSignCommand;
        ButtonMultiply.CommandParameter = ButtonMultiply.Text;
        ButtonMinus.Command = viewModel.InputSignCommand;
        ButtonMinus.CommandParameter = ButtonMinus.Text;
        ButtonPlus.Command = viewModel.InputSignCommand;
        ButtonPlus.CommandParameter = ButtonPlus.Text;
        // =
        ButtonEqual.Command = viewModel.InputEqualCommand;
        ButtonEqual.CommandParameter = ButtonEqual.Text;
        // キーボード入力
        KeyDown += new KeyEventHandler(OnKeyDown);
        // TODO 進む・戻る実装
    }
    private void OnKeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.D0:
            case Keys.NumPad0:
                Button0.PerformClick();
                break;
            case Keys.D1:
            case Keys.NumPad1:
                Button1.PerformClick();
                break;
            case Keys.D2:
            case Keys.NumPad2:
                Button2.PerformClick();
                break;
            case Keys.D3:
            case Keys.NumPad3:
                Button3.PerformClick();
                break;
            case Keys.D4:
            case Keys.NumPad4:
                Button4.PerformClick();
                break;
            case Keys.D5:
            case Keys.NumPad5:
                Button5.PerformClick();
                break;
            case Keys.D6:
            case Keys.NumPad6:
                Button6.PerformClick();
                break;
            case Keys.D7:
            case Keys.NumPad7:
                Button7.PerformClick();
                break;
            case Keys.D8:
            case Keys.NumPad8:
                Button8.PerformClick();
                break;
            case Keys.D9:
            case Keys.NumPad9:
                Button9.PerformClick();
                break;
            case Keys.Decimal:
                ButtonPeriod.PerformClick();
                break;
            case Keys.Add:
                ButtonPlus.PerformClick();
                break;
            case Keys.Subtract:
                ButtonMinus.PerformClick();
                break;
            case Keys.Multiply:
                ButtonMultiply.PerformClick();
                break;
            case Keys.Divide:
                ButtonDivide.PerformClick();
                break;
            case Keys.Enter:
                ButtonEqual.PerformClick();
                break;
            case Keys.Back:
                ButtonBack.PerformClick();
                break;
        }
    }
}
