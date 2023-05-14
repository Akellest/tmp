using System;


abstract class Report // Абстрактный класс для создания отчета
{
    
    public void GenerateReport() // Шаблонный метод
    {
        CollectData();
        FormatData();
        ExportData();
    }

    protected abstract void CollectData();
    protected abstract void FormatData();
    protected virtual void ExportData()
    {
        Console.WriteLine("Exporting report data...");
    }
}


class PDFReport : Report // подкласс для отчета в PDF
{
    protected override void CollectData()
    {
        Console.WriteLine("Collecting data for PDF report...");
    }

    protected override void FormatData()
    {
        Console.WriteLine("Formatting data for PDF report...");
    }

    protected override void ExportData()
    {
        Console.WriteLine("Exporting PDF report...");
    }
}


class CSVReport : Report // подкласс для отчета в CSV
{
    protected override void CollectData()
    {
        Console.WriteLine("Collecting data for CSV report...");
    }

    protected override void FormatData()
    {
        Console.WriteLine("Formatting data for CSV report...");
    }

    protected override void ExportData()
    {
        Console.WriteLine("Exporting CSV report...");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Report pdfReport = new PDFReport();
        pdfReport.GenerateReport();
        Console.WriteLine();

        Report csvReport = new CSVReport();
        csvReport.GenerateReport();
    }
}
