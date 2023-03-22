using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperClean.Application.Interfaces;
using DapperClean.Core.Entities;
using DapperClean.Sql.Queries;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DapperClean.Infrastructure.Repository
{
    public class CreditoRepository:ICreditoRepository
    {
        #region Private Members

        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        #endregion
        public CreditoRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        #region ICreditotRepository Methods

        public async Task<IReadOnlyList<Credito>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<Credito>(CreditoQueries.AllCreditos, _transaction);
            return result.ToList();
        }

        public async Task<Credito> GetByIdAsync(long id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<Credito>(CreditoQueries.CreditoById, new { CreditoId = id }, _transaction);
            return result;
        }

        public async Task<string> AddAsync(Credito entity)
        {
            var result = await _connection.ExecuteAsync(CreditoQueries.AddCredito, entity, _transaction);
            return result.ToString();
        }

        public async Task<string> UpdateAsync(Credito entity)
        {
            var result = await _connection.ExecuteAsync(CreditoQueries.UpdateCredito, entity, _transaction);
            return result.ToString();
        }

        public async Task<string> DeleteAsync(long id)
        {
            var result = await _connection.ExecuteAsync(CreditoQueries.DeleteCredito, new { CreditoId = id}, _transaction);
            return result.ToString();
        }

        #endregion
    }
}
