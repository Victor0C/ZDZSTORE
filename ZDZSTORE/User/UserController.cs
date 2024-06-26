﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ZDZSTORE.User.DTO;
using ZDZSTORE.User.Model;

namespace ZDZSTORE.User
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private UserRepository _userRepository;
        private IMapper _mapper;

        public UserController(UserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseUser>> GetOne(string id)
        {
            UserModel? userModel = await _userRepository.GetOne(id);

            if (userModel == null) { return NotFound(); };

            ResponseUser responseUser = _mapper.Map<ResponseUser>(userModel);

            return Ok(responseUser);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseUser>>> GetAll()
        {
            IEnumerable<UserModel> users = await _userRepository.GetAll();

            IEnumerable<ResponseUser> responseUser = _mapper.Map<List<ResponseUser>>(users);

            return Ok(responseUser);
        }


        [HttpPost]
        public async Task<ActionResult<ResponseUser>> CreateOne([FromBody] CreateUserDTO userDTO)
        {
            UserModel userModel = _mapper.Map<UserModel>(userDTO);

            UserModel user = await _userRepository.CreateOne(userModel);

            ResponseUser responseUser = _mapper.Map<ResponseUser>(user);

            return CreatedAtAction(nameof(GetOne), new { id = responseUser.id }, responseUser);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ResponseUser>> UpdateOne(string id, JsonPatchDocument<UpdateUserDTO> patch)
        {
            UserModel? user = await _userRepository.GetOne(id);

            if (user == null) return NotFound();

            UpdateUserDTO userDTO = _mapper.Map<UpdateUserDTO>(user);

            patch.ApplyTo(userDTO, ModelState);

            if (!TryValidateModel(userDTO))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(userDTO, user);
            await _userRepository.Update();

            ResponseUser responseUser = _mapper.Map<ResponseUser>(user);

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
