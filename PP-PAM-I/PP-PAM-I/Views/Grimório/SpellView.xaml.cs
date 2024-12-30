using PP_PAM_I.ViewModels.SpellViewModel;

namespace PP_PAM_I.Views.Grimório;

public partial class SpellView : ContentPage
{
    private SpellViewModel viewModel;
    public SpellView()
    {
        InitializeComponent();
        viewModel = new SpellViewModel();
        BindingContext = viewModel;
    }
}