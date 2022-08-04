﻿using Aniverse.Application.DTOs.Auth;
using Aniverse.Services.Abstractions.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aniverse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutheticateController : ControllerBase
    {
        private readonly IUnitOfWorkService _unitOfWorkService;

        public AutheticateController(IUnitOfWorkService unitOfWorkService)
        {
            _unitOfWorkService = unitOfWorkService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterAsync([FromForm] Register register) => 
            Ok(await _unitOfWorkService.AuthService.RegisterAsync(register));
    }
}