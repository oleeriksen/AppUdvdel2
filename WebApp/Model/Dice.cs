using System;
namespace WebApp.Model
{
    public class Dice
    {
        private int mEyes;

        private Random mRandom;

        private int mSize;

        public Dice(int size = 6)
        {
            mSize = size;
            mRandom = new Random();
        }

        public void Roll() {
            mEyes = mRandom.Next(mSize) + 1;
        }

        public int Eyes() { return mEyes; }
    }
}

