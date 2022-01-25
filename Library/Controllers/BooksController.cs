using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Library.DTOs;
using Library.Entities;
using Library.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BooksController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        [HttpPost()]
        public async Task<ActionResult<BookDto>> CreateBook(Book book)
        {
            var entity = await _unitOfWork.BookRepository.AddBookAsync(book);
            var bookDto = _mapper.Map<BookDto>(entity);
            
            if (await _unitOfWork.Complete())
            {
                return Ok(bookDto);
            }
            
            return BadRequest("Failed to create book");
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetUsers()
        {
            var books = _mapper.Map<IEnumerable<BookDto>>(await _unitOfWork.BookRepository.GetBooksAsync());
            return Ok(books);
        }
        
        [HttpPut]
        public async Task<ActionResult> UpdateBook(Book book)
        {
            _unitOfWork.BookRepository.Update(book);

            if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update book");
        }
        
        [HttpDelete("{bookId}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            var book = await _unitOfWork.BookRepository.GetBook(bookId);

            if (book == null) return NotFound();
            
            _unitOfWork.BookRepository.DeleteBook(book);

            if (await _unitOfWork.Complete())
            {
                return Ok();
            }

            return BadRequest("Problem deleting book");
        }
    }
}