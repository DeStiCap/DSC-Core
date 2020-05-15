using UnityEngine;

namespace DSC.Core
{
    public static class Extension_Array 
    {
        /// <summary>
        /// Check array not null and length more than zero.
        /// </summary>
        /// <typeparam name="Data">Array Data type</typeparam>
        /// <param name="array">Array</param>
        /// <returns>Return true if not null and length more than zero.</returns>
        public static bool HasData<Data>(this Data[] array)
        {
            return (array != null && array.Length > 0);
        }

        /// <summary>
        /// Try get data in array.
        /// </summary>
        /// <typeparam name="Data">Data type.</typeparam>
        /// <param name="array">Data array</param>
        /// <param name="index">Index</param>
        /// <param name="data">Get data</param>
        /// <returns>Return true success get data.</returns>
        public static bool TryGetData<Data>(this Data[] array,int index, out Data data) where Data : class
        {
            if (array.Length <= index)
            {
                data = default;
                return false;
            }

            data = (Data)array.GetValue(index);
            return data != null;
        }

        /// <summary>
        /// Try get data from array.
        /// </summary>
        /// <typeparam name="Data">Data type</typeparam>
        /// <typeparam name="T">Get Data type</typeparam>
        /// <param name="array">Array data.</param>
        /// <param name="hOutData">Get data</param>
        /// <param name="nOutIndex">Index of get data in array.</param>
        /// <returns>Return true when get data success.</returns>
        public static bool TryGetData<Data, T>(this Data[] array, out T hOutData, out int nOutIndex) where T : Data
        {
            hOutData = default;
            nOutIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] is T)
                {
                    hOutData = (T)array[i];
                    nOutIndex = i;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Try get data from array.
        /// </summary>
        /// <typeparam name="Data">Data type</typeparam>
        /// <typeparam name="T">Get Data type</typeparam>
        /// <param name="array">Array data.</param>
        /// <param name="hOutData">Get data</param>
        /// <returns>Return true when get data success.</returns>
        public static bool TryGetData<Data, T>(this Data[] array, out T hOutData) where T : Data
        {
            return TryGetData(array, out hOutData, out int nOutIndex);
        }

        /// <summary>
        /// Try get data from array.
        /// </summary>
        /// <typeparam name="Data">Data type</typeparam>
        /// <typeparam name="T">Get Data type</typeparam>
        /// <param name="array">Array data.</param>
        /// <param name="nOutIndex">Index of get data in array.</param>
        /// <returns>Return true when get data success.</returns>
        public static bool TryGetData<Data, T>(this Data[] array, out int nOutIndex) where T : Data
        {
            return TryGetData(array, out T hOutData, out nOutIndex);
        }

        /// <summary>
        /// Check if has this data in array.
        /// </summary>
        /// <typeparam name="Data">Data type</typeparam>
        /// <param name="array">Data Array</param>
        /// <param name="checkData">Check data.</param>
        /// <returns>Return true if has this data in array.</returns>
        public static bool Contains<Data>(this Data[] array,Data checkData)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(checkData))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Get random data from array
        /// </summary>
        /// <typeparam name="Data">Array data type</typeparam>
        /// <param name="array">Array data</param>
        /// <returns>Return random data</returns>
        public static Data GetRandom<Data>(this Data[] array)
        {
            return array[Random.Range(0, array.Length)];
        }
    }
}