using AutoMapper;
using BookStore.Books;
using Volo.Abp.AutoMapper;

namespace BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()

    {
        CreateMap<Book, BooksDto>().Ignore(x => x.Base64);
        CreateMap<CreateBookDto, Book>().ReverseMap();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
