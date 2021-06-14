﻿using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Service.Services
{
    public class ServiceTransactionDescription : IServiceTransactionDescription
    {
        private IRepositoryTransactionDescription _repository;
        private IServiceTransaction _serviceTransaction;
        public ServiceTransactionDescription(IRepositoryTransactionDescription repository, IServiceTransaction serviceTransaction)
        {
            _repository = repository;
            _serviceTransaction = serviceTransaction;
        }
        public object AddList(List<TransactionDescription> list)
        {
            throw new System.NotImplementedException();
        }

        public object ImportFileCNAB(List<byte[]> fileBytes)
        {
            List<TransactionDescription> objImports = new List<TransactionDescription>();
            foreach (var itemArchive in fileBytes)
            {
                objImports = BytesToArchive(itemArchive);
            }
            var returnAdd = _repository.AddList(objImports);
            return returnAdd;
        }

        private List<TransactionDescription> BytesToArchive(byte[] fileBytes)
        {
            List<TransactionDescription> objImports = new List<TransactionDescription>();
            MemoryStream stream = new MemoryStream((byte[])fileBytes);
            StreamReader streamFile = new StreamReader(stream);
            string line;
            while ((line = streamFile.ReadLine()) != null)
            {
                TransactionDescription newObj = new TransactionDescription();
                string currentElement = line;

                string type = line.Substring(0, 1);
                string dateTime = line.Substring(1, 4) + "/" + line.Substring(5, 2) + "/" + line.Substring(7, 2) + " " +
                  line.Substring(42, 2) + ":" + line.Substring(44, 2) + ":" + line.Substring(46, 2);
                string value = line.Substring(9, 10);
                string CPF = line.Substring(19, 11); ;
                string Card = line.Substring(30, 12); ;
                string StoreOwner = line.Substring(48, 14);
                string StoreName = line.Substring(62, 18);

                var search = _serviceTransaction.SearchTransactionByType(type);

                if (search != null)
                {
                    if (search is Transaction)
                    {
                        newObj.TransactionId = ((Transaction)search).Id;
                    }
                }
                newObj.DateTime = Convert.ToDateTime(dateTime);
                newObj.Value = Convert.ToDecimal(value) / 100;
                newObj.CPF = CPF;
                newObj.Card = Card;
                newObj.StoreOwner = StoreOwner;
                newObj.StoreName = StoreName;
                objImports.Add(newObj);
            }

            return objImports;
        }

        public object SearchAll()
        {
            throw new System.NotImplementedException();
        }

        public object SearchByStore(string Store)
        {
            throw new System.NotImplementedException();
        }
    }
}
