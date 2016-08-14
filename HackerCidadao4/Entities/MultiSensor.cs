using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerCidadao4.Entities
{
    public class Value
    {
        public string rev { get; set; }
    }

    public class D
    {
        public int tempC { get; set; }
        public int ruido { get; set; }
        public int mq7 { get; set; }
        public int gas { get; set; }
        public int distance { get; set; }
        public int humidity { get; set; }
        public string timestamp { get; set; }
    }

    public class Payload
    {
        public D d { get; set; }
    }

    public class Doc
    {
        public string _id { get; set; }
        public string _rev { get; set; }
        public string topic { get; set; }
        public Payload payload { get; set; }
        public string deviceId { get; set; }
        public string deviceType { get; set; }
        public string eventType { get; set; }
        public string format { get; set; }
    }

    public class Row
    {
        public string id { get; set; }
        public string key { get; set; }
        public Value value { get; set; }
        public Doc doc { get; set; }
    }

    public class MultiSensor
    {
        public int total_rows { get; set; }
        public int offset { get; set; }
        public List<Row> rows { get; set; }

        public EImportanceState GasState
        {
            get
            {
                EImportanceState state = EImportanceState.Normal;
                switch (rows?.First()?.doc?.payload?.d?.gas)
                {
                    case 1:
                        state = EImportanceState.Normal;
                        break;
                    case 2:
                        state = EImportanceState.Alert;
                        break;
                    case 3:
                        state = EImportanceState.Critical;
                        break;
                }

                return state;
            }
        }
    }
}
