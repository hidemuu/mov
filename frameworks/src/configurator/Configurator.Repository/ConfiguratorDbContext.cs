using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mov.Configurators
{
    public class ConfiguratorDbContext : DbContext
    {
        public ConfiguratorDbContext() { }

        public ConfiguratorDbContext(DbContextOptions<ConfiguratorDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 複合キーの場合、以下のように指定してやる。
            // ない場合「Entity type 'Item' has composite primary key defined with data annotations. To set composite primary key, use fluent API.」と表示される
            //modelBuilder.Entity<Item>()
            //     .HasKey(c => new { c.Id, c.PointNo });
            // エリアと店舗情報で1:nの関係を作成
            //modelBuilder.Entity<MShop>()
            //    .HasOne(s => s.Area)
            //    .WithMany(a => a.Shops);

            //modelBuilder.Entity<Covid19LineItem>()
            //.HasOne(b => b.Death)
            //.WithOne()
            //.HasForeignKey<Death>(b => b.Date);

            //modelBuilder.Entity<Covid19LineItem>()
            //.HasOne(b => b.Hospitalization)
            //.WithOne()
            //.HasForeignKey<Hospitalization>(b => b.Date);
        }
    }
}
