# SaveDataLibrary
Unity環境で簡単に暗号化済みセーブデータの作成を行うためのライブラリです。  
データはXORで暗号化された状態で保存されます。  
保存パスはAssets直下です。  
![image](https://github.com/user-attachments/assets/d78135f9-be4f-491a-98c8-8c1ee28fbdf5)

導入する際は、Releaseからバージョンを選んでUnityPackageをダウンロードしてください。  
動作確認バージョン：**Unity2022.3.40f1**  


# 使い方
- データは暗号化されるのでProjectウィンドウのSaveDataViewer (ScriptableSingleton)から変更します。
![image](https://github.com/user-attachments/assets/0fcecdd2-8607-4950-af65-a47aac1cd964)

- 保存するデータを変更する際はSaveDataViewerのフィールドにある`saveData`変数の型を変更します
```C#
public class SaveDataViewer : ScriptableSingleton<SaveDataViewer>
{
    [SerializeField]
    SampleData sampleData;
```
- その際に各メソッド内の型と必要であればResetメソッドの呼び出しを書いてください。
```C#
[ContextMenu("Save")]
public void Save()
{
    TextFileManager<SampleData>.Save(saveData);
}

[ContextMenu("Load")]
public void Load()
{
    TextFileManager<SampleData>.Load(saveData);
}

[ContextMenu("Reset")]
public void Reset()
{
    saveData.Reset();
    TextFileManager<SampleData>.Save(saveData);
}
```
