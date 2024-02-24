using Calculator.View.WinForm.ViewModel;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Calculator.View.WinForm;

public partial class Calculator : MaterialForm
{
    private CalculatorViewModel viewModel;

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
        ButtonDelete.Command = viewModel.BackSpaceCommand;
        ButtonDelete.CommandParameter = ButtonDelete.Text;
        // 数字
        Button0.Command = viewModel.InputNumberCommand;
        Button0.CommandParameter = Button0.Text;
        Button1.Command = viewModel.InputNumberCommand;
        Button1.CommandParameter = Button1.Text;
        Button2.Command = viewModel.InputNumberCommand;
        Button2.CommandParameter = Button2.Text;
        Button3.Command = viewModel.InputNumberCommand;
        Button3.CommandParameter = Button3.Text;
        Button4.Command = viewModel.InputNumberCommand;
        Button4.CommandParameter = Button4.Text;
        Button5.Command = viewModel.InputNumberCommand;
        Button5.CommandParameter = Button5.Text;
        Button6.Command = viewModel.InputNumberCommand;
        Button6.CommandParameter = Button6.Text;
        Button7.Command = viewModel.InputNumberCommand;
        Button7.CommandParameter = Button7.Text;
        Button8.Command = viewModel.InputNumberCommand;
        Button8.CommandParameter = Button8.Text;
        Button9.Command = viewModel.InputNumberCommand;
        Button9.CommandParameter = Button9.Text;
        ButtonPeriod.Command = viewModel.AppendPeriodCommand;
        ButtonPeriod.CommandParameter = ButtonPeriod.Text;
        ButtonPlusMinus.Command = viewModel.ChangePlusMinusCommand;
        ButtonPlusMinus.CommandParameter = ButtonPlusMinus.Text;
        // 演算子
        ButtonDevide.Command = viewModel.InputSignCommand;
        ButtonDevide.CommandParameter = ButtonDevide.Text;
        ButtonMaltiply.Command = viewModel.InputSignCommand;
        ButtonMaltiply.CommandParameter = ButtonMaltiply.Text;
        ButtonMinus.Command = viewModel.InputSignCommand;
        ButtonMinus.CommandParameter = ButtonMinus.Text;
        ButtonPlus.Command = viewModel.InputSignCommand;
        ButtonPlus.CommandParameter = ButtonPlus.Text;
        // =
        ButtonEaual.Command = viewModel.InputEqualCommand;
        ButtonEaual.CommandParameter = ButtonEaual.Text;

        // TODO 進む・戻る実装
    }
}
