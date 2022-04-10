namespace lazy_manager.Enums
{
    /// <summary>
    /// hook에 관한 열거형
    /// </summary>
    public enum HookEnum : int
    {
        WH_KEYBOARD_LL = 13,
        WM_KEYDOWN = 0x100,
        WM_KEYUP = 0x101,
        WM_SYSKEYDOWN = 0x104,
        WM_SYSKEYUP = 0x105
    }
}
