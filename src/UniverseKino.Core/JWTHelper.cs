using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace UniverseKino.Core
{
    public class JWTHelper
    {
        public string JWTSecretKey { get; set; }

        public SymmetricSecurityKey GetSecretKey() =>
             new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTSecretKey));
    }
}