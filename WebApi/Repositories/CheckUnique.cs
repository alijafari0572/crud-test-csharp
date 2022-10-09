using DataLayer;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class CheckUnique:ICheckUnique
    {
        private readonly WebApiDBContext _context;

        public CheckUnique(WebApiDBContext context)
        {
            _context = context;
        }

        public bool checkunique(Customer_Model customerModel)
        {
            var firstname = customerModel.FirstName;
            var lastname = customerModel.LastName;
            var dob = customerModel.DoB;
            var email = customerModel.Email;
            if(_context.Customers.Any(a=>a.FirstName==firstname))
                return true;
            if (_context.Customers.Any(a => a.LastName == lastname))
                return true;
            if (_context.Customers.Any(a => a.DoB == dob))
                return true;
            if (_context.Customers.Any(a => a.Email == email))
                return true;
            return false;
        }
    }
}
