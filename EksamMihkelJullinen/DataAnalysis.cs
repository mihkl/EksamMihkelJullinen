using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EksamMihkelJullinen
{
    
    public class DataAnalysis
    {
        protected List<string> Countries = new List<string>();
        protected List<double> AverageLanguages = new List<double>();
        protected List<string> Total = new List<string>();
        protected List<string> AgeGroup014 = new List<string>();
        protected List<string> AgeGroup1529 = new List<string>();
        protected List<string> AgeGroup3049 = new List<string>();
        protected List<string> AgeGroup5064 = new List<string>();
        protected List<string> AgeGroup65orMore = new List<string>();
        protected List<string> UnknownAge = new List<string>();
        protected List<string> TemporaryListForReading = new List<string>();
        protected List<List<string>> ListHolder = new List<List<string>>();
        protected string _fileName = "";

        protected DataAnalysis()
        {
            ListHolder.Add(Total);
            ListHolder.Add(AgeGroup014);
            ListHolder.Add(AgeGroup1529);
            ListHolder.Add(AgeGroup3049);
            ListHolder.Add(AgeGroup5064);
            ListHolder.Add(AgeGroup65orMore);
            ListHolder.Add(UnknownAge);
        }

        //faili vahetus
        public void SetFileName(string fileName)
        {
            _fileName = fileName;
            ReadValuesFromFile();
        }

        //loeb faili ajutisse listi

        private void ReadValuesFromFile()
        {
            try
            {
                using (StreamReader reader = new StreamReader(_fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (line.StartsWith("Vanuserühm,"))
                        {
                        }
                        else
                        {
                            TemporaryListForReading.Add(line);
                        }
                    }
                }
                SortDataIntoLists();
            }
            catch
            {
                Console.WriteLine("Puudulik fail");
            }
            
        }
        //jaotab read listide vahel ara
        private void SortDataIntoLists()
        {
            for (int i = 0; i < 7; i++)
            {
                ListHolder[i] = TemporaryListForReading[i].Split(",").ToList();
            }
        }
        //1
        protected string FindWhoSpeakAForeignLanguage()
        {
            string returnMessage = String.Empty;
            foreach (var list in ListHolder)
            {
                try
                {
                    int value = 0;
                    for (int i = 2; i < 6; i++)
                    {

                        value += int.Parse(list[i]);
                    }
                    returnMessage += $"{list[0]} on {value} võõrkeelte oskajat.";
                }
                catch
                {
                    Console.WriteLine("Error andmete parsimisega!");
                    return String.Empty;
                }
            }
            return returnMessage;
        }
        //2
        protected string FindWhoSpeakOnlyNative()
        {
            string returnMessage = String.Empty;
            foreach (var list in ListHolder)
            {
                try
                {
                    int value = 0;
                    int substract = 0;
                    for (int i = 2; i < 7; i++)
                    { 
                        value += int.Parse(list[i]);
                        substract = int.Parse(list[1]) - value;
                    }
                    returnMessage += $"{list[0]} on {substract} inimest, kes oskavad ainult oma emakeelt.";
                }
                catch
                {
                    Console.WriteLine("Error andmete parsimisega!");
                    return String.Empty;
                }
            }
            return returnMessage;
        }
        //3
        protected int? FindLanguageSpeakers(int nrOfLanguages)
        {
            if (nrOfLanguages < 0 || nrOfLanguages > 4)
            {
                Console.WriteLine("Vale sisend (0-4)\n");
                return null;
            }
            else
            {
                int value = 0;
                int? returnValue = 0;
                try
                {
                    if (nrOfLanguages == 0)
                    {

                        returnValue = FindPeopleWhoSpeakOnlyNativeHelper(0);
                    }
                    else
                    {
                        returnValue = int.Parse(ListHolder[0][nrOfLanguages + 1]);
                        return returnValue;
                    }
                }
                catch
                    {
                    Console.WriteLine("Error andmete parsimisega!");
                    return null;
                }
                return returnValue;
            }
        }
        //4

        public int? FindPeopleWhoSpeakOnlyNativeHelper(int ageGroup)
        {
            int returnValue = 0;
            int value = 0;
            try
            {
                for (int i = 2; i < 7; i++)
                {
                    value += int.Parse(ListHolder[ageGroup][i]);
                    returnValue = (int.Parse(ListHolder[ageGroup][1]) - value);
                }
                return returnValue;
            }
            catch
            {
                Console.WriteLine("Error andmete parsimisega!");
                return null;
            }
        }
        protected string FindSpeakersPerGroup(int ageGroup)
        {
            string returnString = String.Empty;
            if (ageGroup >= ListHolder.Count)
            {
                Console.WriteLine("Vigane sisend");
                return String.Empty;
            }
            else
            {
                returnString = FindPeopleWhoSpeakOnlyNativeHelper(ageGroup).ToString();
              
                for (int i = 2; i < ListHolder[ageGroup].Count-1; i++)
                {
                    returnString += $".{ListHolder[ageGroup][i].ToString()}";
                }
                return returnString;
            }
        }
        //5
        protected string FindNumberOfPeopleInGroup(int ageGroup)
        {
            if (ageGroup >= ListHolder.Count || ageGroup < 0)
            {
                Console.WriteLine("Vigane sisend");
                return String.Empty;
            }
            else
            {
                return ageGroup switch
                {
                    0 => "Vanuserühmades kokku",
                    1 => "Vanuses 0-14",
                    2 => "Vanuses 15-29",
                    3 => "Vanuses 30-49",
                    4 => "Vanuses 50-64",
                    5 => "Vanuses 65 ja vanemad",
                    6 => "Vanus teadmata",
                    _ => String.Empty
                };
            }
        }
        
        //6
        protected double FindAverageNumberOfLanguagesSpoken()
        {
            double numberOfPeopleTimesLanguages = 0;
            double numberOfPeopleMinusUnknown = 0;
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    numberOfPeopleTimesLanguages += int.Parse(ListHolder[0][i]) * (i);
                }
                numberOfPeopleMinusUnknown = int.Parse(ListHolder[0][1]) - int.Parse(ListHolder[0][6]);
            }
            catch
            {
                return -1;
            }
            double averageLanguagesSpoken = Math.Round((numberOfPeopleTimesLanguages / numberOfPeopleMinusUnknown),2);
            
            return averageLanguagesSpoken;
        }

        //7
        protected string ReadDataForSortingCountries(string file)
        {
            try
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    string TemporaryString = String.Empty;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        TemporaryString += line + "-";
                    }
                    return TemporaryString;
                }
            }
            catch
            {
                Console.WriteLine("Puudulik fail");
                return String.Empty; 
            }
        }
        protected void SortCountriesAndNumbers()
        {
            string Data = ReadDataForSortingCountries("AverageLanguages.txt");
            string[] SplitData = Data.Split('	', '-');

            foreach (string token in SplitData)
            {
                if (double.TryParse(token, out double number))
                {
                    AverageLanguages.Add(number);
                }
                else
                {
                    Countries.Add(token);
                }
            }
            AverageLanguages.Add(FindAverageNumberOfLanguagesSpoken());
            AverageLanguages.Sort();
            AverageLanguages.Reverse();
            DeleteEmptyStrings();
        }
        protected void DeleteEmptyStrings()
        {
            //kustuta tyhjad stringid
            for (int i = 0; i < Countries.Count; i++)
            {
                if (Countries[i] == "")
                {
                    Countries.RemoveAt(i);
                }
            }
            try
            {
                if (Countries[Countries.Count - 1] == "")
                {
                    Countries.RemoveAt(Countries.Count - 1);
                }
            }
            catch
            {
                Console.WriteLine("Viga andmetega");
            }

        }
        protected int FindIndexNumber(double foundAverage)
        { 
            int i = 0;
            int numberIndex = 0;
            foreach (double number in AverageLanguages)
            {
                if (number == foundAverage)
                {
                    numberIndex = i;
                    return numberIndex;
                }
                i++;
            }
            return -1; 
        }
        protected int FindIndexCountry(string countryName)
        {
            int i = 0;
            int countryIndex = 0;
            foreach (string country in Countries)
            {
                if (country == countryName)
                {
                    countryIndex = i;
                    return countryIndex;
                }
                i++;
            }
            return -1;
        }
       
        protected string CompareAverageToTableValue(int numberIndex, int countryIndex)
        {
            if (countryIndex > numberIndex)
            {
                return "\nArvutatud väärtus on suurem kui tabelis";
            }
            else
            {
                return "\nArvutatud väärtus on väiksem kui tabelis";
            }
        }
        
    }
}

