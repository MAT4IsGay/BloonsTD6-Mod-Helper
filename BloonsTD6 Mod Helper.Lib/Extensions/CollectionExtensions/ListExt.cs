using Assets.Scripts.Utils;
using BloonsTD6_Mod_Helper.Api.Utils;
using System;
using System.Collections.Generic;
using UnhollowerBaseLib;

namespace BloonsTD6_Mod_Helper.Extensions
{
    public static class ListExt
    {
        /// <summary>
        /// Not tested
        /// </summary>
        public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T> (this List<T> list)
        {
            Il2CppSystem.Collections.Generic.List<T> il2CppList = new Il2CppSystem.Collections.Generic.List<T>();
            foreach (var item in list)
                il2CppList.Add(item);

            return il2CppList;
        }

        /// <summary>
        /// Not tested
        /// </summary>
        public static SizedList<T> ToSizedList<T> (this List<T> list)
        {
            SizedList<T> sizedList = new SizedList<T>();
            foreach (var item in list)
                sizedList.Add(item);

            return sizedList;
        }

        /// <summary>
        /// Confirmed working
        /// </summary>
        public static Il2CppReferenceArray<T> ToIl2CppReferenceArray<T> (this List<T> list) where T : Il2CppObjectBase
        {
            var il2cppArray = new Il2CppReferenceArray<T>(0);
            foreach (var item in list)
                Il2CppUtils.Add(il2cppArray, item, out il2cppArray);

            return il2cppArray;
        }

        /// <summary>
        /// Not Tested
        /// </summary>
        public static LockList<T> ToLockList<T>(this List<T> list)
        {
            LockList<T> lockList = new LockList<T>();
            foreach (var item in list)
                lockList.Add(item);

            return lockList;
        }


        /// <summary>
        /// Not tested
        /// </summary>
        public static T GetMaxValue<T>()
        {
            object maxValue = default(T);
            TypeCode typeCode = Type.GetTypeCode(typeof(T));
            switch (typeCode)
            {
                case TypeCode.Byte:
                    maxValue = byte.MaxValue;
                    break;
                case TypeCode.Char:
                    maxValue = char.MaxValue;
                    break;
                case TypeCode.DateTime:
                    maxValue = DateTime.MaxValue;
                    break;
                case TypeCode.Decimal:
                    maxValue = decimal.MaxValue;
                    break;
                case TypeCode.Double:
                    maxValue = decimal.MaxValue;
                    break;
                case TypeCode.Int16:
                    maxValue = short.MaxValue;
                    break;
                case TypeCode.Int32:
                    maxValue = int.MaxValue;
                    break;
                case TypeCode.Int64:
                    maxValue = long.MaxValue;
                    break;
                case TypeCode.SByte:
                    maxValue = sbyte.MaxValue;
                    break;
                case TypeCode.Single:
                    maxValue = float.MaxValue;
                    break;
                case TypeCode.UInt16:
                    maxValue = ushort.MaxValue;
                    break;
                case TypeCode.UInt32:
                    maxValue = uint.MaxValue;
                    break;
                case TypeCode.UInt64:
                    maxValue = ulong.MaxValue;
                    break;
                default:
                    maxValue = default(T);//set default value
                    break;
            }

            return (T)maxValue;
        }
    }
}