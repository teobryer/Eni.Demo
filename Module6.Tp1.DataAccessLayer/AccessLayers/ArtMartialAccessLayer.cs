namespace Module6.Tp1.DataAccessLayer.AccessLayers
{
    using Module6.Tp1.DataAccessLayer.AccessLayers.Abstractions;
    using Module6.Tp1.DataAccessLayer.Entities;

    internal class ArtMartielAccessLayer : ABaseAccessLayer<DojoContext, ArtMartial>, IArtMartialAccessLayer
    {
        public ArtMartielAccessLayer(DojoContext context)
            : base(context)
        {

        }
    }
}
