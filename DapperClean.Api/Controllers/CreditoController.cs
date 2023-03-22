using DapperClean.Api.Models;
using DapperClean.Application.Interfaces;
using DapperClean.Core.Entities;
using DapperClean.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DapperClean.Api.Controllers
{
    public class CreditoController : BaseApiController
    {
        //private readonly IUnitOfWork _unitOfWork;

        public CreditoController()
        {
           // this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ApiResponse<List<Cliente>>> GetAll()
        {
            var apiResponse = new ApiResponse<List<Cliente>>();

            using (var unitOfWork = new UnitOfWork(@"Data Source=.\;Initial Catalog=dapper-test;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True"))
            {
                var newCredito = new Credito
                {
                    Cuotas = 1,
                    Interes = 0,
                    Valor = 100000
                };
                var newCliente = new Cliente { Edad = 25, Nombre = "Fabian Zapata" };
                await unitOfWork.CreditoRepository.AddAsync(newCredito);
                await unitOfWork.ClienteRepository.AddAsync(newCliente);

                unitOfWork.Commit();
            }


            return apiResponse;
        }

    }
}
