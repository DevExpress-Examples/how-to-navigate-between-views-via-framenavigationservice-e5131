Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.WindowsUI.Navigation
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes

Namespace FrameNavigationServiceSL
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
	Public NotInheritable Class FrameNavigationServiceConnector
		Public Shared ReadOnly FrameNavigationServiceProperty As DependencyProperty = DependencyProperty.RegisterAttached("FrameNavigationService", GetType(FrameNavigationService), GetType(FrameNavigationServiceConnector), New PropertyMetadata(AddressOf OnFrameNavigationServiceChanged))
		Private Sub New()
		End Sub
		Public Shared Function GetFrameNavigationService(ByVal obj As DependencyObject) As FrameNavigationService
			Return CType(obj.GetValue(FrameNavigationServiceProperty), FrameNavigationService)
		End Function
		Public Shared Sub SetFrameNavigationService(ByVal obj As DependencyObject, ByVal value As FrameNavigationService)
			obj.SetValue(FrameNavigationServiceProperty, value)
		End Sub
		Private Shared Sub OnFrameNavigationServiceChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			Dim oldValue As FrameNavigationService = TryCast(e.OldValue, FrameNavigationService)
			Dim newValue As FrameNavigationService = TryCast(e.NewValue, FrameNavigationService)
			If oldValue IsNot Nothing Then
				oldValue.Frame = Nothing
			End If
			If newValue IsNot Nothing Then
				newValue.Frame = TryCast(d, DevExpress.Xpf.WindowsUI.NavigationFrame)
			End If
		End Sub
	End Class
End Namespace
