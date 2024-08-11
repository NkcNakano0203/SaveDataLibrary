using System;

namespace Service.SaveLoad.Sample
{
    [Serializable]
    internal class SampleData
    {
        public int HP;
        public int MP;
        public int ATK;

        internal SampleData(int hp = 0, int mp = 0, int atk = 0)
        {
            HP = hp;
            MP = mp;
            ATK = atk;
        }

        internal void Reset()
        {
            HP = 0;
            MP = 0;
            ATK = 0;
        }
    }
}
