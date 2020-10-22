using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using CommonUtil;

namespace BizSearch {

    // Storage of Decimals for later retrieval
    public class DecimalValueSet : SearchValueSet {
        public bool IsInRange(decimal? tdValue) {
            return ((tdValue != null) && ((decimal)tdValue >= Low) && ((decimal)tdValue <= High));
        }
        #region Properties
        public decimal Low { get; set; }
        public decimal High { get; set; }
        #endregion (Properties)
    }

    // Class to store integers for later retrieval
    public class IntegerValueSet : SearchValueSet {
        public bool IsInRange(int? tiValue) {
            return ((tiValue != null) && ((int)tiValue >= Low) && ((int)tiValue <= High));
        }
        #region Properties
        public int Low { get; set; }
        public int High { get; set; }
        #endregion (Properties)
    }

    // Class to store booleans for later comparison
    public class BooleanValueSet : SearchValueSet {
        public bool IsInRange(bool? tbValue) {
            return ((tbValue != null) && (bool)tbValue == this.Value);
        }
        #region Properties

        public bool Value { get; set; }
        #endregion (Properties)
    }
    public class SearchValueSet {
        public string Name { get; set; }
        public int Index { get; set; }
    }
    // Class to store strings for later word matching
    public class StringValueSet {
        #region Fields
        // We use a Dictionary to strore individual words as Keys so we can look them up with good performance. 
        // The int Value is the number of times the word appears. This can be used later as a possible weighting
        private Dictionary<string, int> _words = new Dictionary<string, int>();
        private List<string> _hits = new List<string>();
        #endregion (Fields)

        public bool Contains(string tsTarget) {
            return _words.ContainsKey(tsTarget);
        }

        public void AddWords(string tsSentence) {
            string[] sWords = tsSentence.Split(' ');
            string sCandidate;
            int i;

            foreach (string sWord in sWords) {
                sCandidate = StringUtil.StripPunctuation(sWord).ToUpper();

                if (!string.IsNullOrEmpty(sCandidate) && !IsInIgnoreWordsList(sCandidate)){
                    if (!_words.ContainsKey(sCandidate)) {
                        _words.Add(sCandidate, 1);
                    } else {
                        if(_words.TryGetValue(sCandidate, out i)){
                            i++; // increment the counter when the word appears multiple times
                        }
                    }
                }
            }
        }
        private bool IsInIgnoreWordsList(string tsWord) {
            return SrchConstants.IGNORED_WORDS.Contains("," + tsWord.ToUpper() + ",");
        }
        #region Properties
        
        public Dictionary<string, int> Words { get => _words; }
        public List<string> Hits { get => _hits; }
        #endregion (Properties)
    }
}
