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
	public class CreditCardTransactionCollectionProfileTests
	{
		private IMapper _mapper;
		protected readonly ServiceCollection _services;
		private readonly MapperConfiguration _config;

		public CreditCardTransactionCollectionProfileTests()
		{
			_services = new ServiceCollection();
			_mapper = new MapperConfiguration(cfg => { cfg.AddProfile<CreditCardTransactionCollectionProfile>(); }).CreateMapper();

			_services.AddSingleton(_mapper);
		}

		[TestCase(CreditCardOperation.AuthOnly)]
		[TestCase(CreditCardOperation.AuthAndCapture)]
		[TestCase(CreditCardOperation.AuthAndCaptureWithDelay)]
		public void Mapper_transaction_message_request_para_credit_card_transaction_collection(CreditCardOperation operation)
		{
			//Arrange's
			var salesOptionsMessageRequest = Builder<TransactionMessageRequest>
				.CreateNew()
					.With(x => x.AmountInCents, 1000)
					.With(x => x.InstallmentCount, 1)
					.With(x => x.CreditCardOperation, operation)
				.Build();

			//Act's
			var creditCardTransaction = _mapper.Map<TransactionMessageRequest, CreditCardTransaction>(salesOptionsMessageRequest);

			//Assert's
			creditCardTransaction.Should().NotBeNull();
			creditCardTransaction.AmountInCents.Should().Be(1000);
			creditCardTransaction.InstallmentCount.Should().Be(1);
		}
	}
}