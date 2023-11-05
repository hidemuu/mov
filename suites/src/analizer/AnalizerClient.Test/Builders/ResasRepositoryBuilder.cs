using Moq;
using Mov.Suite.AnalizerClient.Resas;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas;
using Mov.Suite.AnalizerClient.Resas.Repository.Schemas.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Suite.AnalizerClient.Test.Builders
{
	public class ResasRepositoryBuilder
	{
		#region field

		private readonly Mock<IResasRepository> _mockRepository;

		#endregion field

		#region constructor

		public ResasRepositoryBuilder() 
		{
			_mockRepository = new Mock<IResasRepository>();
		}

		#endregion constructor

		#region method

		public IResasRepository Build() => _mockRepository.Object;

		public ResasRepositoryBuilder WithGetCities(ResasResponseSchema<CityResultSchema> schema)
		{
			_mockRepository.Setup(x => x.Cities.GetAsync(null)).ReturnsAsync(schema);
			return this;
		}

		public ResasRepositoryBuilder WithGetPrefectures(ResasResponseSchema<PrefectureResultSchema> schema)
		{
			_mockRepository.Setup(x => x.Prefectures.GetAsync(null)).ReturnsAsync(schema);
			return this;
		}

		#endregion method

	}
}
