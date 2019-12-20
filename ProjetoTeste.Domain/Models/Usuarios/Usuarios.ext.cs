using Common.Domain;
using Common.Domain.CustomExceptions;
using Common.Domain.Interfaces;
using Common.Models;
using ProjetoTeste.Core.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace ProjetoTeste.Core.Domain
{
    [MetadataType(typeof(UsuariosValidation))]
    public partial class Usuarios : IDataAgregation<Usuarios>
    {
        public Usuarios()
        {
        }
        public ValidationHelper ValidationHelper = new ValidationHelper();



        public Usuarios Get(Usuarios model)
        {
            return this.rep.GetAll(DataAgregation(new UsuariosFilter
            {
                QueryOptimizerBehavior = model.QueryOptimizerBehavior

            })).Where(_ => _.UsuariosId == model.UsuariosId).SingleOrDefault();
        }

        public IQueryable<Usuarios> GetByFilters(UsuariosFilter filters, params Expression<Func<Usuarios, object>>[] includes)
        {
            var queryBase = this.rep.GetAllAsTracking(includes);
            var queryFilter = queryBase;

            queryFilter = this.SimpleFilters(filters, queryBase);

            //Filter Customizados

            return queryFilter;
        }

        public IEnumerable<DataItem> GetDataItem(UsuariosFilter filters)
        {
            var dataList = this.GetByFilters(filters)
                .Select(_ => new DataItem
                {
                    Id = _.UsuariosId.ToString(),
                });

            return dataList.ToList();
        }

        public Common.Models.Summary GetSummary(IQueryable<Usuarios> result)
        {
            return new Common.Models.Summary
            {
                Total = 0
            };
        }

        public Usuarios Save()
        {
            return Save(this);
        }

        public Usuarios Save(Usuarios model)
        {
            model = SaveDefault(model);
            this.rep.Commit();
            return model;
        }

        public IEnumerable<Usuarios> Save(IEnumerable<Usuarios> models)
        {
            var modelsInserted = new List<Usuarios>();
            foreach (var item in models)
            {
                modelsInserted.Add(SaveDefault(item));
            }

            this.rep.Commit();
            return modelsInserted;
        }

        public void Delete(Usuarios model)
        {
            if (model.IsNull())
                throw new CustomBadRequestException("Delete sem parametros");

            var alvo = this.Get(model);
            this.DeleteFromRepository(alvo);
            this.rep.Commit();
        }

        private void SetInitialValues(Usuarios model)
        {
        }

        private void ValidationReletedClasses(Usuarios model, CurrentUser user, Usuarios modelOld)
        {

        }

        private void DeleteCollectionsOnSave(Usuarios model)
        {

        }

        public Expression<Func<Usuarios, object>>[] DataAgregation(Filter filter)
        {
            return DataAgregation(new Expression<Func<Usuarios, object>>[] { }, filter);
        }

        public Expression<Func<Usuarios, object>>[] DataAgregation(Expression<Func<Usuarios, object>>[] includes, Filter filter)
        {
            return this.DataAgregationBehaviorDefault(includes);

        }


        public override void Dispose()
        {
            if (this.rep != null)
                this.rep.Dispose();
        }

        ~Usuarios()
        {

        }

    }
}