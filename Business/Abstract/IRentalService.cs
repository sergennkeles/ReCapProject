using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
     public  interface IRentalService
    {
        // IBaseService' bilerek kullanmadım. Sadece Add operasyonunu kullanacağım için Add() operasyonunu oluşturdum.
        IResult Update(Rental rental);
        IResult Rent(Rental rental);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<RentalDetailDto>> GetRentalById(int rentId);
        IResult CarIsReturned(int carId);
        bool IsCarAvailable(int carId);
    }
}
