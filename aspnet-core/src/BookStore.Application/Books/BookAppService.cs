using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Content;
using Volo.Abp.Domain.Repositories;
using static System.Net.Mime.MediaTypeNames;

namespace BookStore.Books
{
    [RemoteService(IsEnabled = false)]
    public class BookAppService : BookStoreAppService, IBookAppService
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IBlobContainer<BookContainer> _blobContainer;
        // private readonly IBookContainerAppService _bookContainerAppService;
        public BookAppService(IRepository<Book, Guid> bookRepository, IBlobContainer<BookContainer> blobContainer)
        {
            _bookRepository = bookRepository;
            _blobContainer = blobContainer;
            //_bookContainerAppService = bookContainerAppService;

        }

        public async Task<byte[]> GetCustomerBlobInStream(string filename, Guid? userId)
        {
            return await _blobContainer.GetAllBytesAsync(filename);
        }

        public async Task<List<BooksDto>> Upload(CreateBookDto input)
        {
            // var output=new List<BooksDto>();
            //  using var memoryStream = new MemoryStream();

            await _blobContainer.SaveAsync(GuidGenerator.Create().ToString(), input.File.GetStream(), true);

            //  IFormFile files;
            //  //files.ContentType.Insert(input.MimeType);
            //  //files = (IFormFile)input;
            //  //await files.CopyToAsync(memoryStream).ConfigureAwait(false);
            //  var id = Guid.NewGuid();
            //  var newFile = new Book(
            //      id,
            //      input.Name,
            //      input.Image,
            //      input.MimeType,
            //      input.FileSize
            //      );
            //  //var book = ObjectMapper.Map<CreateBookDto, Book>(input);
            //var book = await _bookRepository.InsertAsync(newFile, autoSave: true);
            //  await _blobContainer.SaveAsync(id.ToString(), memoryStream.ToArray()).ConfigureAwait(false);
            //  output.Add(ObjectMapper.Map<Book,BooksDto>(newFile));
            //  return output;
            return null;

        }
        //public async Task<FileResult> Get(Guid id)
        //{
        //    var currentFile = await _bookRepository.GetAsync(x => x.Id == id);
        //    if (currentFile != null)
        //    {
        //        var myfile = await _blobContainer.GetAllBytesOrNullAsync(id.ToString());
        //        return new FileContentResult(myfile, currentFile.MimeType);
        //    }
        //    throw new FileNotFoundException();
        //}

        //        public async Task<BooksDto> CreateAsync(CreateBookDto input)
        //        {

        //            if (!string.IsNullOrEmpty(input.Base64))
        //            {
        //                input.Base64 = input.Base64.Substring(input.Base64.IndexOf(",") + 1);
        //                var plainTextBytes = Convert.FromBase64String(input.Base64);
        //                input.Image = await _bookContainerAppService.SaveBytesAsync(plainTextBytes, Path.GetExtension(input.Image));
        //            }
        //            var book = ObjectMapper.Map<CreateBookDto, Book>(input);
        //            book = await _bookRepository.InsertAsync(book, autoSave: true);
        //            return ObjectMapper.Map<Book, BooksDto>(book);
        //        }

        //public virtual async Task<IRemoteStreamContent> GetCustomerBlobInStream(string filename, Guid? userId)
        //        {
        //            ////var sign = await _bookContainerAppService.GetBytesAsync(filename);
        //            //if (sign != null)
        //            //{
        //            //    var ms = new MemoryStream(sign);
        //            //    return new RemoteStreamContent(ms, filename, MimeMapping.MimeUtility.GetMimeMapping(filename));
        //            //}
        //            return null;
        //        }


    }
}
