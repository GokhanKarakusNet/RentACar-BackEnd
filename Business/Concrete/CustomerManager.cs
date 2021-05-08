using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
   public class CustomerManager:ICustomerService
   {
       private ICustomerDal _customerDal;

       public CustomerManager(ICustomerDal customerDal)
       {
           _customerDal = customerDal;
       }

       [CacheAspect]
       public IDataResult<List<Customer>> GetAll()
       {
           return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.GetAllCustomersSuccessfully);
       }

       [CacheAspect]
       public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
        }

       public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
       {
           return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
       }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAddedSuccessfully);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdatedSuccessfully);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(int customerId)
        {
            _customerDal.Delete(new Customer{CustomerId = customerId});
            return new SuccessResult(Messages.CustomerDeletedSuccessfully);
        }

        public IDataResult<Customer> GetByUserId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == id));
        }
    }
}
