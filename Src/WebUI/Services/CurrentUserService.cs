using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebUI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = "no users implemented";
            IsAuthenticated = UserId != null;
        }

        public string UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
