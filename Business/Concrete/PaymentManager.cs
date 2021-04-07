using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        public IResult Add(Payment entity)
        {
            entity.PaymentDate = DateTime.Now;
            _paymentDal.Add(entity);
            return new SuccessResult("Ödeme Başarılı");
        }

        public IResult Delete(Payment entity)
        {
            _paymentDal.Delete(entity);
            return new SuccessResult("Ödeme kaydı  silindi.");
        }

        public IResult Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
