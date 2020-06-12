using ExamService.Infrastructure.Seed.Adapter;
using AutoMapper;
using System;
using System.Linq;

namespace ExamService.Infrastructure.Main.Adapter
{
    public class AutomapperTypeAdapterFactory : ITypeAdapterFactory
    {
        private IMapper _mapper;

        #region Constructor
        public AutomapperTypeAdapterFactory()
        {
            var profiles = from t in AppDomain.CurrentDomain.GetAssemblies().Where(ass => ass.IsDynamic == false)
                           from p in t.GetTypes()
                           where p.IsSubclassOf(typeof(Profile))
                           select p;

            var configuration = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    if (profile.FullName != "AutoMapper.Configuration.MapperConfigurationExpression+NamedProfile")
                    {
                        Profile objectProfile = (Profile)Activator.CreateInstance(profile);
                        cfg.AddProfile(objectProfile);
                    }
                }
            });

            _mapper = configuration.CreateMapper();
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        public AutomapperTypeAdapterFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion

        #region ITypeAdapterFactory Members
        public ITypeAdapter Create()
        {
            return new AutomapperTypeAdapter(_mapper);
        }
        #endregion
    }
}