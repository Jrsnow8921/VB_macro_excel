Sub compare_cols()

    'Get the last row
    Dim Report As Worksheet
    Dim i As Integer, j As Integer
    Dim lastRow As Integer

    Set Report = Excel.Worksheets("Sheet1") 'You could also use Excel.ActiveSheet _
                                            if you always want this to run on the current sheet.

    lastRow = Report.UsedRange.Rows.Count

    Application.ScreenUpdating = False

    For i = 2 To lastRow
        For j = 2 To lastRow
            If Report.Cells(i, 1).Value <> "" Then 'This will omit blank cells at the end (in the event that the column lengths are not equal.
                If InStr(1, Report.Cells(j, 2).Value, Report.Cells(i, 1).Value, vbTextCompare) > 0 Then
                    'You may notice in the above instr statement, I have used vbTextCompare instead of its numerical value, _
                    I find this much more reliable.
                    Report.Cells(i, 1).Interior.Color = RGB(255, 255, 255) 'White background
                    Report.Cells(i, 1).Font.Color = RGB(0, 0, 0) 'Black font color
                    Exit For
                Else
                    Report.Cells(i, 1).Interior.Color = RGB(156, 0, 6) 'Dark red background
                    Report.Cells(i, 1).Font.Color = RGB(255, 199, 206) 'Light red font color
                End If
            End If
        Next j
    Next i

    'Now I use the same code for the second column, and just switch the column numbers.
    For i = 2 To lastRow
        For j = 2 To lastRow
            If Report.Cells(i, 2).Value <> "" Then
                If InStr(1, Report.Cells(j, 1).Value, Report.Cells(i, 2).Value, vbTextCompare) > 0 Then
                    Report.Cells(i, 2).Interior.Color = RGB(255, 255, 255) 'White background
                    Report.Cells(i, 2).Font.Color = RGB(0, 0, 0) 'Black font color
                    Exit For
                Else
                    Report.Cells(i, 2).Interior.Color = RGB(156, 0, 6) 'Dark red background
                    Report.Cells(i, 2).Font.Color = RGB(255, 199, 206) 'Light red font color
                End If
            End If
        Next j
    Next i

Application.ScreenUpdating = True

End Sub

