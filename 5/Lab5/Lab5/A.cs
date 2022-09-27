using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    [DataContract]
    public class A
    {
        public string s;
        public int k;
        public float f;

        public A() { }
        public A(string s, int k, float f)
        {
            this.s = s;
            this.k = k;
            this.f = f;
        }

        [DataMember]
        public string S
        {
            get { return s; }
            set { s = value; }
        }

        [DataMember]
        public int K
        {
            get { return k; }
            set { k = value; }
        }
        [DataMember]
        public float F
        {
            get { return f; }
            set { f = value; }
        }

    }
}
