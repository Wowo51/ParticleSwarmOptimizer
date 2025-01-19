//Copyright Warren Harding 2025.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptimizationInterface;
using ParticleSwarm;
using System;

namespace ParticleSwarmTest
{
    [TestClass]
    public class ParticleSwarmUnitTests
    {
        [TestMethod]
        public void TestOptimizationObjectiveFunction()
        {
            ParticleSwarmOptimizer optimizer = new ParticleSwarmOptimizer();
            Func<double[], double> objectiveFunction = x => Math.Pow(x[0] - 1, 2) + Math.Pow(x[1] - 2, 2) + 3;
            Random random = new Random();
            OptimizationOptions options = new OptimizationOptions
            {
                MaxIterations = 500,
                Tolerance = 1e-6
            };
            for (int i = 0; i < 3; i++)
            {
                double[] startPosition = new double[]
                {
                    random.NextDouble() * 10 - 5,
                    random.NextDouble() * 10 - 5
                };
                OptimizationResult result = optimizer.Optimize(objectiveFunction, startPosition, options);
                Assert.IsNotNull(result);
                Assert.AreEqual(3, result.BestObjectiveValue, 1e-6, "Unexpected objective value");
                Assert.AreEqual(1, result.BestSolution[0], 1e-6, "Unexpected solution for x");
                Assert.AreEqual(2, result.BestSolution[1], 1e-6, "Unexpected solution for y");
            }
        }
    }
}