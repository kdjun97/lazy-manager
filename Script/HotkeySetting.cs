using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lazy_manager.Model;
using System.Windows.Forms;

namespace lazy_manager.Script
{
    class HotkeySetting
    {
        
        // 핫키 모델 리스트를 셋팅해주는 함수
        public List<HotkeyModel> SetHotkeyModelList(List<Tuple<char, string>> parsedData)
        {
            // 초기 버전은 loop 없이 q만 허용
            List<HotkeyModel> hotkeyList = new List<HotkeyModel>(); // return해줄 hotkeyList

            try
            {
                for (int index = 0; index < parsedData.Count(); index++)
                {
                    if (parsedData[index].Item1 == 'h')
                    {
                        Debug.Print(index + "번에 h찾음");
                        HotkeyModel hotkeyModel = new HotkeyModel(); // 하나의 핫키 모델
                        hotkeyModel.SetHotkey(parsedData[index].Item2); // 핫키 설정

                        int j = index + 1;
                        while (true)
                        {
                            if (j > parsedData.Count()) // exception, q가 없을경우 무한루프
                                throw new Exception("Loop Exception");
                            if (parsedData[j].Item1 == 'q')
                            {
                                hotkeyModel.SetIsExit(true);
                                hotkeyList.Add(hotkeyModel); // 완성된 모델 추가

                                index = j;
                                break;
                            }
                            else
                            {
                                hotkeyModel.SetCommand(new Tuple<char, string>(parsedData[j].Item1, parsedData[j].Item2));
                                j++;
                            }
                        }
                    }

                }
            }
            catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }

            return hotkeyList;
        }

        // 핫키를 셋팅해주는 함수
        public List<Keys> SetHotkey(List<HotkeyModel> hotkeyModel)
        {
            List<Keys> hookedKeys = new List<Keys>();

            try
            {
                Keys k = (Keys)Enum.Parse(typeof(Keys), "LControlKey", true);
                hookedKeys.Add(k);
                for (int index = 0; index < hotkeyModel.Count(); index++)
                {
                    string tempKeyCode = "0x" + hotkeyModel[index].GetHotkey();
                    hookedKeys.Add(StringToKey(tempKeyCode));

                }
            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
            return hookedKeys;
        }

        // input 키코드를 처리해줌
        public Keys StringToKey(string keyCode)
        {
            Keys key = new Keys();

            try
            {
                switch (keyCode)
                {
                    case "0x70":
                        Debug.Print("0x70찾음");
                        key = Keys.F1;
                        break;
                    case "0x71":
                        key = Keys.F2;
                        break;
                    case "0x72":
                        key = Keys.F3;
                        break;
                    default:
                        key = Keys.None;
                        // throw new Exception("Key Code Error");
                        break;
                }
            } catch (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
            

            return key;
        }
    }
}
