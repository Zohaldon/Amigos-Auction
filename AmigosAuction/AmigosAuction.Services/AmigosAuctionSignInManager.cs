using AmigosAuction.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AmigosAuction.Services
{
    public class AmigosAuctionSignInManager : SignInManager<AmigosAuctionUser, string>
    {
        public AmigosAuctionSignInManager(AmigosAuctionUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(AmigosAuctionUser user)
        {
            return user.GenerateUserIdentityAsync((AmigosAuctionUserManager)UserManager);
        }

        public static AmigosAuctionSignInManager Create(IdentityFactoryOptions<AmigosAuctionSignInManager> options, IOwinContext context)
        {
            return new AmigosAuctionSignInManager(context.GetUserManager<AmigosAuctionUserManager>(), context.Authentication);
        }
    }
}
