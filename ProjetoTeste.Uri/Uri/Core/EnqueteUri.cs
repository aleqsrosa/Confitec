using Common.API;
using Common.Interfaces;
using System.Configuration;
using CNA.Talk.Core.Dto;
using System.Collections.Generic;

namespace CNA.Talk.Core.Uri.Api
{
 public class EnqueteUri
    {
        private string endPointApiCore;

        public EnqueteUri()
        {
            this.endPointApiCore = ConfigurationManager.AppSettings["endPointApiCore"];
        }

        public HttpResult<EnqueteDtoSpecializedResult> Get(string token)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<EnqueteDtoSpecializedResult>(token, string.Format("api/Enquete"));
			return response;
        }

		public HttpResult<EnqueteDtoSpecialized> GetByModel(string token, EnqueteDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<EnqueteDtoSpecialized, EnqueteDto>(token, "api/Enquete/GetByModel", dto);
			return response;
        }

		public HttpResult<EnqueteDtoSpecialized> Get(string token, int id)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<EnqueteDtoSpecialized>(token, string.Format("api/Enquete/{0}", id));
			return response;
        }

		public HttpResult<T> Get<T>(string token, int id)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T>(token, string.Format("api/Enquete/{0}", id));
			return response;
        }

		public HttpResult<EnqueteDtoSpecializedResult> Get(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<EnqueteDtoSpecializedResult, IFilter>(token, "api/Enquete", filter);
            return response;
        }

		public HttpResult<EnqueteDto> GetWarnings(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<EnqueteDto, IFilter>(token, "api/Enquete/GetWarnings", filter);
            return response;
        }

		public HttpResult<EnqueteDtoSpecializedReport> GetReport(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<EnqueteDtoSpecializedReport, IFilter>(token, "api/Enquete/GetReport", filter);
            return response;
        }

		public HttpResult<dynamic> GetDataListCustom(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<dynamic, IFilter>(token, "api/Enquete/GetDataListCustom", filter);
			return response;
        }

		public HttpResult<dynamic> GetDataCustom(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<dynamic, IFilter>(token, "api/Enquete/GetDataCustom", filter);
			return response;
        }

        public HttpResult<int> GetTotalByFilters(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<int, IFilter>(token, "api/Enquete/GetTotalByFilters", filter);
            return response;
        }

		public HttpResult<T> Get<T>(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T, IFilter>(token, "api/Enquete", filter);
            return response;
        }

		public HttpResult<T> GetByModel<T>(string token, EnqueteDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T, EnqueteDto>(token, "api/Enquete/GetByModel", dto);
			return response;
        }

		public HttpResult<EnqueteDtoSpecializedDetails> GetDetails(string token, EnqueteDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<EnqueteDtoSpecializedDetails, EnqueteDto>(token, "api/Enquete/GetDetails", dto);
			return response;
        }

		public HttpResult<T> GetDetails<T>(string token, EnqueteDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T, EnqueteDto>(token, "api/Enquete/GetDetails", dto);
			return response;
        }

		public HttpResult<T> GetReport<T>(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T, IFilter>(token, "api/Enquete/GetReport", filter);
            return response;
        }

		public HttpResult<EnqueteDto> Post(string token,EnqueteDtoSpecialized dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Post<EnqueteDtoSpecialized, EnqueteDto>(token, "api/Enquete/", dto);
            return response;
        }

		public HttpResult<EnqueteDto> Post(string token,IEnumerable<EnqueteDtoSpecialized> dtos)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Post<IEnumerable<EnqueteDtoSpecialized>, EnqueteDto>(token, "api/Enquete/PostMany/", dtos);
            return response;
        }

		public HttpResult<EnqueteDto> Post(string token,IEnumerable<EnqueteDto> dtos)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Post<IEnumerable<EnqueteDto>, EnqueteDto>(token, "api/Enquete/PostMany/", dtos);
            return response;
        }

		public HttpResult<EnqueteDto> Post(string token,EnqueteDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Post<EnqueteDto, EnqueteDto>(token, "api/Enquete/", dto);
            return response;
        }

		public HttpResult<EnqueteDto> Put(string token,EnqueteDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Put<EnqueteDto, EnqueteDto>(token, "api/Enquete/", dto);
            return response;
        }

		public HttpResult<EnqueteDto> Delete(string token,EnqueteDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Delete<EnqueteDto, EnqueteDto>(token, "api/Enquete/", dto);
            return response;
        }
    
    }
}