using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    




        #region STRUCT(S)
        public struct GuessRange
        {
            private int _lowerBound;
            private int _upperBound;

            #region CONSTRUCTOR
            public GuessRange(int lower, int upper)
            {
                this._lowerBound = lower;
                this._upperBound = upper;
            }

            #endregion

            #region PROPERTIES

            public int LowerBound
            {

                get
                {
                    return _lowerBound;
                }

                set
                {
                    _lowerBound = value;
                }

            }

            public int UpperBound
            {

                get
                {
                    return _upperBound;
                }

                set
                {
                    _upperBound = value;
                }
            }



            #endregion

        }
        #endregion












        class GuessingGame
        {

            #region CONSTANTS

            public const int DEFAULT_LOWER_BOUND = 0;

            public const int DEFAULT_UPPER_BOUND = 10;

            #endregion





            // The bounds for allowed guesses
            private GuessRange _bound;

            internal bool CheckGuess(string text)
            {
                throw new NotImplementedException();
            }


            // The number the game is generating and that is supposed to be guessed

            private int _numberToGuess;

            // A random generator that is used to generate the number to guess

            private Random _randomGen;


            #region CONSTRUCTORS

            public GuessingGame() : this(new GuessRange(DEFAULT_LOWER_BOUND, DEFAULT_UPPER_BOUND))
            {

            }



            public GuessingGame(GuessRange bound)
            {
                //initialize the lower and upper bounds
                _bound = bound;


                //generate a random integer between the two bounds
                _randomGen = new Random();
                _numberToGuess = _randomGen.Next(_bound.LowerBound, (_bound.UpperBound + 1));
            }

            #endregion
            #region PROPERTIES

            public int NumberToGuess()
            {

                return this._numberToGuess;

            }

            #endregion

            public bool CheckGuess(int guess)
            {


                if (guess == _numberToGuess)// correct guess
                {

                    return true;
                }
                else  // incorrect guess

                    return false;

            }

        }
    }





