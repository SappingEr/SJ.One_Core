﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SJ.One_Core.Data.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        int Add(T entity);
        //Task AddAsync(T entity);

        int Add(IList<T> entities);

        int Update(T entity);
        int Update(IList<T> entities);
        int Delete(T entity);
        T GetOne(int? id);
        List<T> GetSome(Expression<Func<T, bool>> where);
        List<T> GetAll();
        List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending);
        List<T> ExecuteQuery(string sql);
        List<T> ExecuteQuery(string sql, object[] sqlParametersObjects);
    }
}
