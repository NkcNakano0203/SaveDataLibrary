using System.IO;
using System.Text;
using UnityEngine;

namespace Service.SaveLoad
{
    public static class TextFileManager<T> where T : class
    {
        private const string FileName = "SaveData.txt";
        public const string XORKey = "123456789";

        public static void Save(T data)
        {
            string dataJson = JsonUtility.ToJson(data);
            // XORで正確な結果を得るためにByteにしている
            byte[] dataBytes = Encoding.UTF8.GetBytes(dataJson);
            byte[] keyBytes = Encoding.UTF8.GetBytes(XORKey);
            // XOR暗号化
            byte[] codeBytes = XOR(dataBytes, keyBytes);

            File.WriteAllBytes(GetSavePath(), codeBytes);
            Debug.Log($"セーブ完了:パス({GetSavePath()})");
        }

        public static void Load(T data)
        {
            bool isExists = !File.Exists(GetSavePath());
            // 見つからない時は新規作成
            if (isExists)
            {
                Save(data);
            }

            // XOR復号化
            byte[] codeBytes = File.ReadAllBytes(GetSavePath());
            byte[] keyBytes = Encoding.UTF8.GetBytes(XORKey);
            byte[] dataBytes = XOR(codeBytes, keyBytes);

            string jsonStr = Encoding.UTF8.GetString(dataBytes);
            JsonUtility.FromJsonOverwrite(jsonStr, data);
            Debug.Log("ロード完了");
        }

        private static string GetSavePath()
        {
            return Path.Combine(Application.dataPath, FileName);
        }

        /// <summary>
        /// 排他的論理和
        /// dataとkeyのbyte[]を一文字ずつ比較していく
        /// </summary>
        public static byte[] XOR(byte[] dataBytes, byte[] keyBytes)
        {
            int i, j = 0;

            for (i = 0; i < dataBytes.Length; i++)
            {
                j = (j < keyBytes.Length) ?
                    j + 1 :
                    // keyの文字数が足りない時は１を置く
                    1;

                dataBytes[i] = (byte)(dataBytes[i] ^ keyBytes[j - 1]);
            }
            return dataBytes;
        }
    }
}