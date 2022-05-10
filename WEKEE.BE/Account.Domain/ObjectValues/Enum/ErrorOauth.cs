using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Domain.ObjectValues.Enum
{
    public enum ErrorOauth
    {
        SUCCESS= 0,
        NO_TOKEN = 1,
        NO_VALIDATE= 2,
        ERROR_NO_AUTH = 3,
        REFRESH_TOKEN = 4,
    }
}
