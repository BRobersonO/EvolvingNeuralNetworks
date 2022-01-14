using System.Collections.Generic;
using System.Linq;
using System;

public class NeuralNetwork {
    public int[] layers;
    public int[][] neurons; //make float for real thing
    public int[][][] weights; //make float for real thing
    public int fitness;

    public NeuralNetwork(int[] layers, int[][] neurons, int[][][] weights, int fitness) {
        this.layers = layers;
        this.neurons = neurons;
        this.weights = weights;
        this.fitness = fitness;
    }
}

public class GeneticAlgorithm {
        //variables
        public static int GENS = 1; // Number of Generations
        public static  int POPSIZE = 2; // Population Size
        public static List<NeuralNetwork> POP = new List<NeuralNetwork>(); 
        public static List<NeuralNetwork> selected = new List<NeuralNetwork>(); 
        public static int TOURNEYSIZE = 3; // Tournamenet Size for Parent Selection
        public static Random rand = new Random();
        public static NeuralNetwork BESTIND; //Best ind. of all
        public static double AVERAGEFIT; // average fitness

        //Initializer
        public GeneticAlgorithm(int [] LAYERS) {
            this.LAYERS = LAYERS;
            return runGA(LAYERS);
        }
        
        public static int[][][] test =     new int [][][] {
                                    new int [][] {new int[] {0, 0}, new int[] {0, 0, 0}},
                                    new int [][] {new int[] {0, 0}, new int[] {0, 0}}
            };

        public static int[] lll = {3, 2, 2};
            
        public static int[][] p1nl =  new int [][] {new int[] {1, 2, 3}, new int[] {4, 5}, new int[] {6, 7}};

        public static NeuralNetwork tester = new NeuralNetwork(lll, p1nl, test, 0);

            //Fake NeuralNetworks for testing

            //P1
            
        public static    int[] ll = {3, 2, 2};
            
        public static    int[][] p1n =  new int [][] {new int[] {1, 2, 3}, new int[] {4, 5}, new int[] {6, 7}};

        public static    int[][][] p1w =     new int [][][] {
                                    new int [][] {new int[] {1, 2, 3}, new int[] {4, 5, 6}},
                                    new int [][] {new int[] {7, 8}, new int[] {9, 10}}
                                };

        public static    NeuralNetwork p1 = new NeuralNetwork(ll, p1n, p1w, 1); 

            // P2
            
        public static    int[][] p2n =  new int [][] {new int[] {8, 9 ,10}, new int[] {11, 12}, new int[] {13, 14}};

        public static    int[][][] p2w =     new int [][][] {
                                    new int [][] {new int[] {11, 12}, new int[] {14, 15, 16}},
                                    new int [][] {new int[] {17, 18}, new int[] {19, 20}}
            };                            

        public static    NeuralNetwork p2 = new NeuralNetwork(ll, p2n, p2w, 0);

        //num hidden layers
        //num neurons ea layer
            //rep as array [5, x1, x2, ..., x3, 2]
        //maybe POPSIZE, GENS

        static void Main(string[] args) {

            InitializePopulation();

            //LOOP THROUGH GENERATIONS
            for (int i = 0; i < GENS; i++) {


                //measure fitness (RUN RACE)

                //sort pop
                POP = POP.OrderBy(x => x.fitness).ToList();
                BESTIND = POP[0];

                //repopulate
                List<NeuralNetwork> newPop = new List<NeuralNetwork>();
                for(int j = 0; j < POPSIZE; j++) {
                    // 1/4 elitism
                    if(j < POPSIZE / 4) {
                        newPop.Add(POP[j]);
                    }
                    // 2/4 Xover
                    else if (j < (POPSIZE / 4) * 3) {
                        selected.Clear();
                        SelectParents(/* POP, selected, TOURNEYSIZE */);
                        NeuralNetwork child1 = tester; //!Initialize  child using NeuralNetwork.cs
                        NeuralNetwork p1 = selected[0]; 
                        NeuralNetwork p2 = selected[1];
                        Crossover(ref p1.weights, ref p2.weights, ref child1.weights, child1.layers.Length - 1);
                        newPop.Add(child1);
                    }
                    // 1/4 newly generated
                    else {
                        newPop.Add(/*NeuralNetwork Generator*/);
                    }
                }
                POP = newPop;
            }
            //average fitness of final population.. maybe don't want this but it's easiest
            AVERAGEFIT = POP.Select(x => x.fitness).Average();

            //best individual: Write to JSON???

        }

    //init POP
    public static void InitializePopulation() {
        // for (int i = 0; i < POPSIZE; i++)
        // {
        //     POP.Add(i); //! Populate using constructor from NeuralNet.cs
        // }
        POP.Add(p1);
        POP.Add(p2);
    }

    private static void SelectParents (/* List<int> POP, List<int> selected, int TOURNEYSIZE */) {
        IEnumerable <NeuralNetwork> rands1, rands2;
        List<NeuralNetwork> one = new List<NeuralNetwork>();
        List<NeuralNetwork> two = new List<NeuralNetwork>();
        //creates two groups of <TOURNEYSIZE>. Best Fitness of ea group selected
        for (int i = 0 ; i < TOURNEYSIZE; i++) {
            one.Add(POP[rand.Next(0, POP.Count - 1)]);
            two.Add(POP[rand.Next(0, POP.Count - 1)]);
        }
        rands1 = one;
        rands2 = two;

        selected.Add(rands1.OrderBy(x => x.fitness).First());
        selected.Add(rands2.OrderBy(x => x.fitness).First());
    }

    public static void PrintOut (List<NeuralNetwork> something) {
        foreach (var item in something)
        {
            Console.WriteLine(item);
        }
    }

    public static void Crossover(ref int[][][] src1, ref int[][][] src2, ref int[][][] dest1, int length) {
        for(int i = 0; i < length; i++) {
			if( i % 2 == 0 )
			{
				for (int j = 0; j < dest1[i].Length; j++)
				{
					for (int k = 0; k < dest1[i][j].Length; k++)
					{
						dest1[i][j][k] = src1[i][j][k];
					}
				}
			}
			else
			{
				for (int j = 0; j < dest1[i].Length; j++)
				{
					for (int k = 0; k < dest1[i][j].Length; k++)
					{
						dest1[i][j][k] = src2[i][j][k];
					}
				}
			}
		}    
    }
}

        // Console.WriteLine("Child1");

        // Console.WriteLine(child1.weights[0][0][0]); //1
        // Console.WriteLine(child1.weights[0][1][0]); //4
        // Console.WriteLine(child1.weights[1][0][0]); //17
        // Console.WriteLine(child1.weights[1][1][0]); //19

        // Console.WriteLine(child1.weights[0][0][1]); //2
        // Console.WriteLine(child1.weights[0][1][1]); //5
        // Console.WriteLine(child1.weights[1][0][1]); //18
        // Console.WriteLine(child1.weights[1][1][1]); //20  