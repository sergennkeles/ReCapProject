using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;
        public UserManager(IUserDal userDal)
        {
            _userdal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))] //Validasyon işlemi
        public IResult Add(User entity)
        {
            _userdal.Add(entity);
            return new SuccessResult(Messages.AddedUser);
        }

        public IResult Delete(User entity)
        {
            _userdal.Delete(entity);
            return new SuccessResult(Messages.DeletedUser);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userdal.GetById(m => m.Email == email)); //GetById ismine takılma
            // IEntityRepository de GetById olarak yazmışım. Ama illaki id'ye göre sorgulama yapmama gerek yok :)
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userdal.GetClaims(user),Messages.ClaimsListed);
        }

        public IResult Update(User entity)
        {
            _userdal.Update(entity);
            return new SuccessResult(Messages.UpdatedUser);
        }
}
}
