using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SelectPdf;

namespace PrintWeb
{
    public class CreatePdf
    {
        private PdfPageSize _pdfPageSize;
        private PdfPageOrientation _pdfOrientation;
        public CreatePdf(PdfPageSize pdfPageSize, PdfPageOrientation pdfOrientation)
        {
            _pdfPageSize = pdfPageSize;
            _pdfOrientation = pdfOrientation;
        }
        public void SaveUrlToPdf(string url, string saveTo, int webPageWidth, int webPageHeight, int marginTop, int margineLeft, int margineRight, int marrgineBottom)
        {



            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = _pdfPageSize;
            converter.Options.PdfPageOrientation = _pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            converter.Options.MarginTop = marginTop;
            converter.Options.MarginLeft = margineLeft;
            converter.Options.MarginRight = margineRight;
            converter.Options.MarginBottom = marrgineBottom;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);

            // save pdf document
            doc.Save(saveTo);

            // close pdf document
            doc.Close();
        }
        public void SaveHtmlToPdf(string htmlFile, string saveTo, int webPageWidth, int webPageHeight, int marginTop, int margineLeft, int margineRight, int marrgineBottom)
        {
            string html = File.ReadAllText(htmlFile);
            string directoryName = Path.GetDirectoryName(htmlFile);
            if (!string.IsNullOrEmpty(directoryName) && !directoryName.EndsWith(@"\"))
            {
                directoryName += @"\";
            }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = _pdfPageSize;
            converter.Options.PdfPageOrientation = _pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            converter.Options.MarginTop = marginTop;
            converter.Options.MarginBottom = marrgineBottom;
            converter.Options.MarginLeft = margineLeft;
            converter.Options.MarginRight = margineRight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(html, directoryName);

            // save pdf document
            doc.Save(saveTo);

            // close pdf document
            doc.Close();

        }
    }
}
