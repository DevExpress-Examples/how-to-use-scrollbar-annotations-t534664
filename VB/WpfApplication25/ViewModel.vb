Imports System.Collections.ObjectModel
Imports System.ComponentModel

Namespace WpfApplication25

    Public Class ViewModel

        Public Property List As ObservableCollection(Of TestData)

        Public Sub New()
            List = New ObservableCollection(Of TestData)()
            PopulateData()
        End Sub

        Private Sub PopulateData()
            For i As Integer = 0 To 30 - 1
                Dim t = New TestData(i, "Element" & i.ToString())
                List.Add(t)
            Next
        End Sub
    End Class

    Public Class TestData
        Implements INotifyPropertyChanged, IDataErrorInfo

        Private numberField As Integer

        Private textField As String

        Public Sub New(ByVal number As Integer, ByVal text As String)
            numberField = number
            textField = text
        End Sub

        Public Property Number As Integer
            Get
                Return numberField
            End Get

            Set(ByVal value As Integer)
                If numberField = value Then Return
                numberField = value
                NotifyChanged("Number")
            End Set
        End Property

        Public Property Text As String
            Get
                Return textField
            End Get

            Set(ByVal value As String)
                If Equals(textField, value) Then Return
                textField = value
                NotifyChanged("Text")
            End Set
        End Property

        Public ReadOnly Property [Error] As String Implements IDataErrorInfo.[Error]
            Get
                Dim result As String = String.Empty
                If Number >= 10 AndAlso Number < 20 Then result = "Incorrect value!"
                Return result
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal columnName As String) As String Implements IDataErrorInfo.Item
            Get
                Dim result As String = String.Empty
                Select Case columnName
                    Case "Number"
                        If Number > 20 AndAlso Number <= 40 Then result = String.Format("The current number is less than {0} !", Number.ToString())
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
