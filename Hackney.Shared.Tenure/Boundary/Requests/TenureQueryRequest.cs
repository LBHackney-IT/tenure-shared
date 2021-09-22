using Microsoft.AspNetCore.Mvc;
using System;

namespace Hackney.Shared.Tenure.Boundary.Requests
{
    public class TenureQueryRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    }
}
