using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ConfigMaster.DAL.Repositories
{
    public class IniFileRepository : IIniFileRepository
    {
        private readonly IPathManagerRepository _pathManagerRepository;
        private readonly ILogger<IniFileRepository> _logger;
        private readonly Dictionary<string, Dictionary<string, string>> _sections = new();
        private string _filePath = string.Empty;

        public IniFileRepository(IPathManagerRepository pathManagerRepository, ILogger<IniFileRepository> logger)
        {
            _pathManagerRepository = pathManagerRepository;
            _logger = logger;
        }

        public async Task LoadFile()
        {
            try
            {
                var pathInfo = await _pathManagerRepository.GetPath();
                if (pathInfo == null)
                {
                    throw new InvalidOperationException("Path information is null.");
                }

                _sections.Clear();
                _filePath = pathInfo.Path;

                if (!File.Exists(_filePath))
                {
                    throw new FileNotFoundException($"File not found. Please try loading it manually.", _filePath);
                }

                string[] lines = await File.ReadAllLinesAsync(_filePath);
                string currentSection = string.Empty;

                foreach (string line in lines)
                {
                    var trimmedLine = line.Trim();

                    if (string.IsNullOrWhiteSpace(trimmedLine)) continue;

                    if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                    {
                        currentSection = trimmedLine[1..^1].Trim();

                        if (!_sections.ContainsKey(currentSection))
                        {
                            _sections[currentSection] = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                        }
                    }
                    else if (!string.IsNullOrWhiteSpace(currentSection))
                    {
                        var separatorIndex = trimmedLine.IndexOf('=');
                        if (separatorIndex > 2)
                        {
                            var key = trimmedLine[..separatorIndex].Trim();
                            var value = trimmedLine[(separatorIndex + 1)..].Trim();
                            _sections[currentSection][key] = value;
                        }
                    }
                }

                _logger.LogInformation("INI file loaded successfully from path: {FilePath}", _filePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while loading the INI file.");
                throw;
            }
        }

        public Task<Dictionary<string, Dictionary<string, string>>> GetConfigurationData()
        {
            _logger.LogInformation("Retrieving configuration data.");
            return Task.FromResult(_sections);
        }

        public Task<Dictionary<string, string>> GetKeyValues(string section)
        {
            _logger.LogInformation("Retrieving key values for section: {Section}", section);
            return Task.FromResult(_sections.TryGetValue(section, out var keyValues) ? keyValues : new Dictionary<string, string>());
        }

        public Task<IEnumerable<string>> GetSections()
        {
            _logger.LogInformation("Retrieving all sections.");
            return Task.FromResult(_sections.Keys.AsEnumerable());
        }

        public Task WriteValue(string section, string key, string value)
        {
            try
            {
                WritePrivateProfileString(section, key, value, _filePath);
                if (!_sections.ContainsKey(section))
                {
                    _sections[section] = new Dictionary<string, string>();
                }
                _sections[section][key] = value;
                _logger.LogInformation("Value written to INI file: Section={Section}, Key={Key}, Value={Value}", section, key, value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while writing a value to the INI file: Section={Section}, Key={Key}, Value={Value}", section, key, value);
                throw;
            }

            return Task.CompletedTask;
        }

        public async Task<bool> UpdateKey(Dictionary<string, Dictionary<string, string>> configurationData)
        {
            try
            {
                var lines = new List<string>();

                foreach (var section in configurationData)
                {
                    lines.Add($"[{section.Key}]");
                    lines.AddRange(section.Value.Select(kvp => $"{kvp.Key}={kvp.Value}"));
                    lines.Add(""); // Add a blank line between sections
                }

                await File.WriteAllLinesAsync(_filePath, lines);
                _logger.LogInformation("INI file updated successfully.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the INI file.");
                return false;
            }
        }

        public Task<bool> DeleteKey(string section, string key)
        {
            try
            {
                var result = WritePrivateProfileString(section, key, null, _filePath) != 0;
                if (result)
                {
                    _sections[section].Remove(key);
                    _logger.LogInformation("Key deleted from INI file: Section={Section}, Key={Key}", section, key);
                }
                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a key from the INI file: Section={Section}, Key={Key}", section, key);
                throw;
            }
        }

        public async Task<bool> SectionExists(string section)
        {
            try
            {
                var buffer = new StringBuilder(255);
                GetPrivateProfileString(section, null, null, buffer, buffer.Capacity, _filePath);
                if (buffer.Length > 0) return true;

                var exists = await Task.FromResult(GetAllSections().Contains(section, StringComparer.OrdinalIgnoreCase));
                _logger.LogInformation("Section exists check: Section={Section}, Exists={Exists}", section, exists);
                return exists;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking if section exists: Section={Section}", section);
                throw;
            }

            List<string> GetAllSections()
            {
                const int bufferSize = 2048;
                IntPtr buffer = Marshal.AllocCoTaskMem(bufferSize);
                try
                {
                    int bytesReturned = GetPrivateProfileSectionNames(buffer, (uint)bufferSize, _filePath);
                    if (bytesReturned == 0)
                    {
                        return new List<string>();
                    }

                    string allSections = Marshal.PtrToStringAuto(buffer, bytesReturned) ?? string.Empty;
                    return allSections.Split('\0', StringSplitOptions.RemoveEmptyEntries).ToList();
                }
                finally
                {
                    Marshal.FreeCoTaskMem(buffer);
                }
            }
        }

        public Task<bool> KeyExists(string section, string key)
        {
            try
            {
                var buffer = new StringBuilder(255);
                GetPrivateProfileString(section, key, null, buffer, buffer.Capacity, _filePath);
                var exists = buffer.Length > 0;
                _logger.LogInformation("Key exists check: Section={Section}, Key={Key}, Exists={Exists}", section, key, exists);
                return Task.FromResult(exists);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while checking if key exists: Section={Section}, Key={Key}", section, key);
                throw;
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileSectionNames(IntPtr lpszReturnBuffer, uint nSize, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string section, string? key, string? defaultValue, StringBuilder result, int size, string filePath);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern int WritePrivateProfileString(string section, string key, string? value, string filePath);
    }
}

