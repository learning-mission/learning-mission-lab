using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    public class FinancialEvent
    {
        readonly Guid _financialId;
        Dictionary<Guid, FinancialInfo> _financialAidPoolDictionary = new Dictionary<Guid, FinancialInfo>();
        Dictionary<Guid, FinancialInfo> _salaryPoolDictionary = new Dictionary<Guid, FinancialInfo>();
        Dictionary<Guid, FinancialInfo> _stipendPoolDictionary = new Dictionary<Guid, FinancialInfo>();
        DateTime _startDate;
        DateTime _endDate;
        dynamic _amount;

        public FinancialEvent(Guid financialId, Dictionary<Guid, FinancialInfo> financialAidPoolDictionary, 
                             Dictionary<Guid, FinancialInfo> salaryPoolDictionary,Dictionary<Guid, FinancialInfo> stipendPoolDictionary, 
                             DateTime startDate, DateTime endDate, dynamic amount)
        {
            this._financialId = financialId;
            this._financialAidPoolDictionary = financialAidPoolDictionary;
            this._salaryPoolDictionary = salaryPoolDictionary;
            this._stipendPoolDictionary = stipendPoolDictionary;
            this._startDate = startDate;
            this._endDate = endDate;
            this. _amount = amount;
        }

        public Guid FinancialId => _financialId;
        public Dictionary<Guid, FinancialInfo> FinancialAidPoolDictionary { get => _financialAidPoolDictionary; set => _financialAidPoolDictionary = value; }
        public Dictionary<Guid, FinancialInfo> SalaryPoolDictionary { get => _salaryPoolDictionary; set => _salaryPoolDictionary = value; }
        public Dictionary<Guid, FinancialInfo> StipendPoolDictionary { get => _stipendPoolDictionary; set => _stipendPoolDictionary = value; }
        public DateTime CreateDate { get => _startDate; set => _startDate = value; }
        public DateTime EndDate { get => _endDate; set => _endDate = value; }
        public dynamic Amount { get => _amount; set => _amount = value; }
    }
}
