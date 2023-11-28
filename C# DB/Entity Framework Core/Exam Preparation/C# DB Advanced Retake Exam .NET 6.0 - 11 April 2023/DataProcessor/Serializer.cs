using Invoices.DataProcessor.ExportDto;
using Invoices.Utilities;
using Newtonsoft.Json;

namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using System.Globalization;
    using System.Runtime.Intrinsics.X86;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var clientsWithInvoices = context.Clients
                .ToArray()
                .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                .Select(c => new ExportClientWithInvoiceDto()
                {
                    InvoiceCount = c.Invoices.Count,
                    ClientName = c.Name,
                    VatNumber = c.NumberVat,
                    Invoices = c.Invoices
                        .OrderBy(i => i.IssueDate)
                        .ThenByDescending(i => i.DueDate)
                        .Select(i => new ExportInvoiceDto()
                    {
                        InvoiceNumber = i.Number,
                        InvoiceAmount = i.Amount,
                        DueDate = i.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        
                        Currency = i.CurrencyType.ToString(),
                    })
                        .ToArray()
                }).OrderByDescending(c => c.InvoiceCount)
                .ThenBy(c => c.ClientName)
                .ToArray();

            return xmlHelper.Serialize(clientsWithInvoices, "Clients");
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            ExportProductDto[] products = context.Products
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new ExportProductDto()
                {
                    Name = p.Name,
                    Price = decimal.Parse(p.Price.ToString("0.##").TrimEnd('0')),
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(c => new ExportClientDto()
                        {
                            Name = c.Client.Name,
                            NumberVat = c.Client.NumberVat
                        })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(products,Formatting.Indented);
        }
    }
}