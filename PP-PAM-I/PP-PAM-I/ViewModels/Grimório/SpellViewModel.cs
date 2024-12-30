using PP_PAM_I.Models;
using PP_PAM_I.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PP_PAM_I.ViewModels.SpellViewModel
{
    public class SpellViewModel : BindableObject
    {
        private readonly SpellService _spellService;
        private string _selectedLevel;
        private string _selectedSchool = string.Empty;

        public ObservableCollection<Spell> Spells { get; }
        public ObservableCollection<string> Levels { get; }
        public ObservableCollection<string> Schools { get; }

        public ICommand FilterCommand { get; }
        public ICommand ClearFilterCommand { get; }

        public SpellViewModel()
        {
            _spellService = new SpellService();
            Spells = new ObservableCollection<Spell>();
            Levels = new ObservableCollection<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            Schools = new ObservableCollection<string> { "Abjuration", "Conjuration", "Divination", "Enchantment", "Evocation", "Illusion", "Necromancy", "Transmutation" };
            FilterCommand = new Command(async () => await FilterSpellsAsync());
            ClearFilterCommand = new Command(async () => await ClearFiltersAsync());

            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await LoadSpellsAsync();
        }

        #region Atributos/Propriedades
        public string SelectedLevel
        {
            get => _selectedLevel;
            set
            {
                _selectedLevel = value;
                OnPropertyChanged();
            }
        }

        public string SelectedSchool
        {
            get => _selectedSchool;
            set
            {
                _selectedSchool = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Métodos
        private async Task LoadSpellsAsync()
        {
            var spells = await _spellService.GetSpellsAsync();
            foreach (var spell in spells)
            {
                Spells.Add(spell);
            }
        }

        private async Task FilterSpellsAsync()
        {
            Spells.Clear();
            var spells = await _spellService.GetSpellsAsync(_selectedLevel, _selectedSchool);
            foreach (var spell in spells)
            {
                Spells.Add(spell);
            }
        }

        private async Task ClearFiltersAsync()
        {
            SelectedLevel = null;
            SelectedSchool = null;
            Spells.Clear();
            var spells = await _spellService.GetSpellsAsync();
            foreach (var spell in spells)
            {
                Spells.Add(spell);
            }
        }
        #endregion
    }
}
