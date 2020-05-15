using System;

namespace DSC.Core
{
    public static class FlagUtility
    {
        public static bool HasFlagUnsafe<TEnum>(TEnum eFlags, TEnum eCheckFlag) where TEnum : unmanaged, Enum
        {

            unsafe
            {
                switch (sizeof(TEnum))
                {
                    case 1:
                        return (*(byte*)(&eFlags) & *(byte*)(&eCheckFlag)) > 0;
                    case 2:
                        return (*(ushort*)(&eFlags) & *(ushort*)(&eCheckFlag)) > 0;
                    case 4:
                        return (*(uint*)(&eFlags) & *(uint*)(&eCheckFlag)) > 0;
                    case 8:
                        return (*(ulong*)(&eFlags) & *(ulong*)(&eCheckFlag)) > 0;
                    default:
                        throw new Exception("Size does not match a known Enum backing type.");
                }

            }
        }

        public static bool HasAllFlagUnsafe<TEnum>(TEnum eFlags, TEnum eCheckFlag) where TEnum : unmanaged, Enum
        {

            unsafe
            {
                switch (sizeof(TEnum))
                {
                    case 1:
                        return ((*(byte*)(&eCheckFlag) & ~((*(byte*)(&eFlags))
                                    & ~(*(byte*)(&eFlags) & ~*(byte*)(&eCheckFlag)))) == 0);
                    case 2:
                        return ((*(ushort*)(&eCheckFlag) & ~((*(ushort*)(&eFlags))
                                    & ~(*(ushort*)(&eFlags) & ~*(ushort*)(&eCheckFlag)))) == 0);
                    case 4:
                        return ((*(uint*)(&eCheckFlag) & ~((*(uint*)(&eFlags))
                                    & ~(*(uint*)(&eFlags) & ~*(uint*)(&eCheckFlag)))) == 0);
                    case 8:
                        return ((*(ulong*)(&eCheckFlag) & ~((*(ulong*)(&eFlags))
                                    & ~(*(ulong*)(&eFlags) & ~*(ulong*)(&eCheckFlag)))) == 0);
                    default:
                        throw new Exception("Size does not match a known Enum backing type.");
                }

            }
        }

        public static int SizeOf<TEnum>(TEnum eFlags) where TEnum : unmanaged, Enum
        {
            unsafe
            {
                return sizeof(TEnum);
            }
        }

        public static bool TryParseByte<TEnum>(TEnum eFlags, out byte nOut) where TEnum : unmanaged, Enum
        {
            unsafe
            {
                if (sizeof(TEnum) == 1)
                {
                    nOut = *(byte*)(&eFlags);
                    return true;
                }
                else
                {
                    nOut = 0;
                    return false;
                }
            }
        }

        public static bool TryParseShort<TEnum>(TEnum eFlags, out short nOut) where TEnum : unmanaged, Enum
        {
            unsafe
            {
                if(sizeof(TEnum) == 2)
                {
                    nOut = *(short*)(&eFlags);
                    return true;
                }
                else
                {
                    nOut = 0;
                    return false;
                }
            }
        }

        public static bool TryParseInt<TEnum>(TEnum eFlags,out int nOut) where TEnum : unmanaged, Enum
        {
            unsafe
            {
                if (sizeof(TEnum) == 4)
                {
                    nOut = *(int*)(&eFlags);
                    return true;
                }
                else
                {
                    nOut = 0;
                    return false;
                }
            }
        }

        public static bool TryParseLong<TEnum>(TEnum eFlags, out long nOut) where TEnum : unmanaged, Enum
        {
            unsafe
            {
                if (sizeof(TEnum) == 8)
                {
                    nOut = *(long*)(&eFlags);
                    return true;
                }
                else
                {
                    nOut = 0;
                    return false;
                }
            }
        }

        public static bool TryParseEnum<TEnum,YEnum>(TEnum eFlags,out YEnum eOutEnum) where TEnum : unmanaged, Enum where YEnum : unmanaged , Enum
        {
            unsafe
            {
                if(sizeof(TEnum) == sizeof(YEnum))
                {
                    eOutEnum = *(YEnum*)(&eFlags);
                    return true;
                }
            }

            eOutEnum = default;
            return false;
        }
    }
}