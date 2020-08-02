using Microsoft.AspNetCore.Identity;
using RiSAT.Eshop.Application.Common.Models;
using System.Linq;

namespace RiSAT.Eshop.Infrastructure.Identity
{
    public static class IdentityResultExtensions
    {
        public static Result ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? Result.Success()
                : Result.Failure(result.Errors.Select(e => e.Description));
        }
    }
}