using System;
using System.Collections.Generic;
using System.Text;

namespace IMDEV.gestionOffice
{
    public class documentExcel
    {
        private Microsoft.Office.Interop.Excel.Application _ExcelProcess;
        private Microsoft.Office.Interop.Excel.Workbook _ExcelDoc;
        private Microsoft.Office.Interop.Excel.Worksheet _ExcelFeuille;

        private string _nomencours;

        public void CreerDoc(string nom, string nomfeuille1)
        {
            _ExcelProcess = new Microsoft.Office.Interop.Excel.Application();
	        _ExcelProcess.Visible = false;
	        _ExcelDoc = _ExcelProcess.Workbooks.Add(null);
            _ExcelFeuille = (Microsoft.Office.Interop.Excel.Worksheet)_ExcelDoc.ActiveSheet;
	        _ExcelFeuille.Name = nomfeuille1;
            ((Microsoft.Office.Interop.Excel.Worksheet)(_ExcelDoc.Worksheets["Feuil2"])).Delete();
            ((Microsoft.Office.Interop.Excel.Worksheet)(_ExcelDoc.Worksheets["Feuil3"])).Delete();
	        _nomencours = nom;
        }

        public void OuvrirDoc(string nom)
        {
            if (_ExcelProcess == null)
            {
                _ExcelProcess = new Microsoft.Office.Interop.Excel.Application();
                _ExcelProcess.Visible = true;
            }
	        try
            {
                ((Microsoft.Office.Interop.Excel.Workbook)(_ExcelProcess.Workbooks[0])).Close(null, null, null);
	        }
            catch {}
            _ExcelDoc = _ExcelProcess.Workbooks.Open(nom, null, false, null, null, null, false, null, null, true, true, null, false, false, null);
            _ExcelFeuille = (Microsoft.Office.Interop.Excel.Worksheet)_ExcelDoc.ActiveSheet;
        }

        public void EcrireCellule(object texte, int ligne, int colonne)
        {
	        _ExcelFeuille.Cells[ligne, colonne] = texte;
        }

        public object LireCellule(int ligne, int colonne)
        {
            // TODO .value ?
	        return _ExcelFeuille.Cells[ligne, colonne];
        }

        public void MiseEnGrasCellule(int ligne, int colonne, bool gras)
        {
            ((Microsoft.Office.Interop.Excel.Range)(_ExcelFeuille.Cells[ligne, colonne])).Font.Bold = gras;
        }

        public void SelectionFeuille(string nom)
        {
            ((Microsoft.Office.Interop.Excel.Worksheet)(_ExcelDoc.Worksheets[nom])).Select(null);
            _ExcelFeuille = (Microsoft.Office.Interop.Excel.Worksheet)_ExcelDoc.ActiveSheet;
        }

        public void CreerFeuille(string nom)
        {
            Microsoft.Office.Interop.Excel.Worksheet after;
            after = (Microsoft.Office.Interop.Excel.Worksheet)_ExcelDoc.ActiveSheet;
	        _ExcelDoc.Worksheets.Add(null, after,null,null);
            _ExcelFeuille = (Microsoft.Office.Interop.Excel.Worksheet)_ExcelDoc.ActiveSheet;
	        _ExcelFeuille.Name = nom;
        }

        public bool SauvegardeSous(bool EcraserSiExiste)
        {
	        if (System.IO.File.Exists(_nomencours))
            {
		        if (EcraserSiExiste)
                {
			        System.IO.File.Delete(_nomencours);
                    _ExcelDoc.SaveAs(_nomencours, null, null, null, null, null, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
			        return true;
		        }
                else
			        return false;
	        }
            else
            {
                _ExcelDoc.SaveAs(_nomencours, null, null, null, null, null, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, null, null, null, null, null);
                return true;
	        }
        }

        public void SauveCourant()
        {
	        _ExcelDoc.Save();
        }

        public void FermerAppli()
        {
	        _ExcelFeuille = null;
	        _ExcelDoc.Close(null,null,null);
	        _ExcelDoc = null;
	        _ExcelProcess.Quit();
	        System.Runtime.InteropServices.Marshal.ReleaseComObject(_ExcelProcess);
	        _ExcelProcess = null;
        }

        public void EffacerFeuille(string nom)
        {
	        try
            {
                ((Microsoft.Office.Interop.Excel.Worksheet)(_ExcelDoc.Worksheets[nom])).Delete();
	        }
            catch {}
        }

        public string RetourneFeuilleActive()
        {
            return ((Microsoft.Office.Interop.Excel.Worksheet)(_ExcelDoc.ActiveSheet)).Name;
        }

        public void AutoFitColonne(int numcolonne)
        {
	        // Pourquoi un try ?
	        // Parce que pour une raison inconnue ca ne marche pas la premiere fois seulement
	        // Il applique bien les modif (autofit) mais déclenche quand meme une exception, juste a la premiere utilisation de cette fonction
            // Bug Microsoft
	        try
            {
                ((Microsoft.Office.Interop.Excel.Range)(_ExcelFeuille.Cells[1, numcolonne])).CurrentRegion.EntireColumn.AutoFit();
	        }
            catch {}
        }

        public void Bordure(int lignedebut, int colonnedebut, int lignefin, int colonnefin)
        {
            // TODO : Borders est une propriété d'un type déclaré Interface
/*            if ((lignefin < 0) && (colonnefin < 0))
                ((Excel.Range)(_ExcelFeuille.Cells[lignedebut, colonnedebut])).Borders = Excel.Borders;*/
        }

        public void CentrerSurPlusieursColonne(int ligne, int colonnedebut, int colonnefin)
        {
            // TODO : .Range n'existe pas
	        //_ExcelFeuille.Range(_ExcelFeuille.Cells(ligne, colonnedebut), _ExcelFeuille.Cells(ligne, colonnefin)).HorizontalAlignment = 7;
        }

        public void MiseEnItaliqueCellule(int ligne, int colonne, bool italique)
        {
            ((Microsoft.Office.Interop.Excel.Range)(_ExcelFeuille.Cells[ligne, colonne])).Font.Italic = italique;
        }

        public void HauteurLignes(double nouvelle_hauteur)
        {
            _ExcelFeuille.Rows.RowHeight = nouvelle_hauteur;
        }

        public void LargeurColonnes(double nouvelle_largeur)
        {
	        _ExcelFeuille.Columns.ColumnWidth = nouvelle_largeur;
        }

        public void EcrireCouleur(int ligne, int colonne, int couleur)
        {
            ((Microsoft.Office.Interop.Excel.Range)(_ExcelFeuille.Cells[ligne, colonne])).Font.Color = couleur;
        }

        public string RetourneNomFeuille(int position)
        {
            return ((Microsoft.Office.Interop.Excel.Worksheet)(_ExcelDoc.Worksheets[position])).Name;
        }

        public void CelluleFormatTexte(int ligne, int colonne)
        {
            ((Microsoft.Office.Interop.Excel.Range)(_ExcelFeuille.Cells[ligne, colonne])).NumberFormat = "@";
        }

        public int NbLignes()
        {
            return _ExcelFeuille.Rows.SpecialCells(Microsoft.Office.Interop.Excel.XlCellType.xlCellTypeLastCell, null).Row;
        }
    }
}
