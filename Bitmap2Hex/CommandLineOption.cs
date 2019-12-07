using System;
using CommandLine;

namespace Bitmap2Hex
{
    public class CommandLineOption
    {
        [Option('t', "type", Default = BitmapType.RGB16, HelpText = "ビットマップの変換フォーマット (ARGB32/RGB16")]
        public BitmapType Type { get; set; }
        
        [Option('o', "output", HelpText = "出力先のファイル名")]
        public string Output { get; set; }
        
        [Value(1, HelpText = "変換元のファイル名")]
        public string Input { get; set; }

        public CommandLineOption()
        {
            
        }

        public static CommandLineOption Parse(string[] args)
        {
            var result = Parser.Default.ParseArguments<CommandLineOption>(args);

            var options = result as Parsed<CommandLineOption>;

            if (result.Tag != ParserResultType.Parsed || options == null)
            {
                throw new InvalidOperationException("コマンドライン引数の展開に失敗しました.");
            }

            return options.Value;
        }
    }
}