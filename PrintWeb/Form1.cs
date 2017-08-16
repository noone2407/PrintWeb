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

            string file = Path.Combine(Application.StartupPath, "Sample.pdf");
            string url = TxtUrl.Text;
            createPdf.SaveUrlToPdf(url, file);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), DdlPageSize.Text, true);
            PdfPageOrientation pdfOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), DdlPageOrientation.Text, true);
            var createPdf = new CreatePdf(pageSize, pdfOrientation);

            string file = Path.Combine(Application.StartupPath, "Sample.pdf");
            string html = TxtUrl.Text;
            createPdf.SaveHtmlToPdf(file);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(Application.StartupPath, "Sample.pdf");
            OpenPdfAcrobat(file);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(Application.StartupPath, "Sample.pdf");
            for (int i = 0; i < (int)numericUpDownCopy.Value; i++)
            {
                PrinteAcrobat(file, DdlPrinter.Text);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(Application.StartupPath, "Sample.pdf");
            OpenPdfFoxit(file);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string file = Path.Combine(Application.StartupPath, "Sample.pdf");
            for (int i = 0; i < (int)numericUpDownCopy.Value; i++)
            {
                PrinteFoxit(file, DdlPrinter.Text);
            }
        }

        private void OpenPdfAcrobat(string fileName)
        {
            var gsProcessInfo = new ProcessStartInfo();
            gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            gsProcessInfo.FileName = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe";
            gsProcessInfo.Arguments = fileName;
            var proc = new Process();
            proc.StartInfo = gsProcessInfo;
            proc.Start();
            proc.WaitForExit();
        }
        private void OpenPdfFoxit(string fileName)
        {
            var gsProcessInfo = new ProcessStartInfo();
            gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            gsProcessInfo.FileName = @"C:\Program Files (x86)\Foxit Software\Foxit Reader\Foxit Reader.exe";
            gsProcessInfo.Arguments = fileName;
            var proc = new Process();
            proc.StartInfo = gsProcessInfo;
            proc.Start();
            proc.WaitForExit();
        }
        private void PrinteAcrobat(string fileName, string printerName)
        {
            var gsProcessInfo = new ProcessStartInfo();
            gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            gsProcessInfo.FileName = @"C:\Program Files (x86)\Adobe\Acrobat Reader DC\Reader\AcroRd32.exe";
            gsProcessInfo.Arguments = string.Format("/n /s /h /t {0} \"{1}\"", fileName, printerName);
            gsProcessInfo.CreateNoWindow = true;
            gsProcessInfo.UseShellExecute = false;
            var proc = new Process();
            proc.StartInfo = gsProcessInfo;
            proc.Start();
            proc.WaitForExit();
        }
        private void PrinteFoxit(string fileName, string printerName)
        {
            var gsProcessInfo = new ProcessStartInfo();
            gsProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            gsProcessInfo.FileName = @"C:\Program Files (x86)\Foxit Software\Foxit Reader\Foxit Reader.exe";
            gsProcessInfo.Arguments = string.Format("/t \"{0}\" \"{1}\"", fileName, printerName);
            gsProcessInfo.CreateNoWindow = true;
            gsProcessInfo.UseShellExecute = false;
            var proc = new Process();
            proc.StartInfo = gsProcessInfo;
            proc.Start();
            proc.WaitForExit();
        }


    }
}
