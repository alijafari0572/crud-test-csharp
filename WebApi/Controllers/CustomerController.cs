using System.Reflection.Metadata.Ecma335;
using DataLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly WebApiDBContext _context;
    private readonly ICheckEmail _checkEmail;
    private readonly ICheckPhonenumber _checkPhonenumber;
    private readonly ICheckBankAccountNumber _bankAccountNumber;
    private readonly ICheckUnique _checkUnique;



    public CustomerController(WebApiDBContext context,
        ICheckEmail checkEmail,
        ICheckPhonenumber checkPhonenumber,
        ICheckBankAccountNumber bankAccountNumber,
        ICheckUnique checkUnique)
    {
        _context = context;
        _checkEmail = checkEmail;
        _checkPhonenumber = checkPhonenumber;
        _bankAccountNumber = bankAccountNumber;
        _checkUnique = checkUnique;
        if (_context.Customers.Count() == 0)
        {
            _context.Customers.Add(new Customer
            {
                FirstName = "Ali",
                LastName = "Jafari",
                DoB = DateTime.Now,
                PhoneNumber = "989351623816",
                Email = "alijafari0572@gmail",
                BankAccountNumber = "1111111111111111111"
            });
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public List<Customer> Get()
    {
        return _context.Customers.ToList();
    }

    [HttpPost]
    public IActionResult Create([FromBody] Customer_Model customerViewModel)
    {
        if (_checkUnique.checkunique(customerViewModel))
            return Content("one of Firstname, Lastname, DateOfBirth or Email is not Unique");
        if (!_checkEmail.CheckValidEmail(customerViewModel))
            return Content("Email is not valid");
        if (!_checkPhonenumber.CheckValidPhoneNumber(customerViewModel))
            return Content("Phonenumber is not valid");
        if (!_bankAccountNumber.CheckValidBankAccountNumber(customerViewModel))
            return Content("BankAccountNumber is not valid");

        _context.Customers.Add(new Customer()
        {
            FirstName = customerViewModel.FirstName,
            LastName = customerViewModel.LastName,
            DoB = customerViewModel.DoB,
            PhoneNumber = customerViewModel.PhoneNumber,
            Email = customerViewModel.Email,
            BankAccountNumber = customerViewModel.BankAccountNumber,
        });
        _context.SaveChanges();
        return Content("The customer successfully added");


    }

    [HttpPut("{id:int}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Customer_Model customerViewModel)
    {
        var obj = _context.Customers.FirstOrDefault(x => x.Id == id);

        obj.FirstName = customerViewModel.FirstName;
        obj.LastName = customerViewModel.LastName;
        obj.DoB = customerViewModel.DoB;
        obj.BankAccountNumber = customerViewModel.BankAccountNumber;
        obj.Email = customerViewModel.Email;

        if (_checkUnique.checkunique(customerViewModel))
            return Content("one of Firstname, Lastname, DateOfBirth or Email is not Unique");
        if (!_checkEmail.CheckValidEmail(customerViewModel))
            return Content("Email is not valid");
        if (!_checkPhonenumber.CheckValidPhoneNumber(customerViewModel))
            return Content("Phonenumber is not valid");
        if (!_bankAccountNumber.CheckValidBankAccountNumber(customerViewModel))
            return Content("BankAccountNumber is not valid");

        _context.Customers.Update(obj);
        _context.SaveChanges();

        return Content("The customer successfully updated");
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var Deletitem = _context.Customers.FirstOrDefault(a => a.Id == id);
        if (Deletitem != null)
        {
            _context.Customers.Remove(Deletitem);
            _context.SaveChanges();
            return Content("The customer successfully removed");
        }

        return Content("object not found");

    }
}
