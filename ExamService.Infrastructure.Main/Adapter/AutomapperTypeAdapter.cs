using ExamService.Infrastructure.Seed.Adapter;
using AutoMapper;

namespace ExamService.Infrastructure.Main.Adapter
{
    public class AutomapperTypeAdapter : ITypeAdapter
    {
        private IMapper _mapper;

        #region Constructor
        public AutomapperTypeAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        #region ITypeAdapter Members
        public TTarget Adapt<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            return _mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Adapt<TTarget>(object source) where TTarget : class, new()
        {
            return _mapper.Map<TTarget>(source);
        }

        #endregion
    }
}