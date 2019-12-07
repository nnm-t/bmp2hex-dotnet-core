# Bitmap2Hex

.NET Core 版 ビットマップデータを数値配列へ変換するツール

## 動作確認環境

- Windows 10 x64
- .NET Core 3.1 LTS
- JetBrains Rider 2019.2

## コマンドラインオプション

```sh
Bitmap2Hex [-t|--type] [ARGB32|RGB16] [-o|--output] {output} {input}
```

### -t / --type

変換先のデータ形式

- ARGB32
  - 32ビット A 8bit, R 8bit, G 8bit, B 8bit
- RGB16
  - 16ビット R 5bit, G 6bit, B 5bit
  
 ### -o/--output
 
 出力ファイル名
 
 C 言語形式の配列データで出力される
 
 ### input
 
 入力ファイル名 `System.Drawing.Bitmap` が読み込める形式が扱える
