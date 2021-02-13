using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
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

        public IResult Rent(int carId, int customerId)
        {
            var result = _rentalDal.GetAll(r => r.CarId== carId && r.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.ErrorCarRent);
            }

            _rentalDal.Add(new Rental
            {
                CarId = carId,
                CustomerId = customerId,
                RentDate = DateTime.Now,
                ReturnDate = null
            });
            return new SuccessResult(Messages.CarRented);
        }
    }
}
