using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserRelationshipService
    {
        void Add(UserRelationship userRelationship);
        void Update(UserRelationship userRelationship);
        void Delete(UserRelationship userRelationship);
        IDataResult<List<UserRelationshipDto>> GetListDto(int adminUserId);
        IDataResult<UserRelationshipDto> GetById(int userUserId);
        List<UserRelationship> GetList(int userId);
    }
}