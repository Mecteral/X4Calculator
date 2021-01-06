using System.Collections.Generic;
using ProductionComponents.Resources;

namespace ProductionComponents.Components
{
    public class DroneComponents : IProductionComponent
    {
        public IDictionary<IProductionComponent, double> NeededComponents { get; } =
            new Dictionary<IProductionComponent, double>
            {
                {
                    new EnergyCells(), 180
                },
                {
                    new EngineParts(), 60
                },
                {
                    new HullParts(), 60
                },
                {
                    new MicroChips(), 60
                },
                {
                    new ScanningArrays(), 120
                }
            };

        public IDictionary<IRawResource, double> NeededResources { get; } = new Dictionary<IRawResource, double>();

        public int OutputPerHour { get; } = 360;
    }
}