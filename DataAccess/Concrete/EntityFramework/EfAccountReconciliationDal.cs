using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAccountReconciliationDal : EfEntityRepositoriesBase<AccountReconciliation, ContextDb>, IAccountReconciliationDal
    {
        public List<AccountReconciliationDto> GetAllDto(int companyId)
        {
            using (var context = new ContextDb())
            {
                var result = from reconciliation in context.AccountReconciliations.Where(p => p.CompanyId == companyId)
                             join company in context.Companies on reconciliation.CompanyId equals company.Id
                             join account in context.CurrencyAccounts on reconciliation.CurrencyAccountId equals account.Id
                             join currency in context.Currencies on reconciliation.CurrencyId equals currency.Id
                             select new AccountReconciliationDto
                             {
                                 CompanyId = companyId,
                                 CurrencyAccountId = account.Id,
                                 AccountIdentityNumber = account.IdentityNumber,
                                 AccountName = account.Name,
                                 AccountTaxDepartment = account.TaxDepartment,
                                 AccountTaxIdNumber = account.TaxIdNumber,
                                 CompanyIdentityNumber = company.IdentityNumber,
                                 CompanyName = company.Name,
                                 CompanyTaxDepartment = company.TaxDepartment,
                                 CompanyTaxIdNumber = company.TaxIdNumber,
                                 CurrencyCredit = reconciliation.CurrencyCredit,
                                 CurrencyDebit = reconciliation.CurrencyDebit,
                                 CurrencyId = reconciliation.CurrencyId,
                                 EmailReadDate = reconciliation.EmailReadDate,
                                 EndingDate = reconciliation.EndingDate,
                                 Guid = reconciliation.Guid,
                                 Id = reconciliation.Id,
                                 IsEmailRead = reconciliation.IsEmailRead,
                                 IsResultSucceed = reconciliation.IsResultSucceed,
                                 IsSendEmail = reconciliation.IsSendEmail,
                                 ResultDate = reconciliation.ResultDate,
                                 ResultNote = reconciliation.ResultNote,
                                 SendMailDate = reconciliation.SendMailDate,
                                 StartingDate = reconciliation.StartingDate,
                                 CurrencyCode = currency.Code,
                                 AccountEmail = account.Email,
                                 AccountCode = account.Code
                             };
                return result.ToList();
            }
        }

        public AccountReconciliationDto GetByCodeDto(string code)
        {
            using (var context = new ContextDb())
            {
                var result = from reconciliation in context.AccountReconciliations.Where(p => p.Guid == code)
                             join company in context.Companies on reconciliation.CompanyId equals company.Id
                             join account in context.CurrencyAccounts on reconciliation.CurrencyAccountId equals account.Id
                             join currency in context.Currencies on reconciliation.CurrencyId equals currency.Id
                             select new AccountReconciliationDto
                             {
                                 CompanyId = reconciliation.CompanyId,
                                 CurrencyAccountId = account.Id,
                                 AccountIdentityNumber = account.IdentityNumber,
                                 AccountName = account.Name,
                                 AccountTaxDepartment = account.TaxDepartment,
                                 AccountTaxIdNumber = account.TaxIdNumber,
                                 CompanyIdentityNumber = company.IdentityNumber,
                                 CompanyName = company.Name,
                                 CompanyTaxDepartment = company.TaxDepartment,
                                 CompanyTaxIdNumber = company.TaxIdNumber,
                                 CurrencyCredit = reconciliation.CurrencyCredit,
                                 CurrencyDebit = reconciliation.CurrencyDebit,
                                 CurrencyId = reconciliation.CurrencyId,
                                 EmailReadDate = reconciliation.EmailReadDate,
                                 EndingDate = reconciliation.EndingDate,
                                 Guid = reconciliation.Guid,
                                 Id = reconciliation.Id,
                                 IsEmailRead = reconciliation.IsEmailRead,
                                 IsResultSucceed = reconciliation.IsResultSucceed,
                                 IsSendEmail = reconciliation.IsSendEmail,
                                 ResultDate = reconciliation.ResultDate,
                                 ResultNote = reconciliation.ResultNote,
                                 SendMailDate = reconciliation.SendMailDate,
                                 StartingDate = reconciliation.StartingDate,
                                 CurrencyCode = currency.Code,
                                 AccountEmail = account.Email,
                                 AccountCode = account.Code
                             };
                return result.FirstOrDefault();
            }
        }

        public AccountReconciliationDto GetByIdDto(int id)
        {
            using (var context = new ContextDb())
            {
                var result = from reconciliation in context.AccountReconciliations.Where(p => p.Id == id)
                             join company in context.Companies on reconciliation.CompanyId equals company.Id
                             join account in context.CurrencyAccounts on reconciliation.CurrencyAccountId equals account.Id
                             join currency in context.Currencies on reconciliation.CurrencyId equals currency.Id
                             select new AccountReconciliationDto
                             {
                                 CompanyId = reconciliation.CompanyId,
                                 CurrencyAccountId = account.Id,
                                 AccountIdentityNumber = account.IdentityNumber,
                                 AccountName = account.Name,
                                 AccountTaxDepartment = account.TaxDepartment,
                                 AccountTaxIdNumber = account.TaxIdNumber,
                                 CompanyIdentityNumber = company.IdentityNumber,
                                 CompanyName = company.Name,
                                 CompanyTaxDepartment = company.TaxDepartment,
                                 CompanyTaxIdNumber = company.TaxIdNumber,
                                 CurrencyCredit = reconciliation.CurrencyCredit,
                                 CurrencyDebit = reconciliation.CurrencyDebit,
                                 CurrencyId = reconciliation.CurrencyId,
                                 EmailReadDate = reconciliation.EmailReadDate,
                                 EndingDate = reconciliation.EndingDate,
                                 Guid = reconciliation.Guid,
                                 Id = reconciliation.Id,
                                 IsEmailRead = reconciliation.IsEmailRead,
                                 IsResultSucceed = reconciliation.IsResultSucceed,
                                 IsSendEmail = reconciliation.IsSendEmail,
                                 ResultDate = reconciliation.ResultDate,
                                 ResultNote = reconciliation.ResultNote,
                                 SendMailDate = reconciliation.SendMailDate,
                                 StartingDate = reconciliation.StartingDate,
                                 CurrencyCode = currency.Code,
                                 AccountEmail = account.Email,
                                 AccountCode = account.Code
                             };
                return result.FirstOrDefault();
            }
        }

        public AccountReconciliationsCountDto GetCountDto(int companyId)
        {
            using (var context = new ContextDb())
            {
                var result = context.AccountReconciliations.Where(p => p.CompanyId == companyId).ToList();
                AccountReconciliationsCountDto accountReconciliationsCountDto = new AccountReconciliationsCountDto
                {
                    AllReconciliation = result.Count(),
                    SucceedReconciliation = result.Where(p => p.IsResultSucceed == true).Count(),
                    NotResponseReconciliation = result.Where(p => p.IsResultSucceed == null).Count(),
                    FailReconciliation = result.Where(p => p.IsResultSucceed == false).Count()
                };
                return accountReconciliationsCountDto;
            }
        }
    }
}