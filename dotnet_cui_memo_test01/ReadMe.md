```
PS E:\repos> dotnet new sln --name test01 --output test01
テンプレート "ソリューション ファイル" が正常に作成されました。

PS E:\repos> cd test01
PS E:\repos\test01> dotnet new classlib --name model --output model
テンプレート "クラス ライブラリ" が正常に作成されました。

作成後の操作を処理しています...
E:\repos\test01\model\model.csproj を復元しています:
  復元対象のプロジェクトを決定しています...
  E:\repos\test01\model\model.csproj を復元しました (59 ms)。
正常に復元されました。

PS E:\repos\test01> dotnet new wpf --name test01 --output test01 
テンプレート "WPF アプリケーション" が正常に作成されました。

作成後の操作を処理しています...
E:\repos\test01\test01\test01.csproj を復元しています:
  復元対象のプロジェクトを決定しています...
  E:\repos\test01\test01\test01.csproj を復元しました (52 ms)。
正常に復元されました。

PS E:\repos\test01> dotnet add test01/test01.csproj reference model/model.csproj
参照 `..\model\model.csproj` がプロジェクトに追加されました。

PS E:\repos\test01> dotnet build model/model.csproj
MSBuild のバージョン 17.7.3+8ec440e68 (.NET)
  復元対象のプロジェクトを決定しています...
  復元対象のすべてのプロジェクトは最新です。
  model -> E:\repos\test01\model\bin\Debug\net7.0\model.dll

ビルドに成功しました。
    0 個の警告
    0 エラー

経過時間 00:00:02.49

PS E:\repos\test01> dotnet build test01/test01.csproj
MSBuild のバージョン 17.7.3+8ec440e68 (.NET)
  復元対象のプロジェクトを決定しています...
  E:\repos\test01\test01\test01.csproj を復元しました (79 ms)。
  2 個中 1 個の復元対象のプロジェクトは最新です。
  model -> E:\repos\test01\model\bin\Debug\net7.0\model.dll
  test01 -> E:\repos\test01\test01\bin\Debug\net7.0-windows\test01.dll

ビルドに成功しました。
    0 個の警告
    0 エラー

経過時間 00:00:01.41
```
