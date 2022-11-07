﻿using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public IResult Add(User user)
		{
			ValidationTool.Validate(new UserValidator(), user);
			_userDal.Add(user);
			return new SuccessResult();
		}

		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult();
		}

		public IDataResult<List<User>> GetAll()
		{
			return new SuccessDataResult<List<User>>(_userDal.GetAll());
		}

		public IDataResult<User> GetById(int id)
		{
			return new SuccessDataResult<User>(_userDal.Get(p => p.Id == id));
		}

		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult();
		}
	}
}