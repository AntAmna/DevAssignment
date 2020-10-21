using DevAssignment.Models;
using System.Collections.Generic;

namespace DevAssignment.Data
{
    public interface ITag
    {
        IEnumerable<Tag> GetTags();
    }
}
