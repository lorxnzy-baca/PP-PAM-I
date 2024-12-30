using PP_PAM_I.ViewModel;

namespace PP_PAM_I.Views.FichaPersonagem
{
    public partial class FichaPersonagemView : ContentPage
    {
        private FichaPersonagemViewModel viewModel;
        public FichaPersonagemView()
        {
            InitializeComponent();
            viewModel = new FichaPersonagemViewModel();
            BindingContext = viewModel;
        }
    }
}