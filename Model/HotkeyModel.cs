using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lazy_manager.Model
{
    class HotkeyModel
    {
        string hotkey; // 핫키 정보
        List<Tuple<char, string>> command; // 명령어 리스트
        bool isExit; // exitapp or repeat

        public string GetHotkey() => hotkey;
        public void SetHotkey(string keyValue) => hotkey = keyValue;
        public List<Tuple<char, string>> GetCommand() => command;
        public void SetCommand(Tuple<char, string> commandData) => command.Add(commandData);
        public bool GetIsExit(bool data) => isExit;
        public void SetIsExit(bool data) => isExit = data;
    }
}
