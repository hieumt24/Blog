using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Domain.Content;
[Table("PostTags")]
[PrimaryKey(nameof(PostId), nameof(TagId))]
public class PostTag
{
    public Guid PostId { get; set; }
    public Guid TagId { get; set; }
}