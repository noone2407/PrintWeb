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
        public void SaveUrlToPdf(string url, string file)
        {
            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32(TxtWidth.Value.ToString(CultureInfo.InvariantCulture));
            }
            catch { }

            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32(TxtHeight.Value.ToString(CultureInfo.InvariantCulture));
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            converter.Options.MarginTop = Convert.ToInt32(numericUpDownTop.Value.ToString(CultureInfo.InvariantCulture));
            converter.Options.MarginBottom = Convert.ToInt32(numericUpDownBottom.Value.ToString(CultureInfo.InvariantCulture));
            converter.Options.MarginLeft = Convert.ToInt32(numericUpDownLeft.Value.ToString(CultureInfo.InvariantCulture));
            converter.Options.MarginRight = Convert.ToInt32(numericUpDownRight.Value.ToString(CultureInfo.InvariantCulture));


            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);

            // save pdf document
            doc.Save(file);

            // close pdf document
            doc.Close();
        }
        public void SaveHtmlToPdf(string file)
        {
            var open = new OpenFileDialog();
            open.Filter = "html file |*.html";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string html = File.ReadAllText(open.FileName);
                string directoryName = Path.GetDirectoryName(open.FileName);
                if (!string.IsNullOrEmpty(directoryName) && !directoryName.EndsWith(@"\"))
                {
                    directoryName += @"\";
                }
                string pdf_page_size = DdlPageSize.Text;
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize),
                    pdf_page_size, true);

                string pdf_orientation = DdlPageOrientation.Text;
                PdfPageOrientation pdfOrientation =
                    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation),
                    pdf_orientation, true);

                int webPageWidth = 1024;
                try
                {
                    webPageWidth = Convert.ToInt32(TxtWidth.Value.ToString(CultureInfo.InvariantCulture));
                }
                catch { }

                int webPageHeight = 0;
                try
                {
                    webPageHeight = Convert.ToInt32(TxtHeight.Value.ToString(CultureInfo.InvariantCulture));
                }
                catch { }

                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // set converter options
                converter.Options.PdfPageSize = pageSize;
                converter.Options.PdfPageOrientation = pdfOrientation;
                converter.Options.WebPageWidth = webPageWidth;
                converter.Options.WebPageHeight = webPageHeight;

                converter.Options.MarginTop = Convert.ToInt32(numericUpDownTop.Value.ToString(CultureInfo.InvariantCulture));
                converter.Options.MarginBottom = Convert.ToInt32(numericUpDownBottom.Value.ToString(CultureInfo.InvariantCulture));
                converter.Options.MarginLeft = Convert.ToInt32(numericUpDownLeft.Value.ToString(CultureInfo.InvariantCulture));
                converter.Options.MarginRight = Convert.ToInt32(numericUpDownRight.Value.ToString(CultureInfo.InvariantCulture));

                // create a new pdf document converting an url
                PdfDocument doc = converter.ConvertHtmlString(html, directoryName);

                // save pdf document
                doc.Save(file);

                // close pdf document
                doc.Close();

            }
        }
    }
}
