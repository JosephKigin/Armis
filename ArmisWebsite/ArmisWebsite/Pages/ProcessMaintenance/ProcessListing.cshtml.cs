using Armis.BusinessModels.ProcessModels;
using ArmisWebsite.DataAccess.Process.Interfaces;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArmisWebsite
{
    public class ProcessListingModel : PageModel
    {
        public readonly string _apiAddress; //This is needed whenever javascrit is responsible for loading data from the API.
        public readonly IConfiguration Config;
        //Data Access
        public IProcessDataAccess ProcessDataAccess { get; set; }

        //Models
        public List<ProcessModel> Processes { get; set; }

        //Front-End
        public string PopUpMessage { get; set; }

        [BindProperty]
        public int ProcessIdSelection { get; set; }

        public ProcessListingModel(IProcessDataAccess aProcessDataAccess, IConfiguration aConfig) //Config is injected only to grab the APIAddress for the javascript calls on the web page.
        {
            ProcessDataAccess = aProcessDataAccess;
            Config = aConfig;
            _apiAddress = aConfig["APIAddress"];
        }

        public async Task<IActionResult> OnGet()
        {
            await SetUpProperties();

            return Page();
        }

        public async Task<IActionResult> OnPostPrint()
        {
            var theProcess = await ProcessDataAccess.GetHydratedProcess(ProcessIdSelection);
            var theCurrentRev = theProcess.Revisions.FirstOrDefault(i => i.RevStatusCd == "LOCKED");

            MemoryStream memStream = new MemoryStream();

            Document pdfDoc = new Document(PageSize.Letter, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, memStream);
            pdfDoc.Open();

            //Top Heading
            PdfPTable titleTable = new PdfPTable(3);
            titleTable.WidthPercentage = 100;

            PdfPCell cellDate = new PdfPCell();
            Paragraph paraDate = new Paragraph(DateTime.Now.ToString("MM/dd/yyyy"));
            paraDate.Alignment = Element.ALIGN_LEFT;
            cellDate.AddElement(paraDate);
            cellDate.Border = 0;
            titleTable.AddCell(cellDate);

            PdfPCell cellProcessName = new PdfPCell();
            Paragraph paraName = new Paragraph(theProcess.Name);
            paraName.Alignment = Element.ALIGN_CENTER;
            cellProcessName.AddElement(paraName);
            cellProcessName.Border = 0;
            titleTable.AddCell(cellProcessName);

            PdfPCell cellPageNum = new PdfPCell();
            Paragraph paraPageNum = new Paragraph("Page #");
            paraPageNum.Alignment = Element.ALIGN_RIGHT;
            cellPageNum.AddElement(paraPageNum);
            cellPageNum.Border = 0;
            titleTable.AddCell(cellPageNum);

            pdfDoc.Add(titleTable);

            //Horizontal Line
            var line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.Black, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(line);

            //Step Table
            var tableSteps = new PdfPTable(5);
            tableSteps.WidthPercentage = 100;
            //table.HorizontalAlignment = 0;
            tableSteps.SpacingBefore = 20f;
            //table.SpacingAfter = 30f;
            float[] columnWidths = new float[] { 10f, 20f, 50f, 10f, 10f };
            tableSteps.SetWidths(columnWidths);

            //Title Cells
            tableSteps.AddCell("Seq");
            tableSteps.AddCell("Step Name");
            tableSteps.AddCell("Instructions");
            tableSteps.AddCell("Sign-Off");
            tableSteps.AddCell("Date");

            //Step cells
            foreach (var stepSeq in theCurrentRev.StepSeqs)
            {
                var cellSeq = new PdfPCell(new Phrase(stepSeq.Sequence.ToString()));
                cellSeq.Padding = 10;
                tableSteps.AddCell(cellSeq);

                var cellName = new PdfPCell(new Phrase(stepSeq.Step.StepName));
                cellName.Padding = 10;
                tableSteps.AddCell(cellName);

                var cellInstructions = new PdfPCell(new Phrase(stepSeq.Step.Instructions));
                cellInstructions.Padding = 10;
                tableSteps.AddCell(cellInstructions);

                var cellSignOff = new PdfPCell();
                cellSignOff.Padding = 10;
                tableSteps.AddCell(cellSignOff);

                var cellSignOffDate = new PdfPCell();
                cellSignOffDate.Padding = 10;
                tableSteps.AddCell(cellSignOffDate);
            }

            pdfDoc.Add(tableSteps);

            pdfDoc.Close();
            FileStream file = new FileStream(Config["PdfRouterFileLocaiton"] + theProcess.Name + DateTime.Now.ToString("hhmmss") + ".pdf", FileMode.Create, FileAccess.Write);
            memStream.WriteTo(file);
            memStream.Close();
            file.Close();
            var fsResult = new FileStreamResult(new FileStream(Config["PdfRouterFileLocaiton"] + theProcess.Name + DateTime.Now.ToString("hhmmss") + ".pdf", FileMode.Open, FileAccess.Read), "application/pdf");

            return fsResult;

        }

        public async Task SetUpProperties()
        {
            try
            {
                var theProcesses = await ProcessDataAccess.GetAllHydratedProcesses();

                Processes = theProcesses.ToList();

                foreach (var process in Processes)
                {
                    process.Revisions.OrderBy(i => i.ProcessRevId);
                }
            }
            catch (Exception ex)
            {
                PopUpMessage += "Error: " + ex.Message;
            }
        }


    }
}