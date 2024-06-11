using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZDZSTORE.Product;
using ZDZSTORE.Sale.DTO;
using ZDZSTORE.Sale.Model;
using ZDZSTORE.User;
using ZDZSTORE.User.Model;

namespace ZDZSTORE.Sale
{
    [ApiController]
    [Route("sales")]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private SaleRepository _saleRepository;
        private UserRepository _userRepository;
        private SaleService _saleService;
        private IMapper _mapper;

        public SaleController(SaleRepository saleRepository, IMapper mapper, UserRepository userRepository, ProductRepository productRepository, SaleService saleService)
        {
            _saleRepository = saleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _saleService = saleService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseSaleWithItemsDTO>> GetOne(string id)
        {
            SaleModel? saleModel = await _saleRepository.GetOne(id);

            if (saleModel == null) { return NotFound(); };

            ResponseSaleWithItemsDTO responseSaleWithItemsDTO = _mapper.Map<ResponseSaleWithItemsDTO>(saleModel);

            return Ok(responseSaleWithItemsDTO);
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
        public async Task<ActionResult<ResponseSaleWithItemsDTO>> CreateOne([FromBody] CreateSaleDTO saleDTO)
        {
            UserModel? usermodel = await _userRepository.GetOne(saleDTO.userID);

            if (usermodel == null)
            {
                return NotFound(new { message = "User not found." });
            };

            try
            {
                await _saleService.checkProducts(saleDTO.items);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }

            BuildListItemsResult buildListItemsResult = await _saleService.buildListItems(saleDTO.items);

            SaleModel saleModel = _mapper.Map<SaleModel>(saleDTO);
            saleModel.items = buildListItemsResult.items;
            saleModel.price = buildListItemsResult.salePrice;

            SaleModel sale = await _saleRepository.CreateOne(saleModel);

            ResponseSaleWithItemsDTO responseSaleDTO = _mapper.Map<ResponseSaleWithItemsDTO>(sale);

            return CreatedAtAction(nameof(GetOne), new { id = responseSaleDTO.id }, responseSaleDTO);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteOne(string id)
        {
            SaleModel? sale = await _saleRepository.GetOne(id);

            if (sale == null) return NotFound();

            await _saleService.returnItems(sale.items);

            await _saleRepository.DeleteOne(sale);

            return NoContent();
        }
    }
}
