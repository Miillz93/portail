using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using portail.Models;


public class AppUserManager : UserManager<User>
{
    public AppUserManager(IUserStore<User> store) : base(store)
    {
    }

    public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
    {
        var manager = new AppUserManager(new UserStore<User>(context.Get<PortailContext>()));
        
        //validation pour les noms d'utilisateur
        manager.UserValidator = new UserValidator<User>(manager)
        {
            AllowOnlyAlphanumericUserNames = false,
            RequireUniqueEmail = true
        };

        // Validation pour les mots de passe
        manager.PasswordValidator = new PasswordValidator
        {
            RequiredLength = 6,
            RequireNonLetterOrDigit = true,
            RequireDigit = true,
            RequireLowercase = true,
            RequireUppercase = true,
        };

        // Configuration verrouillage de l'utilisateur
        manager.UserLockoutEnabledByDefault = true;
        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
        manager.MaxFailedAccessAttemptsBeforeLockout = 5;

        return manager;
    }
}
