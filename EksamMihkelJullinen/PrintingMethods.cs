using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamMihkelJullinen
{
    public class PrintingMethods : DataAnalysis
    {
        public PrintingMethods()
        {
            
        }
        //1
        public void PrintWhoSpeakAForeignLangauge()
        {
            string[] printArray = FindWhoSpeakAForeignLanguage().Split('.');

            foreach (string str in printArray)
            {
                Console.WriteLine(str);
            }
        }
        //2
        public void PrintWhoSpeakOnlyNative()
        {
            string[] printArray = FindWhoSpeakOnlyNative().Split('.');
            
            foreach (string str in printArray)
            {
                Console.WriteLine(str);
            }
        }
        //3
        public void PrintLanguageSpeakers(int nrOfLanguages)
        {
            int? print = FindLanguageSpeakers(nrOfLanguages);
            if (print != null)
            {
                Console.WriteLine($"{print} inimest räägib {nrOfLanguages} võõrkeelt.\n");
            }
        }
        //4
        public void PrintSpeakersPerGroup(int index)
        {
            string[] splitValues = FindSpeakersPerGroup((int)index).Split('.');
            int i = 0;
            foreach (string value in splitValues)
            {
                if (value == ""){}
                else
                {
                    Console.Write(value);
                    Console.WriteLine($" inimest oskab {i} võõrkeelt");
                    i++;
                }  
            }
        }
        //5
        public void PrintNumberOfPeopleInGroup(int ageGroup)
        {
            string ageGroupString = FindNumberOfPeopleInGroup(ageGroup);
            if (ageGroupString != String.Empty)
            {
                try
                {
                    Console.WriteLine("\n" + ageGroupString + " on " + ListHolder[ageGroup][1] + " inimest\n");
                }
                catch
                {
                    Console.WriteLine("Viga andmetega");
                }
                
            }

        }
        //6
        public void PrintAverageNumberOfLanguagesSpoken()
        {
            double averageLanguagesSpoken = FindAverageNumberOfLanguagesSpoken();
            if (averageLanguagesSpoken < 0)
            {
                Console.WriteLine("Viga andmetega");
            }
            else
            {
                Console.WriteLine("Keskmiselt räägivad eestlased " + averageLanguagesSpoken + " keelt\n");
            }
            
        }
        //7
        public void PrintCountriesBasedOnAverageLanguages()
        {
            SortCountriesAndNumbers();
            double foundAverage = FindAverageNumberOfLanguagesSpoken();
            if (foundAverage < 0)
            {
                Console.WriteLine("Viga keskmiselt räägitavate keelte arvutamisel");
            }
            else
            {

                int numberIndex = FindIndexNumber(foundAverage);
                int countryIndex = FindIndexCountry("Estonia");

                if (numberIndex >= 0 && countryIndex >= 0)
                {
                    Countries.Insert(numberIndex, "Estonia(arvutatud)");
                    for (int j = 0; j < Countries.Count; j++)
                    {
                        Console.Write(Countries[j] + " ");
                        Console.WriteLine(AverageLanguages[j]);
                    }
                }
                else
                {
                    Console.WriteLine("Viga riikide sorteerimisel");
                }
                

                
                Console.WriteLine(CompareAverageToTableValue(numberIndex, countryIndex));
                
            }
        }

    }
}
