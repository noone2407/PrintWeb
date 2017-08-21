using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SelectPdf;

namespace PrintWeb
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void buttonPrintWeb_Click(object sender, EventArgs e)
        {
            string url = TxtUrl.Text;
            var parseHtml = new ParseHtml();
            parseHtml.LoadUrl(url);
            var setting = parseHtml.ParseSetting();
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), setting.PageSize, true);
            PdfPageOrientation pdfOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), setting.PageOrientation, true);

            var createPdf = new CreatePdf(pageSize, pdfOrientation);
            string saveTo = Path.Combine(Application.StartupPath, "PrintWeb.pdf");
            createPdf.SaveUrlToPdf(url, saveTo, setting.WebPageWidth, setting.WebPageHeight, setting.MargineTop, setting.MargineLeft, setting.MargineRight, setting.MargineBottom);
            var printer = new PrintPDf();
            for (int i = 0; i < setting.NumberOfCopy; i++)
            {
                printer.PrintSettingAllOptions(saveTo, setting.PrinterName, setting.PaperSize);
            }

        }

        private void buttonPrintFile_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.Filter = "html file |*.html";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string file = open.FileName;
                var parseHtml = new ParseHtml();
                parseHtml.LoadUrl(file);
                var setting = parseHtml.ParseSetting();
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), setting.PageSize, true);
                PdfPageOrientation pdfOrientation =
                    (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), setting.PageOrientation, true);

                var createPdf = new CreatePdf(pageSize, pdfOrientation);
                string saveTo = Path.Combine(Application.StartupPath, "PrintFile.pdf");
                createPdf.SaveHtmlToPdf(file, saveTo, setting.WebPageWidth, setting.WebPageHeight, setting.MargineTop,
                    setting.MargineLeft, setting.MargineRight, setting.MargineBottom);
                var printer = new PrintPDf();
                for (int i = 0; i < setting.NumberOfCopy; i++)
                {
                    printer.PrintSettingAllOptions(saveTo, setting.PrinterName, setting.PaperSize);
                }
            }
        }
    }
}
