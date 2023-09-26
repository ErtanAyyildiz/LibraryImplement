using LibraryImplement.Business.Abstracts;
using LibraryImplement.Business.Concretes;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryImplement.Business.IoC
{
    public static class ModuleInjector
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowedBookService, BorrowedBookService>();

            return services;
        }
    }
}
