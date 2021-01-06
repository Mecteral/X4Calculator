using System.Collections.Generic;
using ProductionComponents.Resources;

namespace ProductionComponents.Components
{
    public class ScanningArrays : IProductionComponent
    {
        public IDictionary<IProductionComponent, double> NeededComponents { get; } =
            new Dictionary<IProductionComponent, double>
            {
                {
                    new EnergyCells(), 360
                },
                {
                    new RefinedMetals(), 600
                },
                {
                    new SiliconWafers(), 360
                }
            };

        public IDictionary<IRawResource, double> NeededResources { get; } = new Dictionary<IRawResource, double>();

        public int OutputPerHour { get; } = 240;
    }
}