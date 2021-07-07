using System;
using System.Linq;
using FluentValidation;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace Incremental.Common.Validation
{
    public static class Validators
    {
        public static IRuleBuilderOptions<T, Guid> EntityMustExist<T, TEntity>(this IRuleBuilder<T, Guid> ruleBuilder, DbContext dbContext) where TEntity : class
        {
            return ruleBuilder.MustAsync(async (id, cancellationToken) =>
            {
                return await dbContext.Set<TEntity>().FindAsync(new object[] {id}, cancellationToken) is not null;
            }).WithMessage(nameof(EntityMustExist).Humanize(LetterCasing.Sentence));
        }
        
        public static IRuleBuilderOptions<T, Guid> EntityMustNotExist<T, TEntity>(this IRuleBuilder<T, Guid> ruleBuilder, DbContext dbContext) where TEntity : class
        {
            return ruleBuilder.MustAsync(async (id, cancellationToken) =>
            {
                return await dbContext.Set<TEntity>().FindAsync(new object[] {id}, cancellationToken) is null;
            }).WithMessage(nameof(EntityMustNotExist).Humanize(LetterCasing.Sentence));
        }
    }
}