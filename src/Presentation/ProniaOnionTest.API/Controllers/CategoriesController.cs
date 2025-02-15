﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProniaOnionTest.Application.Abstractions.Services;
using ProniaOnionTest.Application.DTOs.Categories;

namespace ProniaOnionTest.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task <IActionResult> Get(int page=1, int take = 3)
        {
            return Ok(await _service.GetAllAsync(page, take));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CategoryCreateDto categoryDto)
        {
            await _service.Create(categoryDto);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0) return StatusCode(StatusCodes.Status400BadRequest);
            await _service.SoftDeleteAsync(id);
            return StatusCode(StatusCodes.Status204NoContent); 
        }
    }
}
