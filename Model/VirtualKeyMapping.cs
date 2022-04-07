using System.Collections.Generic;

namespace lazy_manager.Model
{
    class VirtualKeyModel
    {
        Dictionary<string, byte> virtualKeyModel = new Dictionary<string, byte>()
        {
            {"30", 0x30},{"31", 0x31},{"32", 0x32},{"33", 0x33},{"34", 0x34},
            {"35", 0x35},{"36", 0x36},{"37", 0x37},{"38", 0x38},{"39", 0x39}
        };

        public Dictionary<string, byte> GetVirtualKeyModel() => virtualKeyModel;
    }
}
