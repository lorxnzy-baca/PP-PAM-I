using System.Text;

namespace PP_PAM_I.Views.DiceRoller;

public partial class DiceRollerView : ContentPage
{
    private readonly Random _rnd = new Random();

    public DiceRollerView()
    {
        InitializeComponent();
    }

    private void OnDiceRoll(object sender, EventArgs e)
    {
        if (ladoDado.SelectedItem != null && quantidadeDado.SelectedItem != null)
        {
            int faces = Convert.ToInt32(ladoDado.SelectedItem);
            int quantity = Convert.ToInt32(quantidadeDado.SelectedItem);
            int total = 0;
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < quantity; i++)
            {
                int roll = _rnd.Next(1, faces + 1);
                total += roll;
                result.AppendLine($"R{i + 1}: {roll}");
            }

            result.AppendLine($"\nTotal: {total}");
            valorDado.Text = result.ToString();
        }
        else
        {
            DisplayAlert("Erro", "Por favor, selecione a quantidade de lados e a quantidade de dados.", "OK");
        }
    }
}