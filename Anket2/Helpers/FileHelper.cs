using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Anket2.Helpers
{
    class FileHelper
    {
        public void JsonSerialization(Questions questions, string filename)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(filename))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, questions);
                }
            }
        }

       
        public void JsonDeserialize(ref Questions anket, string filename)
        {
            Questions questions = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader(filename))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    questions = serializer.Deserialize<Questions>(jr);
                }
                anket = questions;
            }

        }
       

    }
}
