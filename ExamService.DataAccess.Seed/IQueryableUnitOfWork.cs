using ExamService.Domain.Seed;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.DataAccess.Seed
{
    public interface IQueryableUnitOfWork: IUnitOfWork, ISql
    {
        DbSet<T> CreateSet<T>() where T : class;

        void Attach<T>(T item) where T : class;

        void SetModified<T>(T item) where T : class;

        void ApplyCurrentValues<T>(T original, T current) where T : class;
    }
}
