using DevExpress.Xpf.Mvvm;
using System.Windows.Input;

namespace FrameNavigationServiceSL.ViewModel {
    public class HomeViewModel : ViewModelBase {
        public ICommand NavigateDetailsCommand { get; private set; }
        public HomeViewModel() {
            NavigateDetailsCommand = new DelegateCommand(OnNavigateDetailsCommandExecute);
        }
        void OnNavigateDetailsCommandExecute() {
            //Navigate to the DetailView.
            //To allow the FrameNavigationService from the HomeViewModel to be used in the DetailView's ViewModel (DetailViewModel),
            //pass the current object as the method's ParentViewModel parameter.
            ServiceContainer.GetService<INavigationService>().Navigate("DetailView", null, this);
        }
    }
}