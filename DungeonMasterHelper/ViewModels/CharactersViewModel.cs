using System.Collections.ObjectModel;

namespace DungeonMasterHelper.ViewModels {
    public class CharactersViewModel : BaseViewModel {
        private ObservableCollection<CharacterViewModel> generatedCharacters = new ObservableCollection<CharacterViewModel>();
        public ObservableCollection<CharacterViewModel> GeneratedCharacters { get { return generatedCharacters; } }

        private CharacterViewModel _selectedCharacter;
        public CharacterViewModel SelectedCharacter {
            get {
                if (_selectedCharacter == null) return CharacterViewModel.EmptyCharacter;
                return _selectedCharacter; }
            set {
                _selectedCharacter = value;
                OnPropertyChanged();
            }
        }
    }
}
