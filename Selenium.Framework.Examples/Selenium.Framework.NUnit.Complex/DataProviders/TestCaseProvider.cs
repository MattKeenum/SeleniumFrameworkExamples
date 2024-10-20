using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Selenium.Framework.NUnit.Complex.Models;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Selenium.Framework.NUnit.Complex.DataProviders;

public class TestCaseProvider<T> where T : BaseTestEntity, new()
{
    public static IEnumerable<T> GetData(string fileName)
    {
        IEnumerable<dynamic> rows = GetCsvData(fileName);

        return CreateEntities(rows);
    }

    private static IEnumerable<dynamic> GetCsvData(string fileName)
    {
        FileInfo fileInfo = GetFileInfo(fileName);

        using TextReader reader = new StreamReader(fileInfo.FullName);
        CsvConfiguration configuration = new(new CultureInfo("en-US"))
        {
            IgnoreBlankLines = true,
            HeaderValidated = null,
            MissingFieldFound = null,
            UseNewObjectForNullReferenceMembers = true,
        };

        return new CsvReader(reader, configuration).GetRecords<dynamic>().ToList();
    }

    private static IEnumerable<T> CreateEntities(IEnumerable<dynamic> rows)
    {
        List<T> entities = [];

        foreach (dynamic row in rows)
        {
            string json = JsonConvert.SerializeObject(row);
            json = new Regex("\"\"").Replace(json, "null");

            T? entity = JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
            });

            if (entity is null)
            {
                continue;
            }

            if (entities.Any(x => x.ToString().Equals(entity.ToString(), StringComparison.OrdinalIgnoreCase)))
            {
                continue;
            }

            entities.Add(entity);
        }

        return entities;
    }

    private static FileInfo GetFileInfo(string fileName)
    {
        string? path = Directory.GetFiles(Path.Combine("./"), fileName, SearchOption.AllDirectories).FirstOrDefault();

        if (string.IsNullOrEmpty(path?.Trim()))
        {
            throw new FileNotFoundException($"Unable to find {fileName}");
        }

        return new(path);
    }
}
