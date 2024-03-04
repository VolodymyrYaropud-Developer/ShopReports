using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ShopReports.Models;
using ShopReports.Reports;

namespace ShopReports.Services
{
    public class ProductReportService
    {
        private readonly ShopContext shopContext;

        public ProductReportService(ShopContext shopContext)
        {
            this.shopContext = shopContext;
        }

        public ProductCategoryReport GetProductCategoryReport()
        {
            var instance = this.shopContext.Categories.ToList();
            return new ProductCategoryReport(
                instance.OrderBy(c => c.Name)
                .Select(c => new ProductCategoryReportLine
                {
                    CategoryId = c.Id,
                    CategoryName = c.Name,
                }).ToList(), DateTime.UtcNow);
        }

        public ProductReport GetProductReport()
        {
            var instance = this.shopContext.Products
                .Include(p => p.Title)
                .ThenInclude(pt => pt.Category)
                .Select(s => new ProductReportLine
                {
                    ProductId = s.Id,
                    ProductTitle = s.Title.Title,
                    Manufacturer = s.Manufacturer.Name,
                    Price = s.UnitPrice,
                }).OrderByDescending(o => o.ProductTitle)
                .ToList();
            return new ProductReport(instance, DateTime.UtcNow);
        }

        public FullProductReport GetFullProductReport()
        {
            var instance = this.shopContext.Products
                .Include(p => p.Title)
                .ThenInclude(pt => pt.Category)
                .Select(s => new FullProductReportLine
                {
                    ProductId = s.Id,
                    Name = s.Title.Title,
                    CategoryId = s.Title.Category.Id,
                    Manufacturer = s.Manufacturer.Name,
                    Price = s.UnitPrice,
                    Category = s.Title.Category.Name,
                }).OrderBy(o => o.Name)
                .ToList();
            return new FullProductReport(instance, DateTime.UtcNow);
        }

        public ProductTitleSalesRevenueReport GetProductTitleSalesRevenueReport()
        {
            var instance = this.shopContext.OrderDetails
                .Include(p => p.Product)
                .ThenInclude(pt => pt.Title)
                .Select(s => new ProductTitleSalesRevenueReportLine
                {
                    ProductTitleName = s.Product.Title.Title,
                    SalesRevenue = s.PriceWithDiscount,
                    SalesAmount = s.ProductAmount,
                }).GroupBy(g => g.ProductTitleName)
                .Select(newGroup => new ProductTitleSalesRevenueReportLine
                {
                    ProductTitleName = newGroup.Key,
                    SalesRevenue = newGroup.Sum(g => g.SalesRevenue),
                    SalesAmount = newGroup.Sum(g => g.SalesAmount),
                })
                .OrderByDescending(newGrop => newGrop.SalesRevenue)
                .ToList();
            return new ProductTitleSalesRevenueReport(instance, DateTime.UtcNow);
        }
    }
}
