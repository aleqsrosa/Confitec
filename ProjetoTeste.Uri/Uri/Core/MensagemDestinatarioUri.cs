using Common.API;
using Common.Interfaces;
using System.Configuration;
using CNA.Talk.Core.Dto;
using System.Collections.Generic;

namespace CNA.Talk.Core.Uri.Api
{
 public class MensagemDestinatarioUri
    {
        private string endPointApiCore;

        public MensagemDestinatarioUri()
        {
            this.endPointApiCore = ConfigurationManager.AppSettings["endPointApiCore"];
        }

        public HttpResult<MensagemDestinatarioDtoSpecializedResult> Get(string token)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<MensagemDestinatarioDtoSpecializedResult>(token, string.Format("api/MensagemDestinatario"));
			return response;
        }

		public HttpResult<MensagemDestinatarioDtoSpecialized> GetByModel(string token, MensagemDestinatarioDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<MensagemDestinatarioDtoSpecialized, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/GetByModel", dto);
			return response;
        }

		public HttpResult<MensagemDestinatarioDtoSpecialized> Get(string token, int id)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<MensagemDestinatarioDtoSpecialized>(token, string.Format("api/MensagemDestinatario/{0}", id));
			return response;
        }

		public HttpResult<T> Get<T>(string token, int id)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T>(token, string.Format("api/MensagemDestinatario/{0}", id));
			return response;
        }

		public HttpResult<MensagemDestinatarioDtoSpecializedResult> Get(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<MensagemDestinatarioDtoSpecializedResult, IFilter>(token, "api/MensagemDestinatario", filter);
            return response;
        }

		public HttpResult<MensagemDestinatarioDto> GetWarnings(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<MensagemDestinatarioDto, IFilter>(token, "api/MensagemDestinatario/GetWarnings", filter);
            return response;
        }

		public HttpResult<MensagemDestinatarioDtoSpecializedReport> GetReport(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<MensagemDestinatarioDtoSpecializedReport, IFilter>(token, "api/MensagemDestinatario/GetReport", filter);
            return response;
        }

		public HttpResult<dynamic> GetDataListCustom(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<dynamic, IFilter>(token, "api/MensagemDestinatario/GetDataListCustom", filter);
			return response;
        }

		public HttpResult<dynamic> GetDataCustom(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<dynamic, IFilter>(token, "api/MensagemDestinatario/GetDataCustom", filter);
			return response;
        }

        public HttpResult<int> GetTotalByFilters(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<int, IFilter>(token, "api/MensagemDestinatario/GetTotalByFilters", filter);
            return response;
        }

		public HttpResult<T> Get<T>(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T, IFilter>(token, "api/MensagemDestinatario", filter);
            return response;
        }

		public HttpResult<T> GetByModel<T>(string token, MensagemDestinatarioDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/GetByModel", dto);
			return response;
        }

		public HttpResult<MensagemDestinatarioDtoSpecializedDetails> GetDetails(string token, MensagemDestinatarioDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<MensagemDestinatarioDtoSpecializedDetails, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/GetDetails", dto);
			return response;
        }

		public HttpResult<T> GetDetails<T>(string token, MensagemDestinatarioDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/GetDetails", dto);
			return response;
        }

		public HttpResult<T> GetReport<T>(string token, IFilter filter)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Get<T, IFilter>(token, "api/MensagemDestinatario/GetReport", filter);
            return response;
        }

		public HttpResult<MensagemDestinatarioDto> Post(string token,MensagemDestinatarioDtoSpecialized dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Post<MensagemDestinatarioDtoSpecialized, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/", dto);
            return response;
        }

		public HttpResult<MensagemDestinatarioDto> Post(string token,IEnumerable<MensagemDestinatarioDtoSpecialized> dtos)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Post<IEnumerable<MensagemDestinatarioDtoSpecialized>, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/PostMany/", dtos);
            return response;
        }

		public HttpResult<MensagemDestinatarioDto> Post(string token,IEnumerable<MensagemDestinatarioDto> dtos)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Post<IEnumerable<MensagemDestinatarioDto>, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/PostMany/", dtos);
            return response;
        }

		public HttpResult<MensagemDestinatarioDto> Post(string token,MensagemDestinatarioDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Post<MensagemDestinatarioDto, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/", dto);
            return response;
        }

		public HttpResult<MensagemDestinatarioDto> Put(string token,MensagemDestinatarioDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Put<MensagemDestinatarioDto, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/", dto);
            return response;
        }

		public HttpResult<MensagemDestinatarioDto> Delete(string token,MensagemDestinatarioDto dto)
        {
            var request = new HelperHttp(endPointApiCore);
            var response = request.Delete<MensagemDestinatarioDto, MensagemDestinatarioDto>(token, "api/MensagemDestinatario/", dto);
            return response;
        }
    
    }
}