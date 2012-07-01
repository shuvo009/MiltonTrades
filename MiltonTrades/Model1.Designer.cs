﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("MiltonTradesModel", "FK_TransictionTable_0", "Accounts", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(MiltonTrades.Account), "TransictionTable", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(MiltonTrades.TransictionTable), true)]

#endregion

namespace MiltonTrades
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class MiltonTradesEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new MiltonTradesEntities object using the connection string found in the 'MiltonTradesEntities' section of the application configuration file.
        /// </summary>
        public MiltonTradesEntities() : base("name=MiltonTradesEntities", "MiltonTradesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MiltonTradesEntities object.
        /// </summary>
        public MiltonTradesEntities(string connectionString) : base(connectionString, "MiltonTradesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new MiltonTradesEntities object.
        /// </summary>
        public MiltonTradesEntities(EntityConnection connection) : base(connection, "MiltonTradesEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Account> Accounts
        {
            get
            {
                if ((_Accounts == null))
                {
                    _Accounts = base.CreateObjectSet<Account>("Accounts");
                }
                return _Accounts;
            }
        }
        private ObjectSet<Account> _Accounts;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<TransictionTable> TransictionTables
        {
            get
            {
                if ((_TransictionTables == null))
                {
                    _TransictionTables = base.CreateObjectSet<TransictionTable>("TransictionTables");
                }
                return _TransictionTables;
            }
        }
        private ObjectSet<TransictionTable> _TransictionTables;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Accounts EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAccounts(Account account)
        {
            base.AddObject("Accounts", account);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the TransictionTables EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToTransictionTables(TransictionTable transictionTable)
        {
            base.AddObject("TransictionTables", transictionTable);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MiltonTradesModel", Name="Account")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Account : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Account object.
        /// </summary>
        /// <param name="number">Initial value of the Number property.</param>
        /// <param name="date">Initial value of the Date property.</param>
        /// <param name="accountInformation">Initial value of the AccountInformation property.</param>
        public static Account CreateAccount(global::System.Int64 number, global::System.DateTime date, global::System.String accountInformation)
        {
            Account account = new Account();
            account.Number = number;
            account.Date = date;
            account.AccountInformation = accountInformation;
            return account;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 Number
        {
            get
            {
                return _Number;
            }
            set
            {
                if (_Number != value)
                {
                    OnNumberChanging(value);
                    ReportPropertyChanging("Number");
                    _Number = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Number");
                    OnNumberChanged();
                }
            }
        }
        private global::System.Int64 _Number;
        partial void OnNumberChanging(global::System.Int64 value);
        partial void OnNumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String AccountInformation
        {
            get
            {
                return _AccountInformation;
            }
            set
            {
                OnAccountInformationChanging(value);
                ReportPropertyChanging("AccountInformation");
                _AccountInformation = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("AccountInformation");
                OnAccountInformationChanged();
            }
        }
        private global::System.String _AccountInformation;
        partial void OnAccountInformationChanging(global::System.String value);
        partial void OnAccountInformationChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MiltonTradesModel", "FK_TransictionTable_0", "TransictionTable")]
        public EntityCollection<TransictionTable> TransictionTables
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<TransictionTable>("MiltonTradesModel.FK_TransictionTable_0", "TransictionTable");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<TransictionTable>("MiltonTradesModel.FK_TransictionTable_0", "TransictionTable", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="MiltonTradesModel", Name="TransictionTable")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class TransictionTable : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new TransictionTable object.
        /// </summary>
        /// <param name="number">Initial value of the Number property.</param>
        /// <param name="date">Initial value of the Date property.</param>
        /// <param name="withdrawAmount">Initial value of the WithdrawAmount property.</param>
        /// <param name="depositAmount">Initial value of the DepositAmount property.</param>
        public static TransictionTable CreateTransictionTable(global::System.Int64 number, global::System.DateTime date, global::System.Decimal withdrawAmount, global::System.Decimal depositAmount)
        {
            TransictionTable transictionTable = new TransictionTable();
            transictionTable.Number = number;
            transictionTable.Date = date;
            transictionTable.WithdrawAmount = withdrawAmount;
            transictionTable.DepositAmount = depositAmount;
            return transictionTable;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int64 Number
        {
            get
            {
                return _Number;
            }
            set
            {
                if (_Number != value)
                {
                    OnNumberChanging(value);
                    ReportPropertyChanging("Number");
                    _Number = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Number");
                    OnNumberChanged();
                }
            }
        }
        private global::System.Int64 _Number;
        partial void OnNumberChanging(global::System.Int64 value);
        partial void OnNumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int64> AccountNumber
        {
            get
            {
                return _AccountNumber;
            }
            set
            {
                OnAccountNumberChanging(value);
                ReportPropertyChanging("AccountNumber");
                _AccountNumber = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("AccountNumber");
                OnAccountNumberChanged();
            }
        }
        private Nullable<global::System.Int64> _AccountNumber;
        partial void OnAccountNumberChanging(Nullable<global::System.Int64> value);
        partial void OnAccountNumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime Date
        {
            get
            {
                return _Date;
            }
            set
            {
                OnDateChanging(value);
                ReportPropertyChanging("Date");
                _Date = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Date");
                OnDateChanged();
            }
        }
        private global::System.DateTime _Date;
        partial void OnDateChanging(global::System.DateTime value);
        partial void OnDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                OnDescriptionChanging(value);
                ReportPropertyChanging("Description");
                _Description = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Description");
                OnDescriptionChanged();
            }
        }
        private global::System.String _Description;
        partial void OnDescriptionChanging(global::System.String value);
        partial void OnDescriptionChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal WithdrawAmount
        {
            get
            {
                return _WithdrawAmount;
            }
            set
            {
                OnWithdrawAmountChanging(value);
                ReportPropertyChanging("WithdrawAmount");
                _WithdrawAmount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("WithdrawAmount");
                OnWithdrawAmountChanged();
            }
        }
        private global::System.Decimal _WithdrawAmount;
        partial void OnWithdrawAmountChanging(global::System.Decimal value);
        partial void OnWithdrawAmountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal DepositAmount
        {
            get
            {
                return _DepositAmount;
            }
            set
            {
                OnDepositAmountChanging(value);
                ReportPropertyChanging("DepositAmount");
                _DepositAmount = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("DepositAmount");
                OnDepositAmountChanged();
            }
        }
        private global::System.Decimal _DepositAmount;
        partial void OnDepositAmountChanging(global::System.Decimal value);
        partial void OnDepositAmountChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("MiltonTradesModel", "FK_TransictionTable_0", "Accounts")]
        public Account Account
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Account>("MiltonTradesModel.FK_TransictionTable_0", "Accounts").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Account>("MiltonTradesModel.FK_TransictionTable_0", "Accounts").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Account> AccountReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Account>("MiltonTradesModel.FK_TransictionTable_0", "Accounts");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Account>("MiltonTradesModel.FK_TransictionTable_0", "Accounts", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}