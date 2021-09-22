using Microsoft.AspNetCore.Mvc;
using System;

namespace Hackney.Shared.Tenure.Boundary.Requests
{
    public class UpdateTenureRequest
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }

        [FromRoute(Name = "personId")]
        public Guid PersonId { get; set; }
    }
}
