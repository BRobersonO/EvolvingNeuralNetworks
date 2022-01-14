# EvolvingNeuralNetworks
Here are the preliminary programs I made towards implementing a Genetic Algorithm that evolved a Nueral Networ to control a digital car on a track within Unity.

Comparative Analysis of Digital Self-Driving Vehicles: Genetic
Algorithm vs Reinforcement Learning
I worked on a team to study the results of a
genetic algorithm (GA) evolving a self-driving car as represented in a digital
3-dimensional (3D) environment. We compared the results of the GA-evolved car to a
car trained by a widely available deep learning method of machine reinforcement
learning (RL) as well as a human-controlled car. We wanted to discover the relative
power a GA has in creating smart artificial intelligence (AI) in comparison to other
machine learning methods as well as human ability. In many video games, when
parameters are kept equal, AI greatly underperforms human capabilities. We anticipated
experimenting with different ways of evolving a self-driving car as represented in a
digital 3D environment in order to help explore what potential might exist for further AI
competitiveness. We utilized the popular game engine Unity, a tool available for free
when used non-commercially (and even commercially within limits), in order to create
the 3D environment in which a digital car controlled by a neural network learned how to
race around a track. In the case of a self-driving AI car, an ‘individual’ in the GA’s
population will be a digital car object, which most notably contains a neural network,
which acts as the ‘brain’ or agent that drives the car. The input nodes to the neural net
were equal to the number of, and derived their values from, raycasts spreading outward
from the central point of the car which had the ability to sense walls and checkpoints on
the track. The output nodes of the neural were two: acceleration and turn radius.
Iterating on the number of hidden layers and number of nodes within a hidden layer
provided the bulk of the experimentation process. Evolutionary algorithms have already
proven to outperform popular ML algorithms at training agents to self-drive in
two-dimension pixel digital environments. This work has been extended in our project,
as a GA was used on agents in 3D environments, demonstrating their
already-established ability to handle greater complexity in video game settings. A GA,
working on a simple implementation of a neural network, was able to outperform the
commercially available method of RL in training a car to self-drive around a track. It
accomplished this simply by testing diverse structures of the neural network controlling
the car. These results build anticipation for even more complex actions and
environments for GA's to tackle in the realm of video game AI.
