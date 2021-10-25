﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LearningMissionLab
{
    /// <summary>
    /// Unit class contains methods and properties to manage items of <T> type
    /// </summary>
    /// <typeparam name="T">Type of items in the itemList</typeparam>
    public class Unit<T>
    {
        readonly Guid _id;
        UnitType _unitType;
        string _name;
        string _description;
        List<T> _itemList;
        DateTime _createDate;
        DateTime _updateDate;

        public Unit
        (
            Guid id,
            UnitType unitType,
            string name,
            string description,
            List<T> itemList,
            DateTime createDate,
            DateTime updateDate
        )
        {
            this._id = id;
            this._unitType = unitType;
            this._name = name;
            this._description = description;
            this._itemList = itemList;
            this._createDate = createDate;
            this._updateDate = updateDate;
        }

        public Unit
        (
            UnitType unitType,
            string name,
            string description,
            List<T> itemList
        )
        {
            this._id = GetGuid();
            this._unitType = unitType;
            this._name = name;
            this._description = description;
            this._itemList = itemList;
            this._createDate = DateTime.Now;
            this._updateDate = DateTime.Now;
        }

        public Guid Id => _id;
        public UnitType UnitType { get => _unitType; set => _unitType = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public List<T> ItemList { get => _itemList; set => _itemList = value; }
        public DateTime CreateDate { get => _createDate; set => _createDate = value; }
        public DateTime UpdateDate { get => _updateDate; set => _updateDate = value; }

        private static Guid GetGuid()
        {
            Guid guid = Guid.NewGuid();

            return guid;
        }
    }
}