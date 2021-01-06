using System;
using System.Collections.Generic;
using ProductionComponents;
using ProductionComponents.Components;

namespace CalculationConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var calculator = new ModuleAmountCalculator();

            var result = calculator.CalculateForMultipleComponentAmountsUpScaled(new Dictionary<IProductionComponent, double>
            {
                {
                    new MicroChips(), 3600
                }
            });

            Console.WriteLine("Resources:");
            foreach (var neededResource in result.NeededResources)
            {
                Console.WriteLine($"{neededResource.Key.GetType().Name}: {neededResource.Value}");
                Console.WriteLine("_______________________________________________________________________________");
            }

            Console.WriteLine("Components:");
            foreach (var calculationComponentResult in result.CalculationComponentResults)
            {
                Console.WriteLine($"{calculationComponentResult.Component.Id}");
                Console.WriteLine($"Actual: {calculationComponentResult.NeededAmount}");
                Console.WriteLine($"Produced: {calculationComponentResult.ProducedAmount}");
                Console.WriteLine($"Overflow: {calculationComponentResult.OverflowAmount}");
                Console.WriteLine($"Factories: {calculationComponentResult.FactoryCount}");
                Console.WriteLine("_______________________________________________________________________________");
            }
        }
    }
}