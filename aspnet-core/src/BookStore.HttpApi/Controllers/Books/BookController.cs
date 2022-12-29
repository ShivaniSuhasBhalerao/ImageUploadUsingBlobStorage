using BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Content;

namespace BookStore.Controllers.Books
{
    [RemoteService(Name = "app")]
    [Area("app")]
    [Route("api/book-store/books")]
    public class BookController : BookStoreController, IBookAppService
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet]
        [Route("content")]
        public async Task<byte[]> GetCustomerBlobInStream(string filename, Guid? userId)
        {
            return await _bookAppService.GetCustomerBlobInStream(filename, userId);
        }

        [HttpPost]
        [Route("upload")]
        public async Task<List<BooksDto>> Upload(CreateBookDto input)
        {
            return await _bookAppService.Upload(input);
        }
    }
}
