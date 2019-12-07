using System;

namespace Bitmap2Hex
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = CommandLineOption.Parse(args);
            
            var converter = new BitmapConverter(options.Input);
            uint[][] array = converter.ToHexArray(options.Type);
            
            var result = new BitmapResult(array);
            
            result.WriteStandardOutput();
            result.WriteFile(options.Output);
        }
    }
}