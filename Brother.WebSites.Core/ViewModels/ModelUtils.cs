using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Brother.WebSites.Core.ViewModels
{
    static public class ModelUtils
    {
        static public string JsonSerialize<T>(T data) where T : class 
        {
            var serializer = new DataContractJsonSerializer(typeof (T));
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, data);
                return Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
            }
        }

        static public T JsonDeserialize<T>(string data) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof (T));
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            {
                return serializer.ReadObject(ms) as T;
            }
        }
    }
}
