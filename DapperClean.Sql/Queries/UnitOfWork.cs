using DapperClean.Application.Interfaces;
using DapperClean.Core.Entities;

namespace DapperClean.Sql.Queries
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICreditoRepository Creditos { get; set; }
        public UnitOfWork(ICreditoRepository creditoRepository) 
        {
            Creditos = creditoRepository; ;
        }
    }
}
