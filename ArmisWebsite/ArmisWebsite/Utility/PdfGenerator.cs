using Armis.BusinessModels.QualityModels.Process;
using ArmisWebsite.Utility.Interfaces;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ArmisWebsite.Utility
{
    public class PdfGenerator : IPdfGenerator
    {
        private readonly IConfiguration Config;

        public PdfGenerator(IConfiguration aConfig)
        {
            Config = aConfig;
        }

        public string GenerateRouterPdf(ProcessModel aProcessModel, ProcessRevisionModel aRevisionModel)
        {
            var theRouterName = Regex.Replace(aProcessModel.Name, @"[^\w\.@-]", "", RegexOptions.None);
            var thePath = Config["PdfRouterFileLocation"] + aProcessModel.ProcessId + "-" + aRevisionModel.ProcessRevId + "-" + theRouterName + ".pdf";

            if (!File.Exists(thePath))
            {
                FileStream fileStream = new FileStream(thePath, FileMode.Create, FileAccess.Write);
                Document pdfDoc = new Document(PageSize.Letter, 24, 24, 112, 50);
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, fileStream);
                PageEventHelper pgEventHelper = new PageEventHelper();
                pgEventHelper.SetProcessModel(aProcessModel);
                pdfWriter.PageEvent = pgEventHelper;

                pdfDoc.Open();

                //Step Table
                var tableSteps = new PdfPTable(5);
                tableSteps.WidthPercentage = 100;
                tableSteps.SpacingBefore = 10f;
                float[] columnWidths = new float[] { 10f, 20f, 50f, 10f, 10f };
                tableSteps.SetWidths(columnWidths);
                tableSteps.HeaderRows = 1;

                //Title Cells
                tableSteps.AddCell("Seq");
                tableSteps.AddCell("Step Name");
                tableSteps.AddCell("Instructions");
                tableSteps.AddCell("Sign-Off");
                tableSteps.AddCell("Date");

                //Step cells
                foreach (var stepSeq in aRevisionModel.StepSeqs)
                {
                    var cellSeq = new PdfPCell(new Phrase(stepSeq.Sequence.ToString()));
                    cellSeq.Padding = 10;
                    cellSeq.PaddingTop = 6;
                    tableSteps.AddCell(cellSeq);

                    var cellName = new PdfPCell(new Phrase(stepSeq.Step.StepName));
                    cellName.Padding = 10;
                    cellName.PaddingTop = 6;
                    tableSteps.AddCell(cellName);

                    var cellInstructions = new PdfPCell(new Phrase(stepSeq.Step.Instructions));
                    cellInstructions.Padding = 10;
                    cellInstructions.PaddingTop = 6;
                    tableSteps.AddCell(cellInstructions);

                    var cellSignOff = new PdfPCell();
                    cellSignOff.Padding = 10;
                    cellSignOff.PaddingTop = 6;
                    tableSteps.AddCell(cellSignOff);

                    var cellSignOffDate = new PdfPCell();
                    cellSignOffDate.Padding = 10;
                    cellSignOffDate.PaddingTop = 6;
                    tableSteps.AddCell(cellSignOffDate);
                }

                pdfDoc.Add(tableSteps);

                pdfDoc.Close();

                fileStream.Close();
            }

            return thePath;
        }
    }

    public class PageEventHelper : PdfPageEventHelper
    {
        PdfContentByte pdfContentByte;
        PdfTemplate template;
        ProcessModel theProcessModel;

        public void SetProcessModel(ProcessModel aProcessModel)
        {
            theProcessModel = aProcessModel;
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            pdfContentByte = writer.DirectContent;
            template = pdfContentByte.CreateTemplate(50, 50);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            var font = new Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)) { Size = 12, Color = BaseColor.Black };

            int pageN = writer.PageNumber;
            string text = "Page " + pageN + " of ";
            float len = font.BaseFont.GetWidthPoint(text, font.Size);

            Rectangle pageSize = document.PageSize;

            pdfContentByte.SetRgbColorFill(100, 100, 100);

            pdfContentByte.BeginText();
            pdfContentByte.SetFontAndSize(font.BaseFont, font.Size);
            pdfContentByte.SetTextMatrix(pageSize.GetRight(document.RightMargin) - len, pageSize.GetBottom(document.BottomMargin / 2));
            pdfContentByte.ShowText(text);

            //Testing adding the header stuff
            //Generic Router Title
            text = "Process Router";
            len = font.BaseFont.GetWidthPoint(text, font.Size);
            pdfContentByte.SetTextMatrix(pageSize.GetLeft(document.LeftMargin), pageSize.GetTop(document.TopMargin / 2f));
            pdfContentByte.ShowText(text);

            //Process Name Title
            text = theProcessModel.Name;
            len = font.BaseFont.GetWidthPoint(text, font.Size);
            pdfContentByte.SetTextMatrix(pageSize.Width / 2 - (len / 2), pageSize.GetTop(document.TopMargin / 2f));
            pdfContentByte.ShowText(text);

            //Date
            text = DateTime.Now.ToString("MM/dd/yyyy");
            len = font.BaseFont.GetWidthPoint(text, font.Size);
            pdfContentByte.SetTextMatrix(pageSize.GetRight(document.RightMargin) - len, pageSize.GetTop(document.TopMargin / 2f));
            pdfContentByte.ShowText(text);

            pdfContentByte.EndText();

            //How this looks is "Page # of {template}" The template is then filled in when the document is closed with the total amount of pages in the document.
            pdfContentByte.AddTemplate(template, pageSize.GetRight(document.RightMargin), pageSize.GetBottom(document.BottomMargin / 2));
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            var font = new Font(BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)) { Size = 12, Color = BaseColor.Black };

            //Document is closed and the template in "Page # of {template}" is filled in with the total number of pages in the document. Comment at the end of OnPageEnd() for more information.
            template.BeginText();
            template.SetFontAndSize(font.BaseFont, font.Size);
            template.SetTextMatrix(0, 0);
            template.ShowText("" + (writer.PageNumber - 1));
            template.EndText();
        }
    }

}
