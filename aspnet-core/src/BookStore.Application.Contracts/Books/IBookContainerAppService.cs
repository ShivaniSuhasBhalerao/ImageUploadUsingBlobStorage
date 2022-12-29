using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BookStore.Books
{

    public interface IBookContainerAppService : IApplicationService
    {
        Task<string> SaveBytesAsync(byte[] bytes, string extension);
        Task<byte[]> GetBytesAsync(string filename);
        Task DeleteFileAsync(string filename);
    }


}
