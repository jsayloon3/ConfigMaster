﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMaster.DAL.Repositories
{
    public interface IIniFileRepository
    {
        Task LoadFile();
        Task<IEnumerable<string>> GetSections();
        Task<Dictionary<string, string>> GetKeyValues(string section);
    }
}
