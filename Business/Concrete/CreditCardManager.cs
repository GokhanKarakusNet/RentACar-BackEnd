using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }
        public IResult Add(CreditCard creditCard)
        {
            creditCard.SelectedCard = SelectedCardOperations(creditCard);
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAddedSuccessfully);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeletedSuccessfully);
        }

        public IDataResult<List<CreditCard>> GetCreditCardByCustomer(int customerId)
        {
            var result = _creditCardDal.GetAll(c => c.CustomerId == customerId);
            return new SuccessDataResult<List<CreditCard>>(result, Messages.GetUserCardListSuccessfully);
        }

        public IDataResult<List<CreditCard>> GetCreditCard()
        {
            var result = _creditCardDal.GetAll();
            return new SuccessDataResult<List<CreditCard>>(result);
        }

        
        public IDataResult<CreditCard> GetCustomerSelectedCardByCustomerId(int customerId)
        {
            return new SuccessDataResult<CreditCard>(
                _creditCardDal.GetAll(c => c.SelectedCard == true && c.CustomerId == customerId)
                    .Single(), Messages.SelectedCardGetsSuccessfully);


            //var result = _creditCardDal.Get(card => card.SelectedCard == true && card.CustomerId == customerId);
            //return new SuccessDataResult<CreditCard>(result, Messages.SelectedCardGetsSuccessfully);

        }

       private bool SelectedCardOperations(CreditCard creditCard)
        {
            var selectedCardIndex = _creditCardDal.GetAll(c => c.CustomerId == creditCard.CustomerId && c.SelectedCard);

            if (selectedCardIndex.Count == 0)
            {
                return true;
            }
            if (creditCard.SelectedCard && selectedCardIndex.Count > 0)
            {
                selectedCardIndex.Find(c => c.SelectedCard);
                foreach (var selectedCardToFalse in selectedCardIndex)
                {
                    selectedCardToFalse.SelectedCard = false;
                    _creditCardDal.Update(selectedCardToFalse);
                }

                return true;
            }
            return false;
        }
    }
}