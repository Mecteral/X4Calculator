using System.Collections.Generic;
using ProductionComponents.Resources;

namespace ProductionComponents.Components
{
    public class AntimatterConverters : IProductionComponent
    {
        public IDictionary<IProductionComponent, double> NeededComponents { get; } =
            new Dictionary<IProductionComponent, double>
            {
                {
                    new AdvancedComposites(), 240
                },
                {
                    new EnergyCells(), 960
                },
                {
                    new MicroChips(), 360
                }
            };

        public IDictionary<IRawResource, double> NeededResources { get; } = new Dictionary<IRawResource, double>();

        public int OutputPerHour { get; } = 1800;
    }
}