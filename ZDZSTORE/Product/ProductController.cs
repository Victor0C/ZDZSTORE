using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ZDZSTORE.Product.DTO;
using ZDZSTORE.Product.Model;

namespace ZDZSTORE.Product
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private ProductRepository _productRepository;
        private IMapper _mapper;

        public ProductController(ProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseProductDTO>> GetOne(string id)
        {
            ProductModel? productModel = await _productRepository.GetOne(id);

            if (productModel == null) { return NotFound(); };

            ResponseProductDTO responseProduct = _mapper.Map<ResponseProductDTO>(productModel);

            return Ok(responseProduct);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseProductDTO>>> GetAll()
        {
            IEnumerable<ProductModel> products = await _productRepository.GetAll();

            IEnumerable<ResponseProductDTO> responseProducts = _mapper.Map<List<ResponseProductDTO>>(products);

            return Ok(responseProducts);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<ResponseProductDTO>> CreateOne([FromBody] CreateProductDTO productDTO)
        {
            ProductModel productModel = _mapper.Map<ProductModel>(productDTO);

            ProductModel product = await _productRepository.CreateOne(productModel);

            ResponseProductDTO responseProduct = _mapper.Map<ResponseProductDTO>(product);

            return CreatedAtAction(nameof(GetOne), new { id = responseProduct.id }, responseProduct);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ResponseProductDTO>> UpdateOne(string id, JsonPatchDocument<UpdateProductDTO> patch)
        {
            ProductModel? product = await _productRepository.GetOne(id);

            if (product == null) return NotFound();

            UpdateProductDTO productDTO = _mapper.Map<UpdateProductDTO>(product);

            patch.ApplyTo(productDTO, ModelState);

            if (!TryValidateModel(productDTO))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(productDTO, product);
            await _productRepository.Update();

            ResponseProductDTO responseProduct = _mapper.Map<ResponseProductDTO>(product);

            return Ok(responseProduct);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteOne(string id)
        {
            ProductModel? product = await _productRepository.GetOne(id);

            if (product == null) return NotFound();

            await _productRepository.DeleteOne(product);

            return NoContent();
        }
    }
}
