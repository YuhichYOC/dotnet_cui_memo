```
PS E:\repos> dotnet new sln --name test02 --output test02
テンプレート "ソリューション ファイル" が正常に作成されました。

PS E:\repos> cd test02
PS E:\repos\test02> dotnet new classlib --name ICommandImpl --output ICommandImpl
テンプレート "クラス ライブラリ" が正常に作成されました。

作成後の操作を処理しています...
E:\repos\test02\ICommandImpl\ICommandImpl.csproj を復元しています:
  復元対象のプロジェクトを決定しています...
  E:\repos\test02\ICommandImpl\ICommandImpl.csproj を復元しました (51 ms)。
正常に復元されました。


PS E:\repos\test02> dotnet new classlib --name model --output model
テンプレート "クラス ライブラリ" が正常に作成されました。

作成後の操作を処理しています...
E:\repos\test02\model\model.csproj を復元しています:
  復元対象のプロジェクトを決定しています...
  E:\repos\test02\model\model.csproj を復元しました (43 ms)。
正常に復元されました。


PS E:\repos\test02> dotnet new wpf --name test02 --output test02
テンプレート "WPF アプリケーション" が正常に作成されました。

作成後の操作を処理しています...
E:\repos\test02\test02\test02.csproj を復元しています:
  復元対象のプロジェクトを決定しています...
  E:\repos\test02\test02\test02.csproj を復元しました (49 ms)。
正常に復元されました。


PS E:\repos\test02> dotnet sln test02.sln add ICommandImpl/ICommandImpl.csproj
プロジェクト `ICommandImpl\ICommandImpl.csproj` をソリューションに追加しました。
PS E:\repos\test02> dotnet sln test02.sln add model/model.csproj
プロジェクト `model\model.csproj` をソリューションに追加しました。
PS E:\repos\test02> dotnet sln test02.sln add test02/test02.csproj
プロジェクト `test02\test02.csproj` をソリューションに追加しました。
PS E:\repos\test02> dotnet add model/model.csproj reference ICommandImpl/ICommandImpl.csproj
参照 `..\ICommandImpl\ICommandImpl.csproj` がプロジェクトに追加されました。
PS E:\repos\test02> dotnet add test02/test02.csproj reference model/model.csproj
参照 `..\model\model.csproj` がプロジェクトに追加されました。
PS E:\repos\test02> dotnet build test02/test02.csproj
MSBuild のバージョン 17.7.3+8ec440e68 (.NET)
  復元対象のプロジェクトを決定しています...
  E:\repos\test02\model\model.csproj を復元しました (78 ms)。
  E:\repos\test02\test02\test02.csproj を復元しました (78 ms)。
  3 個中 1 個の復元対象のプロジェクトは最新です。
  ICommandImpl -> E:\repos\test02\ICommandImpl\bin\Debug\net7.0\ICommandImpl.dll
  model -> E:\repos\test02\model\bin\Debug\net7.0\model.dll
  test02 -> E:\repos\test02\test02\bin\Debug\net7.0-windows\test02.dll

ビルドに成功しました。
    0 個の警告
    0 エラー

経過時間 00:00:04.24
```
