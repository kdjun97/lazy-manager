using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using lazy_manager.Model;

namespace lazy_manager.Script
{
    class ReadScript
    {
        // 스크립트 읽기 함수
        public List<Tuple<char, string>> ReadScriptLine(string script)
        {
            List<Tuple<char, string>> list = new List<Tuple<char, string>>();
            
            char symbol;
            int lineLen;
            string quit = "q";
            string[] lineCut;

            try
            {
                StringReader stringReader = new StringReader(script);
                while (true)
                {
                    string line = stringReader.ReadLine(); // read line
                    if (line == null)
                        break;

                    if (line.CompareTo(quit) == 0)
                    {
                        list.Add(Tuple.Create('q', "exitapp"));
                        continue;
                    }
                    symbol = line[0]; // 어떤 명령을 수행할 것인지
                    lineLen = line.Length;
                    line = line.Substring(2, lineLen - 2); // 명령어와 분리
                    lineCut = line.Split(','); // split ','가 없어도 처리가 됨

                    for (int i = 0; i < lineCut.Count(); i++)
                    {
                        // '('가 포함되어있으면 ')'까지 한개의 string으로 취급. 
                        // 현재는 () 안에 x,y좌표만 들어가기 때문에 두개의 lineCut을 합쳐 하나로 취급해주면 됨.
                        if (lineCut[i].Contains("("))
                        {
                            list.Add(Tuple.Create(symbol, (lineCut[i]+","+lineCut[++i]))); // ','삽입. 나중에 split을 위함
                            continue;
                      }
                        else
                            list.Add(Tuple.Create(symbol, lineCut[i])); // 각 심볼과 키값을 list에 넣음
                    }

                }
                
            } catch (IndexOutOfRangeException eMsg)
            {
                Debug.Print(eMsg.Message);
            } catch (ArgumentOutOfRangeException eMsg)
            {
                Debug.Print(eMsg.Message);
            } catch  (Exception eMsg)
            {
                Debug.Print(eMsg.Message);
            }
            return list;
        }

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
    }
}
