using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        IResult Add(CreditCard creditCard);
        IResult Delete(CreditCard creditCard);
        
        IDataResult<List<CreditCard>> GetCreditCardByCustomer(int customerId);
        IDataResult<List<CreditCard>> GetCreditCard();
        IDataResult<CreditCard> GetCustomerSelectedCardByCustomerId(int customerId);
    }
}
