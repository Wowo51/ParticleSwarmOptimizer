# Particle Swarm Optimizer

A multivariate Particle Swarm Optimizer. Multicore CPU. Pure C#, no binaries. No dependencies except for Microsoft's unit testing.

## What is PSO?
Particle Swarm Optimization (PSO) is a population-based metaheuristic optimization algorithm inspired by the social behavior of birds flocking or fish schooling. It is useful for finding the minimum (or maximum) of functions without relying on gradient information. Each candidate solution (called a “particle”) moves through the search space influenced by:
1. Its own best-known position.
2. The global best-known position found by any particle in the swarm.

Over multiple iterations, the swarm “collaborates” to converge on an optimal solution.

## How to Use This Library
This library provides a `ParticleSwarmOptimizer` class that implements `IOptimizer` from the `OptimizerInterface` project. Here’s how to integrate it into your .NET 9.0 C# application (without dependencies or external binaries):

1. **Include the Projects**:  
   - `OptimizerInterface` (contains the `IOptimizer` interface, plus `OptimizationOptions` and `OptimizationResult` classes).  
   - `ParticleSwarm` (contains the PSO implementation).

2. **Configure Your Objective Function**:  
   Prepare a function (or delegate) representing the problem you want to minimize.

3. **Set an Initial Guess**:  
   Provide a starting vector for the optimizer.

4. **Adjust Optimization Options** (optional):  
   Such as maximum iterations (`MaxIterations`), convergence tolerance (`Tolerance`), etc.

5. **Invoke PSO**:  
   Create an instance of `ParticleSwarmOptimizer` and call its `Optimize` method, passing in your objective function, initial guess, and any options.

6. **Retrieve Results**:  
   The method returns an `OptimizationResult` containing the best solution found, the best objective value, the number of iterations used, and any remarks.

## How It Works
1. **Initialization**: A swarm of particles is placed randomly in the solution space. Each particle has a position, a velocity, and a memory of its best position so far.
2. **Velocity Update**: Each particle’s velocity is recalculated based on:
   - **Inertia**: Keeps the particle moving in its current direction.
   - **Cognitive Component**: Pulls each particle toward its own best-known position.
   - **Social Component**: Pulls each particle toward the global best-known position.
3. **Position Update**: Particle positions are updated using the new velocities.
4. **Best Tracking**: Each particle updates its personal best, and the algorithm updates the global best if any improvement is found.
5. **Stopping Criteria**: The iteration loop ends if the maximum number of iterations is reached or the objective value is sufficiently low (within `Tolerance`).

## Key Parameters
- **Number of Particles (30 by default)**: Balances coverage of the search space and computational cost.
- **Inertia (default = 0.7)**: Controls how much a particle continues in its current trajectory.
- **Cognitive Component (default = 1.5)**: Strength of pulling a particle toward its personal best.
- **Social Component (default = 1.5)**: Strength of pulling a particle toward the swarm’s best position.
- **MaxIterations (default = 1000)**: The algorithm stops if this number is reached.
- **Tolerance (default = 1e-6)**: If the best objective value is less than or equal to this threshold, the algorithm terminates.

## Parallelization
This library uses `Parallel.For` in the main loop, allowing each particle's update to run on a separate thread for faster performance on multi-core CPUs.

## Customization
- Adjust random initialization ranges in the source code of `ParticleSwarmOptimizer`.
- Modify parameters like `numberOfParticles`, `inertia`, `cognitiveComponent`, and `socialComponent` for tuning performance.
- Extend `OptimizationOptions` for features like custom seeds or logging.

## Testing
The **ParticleSwarmTest** project provides MSTest-based unit tests verifying the optimizer on a known function. You can run or modify these tests to validate changes or new use cases.

## Known Limitations
- PSO does not guarantee a global optimum in all situations, though it often performs well in practice.
- Currently tailored for minimization. Invert the objective function (multiply by -1) to handle maximization problems.
- High-dimensional or very large problems may require additional optimizations.

![AI Image](aiimage.jpg)
</br>
This code is free for non-commercial use. A commercial use license is $20 Canadian.</br>
Copyright [TranscendAI.tech](https://TranscendAI.tech) 2025.</br>
Authored by Warren Harding. AI assisted.</br>
