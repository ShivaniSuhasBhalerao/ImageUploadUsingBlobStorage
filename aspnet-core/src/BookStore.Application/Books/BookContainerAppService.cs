using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;

namespace BookStore.Books
{
   
    public class BookContainerAppService : IBookContainerAppService
    {
        private readonly IBlobContainer<BookContainer> _bookBlobContainer;



        public BookContainerAppService(IBlobContainer<BookContainer> bookBlobContainer)
        {
            _bookBlobContainer = bookBlobContainer;
        }



        public async Task DeleteFileAsync(string filename)
        {
            await _bookBlobContainer.DeleteAsync(filename);
        }



        public async Task<byte[]> GetBytesAsync(string filename)
        {
            return await _bookBlobContainer.GetAllBytesOrNullAsync(filename);
        }



        public async Task<string> SaveBytesAsync(byte[] bytes, string extension)
        {
            var filename = Guid.NewGuid().ToString() + extension;
            await _bookBlobContainer.SaveAsync(filename, bytes);
            return filename;
        }
    }
}
