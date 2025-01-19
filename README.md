# Particle Swarm Optimizer

A multivariate Particle Swarm Optimizer. Multicore CPU. Pure C#, no dependencies, no binaries.

## What is Particle Swarm Optimization?

Particle Swarm Optimization (PSO) is a population-based stochastic optimization technique inspired by the social behavior of birds or fish schools. Each individual in the population (called a *particle*) explores the search space, guided by:
- Its own best position found so far (personal best).
- The best position found so far by any particle in the population (global best).

Over multiple iterations, particles accelerate toward these personal and global best positions, effectively “swarming” around optimal or near-optimal solutions. PSO is widely used for solving continuous optimization problems, and it has the advantages of simplicity, few parameters, and reasonable performance across diverse domains.

## How to Use This Library

This library provides a straightforward implementation of PSO in pure C#. Below is a general guide on how to integrate and use it:

1. **Reference the Library**  
   - Include the `.cs` file(s) in your project or reference the compiled assembly.
   - Import the namespace (e.g., `using ParticleSwarmOptimizer;`) where needed.

2. **Define Your Objective Function**  
   - PSO needs a function to evaluate the “fitness” or “cost” of a solution.
   - This function must accept a vector of parameters (e.g., `double[] position`) and return a single scalar value representing the quality of that position.
   - Example:
     ```csharp
     // Example objective function: Sphere function
     double SphereFunction(double[] position)
     {
         double sum = 0.0;
         foreach (var x in position)
             sum += x * x;
         return sum;
     }
     ```

3. **Configure the PSO**  
   - Set the number of particles, the boundaries for each dimension, and PSO-related parameters:
     ```csharp
     var pso = new ParticleSwarm(
         dimension: 3,                     // Number of parameters
         swarmSize: 30,                    // Number of particles
         lowerBound: new double[] {-10, -10, -10},
         upperBound: new double[] {10, 10, 10}
     );
     
     pso.InertiaWeight = 0.7;             // Typical range: [0.5, 1.0]
     pso.CognitiveCoefficient = 1.5;      // Typical range: [1.0, 2.0]
     pso.SocialCoefficient = 1.5;         // Typical range: [1.0, 2.0]
     ```

4. **Run the Optimization**  
   - Provide the objective function and run for a specified number of iterations (or until convergence):
     ```csharp
     pso.Optimize(SphereFunction, iterations: 1000);
     ```

5. **Retrieve the Results**  
   - After optimization, query the best-found position and its cost:
     ```csharp
     double[] bestSolution = pso.BestPosition;
     double bestCost = pso.BestCost;
     Console.WriteLine("Best Position: " + string.Join(",", bestSolution));
     Console.WriteLine("Best Cost: " + bestCost);
     ```

6. **Multicore Capability**  
   - The library can leverage multiple CPU cores. It may do this automatically or provide configuration options.

## Example Usage

Below is a minimal example demonstrating typical usage:

```csharp
using System;

namespace PSOExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Objective function for demonstration (Sphere)
            double SphereFunction(double[] pos)
            {
                double sum = 0;
                foreach (var x in pos)
                    sum += x * x;
                return sum;
            }

            // Create a PSO instance for a 3-dimensional problem
            var pso = new ParticleSwarm(
                dimension: 3,
                swarmSize: 30,
                lowerBound: new double[] {-5, -5, -5},
                upperBound: new double[] {5, 5, 5}
            );

            // Optionally adjust PSO parameters
            pso.InertiaWeight = 0.7;
            pso.CognitiveCoefficient = 1.4;
            pso.SocialCoefficient = 1.4;

            // Run the optimization
            pso.Optimize(SphereFunction, iterations: 500);

            // Retrieve the results
            Console.WriteLine("Best position found:");
            Console.WriteLine(string.Join(",", pso.BestPosition));
            Console.WriteLine("Cost at best position:");
            Console.WriteLine(pso.BestCost);
        }
    }
}