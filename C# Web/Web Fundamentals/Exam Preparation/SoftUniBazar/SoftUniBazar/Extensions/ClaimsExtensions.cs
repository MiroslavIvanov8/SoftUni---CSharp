﻿namespace SoftUniBazar.Extensions
{
    using System.Security.Claims;
    public static class ClaimsExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);

            return userIdClaim?.Value;
        }
    }
}
