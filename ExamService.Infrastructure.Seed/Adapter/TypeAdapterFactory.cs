namespace ExamService.Infrastructure.Seed.Adapter
{
    public static class TypeAdapterFactory
    {
        #region Members
        static ITypeAdapterFactory _currentTypeAdapterFactory = null;
        #endregion

        #region Public Static Methods
        public static void SetCurrent(ITypeAdapterFactory adapterFactory)
        {
            _currentTypeAdapterFactory = adapterFactory;
        }
        
        public static ITypeAdapter CreateAdapter()
        {
            return _currentTypeAdapterFactory.Create();
        }
        #endregion
    }
}