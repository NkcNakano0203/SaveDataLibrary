using Service.SaveLoad.Sample;
using UnityEditor;
using UnityEngine;

namespace Service.SaveLoad.Data
{
    [CreateAssetMenu(fileName = "SaveDataViewer", menuName = "SaveData/SaveDataViewer")]
    public class SaveDataViewer : ScriptableSingleton<SaveDataViewer>
    {
        [SerializeField]
        SampleData saveData;

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
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(SaveDataViewer))]
    public class InspectorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            SaveDataViewer saveData = target as SaveDataViewer;
            // ボタン作成
            if (GUILayout.Button("Save"))
            {
                saveData.Save();
            }
            if (GUILayout.Button("Load"))
            {
                saveData.Load();
            }
            if (GUILayout.Button("Reset"))
            {
                saveData.Reset();
            }
        }
    }
#endif
}