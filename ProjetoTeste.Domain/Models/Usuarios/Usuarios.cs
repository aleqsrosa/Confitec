using System;
using System.Linq;
using Common.Domain;
using Common.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using ProjetoTeste.Core.Filters;
using Common.Models;
using System.Threading.Tasks;

namespace ProjetoTeste.Core.Domain
{
	public partial class Usuarios : DomainBase, IDisposable, IDomainCrud<Usuarios>
	{
        protected IRepository<Usuarios> rep;
		protected ICache cache;
        public Usuarios(IRepository<Usuarios> rep, ICache cache):this()
        {
            this.rep = rep;
            this.cache = cache;
			this.Init();
        }

        public int UsuariosId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Escolaridade { get; set; }


        public virtual void Warnings(UsuariosFilter filters)
        {
            ValidationHelper.AddDomainWarning<Usuarios>("");
        }

        public IQueryable<Usuarios> GetAll(params Expression<Func<Usuarios, object>>[] includes)
        {
            return this.rep.GetAll(includes);
        }
		
		public Usuarios GetFromContext(Usuarios model)
        {
			return this.rep.Get(model.UsuariosId);
        }

		public int Total()
        {
            return this.rep.GetAll().Count();
        }

		protected IQueryable<Usuarios> SimpleFilters(UsuariosFilter filters,IQueryable<Usuarios> queryBase)
        {

			var queryFilter = queryBase;

            if (filters.UsuariosId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UsuariosId == filters.UsuariosId);
			};
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			};
            if (filters.Sobrenome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Sobrenome.Contains(filters.Sobrenome) );
			};
            if (filters.Email.IsSent())
            {
                queryFilter = queryFilter.Where(_ => _.Email.Contains(filters.Email));
            };
            if (filters.DataNascimento.IsSent()) 
			{ 
				filters.DataNascimento = filters.DataNascimento.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataNascimento  <= filters.DataNascimento);
			};
            if (filters.Escolaridade.IsSent())
            {

                queryFilter = queryFilter.Where(_ => _.Escolaridade == filters.Escolaridade);
            };


            return queryFilter;
        }

		public virtual IEnumerable<dynamic> GetDataListCustom(UsuariosFilter filters)
        {
            var result = this.GetByFilters(filters);

            return result.Select(_ => new
            {
				CustomFieldOrder =_.UsuariosId,
				UsuariosId = _.UsuariosId	
            });
        }
		
		public virtual dynamic GetDataCustom(UsuariosFilter filters)
        {
            var result = this.GetByFilters(filters);

            return result.Select(_ => new
            {
				UsuariosId = _.UsuariosId	
            }).SingleOrDefault();
        }

		public virtual Summary GetSummaryDataListCustom(IEnumerable<dynamic> result)
        {
            return new Summary
            {
                Total = result.Count()
            };
        }

		protected virtual bool Continue(Usuarios model, Usuarios modelOld)
        {
            return true;
        }

		protected virtual void ConfigMessageDomainConfirm(Usuarios model)
        {
            ValidationHelper.AddDomainConfirm<Usuarios>("Realmente deseja realizar essa operação.");
        }

		protected virtual Usuarios UpdateDefault(Usuarios model,Usuarios modelOld)
		{
			var alvo = this.GetFromContext(model);
            modelOld = this.rep.GetAllAsTracking().Where(_ => _.UsuariosId == modelOld.UsuariosId).FirstOrDefault();
            model.TransferTo(alvo);
            this.rep.Update(alvo, modelOld);
			return model;
		}

		protected Usuarios SaveDefault(Usuarios model, bool validation = true, bool questionToContinue = true)
        {
            var modelOld = this.Get(model);
            var isNew = modelOld.IsNull();

			if (questionToContinue)
            {
                if (Continue(model, modelOld) == false)
                {
                    ConfigMessageDomainConfirm(model);
                    return model;
                }
            }

			this.SetInitialValues(model);
			
            if (validation) ValidationHelper.ValidateAll();

            this.DeleteCollectionsOnSave(model);

            if (isNew)
                this.rep.Add(model);
            else
				this.UpdateDefault(model, modelOld);
           
		    this.ClearCache();
            return model;
        }

		public virtual Usuarios SavePartial(Usuarios model)
        {
  		    model = SaveDefault(model, false);
			this.rep.Commit();
			return model;
        }
		public virtual void DeleteFromRepository(Usuarios alvo)
        {
            var modelDelete = this.rep.GetAllAsTracking().Where(_ => _.UsuariosId == alvo.UsuariosId).FirstOrDefault();
            this.rep.Delete(modelDelete);
			this.ClearCache();
        }

		public virtual void ClearCache()
        {
			if (this.cache.IsNotNull())
            {
                var tag = this.cache.GetAndCast<List<string>>("Usuarios");
				if (tag.IsNull()) return;
                foreach (var item in tag)
                {
                    this.cache.Remove(item);    
                }
                this.cache.Remove("Usuarios");
            }
            
        }

		private Expression<Func<Usuarios, object>>[] DataAgregationBehaviorDefault(Expression<Func<Usuarios, object>>[] includes)
        { 
            return includes;
        }


	
	}
}