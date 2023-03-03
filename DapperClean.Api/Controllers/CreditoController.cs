using DapperClean.Api.Models;
using DapperClean.Application.Interfaces;
using DapperClean.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DapperClean.Api.Controllers
{
    public class CreditoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreditoController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ApiResponse<List<Credito>>> GetAll()
        {
            var apiResponse = new ApiResponse<List<Credito>>();

            try
            {
                var data = await _unitOfWork.Creditos.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Result = data.ToList();
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
            }

            return apiResponse;
        }

    }
}
