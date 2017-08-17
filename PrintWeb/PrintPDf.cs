using System.Collections.Generic;
using System.Text;
using Foxit.PDF.Printing;

namespace PrintWeb
{
    public class PrintPDf
    {
        public PrintPDf()
        {
            AddKey();
        }
        private void AddKey()
        {
            StringBuilder key = new StringBuilder(100);
            key.Append("FPM");
            key.Append("99"); // version
            key.Append("N");
            key.Append("E");
            key.Append("S"); // server key
            key.Append("RANDOM");  // 6 dummy charactors

            StringBuilder code = new StringBuilder(86);
            for (int i = 0; i < 86; i++)
            {
                code.Append("A");
            }

            key.Append(code);

            string licenseKey = key.ToString();
            bool valid = PrintJob.AddLicense(licenseKey);

        }

        public List<string> GetPaper(string printer)
        {
            var result = new List<string>();
            PrintJob printJob = new PrintJob(printer);
            foreach (var size in printJob.Printer.PaperSizes)
            {
                if (size != null)
                    result.Add(size.Name);
            }
            return result;
        }
        public void PrintSettingAllOptions(string file, string printer, string papersize)
        {
            PrintJob printJob = new PrintJob(printer, file);
            printJob.DocumentName = "A4";
            if (printJob.Printer.Color)
                printJob.PrintOptions.Color = true;
            if (printJob.Printer.Collate)
                printJob.PrintOptions.Collate = true;
            if (printJob.Printer.Duplex)
                printJob.PrintOptions.DuplexMode = DuplexMode.DuplexHorizontal;
            printJob.PrintOptions.Copies = 1;
            printJob.PrintOptions.HorizontalAlign = HorizontalAlign.Left;
            printJob.PrintOptions.Orientation.Type = OrientationType.Portrait;
            var paper = printJob.Printer.PaperSizes[papersize];
            printJob.PrintOptions.PaperSize = paper;
            printJob.PrintOptions.PrintAnnotations = false;
            printJob.PrintOptions.Resolution = printJob.Printer.Resolutions[0];
            printJob.PrintOptions.VerticalAlign = VerticalAlign.Top;
            printJob.PrintOptions.Scaling = new AutoPageScaling();
            printJob.Print();
        }

    }
}
