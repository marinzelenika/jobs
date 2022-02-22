using dotnet_5_role_based_authorization_api.Entities;
using System.Collections.Generic;

namespace WebApi.Entities
{
    public class Tag
    {
        public string TagId { get; set; }

        public ICollection<JobPost> JobPosts { get; set; }
        public List<Jobs_Tags> JobPostTags { get; set; }
    }
}
