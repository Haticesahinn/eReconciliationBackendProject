using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserRelationshipDal : IEntityRepository<UserRelationship>
    {
        List<UserRelationshipDto> GetListDto(int adminUserId);
        UserRelationshipDto GetById(int userUserId);
    }
}