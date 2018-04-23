Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Mvvm
Imports System.Windows.Input

Namespace FrameNavigationServiceSL.ViewModel
	Public Class DetailViewModel
		Inherits NavigationViewModelBase
		Private privateNavigateBackCommand As ICommand
		Public Property NavigateBackCommand() As ICommand
			Get
				Return privateNavigateBackCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateNavigateBackCommand = value
			End Set
		End Property
		Private ReadOnly Property Service() As INavigationService
			Get
				Return ServiceContainer.GetService(Of INavigationService)()
			End Get
		End Property
		Public Sub New()
			NavigateBackCommand = New DelegateCommand(AddressOf OnNavigateCommandExecute, AddressOf OnNavigateBackCommandCanExecute)
		End Sub
		Protected Overrides Sub OnNavigatedTo()
			MyBase.OnNavigatedTo()
			'Update the NavigateBackCommand after navigation to the current DetailView.
			CType(NavigateBackCommand, DelegateCommand).RaiseCanExecuteChanged()
		End Sub
		Private Function OnNavigateBackCommandCanExecute() As Boolean
			Return Service IsNot Nothing AndAlso Service.CanGoBack
		End Function
		Private Sub OnNavigateCommandExecute()
			Service.GoBack()
		End Sub
	End Class
End Namespace