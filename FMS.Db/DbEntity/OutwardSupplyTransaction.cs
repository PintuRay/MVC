﻿namespace FMS.Db.DbEntity
{
    public class OutwardSupplyTransaction
    {
        public Guid OutwardSupplyTransactionId { get; set; }
        public Guid Fk_OutwardSupplyOrderId { get; set; }
        public string TransactionNo { get; set; }
        public DateTime TransactionDate { get; set; }
        public Guid Fk_ProductId { get; set; }
        public Guid Fk_BranchId { get; set; }
        public Guid Fk_FinancialYearId { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public OutwardSupplyOrder OutwardSupplyOrder { get; set; }
        public Product Product { get; set; }
        public Branch Branch { get; set; }
        public FinancialYear FinancialYear { get; set; }
    }
}
