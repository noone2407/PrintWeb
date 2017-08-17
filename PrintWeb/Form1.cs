using System;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using SelectPdf;

namespace PrintWeb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                DdlPrinter.Items.Add(printer);
            }
            if (DdlPrinter.Items.Count > 0)
                DdlPrinter.SelectedIndex = 0;
            DdlPageSize.SelectedIndex = 3;
            DdlPageOrientation.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), DdlPageSize.Text, true);
            PdfPageOrientation pdfOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), DdlPageOrientation.Text, true);

            var createPdf = new CreatePdf(pageSize, pdfOrientation);
            string saveTo = Path.Combine(Application.StartupPath, "Sample.pdf");
            string url = TxtUrl.Text;
            int webPageWidth = (int)TxtWidth.Value;
            int webPageHeight = (int)TxtHeight.Value;
            int margineTop = (int)numericUpDownTop.Value;
            int margineLeft = (int)numericUpDownLeft.Value;
            int margineRight = (int)numericUpDownRight.Value;
            int margineBottom = (int)numericUpDownBottom.Value;
            createPdf.SaveUrlToPdf(url, saveTo, webPageWidth, webPageHeight, margineTop, margineLeft, margineRight, margineBottom);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.Filter = "html file |*.html";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string htmlFile = open.FileName;
                PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), DdlPageSize.Text, true);
                PdfPageOrientation pdfOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), DdlPageOrientation.Text, true);

                var createPdf = new CreatePdf(pageSize, pdfOrientation);
                string saveTo = Path.Combine(Application.StartupPath, "Sample.pdf");
                int webPageWidth = (int)TxtWidth.Value;
                int webPageHeight = (int)TxtHeight.Value;
                int margineTop = (int)numericUpDownTop.Value;
                int margineLeft = (int)numericUpDownLeft.Value;
                int margineRight = (int)numericUpDownRight.Value;
                int margineBottom = (int)numericUpDownBottom.Value;
                createPdf.SaveHtmlToPdf(htmlFile, saveTo, webPageWidth, webPageHeight, margineTop, margineLeft, margineRight, margineBottom);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var print = new PrintPDf();
            string file = Path.Combine(Application.StartupPath, "Sample.pdf");
            for (int i = 0; i < (int)numericUpDownCopy.Value; i++)
            {
                print.PrintSettingAllOptions(DdlPrinter.Text, file);
            }
        }
    }
}
