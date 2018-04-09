using System;
using AutoMapper;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration.Parsers.Profiles;
using Scorponok.Adquirentes.Contracts.Stone.CreditCardTransactions;
using Scorponok.Adquirentes.Contracts.Stone.Sales;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using Scorponok.Shared.Contracts.Messages.Enuns;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.Parsers
{
	[TestFixture]
	public class CreditCardProfileTests
	{
		private IMapper _mapper;
		protected readonly ServiceCollection _services;
		private readonly MapperConfiguration _config;

		public CreditCardProfileTests()
		{
			_services = new ServiceCollection();
			_mapper = new MapperConfiguration(cfg => { cfg.AddProfile<CreditCardProfile>(); }).CreateMapper();

			_services.AddSingleton(_mapper);
		}

		[TestCase(CreditCardBrand.Visa)]
		[TestCase(CreditCardBrand.Mastercard)]
		[TestCase(CreditCardBrand.Hipercard)]
		[TestCase(CreditCardBrand.Amex)]
		[TestCase(CreditCardBrand.Diners)]
		[TestCase(CreditCardBrand.Elo)]
		[TestCase(CreditCardBrand.Aura)]
		[TestCase(CreditCardBrand.Discover)]
		[TestCase(CreditCardBrand.CasaShow)]
		[TestCase(CreditCardBrand.Havan)]
		[TestCase(CreditCardBrand.HugCard)]
		[TestCase(CreditCardBrand.AndarAki)]
		[TestCase(CreditCardBrand.LeaderCard)]
		public void Mapear_credit_card_message_request_para_credit_card(CreditCardBrand brand)
		{
			//Arrange's
			var creditCardMessageRequest = Builder<CreditCardMessageRequest>
				.CreateNew()
					.With(x => x.InstantBuyKey, Guid.NewGuid())
					.With(x => x.CreditCardBrand, brand)
					//.With(x => x.CurrencyIso, currency)
				.Build();

			//Act's
			var creditCard = _mapper.Map<CreditCardMessageRequest, CreditCard>(creditCardMessageRequest);

			//Assert's
			creditCard.Should().NotBeNull();

			creditCard.InstantBuyKey.Should().Be(creditCardMessageRequest.InstantBuyKey);
			creditCard.CreditCardNumber.Should().Be(creditCardMessageRequest.CreditCardNumber);
			creditCard.HolderName.Should().Be(creditCardMessageRequest.HolderName);
			creditCard.SecurityCode.Should().Be(creditCardMessageRequest.SecurityCode);
			creditCard.ExpMonth.Should().Be(creditCardMessageRequest.ExpMonth);
			creditCard.ExpYear.Should().Be(creditCardMessageRequest.ExpYear);
			creditCard.CreditCardBrand.Should().Be(creditCardMessageRequest.CreditCardBrand);
			
		}
	}
}