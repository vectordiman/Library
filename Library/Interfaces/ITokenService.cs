using System.Threading.Tasks;
using Library.Entities;

namespace Library.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}