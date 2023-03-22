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

namespace DapperClean.Infrastructure.Repository
{
    public class ClienteRepository:IClienteRepository
    {
        #region Private Members

        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        #endregion
        public ClienteRepository(IDbTransaction transaction)
        {
            _transaction = transaction;
        }

        #region IClienteRepository Methods

        public async Task<IReadOnlyList<Cliente>> GetAllAsync()
        {
            var result = await _connection.QueryAsync<Cliente>(ClienteQueries.AllClientes);
            return result.ToList();
        }

        public async Task<Cliente> GetByIdAsync(long id)
        {
            var result = await _connection.QuerySingleOrDefaultAsync<Cliente>(ClienteQueries.ClienteById, new { ClienteId = id }, _transaction);
            return result;
        }

        public async Task<string> AddAsync(Cliente entity)
        {
            var result = await _connection.ExecuteAsync(ClienteQueries.AddCliente, entity, _transaction);
            return result.ToString();
        }

        public async Task<string> UpdateAsync(Cliente entity)
        {
            var result = await _connection.ExecuteAsync(ClienteQueries.UpdateCliente, entity, _transaction);
            return result.ToString();
        }

        public async Task<string> DeleteAsync(long id)
        {
            var result = await _connection.ExecuteAsync(ClienteQueries.DeleteCliente, new { ClienteId = id }, _transaction);
            return result.ToString();
        }
        #endregion
    }
}
