Item[] items = [
  new(){ value = 11, weight = 6},
  new(){ value = 9, weight = 5},
  new(){ value = 18, weight = 8},
  new(){ value = 6, weight = 2},
  new(){ value = 7, weight = 3},
  new(){ value = 3, weight = 1}
  ];


(int[,] backpacks, bool[,] boolTable) = Solution(15,items);
List<Item> itemsOfSolution = GetItems(items, backpacks, boolTable);

foreach (var item in itemsOfSolution)
{
  Console.WriteLine($"value: {item.value}; weight:{item.weight}");
}