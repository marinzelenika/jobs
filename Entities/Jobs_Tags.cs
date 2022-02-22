using dotnet_5_role_based_authorization_api.Entities;
using System;

namespace WebApi.Entities
{
    public class Jobs_Tags
    {
        public DateTime PublicationDate { get; set; }

        public int PostId { get; set; }
        public JobPost JobPost { get; set; }

        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
