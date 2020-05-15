using System.Collections.Generic;

namespace DSC.Core
{
    public static class Extension_IUpdate
    {
        public static void OnUpdate<Data>(this Data[] array) where Data : class, IUpdate
        {
            for (int i = 0; i < array.Length; i++)
            {
                var hData = array[i];
                if (hData != null)
                    hData.OnUpdate();
            }
        }

        public static void OnUpdate<Data>(this List<Data> list) where Data : class, IUpdate
        {
            for(int i = 0; i < list.Count; i++)
            {
                var hData = list[i];
                if (hData != null)
                    hData.OnUpdate();
            }
        }
    }
}