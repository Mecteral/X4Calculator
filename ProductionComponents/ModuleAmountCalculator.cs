using System;
using System.Collections.Generic;
using System.Linq;
using ProductionComponents.Components;
using ProductionComponents.Resources;

namespace ProductionComponents
{
    public class ModuleAmountCalculator
    {
        public CalculationResult CalculateForMultipleComponentAmounts(
            IDictionary<IProductionComponent, double> componentsWithAmounts)
        {
            var calculationResult = new CalculationResult();

            foreach (var componentWithAmount in componentsWithAmounts)
                CalculateByComponentAmount(componentWithAmount.Key, componentWithAmount.Value, calculationResult);

            return calculationResult;
        }

        public CalculationResult CalculateForMultipleComponentAmountsUpScaled(
            IDictionary<IProductionComponent, double> componentsWithAmounts)
        {
            var calculationResult = new CalculationResult();

            foreach (var componentWithAmount in componentsWithAmounts)
                CalculateByComponentAmountUpScaled(componentWithAmount.Key, componentWithAmount.Value,
                    calculationResult);

            return calculationResult;
        }

        public CalculationResult CalculateForMultipleFactoryCounts(
            IDictionary<IProductionComponent, int> factoriesWithAmounts)
        {
            var result = new CalculationResult();

            foreach (var factoriesWithAmount in factoriesWithAmounts)
                CalculateByFactoryCount(factoriesWithAmount.Key, factoriesWithAmount.Value, result);

            return result;
        }

        private void CalculateByComponentAmount(IProductionComponent component, double componentAmount,
            CalculationResult calculationResult)
        {
            var factoryMultiplier = CalculateFactoryMultiplier(component.OutputPerHour, componentAmount);
            AggregateComponentAmounts(component, calculationResult, factoryMultiplier);
        }

        private void CalculateByComponentAmountUpScaled(IProductionComponent component, double componentAmount,
            CalculationResult calculationResult)
        {
            var factoryMultiplier = Math.Ceiling(CalculateFactoryMultiplier(component.OutputPerHour, componentAmount));
            AggregateComponentAmounts(component, calculationResult, factoryMultiplier);
        }

        private CalculationResult AggregateComponentAmounts(IProductionComponent component,
            CalculationResult calculationResult, double factoryMultiplier)
        {
            foreach (var neededComponent in component.NeededComponents)
            {
                var neededAmount = neededComponent.Value * factoryMultiplier;

                var currentComponent =
                    calculationResult.CalculationComponentResults.FirstOrDefault(result
                        => result.Component.Id == neededComponent.Key.Id);
                if (currentComponent == null)
                {
                    currentComponent = new CalculationComponentResult
                    {
                        Component = neededComponent.Key
                    };
                    calculationResult.CalculationComponentResults.Add(currentComponent);
                }

                currentComponent.NeededAmount += neededAmount;

                var currentComponentFactoryMultiplier =
                    CalculateFactoryMultiplier(neededComponent.Key.OutputPerHour, neededAmount);
                AggregateComponentAmounts(neededComponent.Key, calculationResult, currentComponentFactoryMultiplier);
            }

            foreach (var neededResource in component.NeededResources)
            {
                var neededResourceAmount = neededResource.Value * factoryMultiplier;
                var presentResourceKey =
                    calculationResult.NeededResources.Keys.FirstOrDefault(key => key.Id == neededResource.Key.Id);
                if (presentResourceKey != null)
                    calculationResult.NeededResources[presentResourceKey] += neededResourceAmount;
                else
                    calculationResult.NeededResources[neededResource.Key] = neededResourceAmount;
            }

            return calculationResult;
        }

        private double CalculateFactoryMultiplier(int factoryOutput, double wishedAmount)
            => wishedAmount / factoryOutput;

        private CalculationResult CalculateByFactoryCount(IProductionComponent component, int factoryCount,
            CalculationResult calculationResult)
            => AggregateComponentAmounts(component, calculationResult, factoryCount);
    }

    public class CalculationResult
    {
        public IList<CalculationComponentResult> CalculationComponentResults { get; } =
            new List<CalculationComponentResult>();

        public IDictionary<IRawResource, double> NeededResources { get; } = new Dictionary<IRawResource, double>();
    }

    public class CalculationComponentResult
    {
        public IProductionComponent Component { get; set; }

        public int FactoryCount
            => (int) Math.Ceiling(NeededAmount / Component.OutputPerHour);

        public long ProducedAmount
            => Component.OutputPerHour * FactoryCount;

        public double OverflowAmount
            => ProducedAmount - NeededAmount;

        public double NeededAmount { get; set; }
    }
}