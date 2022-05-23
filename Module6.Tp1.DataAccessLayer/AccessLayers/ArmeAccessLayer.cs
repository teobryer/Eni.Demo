namespace Module6.Tp1.DataAccessLayer.AccessLayers
{
    using Module6.Tp1.DataAccessLayer.AccessLayers.Abstractions;
    using Module6.Tp1.DataAccessLayer.Entities;

    internal class ArmeAccessLayer : ABaseAccessLayer<DojoContext, Arme>, IArmeAccessLayer
    {
        public ArmeAccessLayer(DojoContext context)
            : base(context)
        {

        }
    }
}
