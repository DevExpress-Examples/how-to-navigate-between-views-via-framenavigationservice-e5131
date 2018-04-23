using DevExpress.Xpf.Mvvm;
using System.Windows.Input;

namespace FrameNavigationServiceSL.ViewModel {
    public class DetailViewModel : NavigationViewModelBase {
        public ICommand NavigateBackCommand { get; private set; }
        INavigationService Service { get { return ServiceContainer.GetService<INavigationService>(); } }
        public DetailViewModel() {
            NavigateBackCommand = new DelegateCommand(OnNavigateCommandExecute, OnNavigateBackCommandCanExecute);
        }
        protected override void OnNavigatedTo() {
            base.OnNavigatedTo();
            //Update the NavigateBackCommand after navigation to the current DetailView.
            ((DelegateCommand)NavigateBackCommand).RaiseCanExecuteChanged();
        }
        bool OnNavigateBackCommandCanExecute() {
            return Service != null && Service.CanGoBack;
        }
        void OnNavigateCommandExecute() {
            Service.GoBack();
        }
    }
}