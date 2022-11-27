using Microsoft.Extensions.DependencyInjection;
using RestWithASPNETUdemy.Business.Implementations;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Repository.Implementations;
using RestWithASPNETUdemy.Repository;
using RestWithASPNETUdemy.Repository.Generic;
using RestWithASPNETUdemy.Services;
using RestWithASPNETUdemy.Services.Implementations;

namespace RestWithASPNETUdemy.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            #region Business Dependency
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            services.AddScoped<ILoginBusiness, LoginBusinessImplementation>();
            #endregion

            #region Repository Dependency
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
            services.AddScoped<IBookRepository, BookRepositoryImplementation>();
            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion

            #region Services Dependency
            services.AddTransient<ITokenService, TokenService>();

            #endregion
        }
    }
}
