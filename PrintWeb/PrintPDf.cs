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
        public void PrintSettingAllOptions(string printer, string file)
        {
            PrintJob printJob = new PrintJob(printer, file);
            printJob.PrintOptions.Color = true;
            printJob.PrintOptions.Scaling = new AutoPageScaling();
            printJob.Print();
        }

    }
}
