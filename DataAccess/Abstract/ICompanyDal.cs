﻿using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICompanyDal : IEntityRepository<Company>
    {
        /*
         void Add(Company company);
         void Update(Company company);
         void Delete(Company company);
         List<Company> GetAll();
         Company Get(int id);

         BASIC CRUD OPERATIONS related to Company  */


        void UserCompanyAdd(int userId, int companyId);
        UserCompany GetCompany(int userId);
        List<Company> GetListByUserId(int userId);
    }
}