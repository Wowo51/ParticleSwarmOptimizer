//Copyright Warren Harding 2025.
using System;
using System.Linq;
using System.Threading.Tasks;
using OptimizationInterface;

namespace ParticleSwarm
{
    public class ParticleSwarmOptimizer : IOptimizer
    {
        private class Particle
        {
            public double[] Position { get; set; } = Array.Empty<double>();
            public double[] Velocity { get; set; } = Array.Empty<double>();
            public double[] BestPosition { get; set; } = Array.Empty<double>();
            public double BestValue { get; set; }
        }

        public OptimizationResult Optimize(Func<double[], double> objectiveFunction, double[] initialGuess, OptimizationOptions options)
        {
            if (initialGuess == null || initialGuess.Length == 0 || options == null)
            {
                throw new ArgumentException("Invalid input parameters.");
            }

            int dimensions = initialGuess.Length;
            int numberOfParticles = 30;
            double inertia = 0.7;
            double cognitiveComponent = 1.5;
            double socialComponent = 1.5;
            Particle[] particles = new Particle[numberOfParticles];
            Random random = new Random();
            double[] globalBestPosition = new double[dimensions];
            double globalBestValue = double.PositiveInfinity;
            for (int i = 0; i < numberOfParticles; i++)
            {
                double[] position = Enumerable.Range(0, dimensions).Select(_ => random.NextDouble() * 10 - 5).ToArray();
                double[] velocity = Enumerable.Range(0, dimensions).Select(_ => random.NextDouble() * 2 - 1).ToArray();
                double value = objectiveFunction(position);
                particles[i] = new Particle
                {
                    Position = position,
                    Velocity = velocity,
                    BestPosition = (double[])position.Clone(),
                    BestValue = value
                };
                if (value < globalBestValue)
                {
                    globalBestPosition = (double[])position.Clone();
                    globalBestValue = value;
                }
            }

            int iteration = 0;
            for (iteration = 0; iteration < options.MaxIterations; iteration++)
            {
                Parallel.For(0, numberOfParticles, i =>
                {
                    Particle particle = particles[i];
                    for (int d = 0; d < dimensions; d++)
                    {
                        double r1 = random.NextDouble();
                        double r2 = random.NextDouble();
                        particle.Velocity[d] = inertia * particle.Velocity[d] + cognitiveComponent * r1 * (particle.BestPosition[d] - particle.Position[d]) + socialComponent * r2 * (globalBestPosition[d] - particle.Position[d]);
                        particle.Position[d] += particle.Velocity[d];
                    }

                    double newValue = objectiveFunction(particle.Position);
                    if (newValue < particle.BestValue)
                    {
                        particle.BestPosition = (double[])particle.Position.Clone();
                        particle.BestValue = newValue;
                    }

                    lock (globalBestPosition as object)
                    {
                        if (newValue < globalBestValue)
                        {
                            globalBestPosition = (double[])particle.Position.Clone();
                            globalBestValue = newValue;
                        }
                    }
                });
                if (Math.Abs(globalBestValue) <= options.Tolerance)
                {
                    break;
                }
            }

            return new OptimizationResult
            {
                BestSolution = globalBestPosition,
                BestObjectiveValue = globalBestValue,
                Iterations = iteration + 1,
                Remarks = "Particle Swarm Optimization completed."
            };
        }
    }
}