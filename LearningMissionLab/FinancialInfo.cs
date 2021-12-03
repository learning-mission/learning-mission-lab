using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class FinancialInfo
    {
        readonly Guid _financialId;
        Dictionary<Guid, FinancialInfo> _financialAidPoolDictionary = new Dictionary<Guid, FinancialInfo>();
        Dictionary<Guid, FinancialInfo> _salaryPoolDictionary = new Dictionary<Guid, FinancialInfo>();
        Dictionary<Guid, FinancialInfo> _stipendPoolDictionary = new Dictionary<Guid, FinancialInfo>();
        DateTime _createDate;
        DateTime _endDate;

        public FinancialInfo(Guid financialId, Dictionary<Guid, FinancialInfo> financialAidPoolDictionary, 
                             Dictionary<Guid, FinancialInfo> salaryPoolDictionary,Dictionary<Guid, FinancialInfo> stipendPoolDictionary, 
                             DateTime createDate, DateTime endDate)
        {
            this._financialId = financialId;
            this._financialAidPoolDictionary = financialAidPoolDictionary;
            this._salaryPoolDictionary = salaryPoolDictionary;
            this._stipendPoolDictionary = stipendPoolDictionary;
            this._createDate = createDate;
            this._endDate = endDate;
        }

        public Guid FinancialId => _financialId;
        public Dictionary<Guid, FinancialInfo> FinancialAidPoolDictionary { get => _financialAidPoolDictionary; set => _financialAidPoolDictionary = value; }
        public Dictionary<Guid, FinancialInfo> SalaryPoolDictionary { get => _salaryPoolDictionary; set => _salaryPoolDictionary = value; }
        public Dictionary<Guid, FinancialInfo> StipendPoolDictionary { get => _stipendPoolDictionary; set => _stipendPoolDictionary = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
    }
}
