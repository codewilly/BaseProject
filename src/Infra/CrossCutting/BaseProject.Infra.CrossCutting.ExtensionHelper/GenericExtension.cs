using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace BaseProject.Infra.CrossCutting.ExtensionHelper
{
    public static class GenericExtension
    {
        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        public static T DeserializeJson<T>(this string json)
        {
            if (!json.TryDeserializeJson(out T deserialized))
                throw new Exception("Falha ao deserializar json.");

            return deserialized;
        }

        public static bool TryDeserializeJson<T>(this string json, out T resultParsed)
        {
            resultParsed = default;

            try
            {
                JsonSerializerSettings jsonSettings = new()
                {
                    Error = (sender, args) =>
                    {
                        Console.WriteLine($"Falha ao deserializar '{args.ErrorContext.Member}': {args.ErrorContext.Error.Message}");
                    }
                };

                resultParsed = JsonConvert.DeserializeObject<T>(json, jsonSettings);

                return resultParsed != null;
            }
            catch
            {
                return false;
            }
        }
    }
}
