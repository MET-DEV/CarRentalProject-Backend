﻿using DataAccess.Abstract;
using Entities.Concrete;
using MyCore.DataAccess;
using MyCore.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class EfColorDal : EfEntityRepositoryBase<Color, RentACarContext>, IColorDal
    {
       
    }
}
