﻿using System;
using System.Runtime.Serialization;

namespace Scorponok.Adquirentes.Contracts.Stone.InstantBuys {

    [DataContract(Namespace = "")]
    public class UpdateInstantBuyDataRequest {

        /// <summary>
        /// Chave do Comprador
        /// </summary>
        [DataMember]
        public Guid BuyerKey { get; set; }
    }
}
