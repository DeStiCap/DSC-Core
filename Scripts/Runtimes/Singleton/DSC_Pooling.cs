using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DSC.Core
{
    public abstract class DSC_Pooling : MonoBehaviour
    {
        #region Data

        static class PoolingStack
        {
            static class PerType<T> where T : class, IPoolable
            {
                public static Stack<T> list;
            }

            public static Stack<T> Get<T>() where T : class, IPoolable
                => PerType<T>.list;

            public static void Set<T>(Stack<T> newStack) where T : class, IPoolable
                => PerType<T>.list = newStack;

            public static Stack<T> Get<T>(T typeInstance) where T : class, IPoolable
                => Get<T>();

            public static bool TryGet<T>(out Stack<T> outStack) where T : class, IPoolable
            {
                outStack = Get<T>();
                return outStack != null;
            }

            public static Stack<T> CreateNewStack<T>() where T : class, IPoolable
            {
                Stack<T> newStack = new Stack<T>();
                Set(newStack);
                return newStack;
            }
        }

        #endregion
   
        #region Base - Main

        /// <summary>
        /// Add class poolable to stack pooling. (It will call clear method automatic.) 
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="hAdd">Class Instance</param>
        public static void AddPooling<T>(T hAdd) where T : class, IPoolable
        {
            if (hAdd == null)
                return;

            hAdd.Clear();

            if (PoolingStack.TryGet(out Stack<T> stkOut))
            {
                stkOut.Push(hAdd);
            }
            else
            {
                var stkPooling = PoolingStack.CreateNewStack<T>();
                stkPooling.Push(hAdd);
            }
        }

        /// <summary>
        /// Get class poolable back from stack pooling. (It will remove that data from pooling.)
        /// </summary>
        /// <typeparam name="T">Class Type</typeparam>
        /// <returns>Get pooling Class instance</returns>
        public static T GetPooling<T>() where T :class, IPoolable
        {
            if (!PoolingStack.TryGet<T>(out var stkOut) || stkOut.Count <= 0)
                return null;

            return stkOut.Pop();
        }

        /// <summary>
        /// Try get class poolable back from stack pooling. (It will remove that data from pooling.)
        /// </summary>
        /// <typeparam name="T">Class type</typeparam>
        /// <param name="hOut">Out pooling class instance</param>
        /// <returns>Return true if class not null.</returns>
        public static bool TryGetPooling<T>(out T hOut) where T : class, IPoolable
        {
            hOut = GetPooling<T>();

            return hOut != null;
        }

        #endregion
    }
}