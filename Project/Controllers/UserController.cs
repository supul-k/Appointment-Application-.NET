using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Project.DTO;
using Project.DTO.InternalDTO;
using Project.Interfaces.IRepositories;
using Project.Interfaces.IServices;
using Project.Models;
using Project.Services;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHashPasswordService _hashPasswordService;

        public UserController(IUserService userService, IHashPasswordService hashPasswordService)
        {
            _userService = userService;
            _hashPasswordService = hashPasswordService;
        }
        [HttpPost("add-user", Name = "AddUser")]
        public async Task<IActionResult> AddUser(UserRegisterRequestDTO request)
        {
            try
            {
                UserModel user = new UserModel();

                Guid userId = Guid.NewGuid();
                var hashedPassword = await _hashPasswordService.HashPassword(request.Password);
                if (!hashedPassword.Status) 
                {
                    var response = new GeneralResponseDTO(hashedPassword.Status, hashedPassword.Message);
                    return BadRequest(response);
                }
                user.Id = userId.ToString();
                user.Name = request.Name;
                user.Email = request.Email;
                user.contactNumber = request.ContactNumber;
                user.Password = hashedPassword.Message;
                var result = await _userService.AddUser(user);

                return result.Status ? Created("User created", result) : BadRequest(result);

            }
            catch (Exception ex)
            {
                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPost("login-user", Name = "LoginUser")]
        public async Task<IActionResult> LoginUser(UserLoginDTO  request)
        {
            try
            {
                var UserExist = await _userService.UserExist(request.Email);
                if (!UserExist.Status)
                {
                    var response = new GeneralResponseDTO(UserExist.Status, UserExist.Message);
                    return BadRequest(response);
                }
                if (UserExist.Data is UserModel userData)
                {
                    var authenticationResult = await _userService.AuthenticateUser(request.Password, userData.Password);
                    if (authenticationResult.Status)
                    {
                        return Ok(new GeneralResponseInternalDTO(true, "Authentication successful"));
                    }
                    else
                    {
                        var response = new GeneralResponseDTO(authenticationResult.Status, authenticationResult.Message);
                        return BadRequest(response);
                    }
                }
                else
                {
                    var response = new GeneralResponseDTO(false, "Invalid user data format");
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {

                GeneralResponseDTO response = new GeneralResponseDTO(false, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
