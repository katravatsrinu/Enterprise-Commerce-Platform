using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Application.Responses
{
     public record BrandResponse
    {
        public string Id { get; init; }
        public string Name { get; init; }
    }
}
