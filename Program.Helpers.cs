using System.Reflection.Metadata;

partial class Program
{
  public class Item
  {
    public int weight;
    public int value;
  }

  public static (int[,] values, bool[,] boolTable) Solution(in int MAX_WEIGHT, in Item[] items)
  {
    //linha é o item, coluna é o peso máximo de cada mochila
    int[,] backPacks = new int[items.Length+1, MAX_WEIGHT + 1];
    bool[,] itemsInBackpack = new bool[items.Length+1, MAX_WEIGHT + 1];

    //initialazing the first line of the matrix
    // for(int i = 0; i < backPacks.GetLength(1);i++)
    // {
    //   backPacks[0, i] = 0;
    //   itemsInBackpack[0, i] = false;
    // }

    int currentLine;
    int smallerBackpack = 0;
    int newValue = 0;
    int oldValue = 0;
    for(int i = 0; i < items.Length;i++)
    {
      currentLine = i + 1;
      Item currentItem = items[i];

      //agora verificamos se o item é uma solução ótima do problema para as outras mochilas
      for(int backpack = 0; backpack<backPacks.GetLength(1);backpack++)
      {
        //para isso eu verifico se o a mochila já possuia uma solução ótima anterior ao item
        //essa solução ótima pode ser:
        //a mochila atual com o peso do item + a solução ótima de uma mochila mais leve
        //ou uma solução anterior da mochila atual
        //escolhemos a maior solução do caso
        smallerBackpack = backpack - currentItem.weight;
        if (smallerBackpack < 0) smallerBackpack = 0;
        newValue = backPacks[currentLine-1, smallerBackpack] + currentItem.value;

        // try
        // {
          oldValue = backPacks[currentLine - 1, backpack];
          
        // }
        // catch (System.Exception)
        // {
        //   Console.WriteLine($"backPacks Lines:{backPacks.GetLength(0)} actual line: {currentLine-1}");
        //   Console.WriteLine($"backPacks columns:{backPacks.GetLength(1)} actual column: {backpack}");
        //   // throw;
        // }

        //se o novo valor for maior que o anterior salvamos o valor
        //se não, continuamos com o velho
        if(oldValue< newValue)
        {
          backPacks[currentLine, backpack] = newValue;
          itemsInBackpack[currentLine, backpack] = true;
        }else
        {

          backPacks[currentLine, backpack] = oldValue;
          itemsInBackpack[currentLine, backpack] = false;
        }

      }
    }

    return (backPacks, itemsInBackpack);
  }

  public static List<Item> GetItems(Item[] items, int[,]backpacks, bool[,] boolTable)
  {
    List<Item> itemsOnBackpack = [];
    int lastLine = items.Length;
    int backPack = boolTable.GetLength(1) - 1;
    for(int line = lastLine; line > 0; line--)
    {
      if(boolTable[line,backPack])
      {
        backPack -= items[line-1].weight;
        if(backPack < 0)
        {
          return itemsOnBackpack;
          
        }
        itemsOnBackpack.Add(items[line-1]);
        
      }

    }

    return itemsOnBackpack;
  }
}