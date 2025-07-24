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
    Public Partial Class MainWindow
        Inherits System.Windows.Window

        Public Sub New()
            Me.InitializeComponent()
        End Sub

        Private Sub MyScrollBarCustomRowAnnotationEventHandler(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.ScrollBarCustomRowAnnotationEventArgs)
            Dim data As WpfApplication25.TestData = TryCast(e.Row, WpfApplication25.TestData)
            If data Is Nothing Then Return
            Dim number As Integer = data.Number
            If number > 10 AndAlso number < 15 Then Me.ShowCustomScrollAnnotation(e, System.Windows.Media.Brushes.LightCoral)
            If number > 2 AndAlso number < 4 Then Me.ShowCustomScrollAnnotation(e, System.Windows.Media.Brushes.Green)
        End Sub

        Private Sub ShowCustomScrollAnnotation(ByVal e As DevExpress.Xpf.Grid.ScrollBarCustomRowAnnotationEventArgs, ByVal brush As System.Windows.Media.SolidColorBrush)
            e.ScrollBarAnnotationInfo = New DevExpress.Xpf.Grid.ScrollBarAnnotationInfo() With {.Alignment = DevExpress.Xpf.Grid.ScrollBarAnnotationAlignment.Right, .Brush = brush, .MinHeight = 3, .Width = 10}
        End Sub

        Private Sub MyLoadedEventHandler(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
            Dim view As DevExpress.Xpf.Grid.TableView = TryCast(sender, DevExpress.Xpf.Grid.TableView)
            view.SearchString = "Element2"
            view.SelectCells(15, view.Grid.Columns(0), 25, view.Grid.Columns(1))
        End Sub
    End Class
End Namespace
