using BLL.Interfaces;
using DAL.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace HOSPITAL.API.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/registration")]
        public async Task<IActionResult> RegistrationUser(UserDTO userDTO) =>
            Ok(await _userService.RegistrationUserAsync(userDTO));

        [HttpGet]
        [Route("/getbymedicalcardnumber")]
        public async Task<IActionResult> GetByNumber(long number) =>
            Ok(await _userService.GetInfoMyMedicalCardNumberAsync(number));

        [HttpPost]
        [Route("/validate")]
        public async Task<IActionResult> ValidateUser([FromBody] ValidateDTO validateDTO)
        {
            var validate = await _userService.ValidateUserAsync(validateDTO);
            if (validate != null) return Ok(validate);
            else return BadRequest();
        }
    }
}
