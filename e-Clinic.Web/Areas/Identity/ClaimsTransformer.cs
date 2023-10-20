using System.Security.Claims;
using e_Clinic.DataAccess.Entities.Identity;
using e_Clinic.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace e_Clinic.Web.Areas.Identity
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly IUserStore<ApplicationUser> _userStore;

        public ClaimsTransformer(IUserStore<ApplicationUser> userStore)
        {
            _userStore = userStore;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var clonedPrincipal = principal.Clone();
            if (clonedPrincipal.Identity == null) return clonedPrincipal;

            var identity = (ClaimsIdentity) clonedPrincipal.Identity;
            var existingClaim = identity.Claims.FirstOrDefault(c => c.Type == EClinicClaimTypes.FirstName);
            if (existingClaim == null) 
            {
                var nameIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (nameIdClaim != null)
                {
                    var user = await _userStore.FindByIdAsync(nameIdClaim.Value, CancellationToken.None);
                    if (user is { FirstName: not null }) identity.AddClaim(new Claim(EClinicClaimTypes.FirstName, user.FirstName));
                }

            }

            existingClaim = identity.Claims.FirstOrDefault(c => c.Type == EClinicClaimTypes.LastName);
            if (existingClaim == null)
            {
                var nameIdClaim = identity.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                if (nameIdClaim != null)
                {
                    var user = await _userStore.FindByIdAsync(nameIdClaim.Value, CancellationToken.None);
                    if (user is { LastName: not null }) identity.AddClaim(new Claim(EClinicClaimTypes.LastName, user.LastName));
                }
            }

            return clonedPrincipal;
        }
    }
}