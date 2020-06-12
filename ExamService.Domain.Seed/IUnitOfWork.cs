using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamService.Domain.Seed
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void CommitAndRefreshChanges();
        void RollbackChanges();
    }
}
