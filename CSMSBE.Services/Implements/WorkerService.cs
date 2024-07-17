using CSMS.Entity.IdentityAccess;
using CSMS.Model.User;
using CSMSBE.Services.BaseServices.Interfaces;
using CSMSBE.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CSMSBE.Services.Implements
{
    public class WorkerService : IWorkerService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkerService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public CurrentUserDTO GetCurrentUser()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims;
            var userId = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == null)
            {
                foreach (var claim in claims)
                {
                    Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
                }

                throw new Exception("User ID claim not found");
            }

            var user = _userManager.Users.Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .Where(u => u.Id == userId).Select(e => new CurrentUserDTO
                {
                    Id = e.Id,
                    UserName = e.UserName,
                    Email = e.Email,
                    FullName = e.FullName,
                    UserType = e.UserType,
                    Roles = e.UserRoles.Select(c => new RoleDTO
                    {
                        Id = c.Role.Id,
                        Code = c.Role.Code
                    }).ToList()
                }).FirstOrDefault();
            return user;
        }
    }
}
