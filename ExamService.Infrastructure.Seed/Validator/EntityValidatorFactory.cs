﻿namespace ExamService.Infrastructure.Seed.Validator
{
    public static class EntityValidatorFactory
    {
        #region Members
        static IEntityValidatorFactory _factory = null;
        #endregion

        #region Public Methods
        public static void SetCurrent(IEntityValidatorFactory factory)
        {
            _factory = factory;
        }

        public static IEntityValidator CreateValidator()
        {
            return (_factory != null) ? _factory.Create() : null;
        }
        #endregion
    }
}