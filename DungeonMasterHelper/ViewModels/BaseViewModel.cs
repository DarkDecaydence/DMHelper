using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DungeonMasterHelper.ViewModels {
    public class BaseViewModel : INotifyPropertyChanged {

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) { handler(this, new PropertyChangedEventArgs(propertyName)); }
        }
        #endregion

    }
}
