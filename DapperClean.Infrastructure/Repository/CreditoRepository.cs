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
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DapperClean.Infrastructure.Repository
{
    public class CreditoRepository:ICreditoRepository
    {
        #region Private Members

        private readonly IConfiguration configuration;

        #endregion
        public CreditoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        #region ICreditotRepository Methods

        public async Task<IReadOnlyList<Credito>> GetAllAsync()
        {
            using (IDbConnection connection = new NpgsqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Credito>(CreditoQueries.AllCreditos);
                return result.ToList();
            }
        }

        public async Task<Credito> GetByIdAsync(long id)
        {
            using (IDbConnection connection = new NpgsqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Credito>(CreditoQueries.CreditoById, new { CreditoId = id });
                return result;
            }
        }

        public async Task<string> AddAsync(Credito entity)
        {
            using (IDbConnection connection = new NpgsqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CreditoQueries.AddCredito, entity);
                return result.ToString();
            }
        }

        public async Task<string> UpdateAsync(Credito entity)
        {
            using (IDbConnection connection = new NpgsqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CreditoQueries.UpdateCredito, entity);
                return result.ToString();
            }
        }

        public async Task<string> DeleteAsync(long id)
        {
            using (IDbConnection connection = new NpgsqlConnection(configuration.GetConnectionString("DBConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(CreditoQueries.DeleteCredito, new { CreditoId = id });
                return result.ToString();
            }
        }

        #endregion
    }
}
