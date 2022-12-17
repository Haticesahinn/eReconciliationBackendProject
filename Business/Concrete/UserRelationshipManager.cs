using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserRelationshipManager : IUserRelationshipService
    {
        private readonly IUserRelationshipDal _userRelationshipDal;

        public UserRelationshipManager(IUserRelationshipDal userRelationshipDal)
        {
            _userRelationshipDal = userRelationshipDal;
        }

        public void Add(UserRelationship userRelationship)
        {
            _userRelationshipDal.Add(userRelationship);
        }

        public void Delete(UserRelationship userRelationship)
        {
            _userRelationshipDal.Delete(userRelationship);
        }

        public List<UserRelationship> GetList(int userId)
        {
            return _userRelationshipDal.GetList(p => p.UserUserId == userId);
        }

        public IDataResult<UserRelationshipDto> GetById(int userUserId)
        {
            return new SuccessDataResult<UserRelationshipDto>(_userRelationshipDal.GetById(userUserId));
        }

        public IDataResult<List<UserRelationshipDto>> GetListDto(int adminUserId)
        {
            return new SuccessDataResult<List<UserRelationshipDto>>(_userRelationshipDal.GetListDto(adminUserId));
        }

        public void Update(UserRelationship userRelationship)
        {
            _userRelationshipDal.Update(userRelationship);
        }
    }
}