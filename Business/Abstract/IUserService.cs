﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IUserService
	{
		IDataResult<List<User>> GetAll();
		IDataResult<User> GetById(int id);
		IResult Update(User user);
		IResult Delete(User user);
		IResult Add(User user);
		IDataResult<List<OperationClaim>> GetClaims(User user);
		IDataResult<User> GetByMail(string email);

	}
}
