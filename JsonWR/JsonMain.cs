using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace JsonWR{
    public static class JsonMain{
        public static async Task<T> ReadFromFileAsync<T>(string filePath){
        try{
            using (var reader = new StreamReader(filePath)){
                string json = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(json);
            }
        }catch(Exception ex){
            System.Console.WriteLine($"Exception occurred in ReadFromFileAsync: {ex}");
            return default;
        }
}
        public static async Task WriteToFileAsync<T>(string filePath, T data){
            using StreamWriter file = File.CreateText(filePath);
            string jsonContent = JsonConvert.SerializeObject(data);
            await file.WriteAsync(jsonContent);
        }

    }
}