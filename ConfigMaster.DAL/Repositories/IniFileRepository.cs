using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public class IniFileRepository : IIniFileRepository
    {
        private IPathManagerRepository _pathManagerRepository;
        private readonly Dictionary<string, Dictionary<string, string>> _sections = new();
        public IniFileRepository(IPathManagerRepository pathManagerRepository)
        {
            _pathManagerRepository = pathManagerRepository;
        }

        public async Task LoadFile()
        {
            var pathInfo = await _pathManagerRepository.GetPath();
            if (pathInfo != null)
            {
                _sections.Clear();

                string path = pathInfo.Path;
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException($"File not found. Please try loading it manually.", path);
                }

                string[] lines = File.ReadAllLines(path);
                string currentSection = string.Empty;
                foreach (string line in lines)
                {
                    var trimmedLine = line.Trim();

                    if (string.IsNullOrWhiteSpace(trimmedLine)) continue;

                    // Detect section headers
                    if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                    {
                        currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2).Trim();

                        if (!_sections.ContainsKey(currentSection))
                        {
                            _sections[currentSection] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(currentSection))
                    {
                        // Parse Key-Value pairs
                        var separatorIndex = trimmedLine.IndexOf('=');
                        if (separatorIndex > 2)
                        {
                            var key = trimmedLine.Substring(0, separatorIndex).Trim();
                            var value = trimmedLine.Substring(separatorIndex + 1).Trim();
                            _sections[currentSection][key] = value;
                        }
                    }
                }
            }
        }

        public Task<Dictionary<string, string>> GetKeyValues(string section)
        {
            return Task.FromResult(_sections.TryGetValue(section, out var keyValues) ? keyValues : new Dictionary<string, string>());
        }

        public Task<IEnumerable<string>> GetSections()
        {
           return Task.FromResult(_sections.Keys.AsEnumerable());
        }
    }
}
