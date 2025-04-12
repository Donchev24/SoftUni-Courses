using NetPay.Data;
using NetPay.Data.Models;
using Newtonsoft.Json;

namespace NetPay.DataProcessor
{
    public class Serializer
    {
        public static string ExportHouseholdsWhichHaveExpensesToPay(NetPayContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportAllServicesWithSuppliers(NetPayContext context)
        {
            var exportServicesWithSuppliers = context
                .Services
                .Select(s => new
                {
                    s.ServiceName,
                    Suppliers = s.SuppliersServices
                    .Select(ss => ss.Supplier)
                    .Select(supplier => new
                    {
                        supplier.SupplierName
                    })
                    .OrderBy(supplier => supplier.SupplierName)
                    .ToArray()
                })
                .OrderBy(s => s.ServiceName)
                .ToArray();

            string result = JsonConvert
                .SerializeObject(exportServicesWithSuppliers, Formatting.Indented);

            return result;
        }
    }
}
