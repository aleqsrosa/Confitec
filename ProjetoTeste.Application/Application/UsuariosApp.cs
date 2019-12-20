using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domain.Interfaces;
using Common.Infrastructure.Cache;
using System.Collections.Generic;
using Common.Models;
using ProjetoTeste.Core.Filters;
using Common.Interfaces;
using ProjetoTeste.Core.Dto;
using ProjetoTeste.Core.Domain;
using Common.Domain;
using System.Transactions;

namespace ProjetoTeste.Core.Application
{
    public partial class UsuariosApp : IDisposable
    {
        private IRepository<Usuarios> repUsuarios;
        private ICache cache;
        private Usuarios Usuarios;
		public ValidationHelper ValidationHelper;

        public UsuariosApp(string token)
        {
			this.Init(token);
			this.ValidationHelper = Usuarios.ValidationHelper;
        }

		public void GetWarnings(UsuariosFilter filters)
        {
            this.Usuarios.Warnings(filters);
        }
		
		public IEnumerable<UsuariosDto> GetAll()
        {
			var result = default(IEnumerable<UsuariosDto>);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
				var dataList = this.Usuarios.GetAll();
				result =  AutoMapper.Mapper.Map<IQueryable<Usuarios>, IEnumerable<UsuariosDto>>(dataList);
			}
			return result;
        }

