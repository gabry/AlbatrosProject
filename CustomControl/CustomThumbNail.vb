Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections
Imports System.Drawing.Imaging
Imports System.IO

Public Class CustomThumbNail
    Private m_Alfa As Single = 0

    Private m_Selected As ThumbElement = Nothing

    Private m_AlfaAccel As Single = 1

    Private m_Perspective As Single = 4

    Private PI_FACT As Double = Math.PI / 180.0F

    Private m_arImages As New List(Of ThumbElement)()
    Private m_arFO As New List(Of FlyingObject)()
    Private Sub m_Timer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles m_Timer.Tick
        m_Alfa += m_AlfaAccel

        If m_Alfa > 360 Then
            m_Alfa = m_Alfa - 360
        End If

        If m_Alfa < 0 Then
            m_Alfa = m_Alfa + 360
        End If

        '

        Dim maxDX As Integer = Bounds.Width \ 2
        Dim maxDY As Integer = Bounds.Height \ 2

        For i As Integer = 0 To m_arFO.Count - 1
            Dim f As FlyingObject = m_arFO(i)

            Dim rc As Rectangle

            Dim newWidth As Integer = 0
            Dim newHeight As Integer = 0

            If newWidth * f.m_bmpFLyingBitmap.Height \ f.m_bmpFLyingBitmap.Width > maxDY Then
                newWidth = maxDX
                newHeight = newWidth * f.m_bmpFLyingBitmap.Height \ f.m_bmpFLyingBitmap.Width
            Else
                newHeight = maxDY
                newWidth = newHeight * f.m_bmpFLyingBitmap.Width \ f.m_bmpFLyingBitmap.Height
            End If

            rc = New Rectangle(Bounds.Width \ 2 - newWidth \ 2, Bounds.Height \ 2 - newHeight \ 2, newWidth, newHeight)

            Select Case f.m_nFBState
                Case 0
                    If True Then
                        f.m_rcFB = New Rectangle(f.m_rcFBStart.X + (rc.X - f.m_rcFBStart.X) * f.m_nFBPerc \ 100, f.m_rcFBStart.Y + (rc.Y - f.m_rcFBStart.Y) * f.m_nFBPerc \ 100, f.m_rcFBStart.Width + (rc.Width - f.m_rcFBStart.Width) * f.m_nFBPerc \ 100, f.m_rcFBStart.Height + (rc.Height - f.m_rcFBStart.Height) * f.m_nFBPerc \ 100)

                        f.m_nFBPerc += 5

                        If f.m_nFBPerc > 100 Then
                            f.m_nFBPerc = 100
                            f.m_nFBState = 0
                        End If
                    End If
                    Exit Select
                Case 1
                    Exit Select
                Case 2
                    If True Then
                        f.m_rcFB = New Rectangle(f.m_rcFB.X + (f.m_tRef.m_Rect.X - f.m_rcFB.X) * (100 - f.m_nFBPerc) \ 100, f.m_rcFB.Y + (f.m_tRef.m_Rect.Y - f.m_rcFB.Y) * (100 - f.m_nFBPerc) \ 100, f.m_rcFB.Width + (f.m_tRef.m_Rect.Width - f.m_rcFB.Width) * (100 - f.m_nFBPerc) \ 100, f.m_rcFB.Height + (f.m_tRef.m_Rect.Height - f.m_rcFB.Height) * (100 - f.m_nFBPerc) \ 100)

                        f.m_nFBPerc -= 5

                        If f.m_nFBPerc < 0 Then
                            m_arFO.RemoveAt(i)
                            i -= 1
                        End If
                    End If
                    Exit Select
            End Select
        Next

        Refresh()
    End Sub
    Private Sub LoadThumbs()
        Dim arStrings As [String]() = Directory.GetFiles(System.Environment.CurrentDirectory & "\Clipart")

        Dim pb As New FormProgress()
        pb.Show()

        For i As Integer = 0 To arStrings.Length - 1
            If Not arStrings(i).EndsWith("db") Then
                pb.progressBar1.Value = (i + 1) * 100 \ arStrings.Length
                pb.Refresh()
                m_arImages.Add(New ThumbElement(arStrings(i)))

            End If
        Next

        pb.Visible = False

        pb.Dispose()

        pb = Nothing

        For i As Integer = 0 To m_arImages.Count - 1
            m_arImages(i).m_dAngleOriginal = CSng(i) * (360.0F) / CSng(m_arImages.Count)
        Next
    End Sub
    Protected Overloads Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim c As Color = Color.FromArgb(255, 0, 0, 0)
        e.Graphics.FillRectangle(New SolidBrush(c), 0, 0, Width, Height)

        ' disegno
        Dim x0 As Integer = Width \ 2
        Dim y0 As Integer = Height \ 2

        Dim nRadX As Integer = (Width \ 2) * 7 \ 10
        Dim nRadY As Integer = CInt(Math.Truncate(nRadX / m_Perspective))

        ' calcolo i rettangoli
        For i As Integer = 0 To m_arImages.Count - 1
            Dim t As ThumbElement = m_arImages(i)

            ' angle and distance from screen
            m_arImages(i).m_dAngleActual = (m_arImages(i).m_dAngleOriginal + m_Alfa) * PI_FACT

            m_arImages(i).m_dDistanceFromScreen = 10 + 10 * Math.Cos(m_arImages(i).m_dAngleActual)

            ' rectangles
            Dim x As Integer = x0 + CInt(Math.Truncate(nRadX * Math.Sin(t.m_dAngleActual)))
            Dim y As Integer = y0 - CInt(Math.Truncate(nRadY * Math.Cos(t.m_dAngleActual)))

            Dim dSize As Single = CSng(80 - 20 * Math.Cos(t.m_dAngleActual))

            dSize = dSize / 100

            t.m_Rect.X = CInt(Math.Truncate(x - (t.m_bmpMain.Width * dSize) / 2))
            t.m_Rect.Y = CInt(Math.Truncate(y - (t.m_bmpMain.Height * dSize)))
            t.m_Rect.Width = CInt(Math.Truncate(t.m_bmpMain.Width * dSize))
            t.m_Rect.Height = CInt(Math.Truncate(t.m_bmpMain.Height * dSize))

            t.m_RectShadow.X = CInt(Math.Truncate(x - (t.m_bmpMain.Width * dSize) / 2))
            t.m_RectShadow.Y = CInt(y)
            t.m_RectShadow.Width = CInt(Math.Truncate(t.m_bmpMain.Width * dSize))
            t.m_RectShadow.Height = CInt(Math.Truncate(t.m_bmpMain.Height * dSize))
        Next

        ' ordino
        m_arImages.Sort(Function(p1 As ThumbElement, p2 As ThumbElement) p2.m_dDistanceFromScreen.CompareTo(p1.m_dDistanceFromScreen))

        ' ricerca della foto sotto al cursore
        Dim nIndex As Integer = -1

        Dim ptClient As Point = PointToClient(MousePosition)

        Dim i As Integer = m_arImages.Count - 1
        While i >= 0 AndAlso nIndex = -1
            Dim t As ThumbElement = m_arImages(i)

            If t.m_Rect.Contains(ptClient) Then
                nIndex = i
            End If
            i -= 1
        End While
        m_Selected = Nothing

        If nIndex <> -1 Then
            m_Selected = m_arImages(nIndex)
        End If

        For i As Integer = 0 To m_arImages.Count - 1
            Dim t As ThumbElement = m_arImages(i)

            Dim dTrasp As Single = CSng(100 + 100 * Math.Cos(t.m_dAngleActual))

            e.Graphics.DrawImage(t.m_bmpMain, t.m_Rect)
            e.Graphics.DrawImage(t.m_bmpShadow, t.m_RectShadow)

            If nIndex <> i Then
                Dim sb As New SolidBrush(Color.FromArgb(CInt(Math.Truncate(dTrasp)), c.R, c.G, c.B))
                e.Graphics.FillRectangle(sb, t.m_Rect)
                e.Graphics.FillRectangle(sb, t.m_RectShadow)
            End If

            If nIndex = i Then
                e.Graphics.DrawRectangle(Pens.White, t.m_Rect)
            End If
        Next

        For i As Integer = 0 To m_arFO.Count - 1
            Dim f As FlyingObject = m_arFO(i)

            Dim ptsArray As Single()() = {New Single() {1, 0, 0, 0, 0}, New Single() {0, 1, 0, 0, 0}, New Single() {0, 0, 1, 0, 0}, New Single() {0, 0, 0, f.m_nFBPerc / 100.0F, 0}, New Single() {0, 0, 0, 0, 1}}
            Dim clrMatrix As New ColorMatrix(ptsArray)
            Dim imgAttributes As New ImageAttributes()
            imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.[Default], ColorAdjustType.Bitmap)

            e.Graphics.DrawImage(f.m_bmpFLyingBitmap, f.m_rcFB, 0, 0, f.m_bmpFLyingBitmap.Width, f.m_bmpFLyingBitmap.Height, _
             GraphicsUnit.Pixel, imgAttributes)
        Next
    End Sub

    Private Sub CustomThumbNail_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        Dim x0 As Integer = Width \ 2
        Dim y0 As Integer = Height \ 2

        m_AlfaAccel = (CSng(e.X - x0) * 3.0F) / CSng(x0)

        If (e.Button And MouseButtons.Right) = MouseButtons.Right Then
            m_Perspective = 12 - (CSng(-e.Y + y0) * 10.0F) / CSng(y0)
        End If

    End Sub

    Private Sub CustomThumbNail_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub CustomThumbNail_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If (e.Button And MouseButtons.Left) = MouseButtons.Left Then
            For i As Integer = 0 To m_arFO.Count - 1
                Dim f As FlyingObject = m_arFO(i)

                If f.m_nFBState <> 2 Then
                    f.m_nFBState = 2
                End If
            Next

            If m_Selected IsNot Nothing Then
                Dim f As New FlyingObject()

                f.m_tRef = m_Selected
                f.m_bmpFLyingBitmap = New Bitmap(m_Selected.m_bmpMain)
                f.m_rcFBStart = m_Selected.m_Rect
                f.m_nFBState = 0
                f.m_nFBPerc = 0

                m_arFO.Add(f)
            End If
        End If
    End Sub
    Class ThumbElement
        Public Shared m_ThumbSize As Integer = 200

        Public m_bmpOriginal As Bitmap = Nothing

        Public m_bmpMain As Bitmap = Nothing
        Public m_bmpShadow As Bitmap = Nothing

        Public m_dAngleOriginal As Double = 0
        Public m_dAngleActual As Double = 0

        Public m_dDistanceFromScreen As Double = 0

        Public m_Rect As New Rectangle()
        Public m_RectShadow As New Rectangle()

        Public Sub New(ByVal strFileName As [String])
            m_bmpOriginal = New Bitmap(strFileName)

            Dim nWidth As Integer = m_ThumbSize
            Dim nHeight As Integer = m_bmpOriginal.Height * m_ThumbSize \ m_bmpOriginal.Width

            If nHeight > m_ThumbSize Then
                nHeight = m_ThumbSize
                nWidth = m_bmpOriginal.Width * m_ThumbSize \ m_bmpOriginal.Height
            End If

            m_bmpMain = New Bitmap(nWidth, nHeight)

            Dim g As Graphics = Graphics.FromImage(m_bmpMain)

            g.DrawImage(m_bmpOriginal, 0, 0, nWidth, nHeight)

            m_bmpShadow = New Bitmap(m_bmpMain)

            m_bmpShadow.RotateFlip(RotateFlipType.RotateNoneFlipY)

            Dim bmd As System.Drawing.Imaging.BitmapData = m_bmpShadow.LockBits(New Rectangle(0, 0, m_bmpShadow.Width, m_bmpShadow.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, m_bmpShadow.PixelFormat)

            Dim PixelSize As Integer = 4

            Dim row As Pointer(Of Byte) = CType(bmd.Scan0, Pointer(Of Byte))

            For y As Integer = 0 To bmd.Height - 1
                Dim trasp As Byte = CByte(100 * ((m_bmpMain.Height - y)) \ m_bmpMain.Height)

                Dim xx As Integer = 3

                For x As Integer = 0 To bmd.Width - 1
                    row(xx) = trasp

                    xx += PixelSize
                Next

                row += bmd.Stride
            Next


            '
            '            for (int x = 0; x < m_bmpMain.Width; x++)
            '            {
            '                for (int y = 0; y < m_bmpMain.Height; y++)
            '                {
            '                    double trasp = 100 * ((double)y) / ((double)m_bmpMain.Height);
            '
            '                    Color p = m_bmpMain.GetPixel(x, y);
            '
            '                    m_bmpShadow.SetPixel(x, m_bmpShadow.Height - y - 1, Color.FromArgb((int)(trasp), p));
            '                }
            '            }
            '            

            m_bmpShadow.UnlockBits(bmd)
        End Sub
    End Class
End Class
