using Domotics.DataAccessLayer.AccessLayers.Abstractions;
using Domotics.DataAccessLayer.Entities;

namespace Domotics.DataAccessLayer.AccessLayers
{
    

    public class MeasureAccessLayer : ABaseAccessLayer<DomoticsContext, Measure>, IMeasureAccessLayer
    {
        public MeasureAccessLayer(DomoticsContext context)
            : base(context)
        {

        }
    }
}
