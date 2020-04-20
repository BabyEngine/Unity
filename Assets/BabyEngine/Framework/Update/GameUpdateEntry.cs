using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyEngine {
    public struct GameUpdateEntry {
        public string GameName;
        public string GameUrl;

        public override string ToString() {
            return $"{GameName} {GameUrl}";
        }
    }
}