# Particle Swarm Optimizer

A multivariate Particle Swarm Optimizer. Multicore CPU. Pure C#, no dependencies, no binaries.

## What is Particle Swarm Optimization?

Particle Swarm Optimization (PSO) is a population-based stochastic optimization technique inspired by the social behavior of birds or fish. In this method, a population (or *swarm*) of candidate solutions (called *particles*) simultaneously explores the search space. Each particle adjusts its trajectory based on:
- Its personal best position found so far.
- The best position discovered by the entire swarm (global best).

Particles thereby “swarm” around optimal or near-optimal solutions. PSO excels at tackling continuous optimization problems and is often praised for its simplicity and relatively few tuning parameters.

## How to Use This Library

1. **Setup**  
   - Include this library’s `.cs` file(s) in your project or reference the compiled assembly.  
   - Import the relevant namespace in your C# files.

2. **Define an Objective Function**  
   - Provide a function that measures the quality (or cost) of any given set of parameters.  
   - This function should return a numeric value indicating how good the solution is.

3. **Configure the Optimizer**  
   - Specify the dimensionality of your problem (number of parameters).  
   - Set the swarm size (number of particles).  
   - Define the lower and upper search bounds for each dimension.  
   - Adjust hyperparameters such as inertia weight, cognitive coefficient, and social coefficient.

4. **Run the Optimization**  
   - Pass in the objective function and set the number of iterations or stopping criteria.  
   - Each iteration, particles will update their positions and velocities according to both their personal best and the global best found by the swarm.

5. **Retrieve the Results**  
   - After execution completes, you can access the best position (the optimal parameter set) and its corresponding cost (the minimum value of the objective function).

6. **Multicore Execution**  
   - The library is designed to utilize multiple CPU cores, which can expedite evaluations if your objective function is computationally heavy.

## Customization and Advanced Settings

- **Inertia Weight**: Influences how much of a particle’s previous velocity is retained (balancing exploration vs. exploitation).  
- **Cognitive Coefficient**: Determines how strongly a particle is pulled towards its personal best solution.  
- **Social Coefficient**: Determines how strongly a particle is pulled towards the global best solution.  
- **Boundary Conditions**: Decide what happens when particles move outside the defined search space (e.g., clamping or reflection).

## When to Use PSO

- Useful for continuous optimization problems (though discrete variants exist).  
- Straightforward to implement and requires minimal parameter tuning compared to many other methods.  
- Suited for parallel evaluations, leveraging multiple CPU cores.  
- Effective for both low-dimensional and moderately high-dimensional problems.

## Limitations

- May be computationally intensive if objective function evaluations are expensive.  
- Sensitivity to parameter choices (e.g., swarm size, inertia, cognitive, social coefficients).  
- Can converge prematurely in complex landscapes if not properly tuned.

## Getting Help

- Consult the library’s source code comments for further details.  
- Contact the author for advanced use cases, additional features, or specialized stopping criteria.

![AI Image](aiimage.jpg)
</br>
Copyright [TranscendAI.tech](https://TranscendAI.tech) 2025.
<br>
Authored by Warren Harding. AI assisted.</br>
