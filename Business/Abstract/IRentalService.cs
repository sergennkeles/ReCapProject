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
        IResult Rent(int carId, int customerId);
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
