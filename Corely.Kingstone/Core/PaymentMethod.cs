﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corely.Kingstone.Core
{
    [Serializable]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PaymentMethod
    {
        ACH,
        CC,
        CHK
    }
}
