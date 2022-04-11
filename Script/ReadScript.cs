using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;

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
    }
}
