using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
     public  interface IRentalService
    {
        // IBaseService' bilerek kullanmadım. Sadece Add operasyonunu kullanacağım için Add() operasyonunu oluşturdum.
        IResult Add(Rental rental);
        
    }
}
