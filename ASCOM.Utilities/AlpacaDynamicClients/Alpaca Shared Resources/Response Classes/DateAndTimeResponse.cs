﻿using System;

namespace ASCOM.DynamicRemoteClients
{
    public class DateTimeResponse : RestResponseBase
    {
        public DateTimeResponse() { }

        public DateTimeResponse(uint clientTransactionID, uint transactionID, DateTime value)
        {
            base.ServerTransactionID = transactionID;
            base.ClientTransactionID = clientTransactionID;
            Value = value;
        }

        public DateTime Value { get; set; }
    }
}
