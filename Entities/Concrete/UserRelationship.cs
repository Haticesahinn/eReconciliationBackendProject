using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserRelationship : IEntity
    {
        public int Id { get; set; }
        public int AdminUserId { get; set; }
        public int UserUserId { get; set; }
    }
}