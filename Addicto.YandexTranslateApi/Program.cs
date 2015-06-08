using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.YandexTranslateApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var text = "zahtevek";
            var lang = "sl-ru";
            var key = "trnsl.1.1.20150605T133357Z.0f99a7b0863cac2a.2e551c55751ee5ac41920a1a50eb2d42ba5ce9d6";
            try
            {
                WebRequest request = WebRequest.Create("https://translate.yandex.net/api/v1.5/tr/translate?" +
                    "&key=" + key +
                    "&text=" + text +
                    "&lang=" + lang
                    );

                WebResponse response = request.GetResponse();   
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}",e.Message);
            }
        }
    }
}
