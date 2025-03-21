﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SALIH\\SQLEXPRESS;initial Catalog=MultiShopDiscountDb;integrated Security=true;TrustServerCertificate=true");
        }
        public DbSet<Coupon> Coupons { get; set; }
        //CreateConnection metodu çağırıldığında _connectionString içindeki değeri alan yeni bir Sql bağlantısı oluşturur.
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
