PS D:\repos\dotnet_cui_memo> dotnet new sln --name test04 --output dotnet_cui_memo_test04
テンプレート "ソリューション ファイル" が正常に作成されました。

PS D:\repos\dotnet_cui_memo> cd .\dotnet_cui_memo_test04\
PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet new classlib --name ICommandImpl --output ICommandImpl
テンプレート "クラス ライブラリ" が正常に作成されました。

作成後の操作を処理しています...
D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04\ICommandImpl\ICommandImpl.csproj を復元しています:
正常に復元されました。


PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet new classlib --name DisplayOperator --output DisplayOperator
テンプレート "クラス ライブラリ" が正常に作成されました。

作成後の操作を処理しています...
D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04\DisplayOperator\DisplayOperator.csproj を復元しています:
正常に復元されました。


PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet new wpf --name MVVM --output MVVM
テンプレート "WPF アプリケーション" が正常に作成されました。

作成後の操作を処理しています...
D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04\MVVM\MVVM.csproj を復元しています:
正常に復元されました。


PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet new wpf --name EnumDisplay --output EnumDisplay
テンプレート "WPF アプリケーション" が正常に作成されました。

作成後の操作を処理しています...
D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04\EnumDisplay\EnumDisplay.csproj を復元しています:
正常に復元されました。

※ここで MVVM.csproj を編集

PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet sln test04.sln add ICommandImpl/ICommandImpl.csproj
プロジェクト `ICommandImpl\ICommandImpl.csproj` をソリューションに追加しました。
PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet sln test04.sln add DisplayOperator/DisplayOperator.csproj
プロジェクト `DisplayOperator\DisplayOperator.csproj` をソリューションに追加しました。
PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet sln test04.sln add MVVM/MVVM.csproj
プロジェクト `MVVM\MVVM.csproj` をソリューションに追加しました。
PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet sln test04.sln add EnumDisplay/EnumDisplay.csproj
プロジェクト `EnumDisplay\EnumDisplay.csproj` をソリューションに追加しました。
PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet add MVVM/MVVM.csproj reference ICommandImpl/ICommandImpl.csproj  
参照 `..\ICommandImpl\ICommandImpl.csproj` がプロジェクトに追加されました。
PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet add MVVM/MVVM.csproj reference DisplayOperator/DisplayOperator.csproj  
参照 `..\DisplayOperator\DisplayOperator.csproj` がプロジェクトに追加されました。
PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet add EnumDisplay/EnumDisplay.csproj reference MVVM/MVVM.csproj  
参照 `..\MVVM\MVVM.csproj` がプロジェクトに追加されました。
PS D:\repos\dotnet_cui_memo\dotnet_cui_memo_test04> dotnet build EnumDisplay/EnumDisplay.csproj
復元が完了しました (0.2 秒)
  ICommandImpl 成功しました (0.1 秒) → ICommandImpl\bin\Debug\net9.0\ICommandImpl.dll
  DisplayOperator 成功しました (0.3 秒) → DisplayOperator\bin\Debug\net9.0\DisplayOperator.dll
  MVVM 成功しました (0.3 秒) → MVVM\bin\Debug\net9.0-windows\MVVM.dll
  EnumDisplay 成功しました (0.3 秒) → EnumDisplay\bin\Debug\net9.0-windows\EnumDisplay.dll

1.4 秒後に 成功しました をビルド