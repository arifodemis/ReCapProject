﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
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

		[SecuredOperation("user.add,admin")]

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

		public IDataResult<User> GetByMail(string email)
		{
			return new SuccessDataResult<User>(_userDal.Get(p => p.Email == email));
		}

		public List<OperationClaim> GetClaims(User user)
		{
			return _userDal.GetClaims(user);
		}

		
		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult();
		}

		IDataResult<List<OperationClaim>> IUserService.GetClaims(User user)
		{
			return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
		}
	}
}
