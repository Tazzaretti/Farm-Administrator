﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Helpers
{
    public interface IEncryptHelper
    {
        public string GetSHA256(string Clave);

    }
}
