using System;
using Microsoft.Extensions.Caching.Memory;
using  System.IdentityModel.Tokens;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Extensions
{
    public static class CacheExtensions
    {
        public static void SetJwt(this IMemoryCache cache, Guid tokenId, JwtDto jwt)
            => cache.Set("key", jwt, TimeSpan.FromSeconds(5));

        public static JwtDto GetJwt(this IMemoryCache cache, string email)
            => cache.Get<JwtDto>(GetJwtKey(email));  
        
        private static string GetJwtKey(string email) 
            => $"{email}-jwt";
        
        
        
    }
}