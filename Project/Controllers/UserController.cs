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
using System.Text;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHashPasswordService _hashPasswordService;
        private readonly IValidationService _validationService;
        private readonly IJWTService _jwtService;
        private readonly IConfiguration _config;

        public UserController(
            IUserService userService, 
            IHashPasswordService hashPasswordService, 
            IValidationService validationService, 
            IJWTService jWTService,
            IConfiguration configuration
            )
        {
            _userService = userService;
            _hashPasswordService = hashPasswordService;
            _validationService = validationService;
            _jwtService = jWTService;
            _config = configuration;
        }
        [HttpPost("add-user", Name = "AddUser")]
        public async Task<IActionResult> AddUser(UserRegisterRequestDTO request)
        {
            try
            {
                UserModel user = new UserModel();

                var passwordValidation = await _validationService.ValidatePassword(request.Password);
                if (!passwordValidation.Status)
                {
                    return BadRequest(passwordValidation);
                }

                var emailValidation = await _validationService.ValidateEmail(request.Email);
                if (!emailValidation.Status)
                {
                    return BadRequest(emailValidation);
                }

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
                var passwordValidation = await _validationService.ValidatePassword(request.Password);
                if (!passwordValidation.Status)
                {
                    return BadRequest(passwordValidation);
                }

                var emailValidation = await _validationService.ValidateEmail(request.Email);
                if (!emailValidation.Status)
                {
                    return BadRequest(emailValidation);
                }
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
                        try
                        {
                            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                            var JWTToken = _jwtService.GenerateJwtToken(securityKey, credentials, request.Email);

                            return Ok(new GeneralResponseInternalDTO(true, JWTToken, "User Login successful"));
                        }
                        catch (Exception ex)
                        {
                            var response = new GeneralResponseDTO(false, ex.Message);
                            return BadRequest(response);
                        }
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
