﻿using FMS.Model;
using FMS.Model.CommonModel;
using FMS.Model.ViewModel;
using System.Threading.Tasks;

namespace FMS.Service.Devloper
{
    public interface IDevloperSvcs
    {
        #region Branch
        Task<BranchViewModel> GetAllBranch();
        Task<BranchViewModel> GetBranchById(Guid BranchId);
        Task<BranchViewModel> GetBranchAccordingToUser(string UserId);
        Task<Base> CreateBranch(BranchModel data);
        Task<Base> UpdateBranch(BranchModel data);
        Task<Base> DeleteBranch(Guid Id);
        #endregion
        #region FinancialYear
       
        Task<FinancialYearViewModel> GetFinancialYears();
        Task<FinancialYearViewModel> GetFinancialYearById(Guid FinancialYearId);
        Task<FinancialYearViewModel> GetFinancialYears(Guid BranchId);
        Task<Base> CreateFinancialYear(FinancialYearModel data);
        Task<Base> UpdateFinancialYear(FinancialYearModel data);
        Task<Base> DeleteFinancialYear(Guid Id);
        #endregion
        #region Branch Financial Year
        Task<BranchFinancialYearViewModel> GetBranchFinancialYears(Guid BranchId);
        Task<BranchFinancialYearViewModel> GetBranchFinancialYears();
        Task<Base> CreateBranchFinancialYear(BranchFinancialYearModel data);
        Task<Base> UpdateBranchFinancialYear(BranchFinancialYearModel data);
        Task<Base> DeleteBranchFinancialYear(Guid Id);
        #endregion
        #region Accounting Setup
        #region LedgerGroup
        Task<LedgerGroupViewModel> GetLedgerGroups();
        Task<Base> CreateLedgerGroup(LedgerGroupModel data);
        Task<Base> UpdateLedgerGroup(LedgerGroupModel data);
        Task<Base> DeleteLedgerGroup(Guid Id);
        #endregion
        #region LedgerSubGroup
        Task<LedgerSubGroupViewModel> GetLedgerSubGroups(Guid BranchId, Guid GroupId);
        Task<Base> CreateLedgerSubGroup(LedgerSubGroupModel data);
        Task<Base> UpdateLedgerSubGroup(LedgerSubGroupModel data);
        Task<Base> DeleteLedgerSubGroup(Guid BranchId, Guid Id);
        #endregion   
        #region Ledger
        Task<LedgerViewModel> GetLedgers();
        Task<Base> CreateLedger(List<LedgerModel> listData);
        Task<Base> UpdateLedger(LedgerModel data);
        Task<Base> DeleteLedger(Guid Id);
        #endregion
        #endregion
    }
}
