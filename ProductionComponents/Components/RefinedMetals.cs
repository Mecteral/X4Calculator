using System.Collections.Generic;
using ProductionComponents.Resources;

namespace ProductionComponents.Components
{
    public class RefinedMetals : IProductionComponent
    {
        public IDictionary<IProductionComponent, double> NeededComponents { get; } =
            new Dictionary<IProductionComponent, double>
            {
                {
                    new EnergyCells(), 2160
                }
            };

        public IDictionary<IRawResource, double> NeededResources { get; } = new Dictionary<IRawResource, double>
        {
            {
                new Ore(), 9600
            }
        };

        public int OutputPerHour { get; } = 2400;
    }
}