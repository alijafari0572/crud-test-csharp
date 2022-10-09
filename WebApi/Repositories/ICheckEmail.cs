using WebApi.Models;
using System.Threading.Tasks;
namespace WebApi.Repositories
{
    public interface ICheckEmail
    {
        public bool CheckValidEmail (Customer_Model customerModel);

    }
}
