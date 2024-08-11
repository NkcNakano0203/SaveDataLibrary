using Service.SaveLoad.Sample;
using UnityEditor;
using UnityEngine;

namespace Service.SaveLoad.Data
{
    [CreateAssetMenu(fileName = "SaveDataViewer", menuName = "SaveData/SaveDataViewer")]
    public class SaveDataViewer : ScriptableSingleton<SaveDataViewer>
    {
        [SerializeField]
        SampleData sampleData;

        [ContextMenu("Save")]
        public void Save()
        {
            TextFileManager<SampleData>.Save(sampleData);
        }

        [ContextMenu("Load")]
        public void Load()
        {
            TextFileManager<SampleData>.Load(sampleData);
        }

        [ContextMenu("Reset")]
        public void Reset()
        {
            sampleData.Reset();
            TextFileManager<SampleData>.Save(sampleData);
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