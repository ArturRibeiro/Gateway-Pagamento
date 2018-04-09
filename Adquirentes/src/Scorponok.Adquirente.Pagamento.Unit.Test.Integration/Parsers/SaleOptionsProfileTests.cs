using AutoMapper;
using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Scorponok.Adquirente.Pagamento.Unit.Test.Integration.Parsers.Profiles;
using Scorponok.Adquirentes.Contracts.Stone.Sales;
using Scorponok.Shared.Contracts.Messages.Autorizar.Requests;
using Scorponok.Shared.Contracts.Messages.Enuns;

namespace Scorponok.Adquirente.Pagamento.Unit.Test.Integration.Parsers
{
	[TestFixture]
	public class SaleOptionsProfileTests
	{
		private IMapper _mapper;
		protected readonly ServiceCollection _services;
		private readonly MapperConfiguration _config;

		public SaleOptionsProfileTests()
		{
			_services = new ServiceCollection();
			_mapper = new MapperConfiguration(cfg => { cfg.AddProfile<SaleOptionsProfile>(); }).CreateMapper();

			_services.AddSingleton(_mapper);
		}

		[TestCase(CurrencyIso.BRL)]
		[TestCase(CurrencyIso.EUR)]
		[TestCase(CurrencyIso.UYU)]
		public void Mapear_sale_options_message_request_para_sale_options(CurrencyIso currency)
		{
			//Arrange's
			var salesOptionsMessageRequest = Builder<SaleOptionsMessageRequest>
				.CreateNew()
					.With(x => x.IsAntiFraudEnabled, true)
					.With(x => x.CurrencyIso, currency)
				.Build();

			//Act's
			var saleOptions = _mapper.Map<SaleOptionsMessageRequest, SaleOptions>(salesOptionsMessageRequest);

			//Assert's
			saleOptions.Should().NotBeNull();
			saleOptions.AntiFraudServiceCode.Should().BeGreaterOrEqualTo(1);
			saleOptions.IsAntiFraudEnabled.Should().NotBeNull();
			saleOptions.Retries.Should().NotBeNull();
			saleOptions.CurrencyIso.Should().Be(currency);
		}
	}
}