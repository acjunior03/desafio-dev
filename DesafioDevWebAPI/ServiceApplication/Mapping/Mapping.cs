using Domain.Entities;
using ServiceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiceApplication.Mapping
{
    public static class Mapping
    {
        public static BaseErrorModel ToBaseErrorModel(this Exception exception, string message = "") => new BaseErrorModel
        {
            GenericNumber = exception.HResult,
            GenericMessage = exception.Message,
            Message = message
        };
        public static BaseResult ToBaseResultModelGroupByStore(this object Entity, string message = "") => new BaseResult
        {
            Result = Entity is string ? "" :
                                               Entity is GroupByStore ? ((GroupByStore)Entity)?.ToModelGroupByStore() :
                                               Entity?.ToIEnumerableModelPriceShipping(),
            Message = message
        };
        public static ModelGroupByStore ToModelGroupByStore(this GroupByStore obj) => new ModelGroupByStore
        {
           CurrentBalance = obj.CurrentBalance,
           Storename = obj.Storename,
           ListTransactionDescription = obj.ListTransactionDescription.ToModelTransactionDescription().ToList()
        };
        public static IEnumerable<ModelGroupByStore> ToIEnumerableModelPriceShipping(this object obj) => ((List<GroupByStore>)obj).Select(obj => new ModelGroupByStore
        {
            CurrentBalance = obj.CurrentBalance,
            Storename = obj.Storename,
            ListTransactionDescription = obj.ListTransactionDescription.ToModelTransactionDescription().ToList()
        }).ToList();
        public static IEnumerable<ModelTransactionDescription> ToModelTransactionDescription(this List<TransactionDescription> obj) => ((List<TransactionDescription>)obj).Select(obj => new ModelTransactionDescription
        {
            Card = obj.Card,
            CPF = obj.CPF,
            DateTime = obj.DateTime,
            Id = obj.Id,
            StoreName = obj.StoreName,
            StoreOwner = obj.StoreOwner,
            TransactionId = obj.TransactionId,
            Value = obj.Value,
            ModelTransaction = obj.Transaction.ToModelTransaction()
        }).ToList();
        public static ModelTransaction ToModelTransaction(this Transaction obj) => new ModelTransaction
        {
            Id = obj.Id,
            Description = obj.Description,
            Nature = obj.Nature,
            Signal = obj.Signal,
            Type = obj.Type
        };  
    }
}
