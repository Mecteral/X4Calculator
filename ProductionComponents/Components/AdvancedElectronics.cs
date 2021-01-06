using System.Collections.Generic;
using ProductionComponents.Resources;

namespace ProductionComponents.Components
{
    public class AdvancedElectronics : IProductionComponent
    {
        public IDictionary<IProductionComponent, double> NeededComponents { get; } =
            new Dictionary<IProductionComponent, double>
            {
                {
                    new EnergyCells(), 300
                },
                {
                    new MicroChips(), 220
                },
                {
                    new QuantumTubes(), 100
                }
            };

        public IDictionary<IRawResource, double> NeededResources { get; } = new Dictionary<IRawResource, double>();

        public int OutputPerHour { get; } = 300;
    }
}