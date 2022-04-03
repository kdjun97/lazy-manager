using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lazy_manager.Model;

namespace lazy_manager.Script
{
    class HotkeySetting
    {
        // 핫키를 셋팅해주는 함수
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
    }
}
