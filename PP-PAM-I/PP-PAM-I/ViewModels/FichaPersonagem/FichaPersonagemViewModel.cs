using System.Collections.ObjectModel;
using System.Windows.Input;
using PP_PAM_I.Models.FichaPersonagemModel;
using PP_PAM_I.ViewModels;

namespace PP_PAM_I.ViewModel
{
    public class FichaPersonagemViewModel : BaseViewModel
    {
        public ObservableCollection<Personagem> Personagens { get; set; } = new ObservableCollection<Personagem>();
        public ICommand AdicionarPersonagemCommand { get; }
        public FichaPersonagemViewModel()
        {
            AdicionarPersonagemCommand = new Command(AdicionarPersonagem);
        }

        #region Propriedades
        private string nome = string.Empty;
        public string Nome
        {
            get => nome;
            set
            {
                nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }

        private string personagemClasse = string.Empty;
        public string PersonagemClasse
        {
            get => personagemClasse;
            set
            {
                personagemClasse = value;
                OnPropertyChanged(nameof(PersonagemClasse));
            }
        }

        private int nivel;
        public int Nivel
        {
            get => nivel;
            set
            {
                nivel = value;
                OnPropertyChanged(nameof(Nivel));
            }
        }

        private string raca = string.Empty;
        public string Raca
        {
            get => raca;
            set
            {
                raca = value;
                OnPropertyChanged(nameof(Raca));
            }
        }
        #endregion

        #region Métodos
        private async void AdicionarPersonagem()
        {
            if (string.IsNullOrWhiteSpace(Nome) ||
                string.IsNullOrWhiteSpace(PersonagemClasse) ||
                string.IsNullOrWhiteSpace(Raca) ||
                Nivel <= 0)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Aviso",
                    "Todos os campos devem ser preenchidos e o nível deve ser maior que zero.",
                    "OK");
                return;
            }

            var novoPersonagem = new Personagem
            {
                Nome = Nome,
                Classe = PersonagemClasse,
                Nivel = Nivel,
                Raca = Raca
            };

            Personagens.Add(novoPersonagem);

            Nome = string.Empty;
            PersonagemClasse = string.Empty;
            Nivel = 0;
            Raca = string.Empty;
        }
        #endregion
    }
}
