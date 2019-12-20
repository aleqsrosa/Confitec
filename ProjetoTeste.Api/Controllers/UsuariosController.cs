using Common.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using ProjetoTeste.Core.Filters;
using Common.Interfaces;
using ProjetoTeste.Core.Dto;
using ProjetoTeste.Core.Application;
using System.Threading.Tasks;

namespace ProjetoTeste.Core.Api.Controllers
{
    public class UsuariosController : ApiController
    {
        private HttpResult<UsuariosDto> result;
		private HelperHttpLog httpLog;
		private UsuariosApp app;

        public UsuariosController()
        {
			this.httpLog = new HelperHttpLog();
            this.httpLog.LogRequestIni();
            this.result = new HttpResult<UsuariosDto>();
        }

		[ActionName("DefaultAction")]
		public HttpResponseMessage Get(int id)
		{
			var result = new HttpResult<UsuariosDto>();

			try
			{
				var token = HelperAuth.GetHeaderToken();
				this.app = new UsuariosApp(token);
				var data = this.app.Get(new UsuariosDto { UsuariosId = id});
				this.app.Dispose();
				result.Success(data);
				return Request.CreateResponse(result.StatusCode, result);

			}
			catch (Exception ex)
			{
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);

			}

		}



		[ActionName("DefaultAction")]
		public HttpResponseMessage Get([FromUri]UsuariosFilter filters)
        {
			var result = new HttpResult<UsuariosDto>();

            try
            {
                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
				var searchResult = this.app.GetByFilters(filters);
                result.Summary = searchResult.Summary;
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
                result.Success(searchResult.DataList);
				this.app.Dispose();
                return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
            }
        }

		
		[ActionName("GetReport")]
		public HttpResponseMessage GetReport([FromUri]UsuariosFilter filters)
        {
			var result = new HttpResult<UsuariosDto>();

            try
            {
                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
				var searchResult = this.app.GetReport(filters);
                result.Summary = searchResult.Summary;
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
                result.Success(searchResult.DataList);
				this.app.Dispose();
                return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
            }
        }

		[ActionName("DefaultAction")]
		public HttpResponseMessage Post([FromBody]UsuariosDtoSpecialized model)
        {
            try
            {
                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
                var returnModel = this.app.Save(model);
                this.app.Dispose();
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
				result.Confirms = this.app.ValidationHelper.GetDomainConfirms();
                result.Success(returnModel);
				this.httpLog.LogSerialize(model);
				return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
            }

        }

		
		[ActionName("DefaultAction")]
		public HttpResponseMessage Put([FromBody]UsuariosDtoSpecialized model)
        {
            try
            {
                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
                var returnModel = this.app.SavePartial(model);
                this.app.Dispose();
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
				result.Confirms = this.app.ValidationHelper.GetDomainConfirms();
                result.Success(returnModel);
				this.httpLog.LogSerialize(model);
				return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
            }

        }
		
		[ActionName("DefaultAction")]
		public HttpResponseMessage Delete([FromUri]UsuariosDto filter)
        {
            try
            {
                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
                this.app.Delete(filter);
				this.result.Warnings = this.app.ValidationHelper.GetDomainWarning();
                var result = this.result.Success();
                this.app.Dispose();
				return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
            }
        }
		
		[ActionName("PostMany")]
		public HttpResponseMessage PostMany([FromBody]IEnumerable<UsuariosDtoSpecialized> model)
        {
            try
            {
                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
                var returnModel = this.app.Save(model);
                this.app.Dispose();
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
				result.Confirms = this.app.ValidationHelper.GetDomainConfirms();
                result.Success(returnModel);
				this.httpLog.LogSerialize(model);
				return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
            }

        }

		[ActionName("GetDataListCustom")]
        public HttpResponseMessage GetDataListCustom([FromUri]UsuariosFilter filter)
		{
			var result = new HttpResult<object>();

			try
			{
				var token = HelperAuth.GetHeaderToken();
				this.app = new UsuariosApp(token);
                var searchResult = this.app.GetDataListCustom(filter);
                result.Summary = searchResult.Summary;
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
                result.Success(searchResult.DataList);
				this.app.Dispose();
                return Request.CreateResponse(result.StatusCode, result);

			}
			catch (Exception ex)
			{
				result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
			}

		}

		[ActionName("GetDataCustom")]
        public HttpResponseMessage GetDataCustom([FromUri]UsuariosFilter filter)
		{
			var result = new HttpResult<object>();

			try
			{
				var token = HelperAuth.GetHeaderToken();
				this.app = new UsuariosApp(token);
                var data = this.app.GetDataCustom(filter);
				this.app.Dispose();
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
                result.Success(data);
				return Request.CreateResponse(result.StatusCode, result);

			}
			catch (Exception ex)
			{
				result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
			}

		}

		[ActionName("GetByModel")]
		public HttpResponseMessage GetByModel([FromUri]UsuariosDto model)
        {
            var result = new HttpResult<UsuariosDto>();

            try
            {

                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
                var searchResult = this.app.Get(model);
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
                this.app.Dispose();
                result.Success(searchResult);
				return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
            }

        }

		[ActionName("GetDetails")]
		public HttpResponseMessage GetDetails([FromUri]UsuariosDto model)
        {
            var result = new HttpResult<UsuariosDto>();

            try
            {

                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
                var searchResult = this.app.GetDetails(model);
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
				this.app.Dispose();
                result.Success(searchResult);
				return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
            }

        }

		[ActionName("GetTotalByFilters")]
        public HttpResponseMessage GetTotalByFilters([FromUri]UsuariosFilter filters)
        {
            var result = new HttpResult<int>();

            try
            {
                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
                var searchResult = this.app.GetTotalByFilters(filters);
				result.Warnings = this.app.ValidationHelper.GetDomainWarning();
                result.Success(searchResult);
                this.app.Dispose();
                return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
				return Request.CreateResponse(result.StatusCode, result);
            }
        }

		[ActionName("GetWarnings")]
        public HttpResponseMessage GetWarnings([FromUri]UsuariosFilter filters)
        {
            var result = new HttpResult<UsuariosDto>();

            try
            {
                var token = HelperAuth.GetHeaderToken();
                this.app = new UsuariosApp(token);
                this.app.GetWarnings(filters);
                result.Warnings = this.app.ValidationHelper.GetDomainWarning();
                this.app.Dispose();
                result.Success();
                return Request.CreateResponse(result.StatusCode, result);

            }
            catch (Exception ex)
            {
                result.ReturnCustomException(ex);
                return Request.CreateResponse(result.StatusCode, result);

            }

        }

		protected override void Dispose(bool disposing)
        {
			if (this.app.IsNotNull()) this.app.Dispose(); 
            this.httpLog.LogRequestEnd();
            base.Dispose(disposing);
        }
    }
}
