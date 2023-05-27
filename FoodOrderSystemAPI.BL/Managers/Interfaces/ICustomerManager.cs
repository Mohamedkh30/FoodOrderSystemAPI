using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderSystemAPI.BL;

public interface ICustomerManager
{
    public   Task< int> Register(CustomerToRegister RegisterdCustomer);
    public   Task< string> Login(CustomerToLogin customerToLogin );
    public List<CustomerModel> GetAllCutomers();
    public List<CustomerToRead> ReadAllCutomerProperties();

    public CreditToRead UpdateCardCutomerData(int Customerid, CreditToUpdate creditCard);
    public Location UpdateAddressCutomer(int Customerid, LocationToUpadate NewLocation);
    public  Task<CustomerModel> UpdateCustomerPersonalData(int Customerid, CustomerToUpdatPersonalData UpdatedCustomer);
public List<CustomerModel> GetById( );
    public bool Delete( int CustomerID);
}
