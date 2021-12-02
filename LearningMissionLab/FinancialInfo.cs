using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class FinancialInfo
    {
        readonly Guid _financialId;
        FinancialInfo _financialAid;
        FinancialInfo _salary;
        FinancialInfo _stipend;
        DateTime _createDate;
        DateTime _endDate;

        public FinancialInfo(Guid financialId, FinancialInfo financialAid, FinancialInfo salary,
                             FinancialInfo stipend, DateTime createDate, DateTime endDate)
        {
            this._financialId = financialId;
            this._financialAid = financialAid;
            this._salary = salary;
            this._stipend = stipend;
            this._createDate = createDate;
            this._endDate = endDate;
        }

        public Guid FinancialId => _financialId;

        public FinancialInfo FinancialAid { get => _financialAid; set => _financialAid = value; }
        public FinancialInfo Salary { get => _salary; set => _salary = value; }
        public FinancialInfo Stipend { get => _stipend; set => _stipend = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
    }
}
