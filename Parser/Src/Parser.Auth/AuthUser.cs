﻿using System;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Parser.Data.Models;

namespace Parser.Auth
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class AuthUser : IdentityUser
    {
        public Guid? ParserUserId { get; set; }

        public virtual ParserUser ParserUser { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AuthUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
