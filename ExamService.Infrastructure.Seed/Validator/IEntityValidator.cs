﻿using System;
using System.Collections.Generic;

namespace ExamService.Infrastructure.Seed.Validator
{
    public interface IEntityValidator
    {
        bool IsValid<TEntity>(TEntity item) where TEntity : class;
        IEnumerable<String> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class;
    }
}