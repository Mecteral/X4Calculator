using System.Collections.Generic;
using ProductionComponents.Resources;

namespace ProductionComponents.Components
{
    public class MissileComponents : IProductionComponent
    {
        public IDictionary<IProductionComponent, double> NeededComponents { get; } =
            new Dictionary<IProductionComponent, double>
            {
                {
                    new AdvancedComposites(), 8
                },
                {
                    new EnergyCells(), 80
                },
                {
                    new HullParts(), 8
                }
            };

        public IDictionary<IRawResource, double> NeededResources { get; } = new Dictionary<IRawResource, double>();

        public int OutputPerHour { get; } = 1320;
    }
}