Imports DevExpress.XtraEditors.DXErrorProvider
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace WpfApplication25
    Public Class ViewModel
        Public Property List() As ObservableCollection(Of TestData)

        Public Sub New()
            List = New ObservableCollection(Of TestData)()
            PopulateData()
        End Sub

        Private Sub PopulateData()
            For i As Integer = 0 To 29
                Dim t = New TestData(i, "Element" & i.ToString())
                List.Add(t)
            Next i
        End Sub
    End Class

    Public Class TestData
        Implements INotifyPropertyChanged, IDataErrorInfo


        Private number_Renamed As Integer

        Private text_Renamed As String

        Public Sub New(ByVal number As Integer, ByVal text As String)
            Me.number_Renamed = number
            Me.text_Renamed = text
        End Sub

        Public Property Number() As Integer
            Get
                Return number_Renamed
            End Get
            Set(ByVal value As Integer)
                If number_Renamed = value Then
                    Return
                End If
                number_Renamed = value
                NotifyChanged("Number")
            End Set
        End Property
        Public Property Text() As String
            Get
                Return text_Renamed
            End Get
            Set(ByVal value As String)
                If text_Renamed = value Then
                    Return
                End If
                text_Renamed = value
                NotifyChanged("Text")
            End Set
        End Property

        Public ReadOnly Property [Error]() As String Implements IDataErrorInfo.Error
            Get
                Dim result As String = String.Empty
                If Number >= 10 AndAlso Number < 20 Then
                    result = "Incorrect value!"
                End If
                Return result
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements IDataErrorInfo.Item
            Get
                Dim result As String = String.Empty
                Select Case columnName
                    Case "Number"
                        If Number > 20 AndAlso Number <= 40 Then
                            result = String.Format("The current number is less than {0} !", Number.ToString())
                        End If
                End Select
                Return result
            End Get
        End Property

        Private Sub NotifyChanged(ByVal propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub

        #Region "INotifyPropertyChanged Members"
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        #End Region
    End Class
End Namespace
