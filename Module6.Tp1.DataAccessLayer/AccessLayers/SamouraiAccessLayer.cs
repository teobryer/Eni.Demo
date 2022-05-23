namespace Module6.Tp1.DataAccessLayer.AccessLayers
{
    using Module6.Tp1.DataAccessLayer.AccessLayers.Abstractions;
    using Module6.Tp1.DataAccessLayer.Entities;

    internal class SamouraiAccessLayer : ABaseAccessLayer<DojoContext, Samourai>, ISamouraiAccessLayer
    {
        public SamouraiAccessLayer(DojoContext context)
            : base(context)
        {

        }
    }
}
