using System.Collections.Generic;
using ProductionComponents.Resources;

namespace ProductionComponents.Components
{
    public class Claytronics : IProductionComponent
    {
        public IDictionary<IProductionComponent, double> NeededComponents { get; } =
            new Dictionary<IProductionComponent, double>
            {
                {
                    new AntimatterCells(), 400
                },
                {
                    new EnergyCells(), 560
                },
                {
                    new MicroChips(), 640
                },
                {
                    new QuantumTubes(), 400
                }
            };

        public IDictionary<IRawResource, double> NeededResources { get; } = new Dictionary<IRawResource, double>();

        public int OutputPerHour { get; } = 480;
    }
}