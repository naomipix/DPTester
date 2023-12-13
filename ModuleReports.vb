Imports System.IO
Imports DocumentFormat.OpenXml.Packaging
Imports System.Reflection.Emit
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.Text.RegularExpressions
Imports DocumentFormat.OpenXml

Module ModuleReports
    Public Function GenerateLotReport(dt As DataTable) As String

        Try
            Dim TemplatePath As String = "C:\DPTester\Template\EndLotReportTemplate.xlsx"

            Dim OutputFolderTemp As String = "C:\DPTester\LotEnd Report"
            Dim OutputFolder As String = OutputFolderTemp
            Dim OutputDate As DateTime = DateTime.Now
            Dim Templaterowcountmax As Integer = 36
            Dim Reportpages = System.Math.Ceiling(dt.Rows.Count / Templaterowcountmax)


            ' Generate Path
            If Not Directory.Exists(OutputFolderTemp) Then
                Directory.CreateDirectory(OutputFolderTemp)
            End If

            If File.Exists(TemplatePath) Then
                For i As Integer = 0 To Reportpages - 1
                    Dim OutputPath As String = ""
                    If Reportpages > 1 Then
                        OutputPath = Path.Combine(OutputFolder, "EndlotReport" & FormMain.txtbx_LotID.Text & "_" & OutputDate.ToString("yyyyMMdd_HHmmss") & "_" & i + 1 & ".xlsx")
                    Else
                        OutputPath = Path.Combine(OutputFolder, "EndlotReport" & FormMain.txtbx_LotID.Text & "_" & OutputDate.ToString("yyyyMMdd_HHmmss") & ".xlsx")
                    End If

                    ' Create the "output" folder if it doesn't exist.
                    If Not Directory.Exists(OutputFolder) Then
                        Directory.CreateDirectory(OutputFolder)
                    End If

                    ' Close the template file if it's open.
                    Using templateDocument As SpreadsheetDocument = SpreadsheetDocument.Open(TemplatePath, True)
                        ' No need to do anything here; just opening and closing the file to ensure it's not locked.
                    End Using

                    ' Copy the template file after ensuring it's closed.
                    File.Copy(TemplatePath, OutputPath, True)

                    ' Open the copied file for editing.
                    Using outputDocument As SpreadsheetDocument = SpreadsheetDocument.Open(OutputPath, True)
                        ' Access the workbook part of the output file.
                        Dim workbookPart As WorkbookPart = outputDocument.WorkbookPart

                        ' Access the worksheet part where you want to insert data.
                        Dim worksheetPart As WorksheetPart = workbookPart.WorksheetParts.FirstOrDefault()

                        ' Access the worksheet data.
                        Dim sheetData As SheetData = worksheetPart.Worksheet.Elements(Of SheetData)().FirstOrDefault()


                        ' Populate header data
                        If True Then
                            ' Find or create the cell C4. (Work Order)
                            Dim cellC4 As Cell = GetOrCreateCell(sheetData, "C4")
                            With cellC4
                                .DataType = CellValues.String
                                .CellValue = New CellValue(FormMain.txtbx_WorkOrderNumber.Text)
                            End With
                            ' Find or create the cell C5. (Lot ID)
                            Dim cellC5 As Cell = GetOrCreateCell(sheetData, "C5")
                            With cellC5
                                .DataType = CellValues.String
                                .CellValue = New CellValue(FormMain.txtbx_LotID.Text)
                            End With
                            ' Find or create the cell C6. (Part ID)
                            Dim cellC6 As Cell = GetOrCreateCell(sheetData, "C6")
                            With cellC6
                                .DataType = CellValues.String
                                .CellValue = New CellValue(FormMain.txtbx_PartID.Text)
                            End With
                            ' Find or create the cell K4. (Confirmation ID)
                            Dim cellK4 As Cell = GetOrCreateCell(sheetData, "K4")
                            With cellK4
                                .DataType = CellValues.String
                                .CellValue = New CellValue(FormMain.txtbx_ConfirmationID.Text)
                            End With
                            ' Find or create the cell K5. (Confirmation ID)
                            Dim cellK5 As Cell = GetOrCreateCell(sheetData, "K5")
                            With cellK5
                                .DataType = CellValues.String
                                .CellValue = New CellValue(FormMain.txtbx_Quantity.Text)
                            End With
                            ' Find or create the cell K6. (Confirmation ID)
                            Dim cellK6 As Cell = GetOrCreateCell(sheetData, "K6")
                            With cellK6
                                .DataType = CellValues.String
                                .CellValue = New CellValue(FormMain.lbl_BlankDP.Text)
                            End With

                        End If
                        For j As Integer = i * Templaterowcountmax To ((i + 1) * Templaterowcountmax) - 1
                            Dim CurrentRow As Integer = j - (i * Templaterowcountmax)

                            If j < dt.Rows.Count Then
                                If CStr(dt(j)("serial_uid")).Length > 0 Or CStr(dt(j)("serial_attempt")).Length > 0 Then
                                    Dim onRow As Integer = CurrentRow + 10

                                    ' Find or create the cell A. (S.No)
                                    Dim cellA As Cell = GetOrCreateCell(sheetData, "A" & onRow)
                                    With cellA
                                        .DataType = CellValues.String
                                        .CellValue = New CellValue(CStr(CurrentRow + 1))
                                    End With
                                    ' Find or create the cell B. (serial_uid)
                                    Dim cellB As Cell = GetOrCreateCell(sheetData, "B" & onRow)
                                    With cellB
                                        .DataType = CellValues.String
                                        .CellValue = New CellValue(CStr(dt(j)("serial_uid")))
                                    End With
                                    ' Find or create the cell C. (serial_attempt)
                                    Dim cellC As Cell = GetOrCreateCell(sheetData, "C" & onRow)
                                    With cellC
                                        .DataType = CellValues.String
                                        .CellValue = New CellValue(CStr(dt(j)("serial_attempt")))
                                    End With
                                    ' Find or create the cell D. (timestamp)
                                    Dim cellD As Cell = GetOrCreateCell(sheetData, "D" & onRow)
                                    With cellD
                                        .DataType = CellValues.String
                                        .CellValue = New CellValue(CStr(dt(j)("timestamp")))
                                    End With
                                    ' Find or create the cell E. (timestamp)
                                    Dim cellE As Cell = GetOrCreateCell(sheetData, "E" & onRow)
                                    With cellE
                                        .DataType = CellValues.String
                                        If IsDBNull(dt(j)("temperature")) Then
                                            .CellValue = New CellValue(String.Empty)
                                        Else
                                            .CellValue = New CellValue(CStr(dt(j)("temperature")))
                                        End If

                                    End With
                                    ' Find or create the cell F. (flowrate)
                                    Dim cellF As Cell = GetOrCreateCell(sheetData, "F" & onRow)
                                    With cellF
                                        .DataType = CellValues.String
                                        If IsDBNull(dt(j)("flowrate")) Then
                                            .CellValue = New CellValue(String.Empty)
                                        Else
                                            .CellValue = New CellValue(CStr(dt(j)("flowrate")))
                                        End If

                                    End With
                                    ' Find or create the cell G. (Inlet Pressure)
                                    Dim cellG As Cell = GetOrCreateCell(sheetData, "G" & onRow)
                                    With cellG
                                        .DataType = CellValues.String
                                        If IsDBNull(dt(j)("inlet_pressure")) Then
                                            .CellValue = New CellValue(String.Empty)
                                        Else
                                            .CellValue = New CellValue(CStr(dt(j)("inlet_pressure")))
                                        End If

                                    End With
                                    ' Find or create the cell H. (Outlet Pressure)
                                    Dim cellH As Cell = GetOrCreateCell(sheetData, "H" & onRow)
                                    With cellH
                                        .DataType = CellValues.String
                                        If IsDBNull(dt(j)("outlet_pressure")) Then
                                            .CellValue = New CellValue(String.Empty)
                                        Else
                                            .CellValue = New CellValue(CStr(dt(j)("outlet_pressure")))
                                        End If

                                    End With
                                    ' Find or create the cell I. (Viscosity)
                                    Dim cellI As Cell = GetOrCreateCell(sheetData, "I" & onRow)
                                    With cellI
                                        .DataType = CellValues.String
                                        If IsDBNull(dt(j)("viscosity")) Then
                                            .CellValue = New CellValue(String.Empty)
                                        Else
                                            .CellValue = New CellValue(CStr(dt(j)("viscosity")))
                                        End If

                                    End With
                                    ' Find or create the cell J. (Diff Pressure)
                                    Dim cellJ As Cell = GetOrCreateCell(sheetData, "J" & onRow)
                                    With cellJ
                                        .DataType = CellValues.String
                                        If IsDBNull(dt(j)("diff_pressure")) Then
                                            .CellValue = New CellValue(String.Empty)
                                        Else
                                            .CellValue = New CellValue(CStr(dt(j)("diff_pressure")))
                                        End If

                                    End With
                                    ' Find or create the cell K. (Cycle Time)
                                    Dim cellK As Cell = GetOrCreateCell(sheetData, "K" & onRow)
                                    With cellK
                                        .DataType = CellValues.String
                                        If IsDBNull(dt(j)("cycle_time")) Then
                                            .CellValue = New CellValue(String.Empty)
                                        Else
                                            .CellValue = New CellValue(CStr(dt(j)("cycle_time")))
                                        End If

                                    End With
                                    ' Find or create the cell L. (Result)
                                    Dim cellL As Cell = GetOrCreateCell(sheetData, "L" & onRow)
                                    With cellL
                                        .DataType = CellValues.String
                                        If IsDBNull(dt(j)("result")) Then
                                            .CellValue = New CellValue(String.Empty)
                                        Else
                                            .CellValue = New CellValue(CStr(dt(j)("result")))
                                        End If

                                    End With



                                End If
                            Else
                                Exit For
                            End If
                        Next

                        ' Save the changes to the output document.
                        outputDocument.Save()


                    End Using
                    ' Output As PDF
                    If True Then
                        'Dim ExcelOutputPath As String = Path.Combine(OutputFolder, Label14.Text & "_" & OutputDate.ToString("yyyyMMdd_HHmmss") & ".xlsx")
                        'Dim PDFOutputPath As String = Path.Combine(OutputFolder, Label14.Text & "_" & OutputDate.ToString("yyyyMMdd_HHmmss") & ".pdf")

                        Dim workbook As Spire.Xls.Workbook = New Spire.Xls.Workbook 'Workbook = New Workbook
                        workbook.LoadFromFile(OutputPath, Spire.Xls.ExcelVersion.Version2010)
                        workbook.SaveToFile($"{Path.GetDirectoryName(OutputPath)}\{Path.GetFileNameWithoutExtension(OutputPath)}.pdf", Spire.Xls.FileFormat.PDF)

                    End If

                Next
            Else
                MsgBox($"Report Template Not Found, Kindly place Report template in {TemplateFolder}")
                Return "False"
            End If

            Return "True"

        Catch ex As Exception
            MsgBox($"End Lot Report Generation Failed")
        End Try

    End Function

    Private Function GetOrCreateCell(sheetData As SheetData, cellReference As String) As Cell
        ' Check if the cell reference is empty.
        If String.IsNullOrWhiteSpace(cellReference) Then
            Return Nothing
        End If

        ' Split the cell reference into column and row parts.
        Dim cellParts As String() = Regex.Split(cellReference, "(\d+)")

        If cellParts.Length <> 3 Then
            ' Invalid cell reference format.
            Return Nothing
        End If

        Dim columnIndex As Integer = Asc(cellParts(0)) - Asc("A") + 1
        Dim rowIndex As UInteger = Convert.ToUInt32(cellParts(1))

        ' Find the row with the specified index.
        Dim row As Row = sheetData.Elements(Of Row)().FirstOrDefault(Function(r) r.RowIndex.Value = rowIndex)

        If row Is Nothing Then
            ' If the row doesn't exist, create it.
            row = New Row() With {.RowIndex = rowIndex}
            sheetData.AppendChild(row)
        End If

        ' Create a cell at the specified column index.
        Dim cell As Cell = row.Elements(Of Cell)().FirstOrDefault(Function(c) GetColumnIndexFromCellReference(c.CellReference.Value) = columnIndex)

        If cell Is Nothing Then
            ' If the cell doesn't exist, create it.
            cellReference = GetCellReferenceFromColumnIndexAndRowIndex(columnIndex, rowIndex)
            cell = New Cell() With {.CellReference = cellReference}
            row.InsertAt(cell, GetInsertIndexForRow(row, columnIndex))
        End If

        Return cell
    End Function


    Private Function GetColumnIndexFromCellReference(cellReference As String) As Integer
        Dim match As Match = Regex.Match(cellReference, "([A-Za-z]+)(\d+)")
        If match.Success Then
            Return Asc(match.Groups(1).Value.ToUpper()) - Asc("A") + 1
        End If
        Return -1 ' Invalid cell reference.
    End Function

    Private Function GetCellReferenceFromColumnIndexAndRowIndex(columnIndex As Integer, rowIndex As UInteger) As String
        Return ChrW(Asc("A") + columnIndex - 1) & rowIndex.ToString()
    End Function

    Private Function GetInsertIndexForRow(row As Row, columnIndex As Integer) As Integer
        ' Find the correct index to insert the cell in the row based on column index.
        Dim insertIndex As Integer = 0
        For Each cell In row.Elements(Of Cell)()
            Dim cellColumnIndex = GetColumnIndexFromCellReference(cell.CellReference.Value)
            If cellColumnIndex >= columnIndex Then
                Exit For
            End If
            insertIndex += 1
        Next
        Return insertIndex
    End Function


    Private Sub MergeCells(worksheetPart As WorksheetPart, cellRange As String)
        Dim mergeCells As MergeCells = worksheetPart.Worksheet.Elements(Of MergeCells).FirstOrDefault()

        If mergeCells Is Nothing Then
            mergeCells = New MergeCells()
            If worksheetPart.Worksheet.Elements(Of CustomSheetView).Any() Then
                worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements(Of CustomSheetView).First())
            Else
                worksheetPart.Worksheet.InsertAfter(mergeCells, worksheetPart.Worksheet.Elements(Of SheetData).First())
            End If
        End If

        mergeCells.Append(New MergeCell() With {.Reference = New StringValue(cellRange)})
    End Sub


    Private Sub SetPrintArea(workbookPart As WorkbookPart, sheetName As String, cellRange As String)
        Dim definedNames As DefinedNames = workbookPart.Workbook.Descendants(Of DefinedNames)().FirstOrDefault()

        If definedNames Is Nothing Then
            definedNames = workbookPart.Workbook.AppendChild(New DefinedNames())
        End If

        Dim definedName As DefinedName = definedNames.Elements(Of DefinedName)().FirstOrDefault(Function(dn) dn.Name.Value.Equals("_xlnm.Print_Area", StringComparison.OrdinalIgnoreCase))

        If definedName Is Nothing Then
            definedName = definedNames.AppendChild(New DefinedName() With {
            .Name = "_xlnm.Print_Area",
            .LocalSheetId = 0
        })
        End If

        definedName.Text = sheetName & "!" & cellRange
    End Sub


    Private Sub SetCustomRowHeight(worksheetPart As WorksheetPart, rowIndex As UInteger, heightInPoints As Double)
        Dim sheetData As SheetData = worksheetPart.Worksheet.Elements(Of SheetData)().FirstOrDefault()

        ' Find the row with the specified index.
        Dim row As Row = sheetData.Elements(Of Row)().FirstOrDefault(Function(r) r.RowIndex.Value = rowIndex)

        If row Is Nothing Then
            ' If the row doesn't exist, create it.
            row = New Row() With {.RowIndex = rowIndex}
            sheetData.AppendChild(row)
        End If

        ' Set the custom row height in points (and let Excel convert it to twips).
        row.CustomHeight = True
        row.Height = heightInPoints
    End Sub

End Module
