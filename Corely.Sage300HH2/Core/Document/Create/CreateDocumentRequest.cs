﻿using System;

namespace Corely.Sage300HH2.Core.Document
{
    [Serializable]
    public class CreateDocumentRequest
    {
        public string DocumentTypeId { get; set; }
        public InvoiceSnapshot Snapshot { get; set; }
    }
}
