﻿using API.DbModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DbModels.System.Branches
{
    public class Branch : CoreModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Location { get; set; } = null!;
    }
}
