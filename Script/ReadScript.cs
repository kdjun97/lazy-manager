using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                        list.Add(Tuple.Create(symbol, lineCut[i])); // 각 심볼과 키값을 list에 넣음

                }
                
            } catch (IndexOutOfRangeException eMsg)
            {
                Debug.Print(eMsg.ToString());
            } catch (ArgumentOutOfRangeException eMsg)
            {
                Debug.Print(eMsg.ToString());
            }
            return list;
        }
    }
}
