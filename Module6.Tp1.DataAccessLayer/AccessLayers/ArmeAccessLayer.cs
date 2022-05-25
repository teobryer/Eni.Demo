namespace Module6.Tp1.DataAccessLayer.AccessLayers
{
    using Microsoft.EntityFrameworkCore;
    using Module6.Tp1.DataAccessLayer.AccessLayers.Abstractions;
    using Module6.Tp1.DataAccessLayer.Entities;
    using System.Linq;
    using System.Threading.Tasks;

    internal class ArmeAccessLayer : ABaseAccessLayer<DojoContext, Arme>, IArmeAccessLayer
    {
        public ArmeAccessLayer(DojoContext context)
            : base(context)
        {



        }

        public override async Task<int> RemoveAsync(long id)
        {




            var model = this.ModelSet.Include(a=> a.Samourai).FirstOrDefault(model => model.Id == id);
            if (model == null)
            {
                return -1;
            }

            
            if(null == model.Samourai)
            {
                _ = this.ModelSet.Remove(model);
            }
            
            return await this.Context.SaveChangesAsync().ConfigureAwait(false);




        }
    }
}
