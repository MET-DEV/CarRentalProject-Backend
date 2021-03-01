using Entities.Concrete;
using MyCore.Entities.Concrete;
using MyCore.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        User GetByMail(string email);
        List<OperationClaim> GetClaims(User user);
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
    }
}
