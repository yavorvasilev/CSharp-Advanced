namespace _01MatrixOfPalindromes
{
    using System;
    using System.Linq;
    using System.Text;

    public class MatrixPalindromes
    {
        public static void Main()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var rowAndCol = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var row = rowAndCol[0];
            var col = rowAndCol[1];

            var matrix = new string[row][];

            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r] = new string[col];
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    var palindrom = new StringBuilder();
                    palindrom.Append(alphabet[r]);
                    palindrom.Append(alphabet[r + c]);
                    palindrom.Append(alphabet[r]);
                    matrix[r][c] = palindrom.ToString();
                }
            }

            foreach (var palindromes in matrix)
            {
                Console.WriteLine(string.Join(" ",palindromes));
            }
        }
    }
}
