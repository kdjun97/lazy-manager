namespace lazy_manager.Struct
{
    /// <summary>
    /// global keyboard hook을 위한 구조체
    /// </summary>
    public struct keyboardHookStruct
    {
        public int vkCode;
        public int scanCode;
        public int flags;
        public int time;
        public int dwExtraInfo;
    }
}
