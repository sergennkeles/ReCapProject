using DataAccess.Abstract;
using Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfRentalDal:EfEntityRepositoryBase<Rental,RentACarContext>,IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from rent in context.Rentals
                             join car in context.Cars
                             on  rent.CarId equals car.Id
                             join customer in context.Customers
                             on rent.CustomerId equals customer.CustomerId
                             orderby (rent.Id)
                             select new RentalDetailDto
                             {
                                Id=rent.Id,
                                CarId=car.Id,
                                CustomerId=customer.CustomerId,
                                UserId=customer.UserId,
                                RentDate=rent.RentDate,
                                ReturnDate=rent.ReturnDate
                                
                             };
                return result.ToList();
            }
        }
    }
}
