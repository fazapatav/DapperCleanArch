using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperClean.Application.Interfaces;
using DapperClean.Core.Entities;
using Microsoft.Data.SqlClient;
using DapperClean.Infrastructure.Repository;
using System.Data.Common;

namespace DapperClean.Infrastructure
{
    public class UnitOfWork: IUnitOfWork,IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        public CreditoRepository _creditosRepository;
        public ClienteRepository _clienteRepository;
        public UnitOfWork(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public CreditoRepository CreditoRepository
        {
            get
            {
                return _creditosRepository ?? (_creditosRepository = new CreditoRepository(_transaction));
            }
        }

        public ClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepository ?? (_clienteRepository = new ClienteRepository(_transaction));
            }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        private void ResetRepositories()
        {
            _creditosRepository = null;
        }

    }
}
