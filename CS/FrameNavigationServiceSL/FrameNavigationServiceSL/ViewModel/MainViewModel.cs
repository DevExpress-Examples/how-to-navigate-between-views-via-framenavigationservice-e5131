using DevExpress.Xpf.Mvvm;
using System.Windows.Input;

namespace FrameNavigationServiceSL.ViewModel {
    public class MainViewModel : ViewModelBase {
        public ICommand OnViewLoadedCommand { get; private set; }
        public MainViewModel() {
            OnViewLoadedCommand = new DelegateCommand(OnNavigateDetailsCommandExecute);
        }
        void OnNavigateDetailsCommandExecute() {
            //Navigate to the HomeView.
            ServiceContainer.GetService<INavigationService>().Navigate("HomeView", null, this);
        }
    }
}