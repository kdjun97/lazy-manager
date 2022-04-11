namespace lazy_manager.Enums
{
    /// <summary>
    /// mouse_event를 위한 열거형
    /// </summary>
    public enum MouseEnum : uint
    {
        ABSOLUTE = 0x8000, // 전역위치
        MOUSEMOVE = 0x0001, // 마우스 이동
        LEFTDOWN = 0x0002, // 마우스 좌클릭
        LEFTUP = 0x0004, // 마우스 좌클릭 뗌
        MIDDLEDOWN = 0x0020,
        MIDDLEUP = 0x0040,
        RIGHTDOWN = 0x0008,
        RIGHTUP = 0x0010
    };
    
}
