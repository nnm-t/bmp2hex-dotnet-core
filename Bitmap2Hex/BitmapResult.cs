using System;
using System.IO;
using System.Text;

namespace Bitmap2Hex
{
    public class BitmapResult
    {
        private readonly uint[][] array;
        private readonly string outputString;

        public BitmapResult(uint[][] array)
        {
            this.array = array ?? throw new ArgumentNullException(nameof(array));

            outputString = BuildString();
        }

        public void WriteStandardOutput()
        {
            Console.WriteLine(outputString);
        }

        public override string ToString()
        {
            return outputString;
        }

        public void WriteFile(string output)
        {
            if (string.IsNullOrEmpty(output))
            {
                return;
            }
            
            using (var sw = new StreamWriter(output))
            {
                sw.WriteLine(outputString);
            }
        }

        private string BuildString()
        {
            var stringBuilder = new StringBuilder();

            var yLength = array.Length;

            stringBuilder.Append("{ ");

            for (int y = 0; y < yLength; y++)
            {
                var xLength = array[y].Length;

                for (int x = 0; x < xLength; x++)
                {
                    stringBuilder.Append("0x");
                    stringBuilder.Append(array[y][x].ToString("X"));

                    if (x < xLength - 1 || y < yLength - 1)
                    {
                        stringBuilder.Append(", ");
                    }
                }
            }
            
            stringBuilder.Append(" }");

            return stringBuilder.ToString();
        }
    }
}