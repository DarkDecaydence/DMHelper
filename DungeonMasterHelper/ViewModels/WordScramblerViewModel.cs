using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonMasterHelper.ViewModels
{
    public class WordScramblerViewModel : BaseViewModel
    {
        private int scrambleSeed = 0;
        private string input = String.Empty;
        private string output = String.Empty;
        private string encryptMethod = String.Empty;

        public List<string> EncryptionMethods {
            get { return new List<string>() { "Scramble", "Caesar Shuffle" }; }
        }

        public string SelectedMethod {
            get { return encryptMethod; }
            set { 
                encryptMethod = value;
                OnPropertyChanged();
            }
        }

        public int Seed
        {
            get { return scrambleSeed; }
            set {
                if (scrambleSeed != value) {
                    scrambleSeed = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Input
        {
            get { return input; }
            set
            { 
                input = value;
                OnPropertyChanged();
            }
        }

        public string Output
        {
            get { return output; }
            set
            {
                output = value;
                OnPropertyChanged();
            }
        }

        public void ScrambleText()
        {
            if (SelectedMethod.Equals("Scramble")) {
                Output = ScrambleText(Input);
            } else if (SelectedMethod.Equals("Caesar Shuffle")) {
                Output = CeasarShuffleText(Input);
            } else {
                Output = Input;
            }
        }

        private string ScrambleText(string input)
        {
            var tempSeed = new Random(Seed);
            var tempInput = new StringBuilder(input);
            var tempOutput = new StringBuilder();

            for (; tempInput.ToString() != String.Empty; tempInput = tempInput.Remove(0, 1))
            {
                if (tempInput.Length == 0)
                { break; }

                char inputChar = tempInput[0];
                var tempPos = (int)Math.Round(tempSeed.NextDouble() * (tempInput.Length - 1));
                var exchangeChar = tempInput[tempPos];

                tempInput[tempPos] = inputChar;
                tempOutput.Append(exchangeChar);
            }

            return tempOutput.ToString();
        }

        private string CeasarShuffleText(string input) {
            var tempOutput = new StringBuilder();
            
            foreach (char c in input) {
                if (c < 65 || c > 122 || (c > 90 && c < 97)) {
                    tempOutput.Append(c);
                    continue;
                }

                int offset = char.IsUpper(c) ? 65 : 97;
                char c_new = (char)(offset + ((c - offset + Seed) % 25));
                
                tempOutput.Append(c_new);
            }

            return tempOutput.ToString();
        }

    }
}
