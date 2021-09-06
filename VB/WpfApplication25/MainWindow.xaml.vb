Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid

Namespace WpfApplication25
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub
		Private Sub MyScrollBarCustomRowAnnotationEventHandler(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.ScrollBarCustomRowAnnotationEventArgs)
			Dim data As TestData = TryCast(e.Row, TestData)
			If data Is Nothing Then
				Return
			End If
			Dim number As Integer = data.Number
			If number > 10 AndAlso number < 15 Then
				ShowCustomScrollAnnotation(e, Brushes.LightCoral)
			End If
			If number > 2 AndAlso number < 4 Then
				ShowCustomScrollAnnotation(e, Brushes.Green)
			End If

		End Sub
		Private Sub ShowCustomScrollAnnotation(ByVal e As DevExpress.Xpf.Grid.ScrollBarCustomRowAnnotationEventArgs, ByVal brush As SolidColorBrush)
			e.ScrollBarAnnotationInfo = New DevExpress.Xpf.Grid.ScrollBarAnnotationInfo() With {
				.Alignment = DevExpress.Xpf.Grid.ScrollBarAnnotationAlignment.Right,
				.Brush = brush,
				.MinHeight = 3,
				.Width = 10
			}
		End Sub

		Private Sub MyLoadedEventHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim view As TableView = TryCast(sender, TableView)
			view.SearchString = "Element2"
			view.SelectCells(15, view.Grid.Columns(0), 25, view.Grid.Columns(1))
		End Sub
	End Class
End Namespace
