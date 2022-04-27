using Account.Domain.ObjectValues.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.Input
{
    public class ExportFileInput : SearchOrderPageInput
    {
        public TypesFileReport TypesFile { get; set; }
    }
}
