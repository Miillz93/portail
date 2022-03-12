using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using portail.Models;


public class AppUserStore: UserStore<User>
{
    public AppUserStore(PortailContext context) : base(context)
    {
    }
}
