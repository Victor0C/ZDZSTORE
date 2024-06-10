using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ZDZSTORE.Sale.DTO;
using ZDZSTORE.Sale.Model;
using ZDZSTORE.User;
using ZDZSTORE.User.Model;

namespace ZDZSTORE.Sale
{
    [ApiController]
    [Route("sales")]
    public class SaleController : ControllerBase
    {
        private SaleRepository _saleRepository;
        private IMapper _mapper;
        private UserRepository _userRepository;

        public SaleController(SaleRepository saleRepository, IMapper mapper, UserRepository userRepository)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseSaleDTO>> GetOne(string id)
        {
            SaleModel? saleModel = await _saleRepository.GetOne(id);

            if (saleModel == null) { return NotFound(); };

            ResponseSaleDTO responseSaleDTO = _mapper.Map<ResponseSaleDTO>(saleModel);

            return Ok(responseSaleDTO);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseSaleDTO>>> GetAll()
        {
            IEnumerable<SaleModel> sales = await _saleRepository.GetAll();

            IEnumerable<ResponseSaleDTO> responseSaleDTOs = _mapper.Map<List<ResponseSaleDTO>>(sales);

            return Ok(responseSaleDTOs);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ResponseSaleDTO>> CreateOne([FromBody] CreateSaleDTO saleDTO)
        {
            UserModel? usermodel = await _userRepository.GetOne(saleDTO.userID);

            if (usermodel == null) { return NotFound(new { message = $"User not found." }); };

            SaleModel saleModel = _mapper.Map<SaleModel>(saleDTO);

            SaleModel sale = await _saleRepository.CreateOne(saleModel);

            ResponseSaleDTO responseSaleDTO = _mapper.Map<ResponseSaleDTO>(sale);

            return CreatedAtAction(nameof(GetOne), new { id = responseSaleDTO.id }, responseSaleDTO);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseSaleDTO>> UpdateOne(string id, JsonPatchDocument<UpdateSaleDTO> patch)
        {
            SaleModel? sale = await _saleRepository.GetOne(id);

            if (sale == null) return NotFound();

            UpdateSaleDTO saleDTO = _mapper.Map<UpdateSaleDTO>(sale);

            patch.ApplyTo(saleDTO, ModelState);

            if (!TryValidateModel(saleDTO))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(saleDTO, sale);
            await _saleRepository.Update();

            ResponseSaleDTO responseSaleDTO = _mapper.Map<ResponseSaleDTO>(sale);

            return Ok(responseSaleDTO);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteOne(string id)
        {
            SaleModel? sale = await _saleRepository.GetOne(id);

            if (sale == null) return NotFound();

            await _saleRepository.DeleteOne(sale);

            return NoContent();
        }
    }
}
