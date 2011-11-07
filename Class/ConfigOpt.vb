Imports System.IO

' Class for managing configuration persistence
Public Class ConfigOpt

    ' This DataSet is used as a memory data structure to hold config key/value pairs
    ' Inside this DataSet, a single DataTable named ConfigValues is created
    Private Shared DSoptions As DataSet
    ' This is the filename for the DataSet XML serialization
    Private Shared mConfigFileName As String

    ' This property is read-only, because it is set through Initialize or Store methods
    Public Shared ReadOnly Property ConfigFileName() As String
        Get
            Return mConfigFileName
        End Get
    End Property

    ' This method has to be invoked before using any other method of ConfigOpt class
    ' ConfigFile parameter is the name of the config file to be read
    ' (if that file doesn't exists, the method simply initialize the data structure
    ' and the ConfigFileName property)
    Public Shared Sub Initialize(ByVal ConfigFile As String)
        mConfigFileName = ConfigFile
        DSoptions = New DataSet("ConfigOpt")
        If File.Exists(ConfigFile) Then
            ' If the specified config file exists, it is read to populate the DataSet
            DSoptions.ReadXml(ConfigFile)
        Else
            ' If the specified config file doesn't exists, 
            ' the DataSet is simply initialized (and left empty):
            ' the ConfigValues DataTable is created with two fields (to hold key/values pairs)
            Dim dt As New DataTable("ConfigValues")
            dt.Columns.Add("OptionName", System.Type.GetType("System.String"))
            dt.Columns.Add("OptionValue", System.Type.GetType("System.String"))
            DSoptions.Tables.Add(dt)
        End If
    End Sub
  
    ' This method serializes the memory data structure holding the config parameters
    ' The filename used is the one defined calling Initialize method
    Public Shared Sub Store()
        Store(mConfigFileName)
    End Sub

    ' Same as Store() method, but with the ability to serialize on a different filename
    Public Shared Sub Store(ByVal ConfigFile As String)
        mConfigFileName = ConfigFile
        DSoptions.WriteXml(ConfigFile)
    End Sub

    ' Read a configuration Value (aka OptionValue), given its Key (aka OptionName)
    ' If the Key is not defined, an empty string is returned
    Public Shared Function GetOption(ByVal OptionName As String) As String
        Dim dv As DataView = DSoptions.Tables("ConfigValues").DefaultView
        dv.RowFilter = "OptionName='" & OptionName & "'"
        If dv.Count > 0 Then
            Return CStr(dv.Item(0).Item("OptionValue"))
        Else
            Return ""
        End If
    End Function
    Public Shared Function GetListOptionS(ByVal OptionName As String) As String()
        Dim list() As String
        Dim i As Integer
        Dim dv As DataView = DSoptions.Tables("ConfigValues").DefaultView
        'dv.RowFilter = "OptionName='" & OptionName & "'"

        If dv.Count > 0 Then
            ReDim list(dv.Count - 1)
            For i = 0 To dv.Count - 1
                list(i) = CStr(dv.Item(i).Item("OptionValue"))
            Next
            Return list
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function GetListOptionsKey(ByVal OptionName As String, ByVal sKey As String) As String
        Dim value As String
        Dim i As Integer

        Dim dv As DataView = DSoptions.Tables("ConfigValues").DefaultView
        'dv.RowFilter = "OptionName='" & OptionName & "'"

        If dv.Count > 0 Then
            For i = 0 To dv.Count - 1
                If CStr(dv.Item(i).Item("OptionValue")).ToString.StartsWith(sKey) Then

                    value = CStr(dv.Item(i).Item("OptionValue"))
                End If
            Next
            Return value
        Else
            Return Nothing
        End If
    End Function
    ' Write in the memory data structure a Key/Value pair for a configuration setting
    ' If the Key already exists, the Value is simply updated, else the Key/Value pair is added
    ' Warning: to update the written Key/Value pair on the config file, you need to call Store
    Public Shared Sub SetOption(ByVal OptionName As String, ByVal OptionValue As String)
        Dim dv As DataView = DSoptions.Tables("ConfigValues").DefaultView
        dv.RowFilter = "OptionName='" & OptionName & "'"
        If dv.Count > 0 Then
            dv.Item(0).Item("OptionValue") = OptionValue
        Else
            Dim dr As DataRow = DSoptions.Tables("ConfigValues").NewRow()
            dr("OptionName") = OptionName
            dr("OptionValue") = OptionValue
            DSoptions.Tables("ConfigValues").Rows.Add(dr)
        End If
    End Sub
    'crea una lista di N elementi e cancella il + vecchio inserito
    Public Shared Sub SetOptionList(ByVal OptionName As String, ByVal OptionValue As String, ByVal nLimit As Integer)
        Dim dv As DataView = DSoptions.Tables("ConfigValues").DefaultView
        Dim ArrOldValue As New ArrayList
        Dim count As Integer
        Dim i As Integer

        dv.RowFilter = "OptionName='" & OptionName & "'"


        If dv.Count > 0 Then

            ArrOldValue.Add(OptionName & "|" & OptionValue)

            For i = 0 To dv.Count - 1
                ArrOldValue.Add(dv.Item(i).Item("OptionName") & "|" & dv.Item(i).Item("OptionValue"))
            Next

            DSoptions.Clear()
            'aggiungo in testa l'elemento + recente
            'Dim drNew As DataRow = DSoptions.Tables("ConfigValues").NewRow()
            'drNew("OptionName") = OptionName
            'drNew("OptionValue") = OptionValue
            'DSoptions.Tables("ConfigValues").Rows.Add(drNew)

            count = 1


            For i = 0 To ArrOldValue.Count - 1
                If count < nLimit Then
                    Dim dr As DataRow = DSoptions.Tables("ConfigValues").NewRow()
                    dr("OptionName") = ArrOldValue(i).ToString.Split("|")(0) 'OptionName
                    dr("OptionValue") = ArrOldValue(i).ToString.Split("|")(1)
                    DSoptions.Tables("ConfigValues").Rows.Add(dr)
                    count += 1
                End If
            Next
            'dv.Item(0).Item("OptionValue") = OptionValue
        Else
            Dim dr As DataRow = DSoptions.Tables("ConfigValues").NewRow()
            dr("OptionName") = OptionName
            dr("OptionValue") = OptionValue
            DSoptions.Tables("ConfigValues").Rows.Add(dr)
        End If
    End Sub

End Class

