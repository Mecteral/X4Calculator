using System.Collections.Generic;
using ProductionComponents.Resources;

namespace ProductionComponents.Components
{
    public interface IProductionComponent
    {
        IDictionary<IProductionComponent, double> NeededComponents { get; }
        IDictionary<IRawResource, double> NeededResources { get; }
        int OutputPerHour { get; }

        public string Id
            => GetType().Name;
    }
}