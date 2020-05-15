using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Core
{
    public static class Extension_List
    {
        /// <summary>
        /// Check list not null and count more than zero.
        /// </summary>
        /// <typeparam name="Data">List Data type</typeparam>
        /// <param name="list">List</param>
        /// <returns>Return true if not null and count more than zero.</returns>
        public static bool HasData<Data>(this List<Data> list)
        {
            return (list != null && list.Count > 0);
        }

        /// <summary>
        /// Try get data in list.
        /// </summary>
        /// <typeparam name="Data">Data type.</typeparam>
        /// <param name="list">Data List</param>
        /// <param name="index">Index</param>
        /// <param name="data">Get data</param>
        /// <returns>Return true success get data.</returns>
        public static bool TryGetData<Data>(this List<Data> list,int index, out Data data) where Data : class
        {
            if(list.Count <= index)
            {
                data = default;
                return false;
            }

            data = list[index];
            return data != null;
        }

        /// <summary>
        /// Try get data from list.
        /// </summary>
        /// <typeparam name="Data">Data type</typeparam>
        /// <typeparam name="T">Get Data type</typeparam>
        /// <param name="list">List data.</param>
        /// <param name="hOutData">Get data</param>
        /// <param name="nOutIndex">Index of get data in list.</param>
        /// <returns>Return true when get data success.</returns>
        public static bool TryGetData<Data,T>(this List<Data> list, out T hOutData, out int nOutIndex) where T : Data
        {
            hOutData = default;
            nOutIndex = -1;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is T)
                {
                    hOutData = (T)list[i];
                    nOutIndex = i;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Try get data from list.
        /// </summary>
        /// <typeparam name="Data">Data type</typeparam>
        /// <typeparam name="T">Get Data type</typeparam>
        /// <param name="list">List data.</param>
        /// <param name="hOutData">Get data</param>
        /// <returns>Return true when get data success.</returns>
        public static bool TryGetData<Data, T>(this List<Data> list, out T hOutData) where T : Data
        {
            return TryGetData(list, out hOutData,out int nOutIndex);
        }

        /// <summary>
        /// Try get data from list.
        /// </summary>
        /// <typeparam name="Data">Data type</typeparam>
        /// <typeparam name="T">Get Data type</typeparam>
        /// <param name="list">List data.</param>
        /// <param name="nOutIndex">Index of get data in list.</param>
        /// <returns>Return true when get data success.</returns>
        public static bool TryGetData<Data, T>(this List<Data> list, out int nOutIndex) where T : Data
        {
            return TryGetData(list, out T hOutData, out nOutIndex);
        }

        /// <summary>
        /// Get random data from list
        /// </summary>
        /// <typeparam name="Data">List data type</typeparam>
        /// <param name="list">List data</param>
        /// <returns>Return random data</returns>
        public static Data GetRandom<Data>(this List<Data> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        /// <summary>
        /// Remove all null in list.
        /// </summary>
        /// <typeparam name="Data">List data type</typeparam>
        /// <param name="list">List data</param>
        public static void RemoveAllNull<Data>(this List<Data> list)
        {
            for(int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i] == null)
                    list.RemoveAt(i);
            }
        }
    }
}