using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace PrintWeb
{
    public class ParseHtml
    {
        private readonly HtmlDocument _document;
        public ParseHtml()
        {
            _document = new HtmlDocument();
        }

        public void LoadUrl(string url)
        {
            var wc = new WebClient();
            string html = wc.DownloadString(url);
            _document.LoadHtml(html);
        }

        public void LoadFile(string path)
        {
            string html = File.ReadAllText(path);
            _document.LoadHtml(html);
        }
        public void LoadHtml(string html)
        {
            _document.LoadHtml(html);
        }

        public PdfSetting ParseSetting()
        {
            var setting = new PdfSetting();
            var pageSize = _document.DocumentNode.SelectSingleNode("//meta[@name='PageSize']");
            if (pageSize != null)
                setting.PageSize = pageSize.GetAttributeValue("content", "");

            var pageOrientation = _document.DocumentNode.SelectSingleNode("//meta[@name='PageOrientation']");
            if (pageOrientation != null)
                setting.PageOrientation = pageOrientation.GetAttributeValue("content", "");

            var webPageWidth = _document.DocumentNode.SelectSingleNode("//meta[@name='WebPageWidth']");
            if (webPageWidth != null)
                setting.WebPageWidth = int.Parse(webPageWidth.GetAttributeValue("content", ""));

            var webPageHeight = _document.DocumentNode.SelectSingleNode("//meta[@name='WebPageHeight']");
            if (webPageHeight != null)
                setting.WebPageHeight = int.Parse(webPageHeight.GetAttributeValue("content", ""));

            var margineTop = _document.DocumentNode.SelectSingleNode("//meta[@name='MargineTop']");
            if (margineTop != null)
                setting.MargineTop = int.Parse(margineTop.GetAttributeValue("content", ""));

            var margineLeft = _document.DocumentNode.SelectSingleNode("//meta[@name='MargineLeft']");
            if (margineLeft != null)
                setting.MargineLeft = int.Parse(margineLeft.GetAttributeValue("content", ""));

            var margineRight = _document.DocumentNode.SelectSingleNode("//meta[@name='MargineRight']");
            if (margineRight != null)
                setting.MargineRight = int.Parse(margineRight.GetAttributeValue("content", ""));

            var margineBottom = _document.DocumentNode.SelectSingleNode("//meta[@name='MargineBottom']");
            if (margineBottom != null)
                setting.WebPageWidth = int.Parse(margineBottom.GetAttributeValue("content", ""));


            var printerName = _document.DocumentNode.SelectSingleNode("//meta[@name='PrinterName']");
            if (printerName != null)
                setting.PrinterName = printerName.GetAttributeValue("content", "");

            var paperSize = _document.DocumentNode.SelectSingleNode("//meta[@name='PaperSize']");
            if (paperSize != null)
                setting.PaperSize = paperSize.GetAttributeValue("content", "");

            var numberOfCopy = _document.DocumentNode.SelectSingleNode("//meta[@name='NumberOfCopy']");
            if (numberOfCopy != null)
                setting.NumberOfCopy = int.Parse(numberOfCopy.GetAttributeValue("content", ""));

            return setting;
        }
    }

    public class PdfSetting
    {
        public string PageSize;
        public string PageOrientation;
        public int WebPageWidth;
        public int WebPageHeight;
        public int MargineTop;
        public int MargineLeft;
        public int MargineRight;
        public int MargineBottom;

        public string PrinterName;
        public string PaperSize;
        public int NumberOfCopy;

        public PdfSetting()
        {
            PageSize = "A4";
            PageOrientation = "Portrait";
            WebPageWidth = 600;
            WebPageHeight = 800;
            MargineTop = 0;
            MargineLeft = 0;
            MargineRight = 0;
            MargineBottom = 0;
            PrinterName = "";
            PaperSize = "A4";
            NumberOfCopy = 1;
        }
    }
}
