using Microsoft.Extensions.DependencyInjection;
using RestWithASPNETUdemy.Business.Implementations;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Repository.Implementations;
using RestWithASPNETUdemy.Repository;

namespace RestWithASPNETUdemy.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            #region Business Dependency
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            #endregion

            #region Repository Dependency
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
            services.AddScoped<IBookRepository, BookRepositoryImplementation>();
            #endregion
        }
    }
}
