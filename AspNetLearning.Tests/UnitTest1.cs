namespace AspNetLearning.Tests
{
    public class BasicTests
    {
        [Fact]
        public void IkiSayiToplandiginda_SonucBesOlmali()
        {
            // Arrange
            int birinciSayi = 2;
            int ikinciSayi = 3;

            // Act
            int gercekSonuc = birinciSayi + ikinciSayi;

            // Assert
            Assert.Equal(5, gercekSonuc);
        }

        [Theory]
        [InlineData(2, 3, 5)]
        [InlineData(10, 5, 15)]
        [InlineData(-2, 2, 0)]
        [InlineData(0, 0, 0)]
        public void FarkliSayilarToplandiginda_BeklenenSonucuVermeli(
            int birinciSayi,
            int ikinciSayi,
            int beklenenSonuc)
        {
            // Act
            int gercekSonuc = birinciSayi + ikinciSayi;

            // Assert
            Assert.Equal(beklenenSonuc, gercekSonuc);
        }
    }
}