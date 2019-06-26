﻿using FirmaBudowlana.Core.DTO;
using FirmaBudowlana.Infrastructure.Commands.User;
using Komis.Infrastructure.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FirmaBudowlana.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public AccountController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginDTO userParam)
        {
            var command = new Login() { LoginCredentials = userParam };
            try
            {
                await _commandDispatcher.DispatchAsync(command);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return new JsonResult(command.Token);
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserRegisterDTO userParam)
        {
            try
            {
                await _commandDispatcher.DispatchAsync(new Register() { UserCredentials = userParam });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return Ok();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> UserOrders(Guid id)
        {
            var command = new GetUserOrders()
            {
                Token = Request.Headers["Authorization"],
                User = User,
                UserID = id
            };

            try
            {
                await _commandDispatcher.DispatchAsync(command);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

            return new JsonResult(command.Orders);
        }

        [Authorize(Roles = "User")]
        [HttpGet("Account/OrderDetails/{idUser}/{idOrder}")]
        public async Task<IActionResult> OrderDetails(Guid idUser, Guid idOrder)
        {
            var command = new GetUserSpecifyOrder()
            {
                Token = Request.Headers["Authorization"],
                User = User,
                UserID = idUser,
                OrderID = idOrder
            };

            try
            {
                await _commandDispatcher.DispatchAsync(command);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                return StatusCode(500, e.Message);
            }

            return new JsonResult(command.Order);
        }



    }
}