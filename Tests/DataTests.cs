using EksamMihkelJullinen;

namespace Tests
{
    [TestClass]
    public class DataTests : DataAnalysis
    {

        [TestInitialize]
        public void TestInitialize()
        {
            SetFileName("Language_2000.csv");
            SortCountriesAndNumbers();
        }

        [TestMethod]
        public void TestFindLanguageSpeakers4()
        {
            Assert.AreEqual(26366, FindLanguageSpeakers(4));
        }
        [TestMethod]
        public void TestFindLanguageSpeakers2()
        {
            Assert.AreEqual(278813, FindLanguageSpeakers(2));
        }
        [TestMethod]
        public void TestFindLanguageSpeakersNull()
        {
            Assert.AreEqual(null, FindLanguageSpeakers(-1));
        }

        [TestMethod]
        public void TestFindNumberOfPeopleInGroup6()
        {
            Assert.AreEqual("Vanus teadmata", FindNumberOfPeopleInGroup(6));
        }
        [TestMethod]
        public void TestFindNumberOfPeopleInGroup2()
        {
            Assert.AreEqual("Vanuses 15-29", FindNumberOfPeopleInGroup(2));
        }
        [TestMethod]
        public void TestFindNumberOfPeopleInGroupNull()
        {
            Assert.AreEqual(String.Empty, FindNumberOfPeopleInGroup(-1));
        }
        [TestMethod]
        public void TestFindAverageNumberOfLanguagesSpoken()
        {
            Assert.AreEqual(3.04, FindAverageNumberOfLanguagesSpoken());
        }
        [TestMethod]
        public void TestFindIndexNumber304()
        {
            Assert.AreEqual(2, FindIndexNumber(3.04));
        }
        [TestMethod]
        public void TestFindIndexNumberNull()
        {
            Assert.AreEqual(-1, FindIndexNumber(-1));
        }
        [TestMethod]
        public void TestFindIndexCountryEstonia()
        {
            Assert.AreEqual(6, FindIndexCountry("Estonia"));
        }
        [TestMethod]
        public void TestFindIndexCountryLatvia()
        {
            Assert.AreEqual(5, FindIndexCountry("Latvia"));
        }
        [TestMethod]
        public void TestFindIndexCountryNull()
        {
            Assert.AreEqual(-1, FindIndexCountry("WrongCountry"));
        }
        [TestMethod]
        public void TestFindSpeakersPerGroup()
        {
            Assert.AreEqual(String.Empty, FindSpeakersPerGroup(7));
        }
        [TestMethod]
        public void TestFindWhoSpeakOnlyNative()
        {
            Assert.AreEqual("Vanuserühmad kokku on 349678 inimest," +
                " kes oskavad ainult oma emakeelt.0-14 on 99704 inimest," +
                " kes oskavad ainult oma emakeelt.15-29 on 41941 inimest," +
                " kes oskavad ainult oma emakeelt.30-49 on 64790 inimest," +
                " kes oskavad ainult oma emakeelt.50-64 on 54844 inimest," +
                " kes oskavad ainult oma emakeelt.65 ja vanemad on 88335 inimest," +
                " kes oskavad ainult oma emakeelt.Vanus teadmata on 64 inimest," +
                " kes oskavad ainult oma emakeelt.", FindWhoSpeakOnlyNative());
        }
        [TestMethod]
        public void TestFindWhoSpeakAForeginLanguage()
        {
            Assert.AreEqual("Vanuserühmad kokku on 851639 võõrkeelte oskajat." +
                "0-14 on 71977 võõrkeelte oskajat." +
                "15-29 on 230602 võõrkeelte oskajat." +
                "30-49 on 290873 võõrkeelte oskajat." +
                "50-64 on 168656 võõrkeelte oskajat." +
                "65 ja vanemad on 89379 võõrkeelte oskajat." +
                "Vanus teadmata on 152 võõrkeelte oskajat.", FindWhoSpeakAForeignLanguage());
        }
        
        [TestMethod]
        public void TestFindPeopleWhoSpeakOnlyNativeHelper0()
        {
            Assert.AreEqual(349678, FindPeopleWhoSpeakOnlyNativeHelper(0));
        }
        [TestMethod]
        public void TestFindPeopleWhoSpeakOnlyNativeHelper2()
        {
            Assert.AreEqual(41941, FindPeopleWhoSpeakOnlyNativeHelper(2));
        }
        [TestMethod]
        public void TestCompareAverageToTableValueBigger()
        {
            Assert.AreEqual("\nArvutatud väärtus on suurem kui tabelis", CompareAverageToTableValue(1,2));
        }
        [TestMethod]
        public void TestCompareAverageToTableValueSmaller()
        {
            Assert.AreEqual("\nArvutatud väärtus on väiksem kui tabelis", CompareAverageToTableValue(2, 1));
        }
        [TestMethod]
        public void TestReadDataForSortingCountries()
        {
            Assert.AreEqual(String.Empty, ReadDataForSortingCountries("WrongFile.txt"));
        }


    }
}