		public SearchResult<UsuariosDto> GetByFilters(UsuariosFilter filter)
        {
			var result = default(SearchResult<UsuariosDto>);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
				result = GetByFiltersWithCache(filter, MapperDomainToResult);
			}
			return result;
        }

		public SearchResult<UsuariosDto> GetReport(UsuariosFilter filter)
        {	
			var result = default(SearchResult<UsuariosDto>);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
				result = GetByFiltersWithCache(filter, MapperDomainToReport);
			}
			return result;
        }
		
		public SearchResult<dynamic> GetDataListCustom(UsuariosFilter filters)
        {
			var result = default(SearchResult<dynamic>);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
				var queryBase = this.Usuarios.GetDataListCustom(filters);
				var dataList = PagingAndSorting<dynamic>(filters, queryBase.AsQueryable(), PaginationDynamic);
				result = new SearchResult<dynamic>
				{
					DataList = dataList.ResultPaginatedData.ToList(),
					Summary = this.Usuarios.GetSummaryDataListCustom(queryBase)
				};
			}
			return result;
        }

		
		public dynamic GetDataCustom(UsuariosFilter filters)
        {
			var result = default(dynamic);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
				result = this.Usuarios.GetDataCustom(filters);
			}
			return result;
        }

		public UsuariosDto Get(UsuariosDto dto)
        {
			var result = default(UsuariosDto);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
				var model =  AutoMapper.Mapper.Map<UsuariosDto, Usuarios>(dto);
				var data = this.Usuarios.Get(model);
				result =  this.MapperDomainToDtoSpecialized(data);
			}
			return result;
        }

		public UsuariosDto GetDetails(UsuariosDto dto)
        {
			var result = default(UsuariosDto);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))            
			{
				var model =  AutoMapper.Mapper.Map<UsuariosDto, Usuarios>(dto);
				var data = this.Usuarios.Get(model);
				result =  this.MapperDomainToDtoDetails(data, dto);
			}

			return result;
        }

		public IEnumerable<DataItem> GetDataItem(IFilter filters)
		{
			var result = default(IEnumerable<DataItem>);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
				var filter = (filters as UsuariosFilter).IsNotNull() ? filters as UsuariosFilter : new UsuariosFilter { };
				var filterKey = filter.CompositeKey(); 

				if (filter.ByCache)
				{
					if (this.cache.ExistsKey<IEnumerable<DataItemCache>>(filterKey))
					{
						var resultCache = this.cache.GetAndCast<IEnumerable<DataItemCache>>(filterKey);
						return resultCache.Select(_ => new DataItem
						{
							Id = _.Id,
							Name = _.Name
						});
					}
				}

				result = this.Usuarios.GetDataItem(filter);
				if (filter.ByCache)
				{
					this.cache.Add(filterKey, result.Select(_ => new DataItemCache
					{
						Id = _.Id,
						Name = _.Name
					}).ToList());
					this.AddTagCache(filterKey);
				}
			}
			return result;
		}

		public int GetTotalByFilters(UsuariosFilter filter)
        {
			var result = default(int);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
				result = this.Usuarios.GetByFilters(filter).Count();
			}
			return result;
        }

		public UsuariosDto Save(UsuariosDto dto)
        {
			var result = default(UsuariosDto);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
				var model =  AutoMapper.Mapper.Map<UsuariosDto, Usuarios>(dto);
				var data = this.Usuarios.Save(model);
				result =  AutoMapper.Mapper.Map<Usuarios, UsuariosDto>(data);
				transaction.Complete();
			}
			return result;
        }

		public UsuariosDto Save(UsuariosDtoSpecialized dto)
        {
			var result = default(UsuariosDto);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
				var model =  AutoMapper.Mapper.Map<UsuariosDtoSpecialized, Usuarios>(dto);
				var data = this.Usuarios.Save(model);
				result =  AutoMapper.Mapper.Map<Usuarios, UsuariosDto>(data);
				transaction.Complete();
			}
			return result;
        }

		public UsuariosDto SavePartial(UsuariosDtoSpecialized dto)
        {
			var result = default(UsuariosDto);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))            
			{
				var model =  AutoMapper.Mapper.Map<UsuariosDtoSpecialized, Usuarios>(dto);
				var data = this.Usuarios.SavePartial(model);
				result =  AutoMapper.Mapper.Map<Usuarios, UsuariosDto>(data);
				transaction.Complete();
			}
			return result;
        }

		public IEnumerable<UsuariosDto> Save(IEnumerable<UsuariosDtoSpecialized> dtos)
        {
			var result = default(IEnumerable<UsuariosDto>);
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
				var models = AutoMapper.Mapper.Map<IEnumerable<UsuariosDtoSpecialized>, IEnumerable<Usuarios>>(dtos);
				var data = this.Usuarios.Save(models);
				result = AutoMapper.Mapper.Map<IEnumerable<Usuarios>, IEnumerable<UsuariosDto>>(data);
				transaction.Complete();
			}
			return result;
        }

		public void Delete(UsuariosDto dto)
        {
			using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
				var model =  AutoMapper.Mapper.Map<UsuariosDto, Usuarios>(dto);
				this.Usuarios.Delete(model);
				transaction.Complete();
			}
        }
				
		private Common.Models.Summary Summary(IQueryable<Usuarios> queryBase, PaginateResult<Usuarios> dataList)
        {
			var domainSummary = this.Usuarios.GetSummary(queryBase);
			var summary = new Common.Models.Summary
			{
				Total = dataList.TotalCount,
				AdditionalSummary = domainSummary.AdditionalSummary.IsNotNull() ? domainSummary.AdditionalSummary : null
			};
			return summary;
        }

		private PaginateResult<T> PagingAndSorting<T>(UsuariosFilter filter, IQueryable<T> queryBase, Func<UsuariosFilter, IQueryable<T>, PaginateResult<T>, PaginateResult<T>> PaginationDefault) where T: class
        {
           var querySorting = queryBase;

            if (filter.IsOrderByDynamic)
                querySorting = queryBase.OrderByDynamic(filter);

            var dataList = new PaginateResult<T>
            {
                ResultPaginatedData = querySorting,
                TotalCount = 0
            };

            if (filter.IsPagination)
            {
                if (filter.IsOrderByDynamic || filter.IsOrderByDomain)
                    return dataList = querySorting.PaginateNew(filter);

                dataList = PaginationDefault(filter, querySorting, dataList);
            }

			return dataList;
        }

		private PaginateResult<Usuarios> PaginationDefault(UsuariosFilter filter, IQueryable<Usuarios> querySorting, PaginateResult<Usuarios> dataList)
        {
            dataList = querySorting.OrderByDescending(_ => _.UsuariosId).PaginateNew(filter);
            return dataList;
        }

        private PaginateResult<dynamic> PaginationDynamic(UsuariosFilter filter, IQueryable<dynamic> querySorting, PaginateResult<dynamic> dataList)
        {
            if (filter.OrderFields.IsNull())
            {
                filter.OrderFields = new[] { "CustomFieldOrder" };
                filter.orderByType = Common.Enum.OrderByType.OrderByDescending;
            }
            dataList = querySorting.OrderByDynamic(filter).PaginateNew(filter);
            return dataList;
        }

		private SearchResult<UsuariosDto> GetByFiltersWithCache(UsuariosFilter filter, Func<UsuariosFilter, PaginateResult<Usuarios>, IEnumerable<UsuariosDto>> MapperDomainToDto)
        {
            var filterKey = filter.CompositeKey();
            if (filter.ByCache)
                if (this.cache.ExistsKey<SearchResult<UsuariosDto>>(filterKey))
                    return this.cache.GetAndCast<SearchResult<UsuariosDto>>(filterKey);

            var queryBase = this.Usuarios.GetByFilters(filter);
            var dataList = PagingAndSorting(filter, queryBase,PaginationDefault);
            var result = MapperDomainToDto(filter, dataList);
            var summary = Summary(queryBase, dataList);

            var searchResult = new SearchResult<UsuariosDto>
            {
                DataList = result,
                Summary = summary,
            };

            if (filter.ByCache)
			{
                this.cache.Add(filterKey, searchResult);
				this.AddTagCache(filterKey);
			}

            return searchResult;
        }
		
        private void AddTagCache(string filterKey)
        {
            var tags = this.cache.GetAndCast<List<string>>("Usuarios") as List<string>;
            if (tags.IsNull()) tags = new List<string>();
            tags.Add(filterKey);
            this.cache.Add("Usuarios", tags);
        }
		
		private UsuariosDto MapperDomainToDtoSpecialized(Usuarios data)
        {
            var result =  AutoMapper.Mapper.Map<Usuarios, UsuariosDtoSpecialized>(data);
            return result;
        }

        public void Dispose()
        {
            this.Usuarios.Dispose();
        }
    }
}
