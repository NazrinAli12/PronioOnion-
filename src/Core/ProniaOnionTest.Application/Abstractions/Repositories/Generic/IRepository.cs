﻿using ProniaOnionTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnionTest.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll(bool isTracking = false, bool ignoreQuery = false, params string[] includes);
        IQueryable<T> GetAllWhere(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderExpression = null, bool isDeccending = false, int skip = 0, int take = 0, bool isTracking = false,bool ignoreQuery=false, params string[] includes);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id, bool isTracking = false, bool ignoreQuery = false, params string[] includes);
        Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression, int id, bool isTracking = false, bool ignoreQuery = false, params string[] includes);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDelete(T entity);
        void ReverseDelete(T entity);
        Task SaveChangesAsync();
    }
}
