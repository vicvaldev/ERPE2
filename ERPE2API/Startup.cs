using ERPE2.BL.Implementations.Auth;
using ERPE2.BL.Implementations.Maintainer;
using ERPE2.BL.Interfaces.Auth;
using ERPE2.BL.Interfaces.Maintainer;
using ERPE2.Context.Repository.Implementations;
using ERPE2.Context.Repository.Interfaces;

namespace ERPE2API;

public class Startup
{
    public static void Init(IServiceCollection services)
    {
        InitContext(services);
        InitLogic(services);
    }

    private static void InitContext(IServiceCollection services)
    {
        services.AddScoped<IE2ContextImplementation, E2ContextImplementation>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRolRepository, RolRepository>();
        services.AddScoped<IColorRepository, ColorRepository>();
        services.AddScoped<ICaseTypeRepository, CaseTypeRepository>();
    }

    private static void InitLogic(IServiceCollection services)
    {
        services.AddScoped<IRegisterLogic, RegisterLogic>();
        services.AddScoped<ILoginLogic, LoginLogic>();
        services.AddScoped<IColorLogic, ColorLogic>();
        services.AddScoped<ICaseTypeLogic, CaseTypeLogic>();
    }
}