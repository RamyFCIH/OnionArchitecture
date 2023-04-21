using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onion.Core.Models;
using OnionArchitecture.Core.Interfaces;
using System.Linq;

namespace OnionArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
           var spec = new BookWithAuthorAndPublisherSpecification();
           var response  = await _unitOfWork.Books.ListAsync(spec);
            return Ok(response);
        }

        [HttpGet("GetBookAuthors/{id:int}")]
        public async Task<IActionResult> GetBookAuthors(int id)
        {
            var spec = new BookWithAuthorAndPublisherSpecification(id);
            var response = await _unitOfWork.Books.GetEntityWithSpec(spec);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult AddOne()
        {
            var author = _unitOfWork.Authors.Add(new Author {  Name = "Ramy Ayman" });
            var book = _unitOfWork.Books.Add(new Book {  Title = "Tale of Two Cities"  , AuthorId = 2});
            _unitOfWork.Complete();
            return Ok();
        }
        //[HttpGet]
        //public IActionResult GetByIdAsync(int id)
        //{
        //    return Ok(_unitofWork.Authors.GetByIdAsync(id));
        //}

        //[HttpGet]
        //public IActionResult GetAuthorName(string title)
        //{
        //    return Ok(_unitofWork.Authors.Find(x => x.Name == title, new[] { "Author" }));
        //}

        //[HttpGet]
        //public IActionResult GetAllBooks()
        //{
        //    return Ok(_unitofWork.Books.FindAll(x => x.Title.Contains("A"), new[] { "Author" }));
        //}

        //[HttpGet]
        //public IActionResult GetOrdered()
        //{
        //    return Ok(_unitofWork.Authors.FindAll(x => x.Name.Contains("A"), null, null, x => x.Id, OrderBy.Descending));
        //}


    }
}
