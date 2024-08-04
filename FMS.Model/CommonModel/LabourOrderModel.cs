﻿using FMS.Db.DbEntity;

namespace FMS.Model.CommonModel
{
    public class LabourOrderModel : Base
    {
        public Guid LabourOrderId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_LabourId { get; set; }
        public string Fk_LabourTypeId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public Guid FK_BranchId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public decimal OTAmount { get; set; }
        public string Narration { get; set; }
        public ProductModel Product { get; set; } 
        public LabourModel Labour { get; set; }
        public LabourTypeModel LabourType { get; set; }
        public FinancialYearModel FinancialYear { get; set; } 
        public BranchModel Branch { get; set; }
        public List<LabourTransactionModel> LabourTransactions { get; set; }

        //Others
        public string Date { get; set; }
        public string Labourtype { get; set; }
    }
}
  