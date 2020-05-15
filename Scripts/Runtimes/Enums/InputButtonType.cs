namespace DSC.Core
{
    public enum InputButtonType
    {
        DPadUp      =   1 << 0,
        DPadDown    =   1 << 1,
        DPadLeft    =   1 << 2,
        DPadRight   =   1 << 3,
        North       =   1 << 4,
        South       =   1 << 5,
        West        =   1 << 6,
        East        =   1 << 7,        
        L1          =   1 << 8,
        L2          =   1 << 9,
        L3          =   1 << 10,
        R1          =   1 << 11,
        R2          =   1 << 12,
        R3          =   1 << 13,
        Start       =   1 << 14,
        Select      =   1 << 15,
        Confirm     =   1 << 16,
        Cancel      =   1 << 17,
    }
}