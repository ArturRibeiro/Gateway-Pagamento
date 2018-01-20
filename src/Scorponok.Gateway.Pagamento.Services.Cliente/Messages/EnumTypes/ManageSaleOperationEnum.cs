﻿using System.Runtime.Serialization;

namespace Scorponok.Gateway.Pagamento.Services.Cliente.Messages.EnumTypes {

    /// <summary>
    /// Tipo de operação de gerenciamento
    /// </summary>
    [DataContract]
    public enum ManageSaleOperationEnum {

        /// <summary>
        /// Capturar
        /// </summary>
        [EnumMember]
        Capture = 1,

        /// <summary>
        /// Cancelar
        /// </summary>
        [EnumMember]
        Void = 2,

        /// <summary>
        /// Autorizar
        /// </summary>
        [EnumMember]
        Authorize = 3
    }
}