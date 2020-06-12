using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.DataAccess.Main.UnitOfWork.Mapping
{
    public class UserEntityConfiguration : EntityTypeConfiguration<Domain.Main.User.Aggregates.User>
    {
        public UserEntityConfiguration()
        {
            HasKey(entity => entity.Id)
                .HasEntitySetName("IdUsuario");

            Property(entity => entity.Nombre)
                .HasMaxLength(200)
                .IsOptional();

            Property(entity => entity.Apellido)
                .IsOptional()
                .HasMaxLength(200);

            Property(entity => entity.Password)
                .IsOptional()
                .HasMaxLength(200);

            Property(entity => entity.UsuarioBloqueado)
                .IsOptional();

            Property(entity => entity.UserLoginTries)
                .IsOptional();

            ToTable("Users");
        }
    }
}
