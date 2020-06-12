using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.DataAccess.Main.UnitOfWork.Mapping
{
    public class ProductEntityConfiguration : EntityTypeConfiguration<Domain.Main.Product.Aggregates.Product>
    {
        public ProductEntityConfiguration()
        {
            HasKey(entity => entity.Id)
                .HasEntitySetName("IdProduct");

            Property(entity => entity.Name)
                .HasMaxLength(200)
                .IsOptional();

            Property(entity => entity.Cost)
                .HasColumnType("float")
                .IsOptional();

            Property(entity => entity.Inverntory)
                .IsOptional();

            ToTable("Products");
        }
    }
}
