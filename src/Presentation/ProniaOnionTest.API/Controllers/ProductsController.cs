using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnionTest.Application.Abstractions.Services;
using ProniaOnionTest.Application.DTOs.Products;

namespace ProniaOnionTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page=1, int take=10)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }

        [HttpGet("{id}")]
        public async Task <IActionResult>Get(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            //var product = await _service.GetByIdAsync(id);
            //if (product == null) return NotFound();
            //return Ok(product);
            return StatusCode(StatusCodes.Status200OK, await _service.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,  ProductUpdateDto dto)
        {
            if(id<=0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.UpdateAsync(id, dto);    
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
