using System;
public class RandomInt {
    Random rd = null;
    public RandomInt() {
        rd = new Random();
    }
    public RandomInt(int seed) {
        rd = new Random(seed);
    }

    public int Next() {
        return rd.Next();
    }

    public int Next(int max) {
        return rd.Next(max);
    }

    public int Next(int min, int max) {
        return rd.Next(min, max);
    }
}
