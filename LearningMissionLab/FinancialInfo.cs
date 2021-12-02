using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class FinancialInfo
    {
        readonly Guid _financialId;
        FinancialInfo _financialAid;
        Dictionary<Guid, FinancialInfo> _salaryPoolDictionary = new Dictionary<Guid, FinancialInfo>();
        Dictionary<Guid, FinancialInfo> _stipendPoolDictionary = new Dictionary<Guid, FinancialInfo>();
        DateTime _createDate;
        DateTime _endDate;

        public FinancialInfo(Guid financialId, FinancialInfo financialAid, Dictionary<Guid, FinancialInfo> salaryPoolDictionary,
                             Dictionary<Guid, FinancialInfo> stipendPoolDictionary, DateTime createDate, DateTime endDate)
        {
            this._financialId = financialId;
            this._financialAid = financialAid;
            this._salaryPoolDictionary = salaryPoolDictionary;
            this._stipendPoolDictionary = stipendPoolDictionary;
            this._createDate = createDate;
            this._endDate = endDate;
        }

        public Guid FinancialId => _financialId;
        public FinancialInfo FinancialAid { get => _financialAid; set => _financialAid = value; }
        public Dictionary<Guid, FinancialInfo> SalaryPoolDictionary { get => _salaryPoolDictionary; set => _salaryPoolDictionary = value; }
        public Dictionary<Guid, FinancialInfo> StipendPoolDictionary { get => _stipendPoolDictionary; set => _stipendPoolDictionary = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
    }
}
