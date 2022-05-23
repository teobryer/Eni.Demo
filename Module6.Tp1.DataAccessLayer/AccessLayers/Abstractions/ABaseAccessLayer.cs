namespace Module6.Tp1.DataAccessLayer.AccessLayers.Abstractions
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query;
    using Module6.Tp1.DataAccessLayer.Entities.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    /// <summary>
    ///     Provides a base implementation for access layer.
    /// </summary>
    /// <typeparam name="TContext">Type context type.</typeparam>
    /// <typeparam name="TEntity">Type entity type.</typeparam>
    public abstract class ABaseAccessLayer<TContext, TEntity> : IBaseAccessLayer<TEntity>
        where TContext : DbContext
        where TEntity : ADataObject
    {
        /// <summary>
        ///     The sql insensitive collation.
        /// </summary>
        protected const string SQLCollationInsensitive = "SQL_Latin1_General_CP1_CI_AI";

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="ABaseAccessLayer{TContext, TEntity}"/>.
        /// </summary>
        /// <param name="context">The DB context.</param>
        protected ABaseAccessLayer(TContext context)
        {
            this.Context = context;
            this.ModelSet = this.Context.Set<TEntity>();
        }

        /// <summary>
        ///     Obtient le Db context.
        /// </summary>
        protected TContext Context { get; }

        /// <summary>
        ///     Obtient le Db model set.
        /// </summary>
        protected DbSet<TEntity> ModelSet { get; }

        /// <summary>
        ///     Async Method that add new object in Db.
        /// </summary>
        /// <param name="model">Object model to add.</param>
        /// <returns>Returns the Id of newly created object.</returns>
        public async Task<long> AddAsync(TEntity model)
        {
            var result = this.ModelSet.Add(model);
            _ = await this.Context.SaveChangesAsync().ConfigureAwait(false);

            return result.Entity.Id;
        }

        /// <summary>
        ///     Async Method that add a range of new object in Db.
        /// </summary>
        /// <param name="models">Enumerable of objects model to add.</param>
        /// <returns>Returns number of state entries written to the database.</returns>
        public async Task<int> AddRangeAsync(IEnumerable<TEntity> models)
        {
            this.ModelSet.AddRange(models);
            return await this.Context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     Method that retrieve a collection of data according to the filter.
        /// </summary>
        /// <remarks>
        ///     Tracking on data returned is disabled by default.
        /// </remarks>
        /// <param name="filter">Expression to filter data to return.</param>
        /// <param name="trackingEnabled">true if tracking is needed on data returned, false otherwise.</param>
        /// <param name="navigationProperties">Navigation properties to include for data to returned.</param>
        /// <returns>Returns Enumerable of <typeparamref name="TEntity" />.</returns>
        public IQueryable<TEntity> GetCollection(
            Expression<Func<TEntity, bool>>? filter = null,
            bool trackingEnabled = false,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? navigationProperties = null)
        {
            var dbQuery = this.ModelSet.AsQueryable();

            if (navigationProperties != null)
            {
                dbQuery = navigationProperties(dbQuery);
            }

            if (filter != null)
            {
                dbQuery = dbQuery.Where(filter);
            }

            var collection = trackingEnabled
                                 ? dbQuery
                                 : dbQuery.AsNoTracking();

            return collection;
        }

        /// <summary>
        ///     Method that retrieve a collection of data according to the filter.
        /// </summary>
        /// <remarks>
        ///     Tracking on data returned is disabled by default.
        /// </remarks>
        /// <typeparam name="TResult">Type result type.</typeparam>
        /// <param name="selector">The selector to apply.</param>
        /// <param name="filter">Expression to filter data to return.</param>
        /// <param name="trackingEnabled">true if tracking is needed on data returned, false otherwise.</param>
        /// <param name="navigationProperties">Navigation properties to include for data to returned.</param>
        /// <returns>Returns Enumerable of <typeparamref name="TResult" />.</returns>
        public IQueryable<TResult> GetCollection<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>>? filter = null,
            bool trackingEnabled = false,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? navigationProperties = null)
        {
            var dbQuery = this.ModelSet.AsQueryable();

            if (navigationProperties != null)
            {
                dbQuery = navigationProperties(dbQuery);
            }

            if (filter != null)
            {
                dbQuery = dbQuery.Where(filter);
            }

            var collection = trackingEnabled
                                 ? dbQuery.Select(selector)
                                 : dbQuery.AsNoTracking().Select(selector);

            return collection;
        }

        /// <summary>
        ///     Async Method that retrieve first data object matching the given filter.
        /// </summary>
        /// <remarks>
        ///     Tracking on data returned is disabled by default.
        /// </remarks>
        /// <param name="filter">filter to apply.</param>
        /// <param name="trackingEnabled">true if tracking is needed on data returned, false otherwise.</param>
        /// <param name="navigationProperties">Navigation properties to include for data to returned.</param>
        /// <returns>Returns <typeparamref name="TEntity" />.</returns>
        public async Task<TEntity?> GetSingleAsync(
            Expression<Func<TEntity, bool>>? filter = null,
            bool trackingEnabled = false,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? navigationProperties = null)
        {
            var dbQuery = this.ModelSet.AsQueryable();

            if (navigationProperties != null)
            {
                dbQuery = navigationProperties(dbQuery);
            }

            if (filter != null)
            {
                dbQuery = dbQuery.Where(filter);
            }

            var item = trackingEnabled
                           ? await dbQuery.FirstOrDefaultAsync()
                           : await dbQuery.AsNoTracking().FirstOrDefaultAsync();

            return item;
        }

        /// <summary>
        ///     Async Method that retrieve first data object matching the given filter.
        /// </summary>
        /// <remarks>
        ///     Tracking on data returned is disabled by default.
        /// </remarks>
        /// <typeparam name="TResult">Type result type.</typeparam>
        /// <param name="selector">The selector to apply.</param>
        /// <param name="filter">filter to apply.</param>
        /// <param name="trackingEnabled">true if tracking is needed on data returned, false otherwise.</param>
        /// <param name="navigationProperties">Navigation properties to include for data to returned.</param>
        /// <returns>Returns <typeparamref name="TEntity" />.</returns>
        public async Task<TResult?> GetSingleAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>>? filter = null,
            bool trackingEnabled = false,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? navigationProperties = null)
        {
            var dbQuery = this.ModelSet.AsQueryable();

            if (navigationProperties != null)
            {
                dbQuery = navigationProperties(dbQuery);
            }

            if (filter != null)
            {
                dbQuery = dbQuery.Where(filter);
            }

            var item = trackingEnabled
                           ? await dbQuery.Select(selector).FirstOrDefaultAsync()
                           : await dbQuery.AsNoTracking().Select(selector).FirstOrDefaultAsync();

            return item;
        }

        /// <summary>
        ///     Async method that update a specific data object.
        /// </summary>
        /// <param name="model">The object data model to update.</param>
        /// <returns>Returns number of state entries written to the database.</returns>
        public async Task<int> UpdateAsync(TEntity model)
        {
            _ = this.ModelSet.Update(model);
            return await this.Context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     Async Method that remove a specific object in Db.
        /// </summary>
        /// <param name="model">The object data model to remove.</param>
        /// <returns>Returns number of state entries written to the database.</returns>
        public async Task<int> RemoveAsync(TEntity model)
        {
            _ = this.ModelSet.Remove(model);
            return await this.Context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     Async Method that remove a specific object in Db.
        /// </summary>
        /// <param name="id">The object id of data model to remove.</param>
        /// <returns>Returns number of state entries written to the database.</returns>
        public async Task<int> RemoveAsync(long id)
        {
            var model = this.ModelSet.FirstOrDefault(model => model.Id == id);
            if (model == null)
            {
                return -1;
            }

            _ = this.ModelSet.Remove(model);
            return await this.Context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     Async method using bulk deletion method to remove data object from db context.
        /// </summary>
        /// <param name="models">Enumerable of Data object to remove.</param>
        /// <returns>Returns number of state entries written to the database.</returns>
        public async Task<int> RemoveRangeAsync(IEnumerable<TEntity> models)
        {
            this.ModelSet.RemoveRange(models);
            return await this.Context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     Async method using bulk deletion method to remove data object from db context.
        /// </summary>
        /// <param name="ids">Enumerable of ids of Data object to remove.</param>
        /// <returns>Returns number of state entries written to the database.</returns>
        public async Task<int> RemoveRangeAsync(IEnumerable<long> ids)
        {
            this.ModelSet.RemoveRange(this.ModelSet.Where(model => ids.Contains(model.Id)));
            return await this.Context.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        ///     Check the existence of an object in a collection from on its id.
        /// </summary>
        /// <param name="id">Id of object to check.</param>
        /// <returns>Returns true if object exists, false otherwise.</returns>
        public bool Exists(long id)
            => this.GetCollection(filter: o => o.Id == id).Any();
    }
}
