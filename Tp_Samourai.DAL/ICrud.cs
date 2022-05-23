using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp_Samourai.DAL.Entities;

namespace Tp_Samourai.DAL
{
    
		public interface ICrud<T> where T : IEntity
		{
			Task<List<T>> recupererTous();
			Task supprimer(int id);
			Task<T> recupererParId(int id);
			Task ajouter(T entity);
			Task modifier(int id, T entity);

		

	}
}
