using System.Numerics;
namespace BabyEngine {
    public class Integer {
        private BigInteger value;
        public bool IsOk { get; private set; }
        public Integer() {
            IsOk = false;
        }
        public Integer(int num) {
            IsOk = BigInteger.TryParse(num.ToString(), out value);
        }
        public Integer(string num) {
            IsOk = BigInteger.TryParse(num, out value);
        }
        public override string ToString() {
            return ToString("D");
        }
        public string ToString(string fmt) {
            return value.ToString(fmt);
        }
        
        public static Integer Add(Integer lhs, Integer rhs) {
            Integer result = new Integer();
            result.IsOk = lhs.IsOk && rhs.IsOk;
            result.value = BigInteger.Add(lhs.value, rhs.value);
            return result;
        }
        public static Integer Sub(Integer lhs, Integer rhs) {
            Integer result = new Integer();
            result.IsOk = lhs.IsOk && rhs.IsOk;
            result.value = BigInteger.Subtract(lhs.value, rhs.value);
            return result;
        }
        public static Integer Mul(Integer lhs, Integer rhs) {
            Integer result = new Integer();
            result.IsOk = lhs.IsOk && rhs.IsOk;
            result.value = BigInteger.Multiply(lhs.value, rhs.value);
            return result;
        }
        public static Integer Mul(Integer lhs, int val) {
            Integer result = new Integer();
            result.value = BigInteger.Multiply(lhs.value, val);
            return result;
        }
        public static Integer Div(Integer lhs, Integer rhs) {
            Integer result = new Integer();
            result.IsOk = lhs.IsOk && rhs.IsOk;
            result.value = BigInteger.Divide(lhs.value, rhs.value);
            return result;
        }
        public static bool Equal(Integer lhs, Integer rhs) {
            return lhs.value.CompareTo(rhs.value) == 0;
        }
        public static bool GreaterThan(Integer lhs, Integer rhs) {
            return lhs.value.CompareTo(rhs.value) == 1;
        }
        public static bool LessThan(Integer lhs, Integer rhs) {
            return lhs.value.CompareTo(rhs.value) == -1;
        }
        public static int CompareTo(Integer lhs, Integer rhs) {
            return lhs.value.CompareTo(rhs.value);
        }
    }
}