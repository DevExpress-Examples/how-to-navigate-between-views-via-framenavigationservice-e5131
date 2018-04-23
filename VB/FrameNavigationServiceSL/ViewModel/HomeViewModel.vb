Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Mvvm
Imports System.Windows.Input

Namespace FrameNavigationServiceSL.ViewModel
	Public Class HomeViewModel
		Inherits ViewModelBase
		Private privateNavigateDetailsCommand As ICommand
		Public Property NavigateDetailsCommand() As ICommand
			Get
				Return privateNavigateDetailsCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateNavigateDetailsCommand = value
			End Set
		End Property
		Public Sub New()
			NavigateDetailsCommand = New DelegateCommand(AddressOf OnNavigateDetailsCommandExecute)
		End Sub
		Private Sub OnNavigateDetailsCommandExecute()
			'Navigate to the DetailView.
			'To allow the FrameNavigationService from the HomeViewModel to be used in the DetailView's ViewModel (DetailViewModel),
			'pass the current object as the method's ParentViewModel parameter.
			ServiceContainer.GetService(Of INavigationService)().Navigate("DetailView", Nothing, Me)
		End Sub
	End Class
End Namespace