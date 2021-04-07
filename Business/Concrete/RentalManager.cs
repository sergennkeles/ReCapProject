using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
          
            _rentalDal = rentalDal;
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.CarRented);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetail());
        }
        [ValidationAspect(typeof(RentalValidator))] //Validasyon işlemi
        public IResult Rent(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckCarIdandReturnDate(rental.CarId));

            if(result!=null)
            {
                return result;
            }
             _rentalDal.Add(rental);
            return new SuccessResult(Messages.CarRented);
        }



        public IDataResult<List<RentalDetailDto>> GetRentalById(int rentId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetail(r=>r.Id==rentId));
        }


        private IResult CheckCarIdandReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.ErrorCarRent);
            }
            return new SuccessResult();
        }

        public IResult CarIsReturned(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                Rental result = _rentalDal.Get(r => r.CarId == carId && r.ReturnDate == null);
                result.ReturnDate = DateTime.Now;
                _rentalDal.Update(result);
            }
            return new SuccessResult(Messages.RentalUpdated); ;
        }

        public bool IsCarAvailable(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId && r.ReturnDate == null
                             select r;
                return (result.Count() == 0) ? false : true;
            }
        }
    }
}
