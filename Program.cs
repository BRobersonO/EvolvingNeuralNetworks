using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayWOrk
{
	public class NNet {
    public int[] layers;
    public int[][] neurons; //make float for real thing
    public int[][][] weights; //make float for real thing
    public int fitness;

    public NNet(int[] layers, int[][] neurons, int[][][] weights) {
        this.layers = layers;
        this.neurons = neurons;
        this.weights = weights;
    }
}

	public class GeneticAlgorithm
	{
		//variables
		public static int gens = 1; // Number of Generations
		public static int popSize = 2; // Population Size
		public static List<int> pop = new List<int>();
		public static List<int> selected = new List<int>();
		public static int tourneySize = 3; // Tournamenet Size for Parent Selection
		public static Random rand = new Random();

		public static int[][][] test = new int[][][] {
                                    new int [][] {new int[] {0, 0}, new int[] {0, 0, 0}},
                                    new int [][] {new int[] {0, 0}, new int[] {0, 0}}
            };

		public static int[] lll = { 3, 2, 2 };

		public static int[][] p1nl = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 6, 7 } };

		public static NNet tester = new NNet(lll, p1nl, test);

		//num hidden layers
		//num neurons ea layer
		//rep as array [5, x1, x2, ..., x3, 2]
		//maybe popSize, gens

		static void Main(string[] args)
		{

			//Fake NNets for testing

			//P1

			int[] ll = { 3, 2, 2 };

			int[][] p1n = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5 }, new int[] { 6, 7 } };

			int[][][] p1w = new int[][][] {
                                    new int [][] {new int[] {1, 2, 3}, new int[] {4, 5, 6}},
                                    new int [][] {new int[] {7, 8}, new int[] {9, 10}}
                                };

//			printInner(ref p1w);

			NNet p1 = new NNet(ll, p1n, p1w);

			//printInner(ref p1.weights);

			// P2

			int[][] p2n = new int[][] { new int[] { 8, 9, 10 }, new int[] { 11, 12 }, new int[] { 13, 14 } };

			int[][][] p2w = new int[][][] {
                                    new int [][] {new int[] {11, 12}, new int[] {14, 15, 16}},
                                    new int [][] {new int[] {17, 18}, new int[] {19, 20}}
            };

//			printInner(ref p2w);

			NNet p2 = new NNet(ll, p2n, p2w);

			//printInner(ref p2.weights);

			InitializePopulation();

			//LOOP THROUGH GENERATIONS
			for (int i = 0; i < gens; i++)
			{


				//measure fitness (RUN RACE)

				//select parents
				selected.Clear();
				SelectParents(/* pop, selected, tourneySize */);
				//PrintOut(selected);


				//crossover
				Crossover(p1, p2);


				//mutate
			}
		}

		//init pop
		public static void InitializePopulation()
		{
			for (int i = 0; i < popSize; i++)
			{
				pop.Add(i);
			}
		}

		private static void SelectParents(/* List<int> pop, List<int> selected, int tourneySize */)
		{
			IEnumerable<int> rands1, rands2;
			List<int> one = new List<int>();
			List<int> two = new List<int>();
			//creates two groups of <tourneySize>. Best Fitness of ea group selected
			for (int i = 0; i < tourneySize; i++)
			{
				one.Add(pop[rand.Next(0, pop.Count - 1)]);
				two.Add(pop[rand.Next(0, pop.Count - 1)]);
			}
			rands1 = one;
			rands2 = two;

			selected.Add(rands1.Max()); //Max here is stand-in for best fitness score
			selected.Add(rands2.Max());
		}

		public static void PrintOut(List<int> something)
		{
			foreach (var item in something)
			{
				Console.WriteLine(item);
			}
		}

		private static void printInner(ref int[][][] dest)
		{
			for (int i = 0; i < dest.Length; i++)
			{
				for (int j = 0; j < dest[i].Length; j++)
				{
					for (int k = 0; k < dest[i][j].Length; k++)
					{
						Console.WriteLine( dest[i][j][k] );
					}
				}
			}
		}

		private static void copyInner(ref int[][][] dest, ref int[][][] src1, ref int[][][] src2, int i)
		{
			if( i % 2 == 0 )
			{
				for (int j = 0; j < dest[i].Length; j++)
				{
					for (int k = 0; k < dest[i][j].Length; k++)
					{
						dest[i][j][k] = src1[i][j][k];
					}
				}
			}
			else
			{
				for (int j = 0; j < dest[i].Length; j++)
				{
					for (int k = 0; k < dest[i][j].Length; k++)
					{
						dest[i][j][k] = src2[i][j][k];
					}
				}
			}
		}

		public static void Crossover(NNet one, NNet two)
		{
			NNet child1 = new NNet(lll, p1nl, test);
			NNet child2 = new NNet(lll, p1nl, test);

			printInner(ref child1.weights);
			printInner(ref child2.weights);

			// child1.layers = one.layers;
			// child1.neurons = one.neurons;
			// child2.layers = two.layers;
			// child2.neurons = two.neurons;

			for (int i = 0; i < one.layers.Length - 1; i++)
			{
				copyInner(ref child1.weights, ref one.weights, ref two.weights, i );
				copyInner(ref child2.weights, ref two.weights, ref one.weights, i);
			}

			Console.WriteLine("Child1");

			Console.WriteLine(child1.weights[0][0][0]); //1
			Console.WriteLine(child1.weights[0][1][0]); //4
			Console.WriteLine(child1.weights[1][0][0]); //17
			Console.WriteLine(child1.weights[1][1][0]); //19

			Console.WriteLine(child1.weights[0][0][1]); //2
			Console.WriteLine(child1.weights[0][1][1]); //5
			Console.WriteLine(child1.weights[1][0][1]); //18
			Console.WriteLine(child1.weights[1][1][1]); //20  

			Console.WriteLine("Child2");

			Console.WriteLine(child2.weights[0][0][0]); //11
			Console.WriteLine(child2.weights[0][1][0]); //14
			Console.WriteLine(child2.weights[1][0][0]); //7
			Console.WriteLine(child2.weights[1][1][0]); //9

			Console.WriteLine(child2.weights[0][0][1]); //12
			Console.WriteLine(child2.weights[0][1][1]); //15
			Console.WriteLine(child2.weights[1][0][1]); //8
			Console.WriteLine(child2.weights[1][1][1]); //10      
		}
	}
}
