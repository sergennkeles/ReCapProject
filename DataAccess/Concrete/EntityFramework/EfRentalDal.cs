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
                             join brand in context.Brands 
                             on car.BrandId equals brand.BrandId
                             join customer in context.Customers
                             on rent.CustomerId equals customer.CustomerId
                             join user in context.Users on customer.UserId equals user.Id
                             orderby (rent.Id)
                             select new RentalDetailDto
                             {
                                Id=rent.Id,
                                BrandName=brand.BrandName,
                                FirstName=user.FirstName,
                                LastName=user.LastName,
                                RentDate=rent.RentDate,
                                ReturnDate=rent.ReturnDate
                                
                             };
                return result.ToList();
            }
        }
    }
}
