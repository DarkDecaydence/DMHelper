using System.Collections.ObjectModel;

namespace DungeonMasterHelper.ViewModels {
    public class CitiesViewModel : BaseViewModel {
        private ObservableCollection<CityModel> generatedCities = new ObservableCollection<CityModel>();
        public ObservableCollection<CityModel> GeneratedCities { get { return generatedCities; } }

        private CityModel _selectedCity;
        public CityModel SelectedCity {
            get { return _selectedCity; }
            set { 
                _selectedCity = value;
                OnPropertyChanged();
            }
        }
    }
}
