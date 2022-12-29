using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;

namespace BookStore.Books
{
    public interface IBookAppService : IApplicationService
    {
        //Task<BooksDto> CreateAsync(CreateBookDto input);
        Task<byte[]> GetCustomerBlobInStream(string filename, Guid? userId);
        Task<List<BooksDto>> Upload(CreateBookDto input);

        //Task<IRemoteStreamContent> Get(Guid id);
    }
}
