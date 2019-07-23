using Moq;
using MovieCup.Domain.Commands;
using MovieCup.Domain.Events;
using MovieCup.Shared.Commands;
using Xunit;

namespace MovieCup.Domain.Tests
{
    public class CompetitionCommandHandlerTest : IClassFixture<CompetitionFixture>
    {
        private readonly CompetitionFixture _fixture;
        public CompetitionCommandHandlerTest(CompetitionFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async void Players_Complete_ShouldBeValid()
        {
            // Arrange
            var competitionCommandHandler = _fixture.GetCompetitionCommandHandler();
            var movies = _fixture.GetMoviesAsync();
            _fixture.MovieRepositoryMock.Setup(r => r.GetByIdsAsync(It.IsAny<string[]>())).Returns(movies);

            // Act
            var movieSelecteds = new string[] { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" };
            var result = await competitionCommandHandler.Handler(new NewCompetitionCommand(movieSelecteds, 8)) as CompetitionCompletedEvent;

            // Assert
            _fixture.MovieRepositoryMock.Verify(r => r.GetByIdsAsync(It.IsAny<string[]>()), Times.Once);
            Assert.Equal("Vingadores: Guerra Infinita", result.Ranking[0].Title);
            Assert.Equal("Os Incríveis 2", result.Ranking[1].Title);
        }

        [Fact]
        public async void Players_Not_Complete_ShouldBeInvalid()
        {
            // Arrange
            var competitionCommandHandler = _fixture.GetCompetitionCommandHandler();
            var movies = _fixture.GetMoviesAsync();
            _fixture.MovieRepositoryMock.Setup(r => r.GetByIdsAsync(It.IsAny<string[]>())).Returns(movies);

            // Act
            var movieSelecteds = new string[] { "tt3606756" };
            var result = await competitionCommandHandler.Handler(new NewCompetitionCommand(movieSelecteds, 8));

            // Assert
            _fixture.MovieRepositoryMock.Verify(r => r.GetByIdsAsync(It.IsAny<string[]>()), Times.Once);
            Assert.IsType<ValidationFailureEvent>(result);
        }
    }
}
