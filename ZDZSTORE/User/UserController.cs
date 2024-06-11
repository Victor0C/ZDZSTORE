using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ZDZSTORE.User.DTO;
using ZDZSTORE.User.Model;

namespace ZDZSTORE.User
{
    [ApiController]
    [Route("users")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository;
        private IMapper _mapper;
        private readonly IPasswordHasher<UserModel> _passwordHasher;

        public UserController(UserRepository userRepository, IMapper mapper, IPasswordHasher<UserModel> passwordHasher)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseUserDTO>> GetOne(string id)
        {
            UserModel? userModel = await _userRepository.GetOne(id);

            if (userModel == null) { return NotFound(); };

            ResponseUserDTO responseUser = _mapper.Map<ResponseUserDTO>(userModel);

            return Ok(responseUser);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseUserDTO>>> GetAll()
        {
            IEnumerable<UserModel> users = await _userRepository.GetAll();

            IEnumerable<ResponseUserDTO> responseUser = _mapper.Map<List<ResponseUserDTO>>(users);

            return Ok(responseUser);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ResponseUserDTO>> CreateOne([FromBody] CreateUserDTO userDTO)
        {
            UserModel userModel = _mapper.Map<UserModel>(userDTO);

            userModel.password = _passwordHasher.HashPassword(userModel, userModel.password);

            UserModel user = await _userRepository.CreateOne(userModel);

            ResponseUserDTO responseUser = _mapper.Map<ResponseUserDTO>(user);

            return CreatedAtAction(nameof(GetOne), new { id = responseUser.id }, responseUser);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseUserDTO>> UpdateOne(string id, JsonPatchDocument<UpdateUserDTO> patch)
        {
            UserModel? user = await _userRepository.GetOne(id);

            if (user == null) return NotFound();

            UpdateUserDTO userDTO = _mapper.Map<UpdateUserDTO>(user);

            patch.ApplyTo(userDTO, ModelState);

            if (!TryValidateModel(userDTO))
            {
                return ValidationProblem(ModelState);
            }

            if (patch.Operations.Any(op => op.path == "/password"))
            {
                userDTO.password = _passwordHasher.HashPassword(user, userDTO.password);
            }

            _mapper.Map(userDTO, user);
            await _userRepository.Update();

            ResponseUserDTO responseUser = _mapper.Map<ResponseUserDTO>(user);

            return Ok(responseUser);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteOne(string id)
        {
            UserModel? user = await _userRepository.GetOne(id);

            if (user == null) return NotFound();

            await _userRepository.DeleteOne(user);

            return NoContent();
        }

    }
}
