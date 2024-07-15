using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class RequestsController : BaseController
    {
        private readonly IRequestService _requestService;
        public RequestsController(IRequestService requestService) 
        {
            _requestService = requestService;
        }


    }
}
