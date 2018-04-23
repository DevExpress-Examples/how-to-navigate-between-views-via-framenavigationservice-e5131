Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Mvvm
Imports System.Windows.Input

Namespace FrameNavigationServiceSL.ViewModel
	Public Class MainViewModel
		Inherits ViewModelBase
		Private privateOnViewLoadedCommand As ICommand
		Public Property OnViewLoadedCommand() As ICommand
			Get
				Return privateOnViewLoadedCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateOnViewLoadedCommand = value
			End Set
		End Property
		Public Sub New()
			OnViewLoadedCommand = New DelegateCommand(AddressOf OnNavigateDetailsCommandExecute)
		End Sub
		Private Sub OnNavigateDetailsCommandExecute()
			'Navigate to the HomeView.
			ServiceContainer.GetService(Of INavigationService)().Navigate("HomeView", Nothing, Me)
		End Sub
	End Class
End Namespace