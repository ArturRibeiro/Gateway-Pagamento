using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration.EnumTypes;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration {

    /// <summary>
    /// Dados da pessoa
    /// </summary>
    [DataContract(Name = "Person", Namespace = "")]
    public class Person {

        /// <summary>
        /// Nome da pessoa
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        #region PersonType

        /// <summary>
        /// Define se é pessoa física ou jurídica
        /// </summary>
        [DataMember(Name = "PersonType")]
        private string PersonTypeField {
            get {
                return this.PersonType.ToString();
            }
            set {
                this.PersonType = (PersonTypeEnum)Enum.Parse(typeof(PersonTypeEnum), value);
            }
        }

        /// <summary>
        /// Define se é pessoa física ou jurídica
        /// </summary>
        public PersonTypeEnum PersonType { get; set; }

        #endregion

        /// <summary>
        /// Número do documento
        /// </summary>
        [DataMember]
        public string DocumentNumber { get; set; }

        #region DocumentType

        /// <summary>
        /// Tipo de documento
        /// </summary>
        [DataMember(Name = "DocumentType")]
        private string DocumentTypeField {
            get {
                return this.DocumentType.ToString();
            }
            set {
                this.DocumentType = (DocumentTypeEnum)Enum.Parse(typeof(DocumentTypeEnum), value);
            }
        }

        /// <summary>
        /// Tipo de documento
        /// </summary>
        public DocumentTypeEnum DocumentType { get; set; }

        #endregion

        #region Gender

        /// <summary>
        /// Sexo da pessoa
        /// </summary>
        [DataMember(Name = "Gender", EmitDefaultValue = false)]
        private string GenderField {
            get {
                if (this.Gender == null) { return null; }
                return Gender.ToString();
            }
            set {
                if (value == null) {
                    this.Gender = null;
                }
                else {
                    this.Gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), value);
                }
            }
        }

        /// <summary>
        /// Sexo da pessoa
        /// </summary>
        public Nullable<GenderEnum> Gender { get; set; }

        #endregion

        #region Birthdate

        /// <summary>
        /// Data de nascimento
        /// </summary>
        [DataMember(Name = "Birthdate", EmitDefaultValue = false)]
        private string BirthdateField {
            get {
                if (this.Birthdate == null) { return null; }
                return this.Birthdate.Value.ToString(ServiceConstants.DATE_TIME_FORMAT);
            }
            set {
                if (value == null) {
                    this.Birthdate = null;
                }
                else {
                    this.Birthdate = DateTime.ParseExact(value, ServiceConstants.DATE_TIME_FORMAT, null);
                }
            }
        }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        public Nullable<DateTime> Birthdate { get; set; }

        #endregion

        /// <summary>
        /// E-mail
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        #region EmailType

        /// <summary>
        /// Tipo de e-mail. Pessoal ou comercial
        /// </summary>
        [DataMember(Name = "EmailType")]
        private string EmailTypeField {
            get {
                return this.EmailType.ToString();
            }
            set {
                this.EmailType = (EmailTypeEnum)Enum.Parse(typeof(EmailTypeEnum), value);
            }
        }

        /// <summary>
        /// Tipo de e-mail. Pessoal ou comercial
        /// </summary>
        public EmailTypeEnum EmailType { get; set; }

        #endregion

        /// <summary>
        /// Código identificador do cadsastro do Facebook
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string FacebookId { get; set; }

        /// <summary>
        /// Código identificador do cadastro do Twitter
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string TwitterId { get; set; }

        /// <summary>
        /// Telefone celular
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string MobilePhone { get; set; }

        /// <summary>
        /// Telefone residencial
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string HomePhone { get; set; }

        /// <summary>
        /// Telefone comercial
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string WorkPhone { get; set; }
    }
}