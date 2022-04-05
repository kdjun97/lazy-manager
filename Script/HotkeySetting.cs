using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using lazy_manager.Model;
using System.Windows.Forms;

namespace lazy_manager.Script
{
    class HotkeySetting
    {
        // 핫키를 셋팅해주는 함수
        public List<Keys> SetHotkey(List<HotkeyModel> hotkeyModel)
        {
            List<Keys> hookedKeys = new List<Keys>();

            try
            {
                for (int index = 0; index < hotkeyModel.Count(); index++)
                {
                    Keys keys = (Keys)Enum.Parse(typeof(Keys), hotkeyModel[index].GetHotkey());
                    hookedKeys.Add(keys);
                }
            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
            return hookedKeys;
        }
    }
}
