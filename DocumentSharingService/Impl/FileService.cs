using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Upwork.SocialMediaAutoPoster.Service.Impl
{
    public class FileService<T> : IFileService<T>
    {
        public async Task Add(string fileName, T data)
        {
            var items = await Get(fileName) ?? new List<T>();

            items.Add(data);
            await File.WriteAllTextAsync(fileName, JsonConvert.SerializeObject(items));
        }

        public async Task Delete(string fileName, Expression<Func<T, bool>> filter)
        {
            var items = await Get(fileName, filter);
            await File.WriteAllTextAsync(fileName, JsonConvert.SerializeObject(items));
        }

        public async Task<List<T>> Get(string fileName, Expression<Func<T, bool>> filter = null)
        {
            try
            {
                using var sr = new StreamReader(fileName);
                var jsonData = await sr.ReadToEndAsync();

                var filteredData = filter == null
                    ? JsonConvert.DeserializeObject<List<T>>(jsonData)
                    : JsonConvert.DeserializeObject<List<T>>(jsonData).AsQueryable().Where(filter).ToList();

                return filteredData ?? new List<T>();
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        public async Task<T> GetById(string fileName, Expression<Func<T, bool>> filter)
        {
            var items = await Get(fileName);
            return items.AsQueryable().SingleOrDefault(filter);
        }

        public async Task Update(string fileName, T data, Expression<Func<T, bool>> filter)
        {
            var items = await Get(fileName, filter);
            items.Add(data);
            await File.WriteAllTextAsync(fileName, JsonConvert.SerializeObject(items));
        }
    }
}
