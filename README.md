# cs-data-structures
Data structures are fundamental for a software engineer. This repository's goal is to demonstrate how one could implement common data structures using nothing more than .Net Core framework installed on a local machine besides Nuget packages such as: XUnit and FluentAssertions which are used for testing purpose.
# Contribution
This repository is contribution friendly. If you'd like to add or improve an anything, you are welcome. Feel free to work on your own and then simply make a pull request.
# Running
To run this whole example you will first of all need to install .Net Core which is avilable at https://dotnet.microsoft.com/download  
Additionaly project with test is using XUnit and FluentAssertions.  
Originally it was written and compiled on macOS Catalina using .Net Core 2.2.2. 
# Data structures
## HashTables
HashTable (HashMap, Dictionary, etc) is a data structure that implements an unordered associative array which connects keys with values. It strongly relies on hashing function used to calculate index in which value would be stored internally.  
We different implementations by the way they solves hash function collisions.  
Examples:
  * [ChainingHashTable](https://github.com/tyburam/cs-data-structures/blob/master/cs-data-structures/DataStructures/ChainingHashTable.cs)
## Lists
List is a data structure that represents collection of values.  
Typical implementations either uses array which is dynamically realocated or elements of class which at least stores both value and pointer/reference to the next element in the list.  
Examples:
  * [DynamicArray](https://github.com/tyburam/cs-data-structures/blob/master/cs-data-structures/DataStructures/DynamicArray.cs)
  * [DoubleLinkedList](https://github.com/tyburam/cs-data-structures/blob/master/cs-data-structures/DataStructures/DoubleLinkedList.cs)
  * [LinkedList](https://github.com/tyburam/cs-data-structures/blob/master/cs-data-structures/DataStructures/LinkedList.cs)
## Queues
Queue is a data structure that represents collection of values stored and processed in FIFO (first-in first-out) order.  
It could be altered by for instance internal mechanism for sorting values using priority mechanism.  
Examples:
  * [Queue](https://github.com/tyburam/cs-data-structures/blob/master/cs-data-structures/DataStructures/Queue.cs)
  * [PriorityQueue](https://github.com/tyburam/cs-data-structures/blob/master/cs-data-structures/DataStructures/PriorityQueue.cs)
## Stack
Stack is a data structure that represents collection of values stored and processed in LIFO (last-in first-out) order.  
Examples:
  * [Stack](https://github.com/tyburam/cs-data-structures/blob/master/cs-data-structures/DataStructures/Stack.cs)
## Trees:
Tree is a data structure which stores data in a hierachical way. With root value at the top of the structures and all the rest below it, connected in a parent-child relation. All the values are acesible throught root and it's child nodes.  
Examples: 
  * [BinarySearchTree](https://github.com/tyburam/cs-data-structures/blob/master/cs-data-structures/DataStructures/BinarySearchTree.cs)
## UnionFind
UnionFind also known as disjoint-set or MergeFind is a data structure that is used to track a set of elements unified into a number of non-overlapping (disjoint) subsets.  
Examples:  
* [UnionFind](https://github.com/tyburam/cs-data-structures/blob/master/cs-data-structures/DataStructures/UnionFind.cs)