﻿using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Hackney.Shared.Tenure.Boundary.Response
{
    [ExcludeFromCodeCoverage]
    public class CustomEditTenureDetailsBadRequestResponse
    {
        public int Status { get; set; } = 400;

        public Dictionary<string, List<string>> Errors { get; set; }
    }

    /*
    Example Response
    ================

    {
       "status": 400,
       "errors": {
         "EndOfTenureDate": [
           "{\r\n  \"errorCode\": \"GreaterThanValidator\",\r\n  \"errorMessage\": \"'End Of Tenure Date' must be greater than '14/09/2021 08:21:58'.\"\r\n}"
          ]
        }
    }
    */
}
