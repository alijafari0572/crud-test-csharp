using WebApi.Models;

namespace WebApi.Repositories
{
    public interface ICheckUnique
    {
        public bool checkunique(Customer_Model customerModel);
    }
}
