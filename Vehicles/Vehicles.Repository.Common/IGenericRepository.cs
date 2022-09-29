﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles.Model;
using Vehicles.Model.Common;

namespace Vehicles.Repository.Common
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		T GetById(object id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(T entity);
		IQueryable<T> Table { get; }
	}
}
