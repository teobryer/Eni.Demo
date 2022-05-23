using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp_Samourai.DAL.Entities;

namespace Tp_Samourai.DAL
{
   public class AccesLayer<T> : ICrud<T> where T : IEntity
    {
        private readonly SamouraiDbContext context;

        public AccesLayer(SamouraiDbContext context)
        {
            this.context = context;
        }
		public async Task ajouter(T entity)
		{
			context.Set<T>().Add(entity);
			await context.SaveChangesAsync();


		}

		public async Task modifier(int id, T entity)
		{
			if (id != entity.getId())
			{
				throw new BadRequestException();
			}

			context.Entry(entity).State = EntityState.Modified;

			try
			{
				await context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!Exists(id))
				{
					throw new NotFoundException();
				}

			}
		}

		public async Task<T> recupererParId(int id)
		{
			var affaire = await context.Set<T>().FindAsync(id);

			if (affaire == null)
			{
				throw new DllNotFoundException();
			}

			return affaire;
		}

		public Task<List<T>> recupererTous()
		{
			return context.Set<T>().ToListAsync();
		}

		public async Task supprimer(int id)
		{
			var affaire = await context.Set<T>().FindAsync(id);
			if (affaire == null)
			{
				throw new NotFoundException();
			}

			context.Set<T>().Remove(affaire);
			await context.SaveChangesAsync();
		}


		public bool Exists(int id)
		{
			return context.Set<T>().Any(e => e.getId() == id);
		}


	}
}
