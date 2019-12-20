using Cna.Erp.Domain.Cache;
using Cna.Erp.Domain.Helpers;
using Common.Domain;
using Common.Domain.Interfaces;

namespace CNA.Talk.Core.Domain
{
    public abstract class ConfigDomainCore : DomainBase
    {
		
		private CurrentUser _user;
        private CurrentUser _userMinimal;

		public void Config(Common.Domain.Interfaces.ICache cache)
        {

        }

		public CurrentUser ValidateAuthSimple(string token, ICache cache)
        {
            if (_userSimple.IsNull())
                _userSimple = HelperValidateAuth.ValidateAuthSimple(token, cache);

            return _userSimple;
        }

        public CurrentUser ValidateAuthModules(string token, ICache cache)
        {
            if (_userModules.IsNull())
                _userModules = HelperValidateAuth.ValidateAuthModules(token, cache);

            return _userModules;
        }

        public CurrentUser ValidateAuthParameters(string token, ICache cache)
        {
            if (_userParameters.IsNull())
                _userParameters = HelperValidateAuth.ValidateAuthParameters(token, cache);

            return _userParameters;
        }

        public CurrentUser ValidateAuthFull(string token, ICache cache)
        {
            if (_userFull.IsNull())
                _userFull = HelperValidateAuth.ValidateAuthFull(token, cache);

            return _userFull;
        }

		public override void Dispose()
        {
        
		}
    }
}
