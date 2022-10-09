
using PhoneNumbers;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class CheckPhonenumber: ICheckPhonenumber
    {
        public bool CheckValidPhoneNumber(Customer_Model customerModel)
        {
            var IsViablePhoneNumber = PhoneNumberUtil.IsViablePhoneNumber(customerModel.PhoneNumber);

            return IsViablePhoneNumber;
        }
    }
}
