using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IUserService:IBaseService<User>
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        User GetByMail(string email);

        IDataResult<User> GetByUserId(int userId);
        IDataResult<List<User>> GetAll();
        
         IDataResult<User> GetByUserMail(string email);
       
    }
}
