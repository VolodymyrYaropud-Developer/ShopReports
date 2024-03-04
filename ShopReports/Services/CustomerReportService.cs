using Microsoft.EntityFrameworkCore;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services
{
    public class CustomerReportService
    {
        private readonly ShopContext shopContext;

        public CustomerReportService(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public CustomerSalesRevenueReport GetCustomerSalesRevenueReport()
        {
            var report = shopContext.Customers
          .Include(c => c.Orders)
              .ThenInclude(o => o.Details)
                  .ThenInclude(od => od.Product.OrderDetails)
          .Select(c => new CustomerSalesRevenueReportLine
          {
              CustomerId = c.Id,
              PersonFirstName = c.Person.FirstName,
              PersonLastName = c.Person.LastName,
              SalesRevenue = c.Orders
              .SelectMany(o => o.Details)
                  .Sum(od => od.PriceWithDiscount),
          })
          .Where(c => c.SalesRevenue > 0)
          .OrderByDescending(c => c.SalesRevenue)
          .ToList();

            var reportNew = new CustomerSalesRevenueReport(report, DateTime.Now);

            return reportNew;
        }
    }
}
