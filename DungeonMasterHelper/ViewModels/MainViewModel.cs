
namespace DungeonMasterHelper.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly WordScramblerViewModel scramblerViewModel;
        public WordScramblerViewModel ScramblerViewModel
        { get { return scramblerViewModel; } }

        private readonly CitiesViewModel citiesViewModel;
        public CitiesViewModel CitiesViewModel
        { get { return citiesViewModel; } }

        private readonly CharactersViewModel npcsViewModel;
        public CharactersViewModel NPCsViewModel 
        { get { return npcsViewModel; } }

        public MainViewModel()
        {
            scramblerViewModel = new WordScramblerViewModel();
            citiesViewModel = new CitiesViewModel();
            npcsViewModel = new CharactersViewModel();
        }

        public void AddCity(CityModel newCity) {
            citiesViewModel.GeneratedCities.Add(newCity);
        }
        public void AddNPC(CharacterModel newNPC) {
            npcsViewModel.GeneratedCharacters.Add(new CharacterViewModel(newNPC));
        }
    }
}
