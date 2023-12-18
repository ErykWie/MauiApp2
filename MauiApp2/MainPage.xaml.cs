using Microsoft.Maui.Controls;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        double currentResult = 0;
        string currentOperation = "";
        bool isNewOperation = true;

        public MainPage()
        {
            InitializeComponent();
        }
        void OnBackspaceButtonClicked(object sender, EventArgs e)
        {
            if (ResultLabel.Text.Length > 0)
            {
                ResultLabel.Text = ResultLabel.Text.Remove(ResultLabel.Text.Length - 1);
            }
        }

        void OnClearButtonClicked(object sender, EventArgs e)
        {
            ResultLabel.Text = "0";
            currentResult = 0;
            currentOperation = "";
            isNewOperation = true;
        }

        void OnNumberButtonClicked(object sender, EventArgs e)
        {
            if (isNewOperation)
            {
                ResultLabel.Text = "";
                isNewOperation = false;
            }

            Button button = (Button)sender;
            string pressed = button.Text;

            if (ResultLabel.Text == "0" && pressed != ".")
            {
                ResultLabel.Text = pressed;
            }
            else if (pressed == ".")
            {
                if (!ResultLabel.Text.Contains("."))
                {
                    ResultLabel.Text += pressed;
                }
            }
            else
            {
                ResultLabel.Text += pressed;
            }
        }

        void OnOperationButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Text;

            if (!isNewOperation)
            {
                double currentValue = double.Parse(ResultLabel.Text);

                switch (currentOperation)
                {
                    case "+":
                        currentResult += currentValue;
                        break;
                    case "-":
                        currentResult -= currentValue;
                        break;
                    case "×":
                        currentResult *= currentValue;
                        break;
                    case "÷":
                        currentResult /= currentValue;
                        break;
                    default:
                        currentResult = currentValue;
                        break;
                }

                ResultLabel.Text = currentResult.ToString();
            }

            currentOperation = operation;
            isNewOperation = true;
        }

       

        void OnEqualButtonClicked(object sender, EventArgs e)
        {
            double currentValue = double.Parse(ResultLabel.Text);

            switch (currentOperation)
            {
                case "+":
                    currentResult += currentValue;
                    break;
                case "-":
                    currentResult -= currentValue;
                    break;
                case "×":
                    currentResult *= currentValue;
                    break;
                case "÷":
                    currentResult /= currentValue;
                    break;
                default:
                    currentResult = currentValue;
                    break;
            }

            ResultLabel.Text = currentResult.ToString();
            isNewOperation = true;
        }
    }
}
