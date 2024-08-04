﻿using FMS.Model.CommonModel;
using FMS.Model.ViewModel;
using FMS.Service.Admin;
using FMS.Service.Reports;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace FMS.Controllers.Print
{
    public class PrintController : Controller
    {
        private readonly IAdminSvcs _adminSvcs;
        private readonly IReportSvcs _reportSvcs;
        public PrintController(IAdminSvcs adminSvcs, IReportSvcs reportSvcs)
        {
            _adminSvcs = adminSvcs;
            _reportSvcs = reportSvcs;
        }
        #region Sales Print
        [HttpPost]
        public IActionResult SalesPrintData([FromBody] SalesDataRequest requestData)
        {
            var json = JsonConvert.SerializeObject(requestData);
            var url = Url.Action("SalesPrint", "Print", new { data = json });
            return Json(new { redirectTo = url });
        }
        [HttpGet]
        public IActionResult SalesPrint(string data)
        {
            var requestData = JsonConvert.DeserializeObject<SalesDataRequest>(data);
            return View(requestData);
        }
        #endregion
        #region Daysheet Report
        [HttpPost]
        public IActionResult DaySheetPrintData([FromBody] DaySheetModel requestData)
        {
            TempData["DaySheetData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("DaySheetPrint", "Print") });
        }
        [HttpGet]
        public IActionResult DaySheetPrint(string data)
        {
            if (TempData.TryGetValue("DaySheetData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<DaySheetModel>(jsonData);
                var CashBookPrintModel = new DaysheetPrintModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    daySheet = requestPrintData
                };

                return View(CashBookPrintModel);
            }
            return RedirectToAction("Error");
        }
        #endregion
        #region Cash Book
        [HttpPost]
        public IActionResult CashBookPrintData([FromBody] CashBookModal requestData)
        {
            TempData["CashBookData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("CashBookPrint", "Print") });
        }
        [HttpGet]
        public IActionResult CashBookPrint()
        {
            if (TempData.TryGetValue("CashBookData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<CashBookModal>(jsonData);
                var CashBookPrintModel = new CashBookPrintModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    cashbook = requestPrintData
                };

                return View(CashBookPrintModel);
            }
            return RedirectToAction("Error");
        }
        #endregion
        #region Bank Book Reports
        [HttpPost]
        public IActionResult BankBookPrintData([FromBody] BankBookModal requestData)
        {
            TempData["BankBookData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("BankBookPrint", "Print") });
        }
        [HttpGet]
        public IActionResult BankBookPrint()
        {
            if (TempData.TryGetValue("BankBookData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<BankBookModal>(jsonData);
                var BankBookPrintModel = new BankBookPrintModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    bankbook = requestPrintData
                };

                return View(BankBookPrintModel);
            }
            return RedirectToAction("Error");

        }
        #endregion
        #region Ledger Book Reports
        [HttpPost]
        public IActionResult LedgerBookPrintData([FromBody] LedgerBookModel requestData)
        {
            TempData["LedgerBookData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("LedgerBookPrint", "Print") });
        }
        [HttpGet]
        public IActionResult LedgerBookPrint()
        {
            if (TempData.TryGetValue("LedgerBookData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<LedgerBookModel>(jsonData);
                var LedgerBookPrintModel = new LedgerBookPrintModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    ledgerBook = requestPrintData
                };
                return View(LedgerBookPrintModel);
            }
            return RedirectToAction("Error");

        }
        #endregion
        #region TrialBalance Reports
        [HttpPost]
        public IActionResult TrialBalancePrintData([FromBody] TrailBalancesModel requestData)
        {
            TempData["TrialBalanceData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("TrialBalancePrint", "Print") });
        }
        [HttpGet]
        public IActionResult TrialBalancePrint()
        {
            if (TempData.TryGetValue("TrialBalanceData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<TrailBalancesModel>(jsonData);
                var TrialBalancePrintModel = new TrialBalancePrintModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    Balances = requestPrintData
                };
                return View(TrialBalancePrintModel);
            }
            return RedirectToAction("Error");

        }
        #endregion
        #region Journal Book 
        [HttpPost]
        public IActionResult JournalBookPrintData([FromBody] JournalBookModel requestData)
        {
            TempData["JournalBookData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("JournalBookPrint", "Print") });
        }
        [HttpGet]
        public IActionResult JournalBookPrint()
        {
            if (TempData.TryGetValue("JournalBookData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<JournalBookModel>(jsonData);
                var JournalBookPrintModel = new JournalBookPrintModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    JournalBook = requestPrintData
                };

                return View(JournalBookPrintModel);
            }
            return RedirectToAction("Error");

        }
        #endregion
        #region Labour Reports
        [HttpPost]
        public IActionResult LabourDetailedPrintData([FromBody] LabourDetailsModal requestData)
        {
            TempData["LabourDetailedData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("LabourDetailedPrint", "Print") });
        }
        [HttpGet]
        public IActionResult LabourDetailedPrint()
        {

            if (TempData.TryGetValue("LabourDetailedData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<LabourDetailsModal>(jsonData);
                var LabourDetailedReportModal = new LabourDetailedReportModal()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    LabourDetails = requestPrintData
                };
                return View(LabourDetailedReportModal);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public IActionResult LabourSummarizedPrintData([FromBody] LabourDetailsModal requestData)
        {
            TempData["LabourSummarizedData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("LabourSummarizedPrint", "Print") });
        }
        [HttpGet]
        public IActionResult LabourSummarizedPrint()
        {
            if (TempData.TryGetValue("LabourSummarizedData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<LabourDetailsModal>(jsonData);
                var LabourDetailedReportModal = new LabourDetailedReportModal()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    LabourDetails = requestPrintData
                };
                return View(LabourDetailedReportModal);
            }
            return RedirectToAction("Error");

        }
        #endregion
        #region Stock Reports
        [HttpPost]
        public IActionResult StockSumrizedPrintData([FromBody] StockReportDataModel requestData)
        {
            TempData["StockSumrizedData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("StockSumrizedReportPrint", "Print") });
        }
        [HttpGet]
        public IActionResult StockSumrizedReportPrint()
        {
            if (TempData.TryGetValue("StockSumrizedData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<StockReportDataModel>(jsonData);
                var StockSumrizedReportModal = new StockSumrizedReportModal()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    StockReports = requestPrintData
                };
                return View(StockSumrizedReportModal);
            }
            return RedirectToAction("Error");

        }
        [HttpPost]
        public IActionResult StockDetailedPrintData([FromBody] StockReportDataModel requestData)
        {
            TempData["StockDetailedData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("StockDetailedReportPrint", "Print") });
        }
        [HttpGet]
        public IActionResult StockDetailedReportPrint()
        {
            if (TempData.TryGetValue("StockDetailedData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<StockReportDataModel>(jsonData);
                var StockDetailedReportModal = new StockSumrizedReportModal()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    StockReports = requestPrintData
                };
                return View(StockDetailedReportModal);
            }
            return RedirectToAction("Error");

        }
        #endregion
        #region Customer Report
        [HttpPost]
        public IActionResult CustomerSummarizedPrintData([FromBody] CustomerSummarizedModel requestData)
        {
            TempData["CustomerSummarizedData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("CustomerSummarizedReportPrint", "Print") });
        }
        [HttpGet]
        public IActionResult CustomerSummarizedReportPrint()
        {
            if (TempData.TryGetValue("CustomerSummarizedData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<CustomerSummarizedModel>(jsonData);
                var StockSumrizedReportModal = new CustomerReportDataModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    Customers = requestPrintData
                };
                return View(StockSumrizedReportModal);
            }
            return RedirectToAction("Error");

        }
        [HttpPost]
        public IActionResult CustomerDetailedPrintData([FromBody] CustomerSummarizedModel requestData)
        {
            TempData["CustomerDetailedData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("CustomerDetailedReportPrint", "Print") });
        }
        [HttpGet]
        public IActionResult CustomerDetailedReportPrint()
        {
            if (TempData.TryGetValue("CustomerDetailedData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<CustomerSummarizedModel>(jsonData);
                var StockSumrizedReportModal = new CustomerReportDataModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    Customers = requestPrintData
                };
                return View(StockSumrizedReportModal);
            }
            return RedirectToAction("Error");

        }
        #endregion
        #region Supplyer Report
        [HttpPost]
        public IActionResult SupplyerSummarizedPrintData([FromBody] CustomerSummarizedModel requestData)
        {
            TempData["SupplyerSummarizedData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("SupplyerSummarizedReportPrint", "Print") });
        }
        [HttpGet]
        public IActionResult SupplyerSummarizedReportPrint()
        {
            if (TempData.TryGetValue("SupplyerSummarizedData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<CustomerSummarizedModel>(jsonData);
                var StockSumrizedReportModal = new CustomerReportDataModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    Customers = requestPrintData
                };
                return View(StockSumrizedReportModal);
            }
            return RedirectToAction("Error");

        }
        [HttpPost]
        public IActionResult SupplyerDetailsPrintData([FromBody] CustomerSummarizedModel requestData)
        {

            TempData["SupplyerDetailedData"] = JsonConvert.SerializeObject(requestData);
            return Json(new { redirectTo = Url.Action("SupplyerDetailedReportPrint", "Print") });
        }
        [HttpGet]
        public IActionResult SupplyerDetailedReportPrint()
        {
            if (TempData.TryGetValue("SupplyerDetailedData", out object tempData) && tempData is string jsonData)
            {
                var requestPrintData = JsonConvert.DeserializeObject<CustomerSummarizedModel>(jsonData);
                var StockSumrizedReportModal = new CustomerReportDataModel()
                {
                    Cmopany = _adminSvcs.GetCompany().Result.GetCompany,
                    Customers = requestPrintData
                };
                return View(StockSumrizedReportModal);
            }
            return RedirectToAction("Error");

        }
        #endregion
    }
}
