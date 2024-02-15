namespace EksamMihkelJullinen
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            PrintingMethods printingMethods = new PrintingMethods();
            printingMethods.SetFileName("Language_2000.csv");
            printingMethods.PrintWhoSpeakAForeignLangauge();
            printingMethods.PrintWhoSpeakOnlyNative();
            printingMethods.PrintLanguageSpeakers(4);
            printingMethods.PrintSpeakersPerGroup(2);
            printingMethods.PrintNumberOfPeopleInGroup(2);
            printingMethods.PrintAverageNumberOfLanguagesSpoken();
            printingMethods.PrintCountriesBasedOnAverageLanguages();

            
            

            
            
            
            
        }
    }
}