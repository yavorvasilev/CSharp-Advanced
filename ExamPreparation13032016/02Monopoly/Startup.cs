namespace _02Monopoly
{
    using System;

    public class Startup
    {
        public static int MoneyOfPlayer = 50;
        public static int CountHotels = 0;
        public static int Jail = 0;
        public static int Turns = 0;

        public static void Main()
        {
            var rowAndCol = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var row = int.Parse(rowAndCol[0]);
            var col = int.Parse(rowAndCol[1]);

            char[][] monopolyFields = CreatMonopolyFields(row, col);
            

            for (int r = 0; r < row; r++)
            {
                if (r % 2 == 0)
                {
                    for (int c = 0; c < col; c++)
                    {
                        if (Jail != 0)
                        {
                            Turns++;
                            c--;
                            Jail--;
                            MoneyOfPlayer += CountHotels * 10;
                        }
                        else
                        {
                            MovePlayer(r, c, monopolyFields);
                            Turns++;
                        }
                    }
                }
                else if (r % 2 != 0)
                {
                    for (int c = col - 1; c >= 0; c--)
                    {
                        if (Jail != 0)
                        {
                            Turns++;
                            c++;
                            Jail--;
                            MoneyOfPlayer += CountHotels * 10;
                        }
                        else
                        {
                            MovePlayer(r, c, monopolyFields);
                            Turns++;
                        }
                    }
                }

            }

            Console.WriteLine($"Turns {Turns + Jail}");
            Console.WriteLine($"Money {MoneyOfPlayer += Jail * CountHotels * 10}");
        }

        private static void MovePlayer(int r, int c, char[][] monopolyFields)
        {
            switch (monopolyFields[r][c])
            {
                case 'H':
                    CountHotels++;
                    Console.WriteLine($"Bought a hotel for {MoneyOfPlayer}. Total hotels: {CountHotels}.");
                    MoneyOfPlayer = 0;
                    break;
                case 'J':
                    Jail = 2;
                    Console.WriteLine($"Gone to jail at turn {Turns}.");
                    break;

                case 'F':
                    break;

                case 'S':
                    var moneySpend = (r + 1) * (c + 1);
                    if (MoneyOfPlayer >= moneySpend)
                    {
                        MoneyOfPlayer -= moneySpend;
                        Console.WriteLine($"Spent {moneySpend} money at the shop.");
                    }
                    else
                    {
                        Console.WriteLine($"Spent {MoneyOfPlayer} money at the shop.");
                        MoneyOfPlayer = 0;
                    }
                    break;
            }

            MoneyOfPlayer += CountHotels * 10;
        }

        private static char[][] CreatMonopolyFields(int row, int col)
        {
            var fields = new char[row][];

            for (int r = 0; r < row; r++)
            {

                fields[r] = new char[col];
                var inputFields = Console.ReadLine();

                for (int c = 0; c < col; c++)
                {
                    fields[r][c] = inputFields[c];
                }
            }

            return fields;
        }
    }
}
