using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TerroristsWin
{
    static void Main()
    {
        char[] command = Console.ReadLine().ToCharArray();

        int endOfBomb = 0;
        for (int i = 0; i < command.Length; i++)
        {
            if(command[i] == '|')
            {
                int bomb = 0;
                for (int j = i+1; j < command.Length; j++)
                {
                    if (command[j] == '|')
                    {
                        endOfBomb = j;
                        break;
                    }

                    bomb += Convert.ToInt32(command[j]);
                }
                
                string bombPower = bomb.ToString();
                int power = int.Parse(bombPower[bombPower.Length - 1].ToString());


                for (int k = i; k >= i-power; k--) // destroys X amount before bomb
                {
                    if (k < 0)
                        break;
                    command[k] = '.';
                }
                for (int k = endOfBomb; k <= endOfBomb+power; k++) // destroys X amount from bomb
                {
                    
                    if(k == endOfBomb)
                    {
                        for (int l = i; l < k; l++) // destroys bomb
                        {
                            command[l] = '.';
                        }
                    }
                    if (command.Length <= k)
                        break;
                    command[k] = '.';
                }
               // i = endOfBomb;
            }
        }

        foreach (var item in command)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}

