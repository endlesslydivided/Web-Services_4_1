//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lab5__Client_.Client {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Client.ISimplex")]
    public interface ISimplex {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Add", ReplyAction="http://tempuri.org/ISimplex/AddResponse")]
        int Add(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Add", ReplyAction="http://tempuri.org/ISimplex/AddResponse")]
        System.Threading.Tasks.Task<int> AddAsync(int x, int y);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Concat", ReplyAction="http://tempuri.org/ISimplex/ConcatResponse")]
        string Concat(string s, double d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Concat", ReplyAction="http://tempuri.org/ISimplex/ConcatResponse")]
        System.Threading.Tasks.Task<string> ConcatAsync(string s, double d);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Sum", ReplyAction="http://tempuri.org/ISimplex/SumResponse")]
        Lab5.A Sum(Lab5.A a1, Lab5.A a2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISimplex/Sum", ReplyAction="http://tempuri.org/ISimplex/SumResponse")]
        System.Threading.Tasks.Task<Lab5.A> SumAsync(Lab5.A a1, Lab5.A a2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISimplexChannel : Lab5__Client_.Client.ISimplex, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SimplexClient : System.ServiceModel.ClientBase<Lab5__Client_.Client.ISimplex>, Lab5__Client_.Client.ISimplex {
        
        public SimplexClient() {
        }
        
        public SimplexClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SimplexClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimplexClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SimplexClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Add(int x, int y) {
            return base.Channel.Add(x, y);
        }
        
        public System.Threading.Tasks.Task<int> AddAsync(int x, int y) {
            return base.Channel.AddAsync(x, y);
        }
        
        public string Concat(string s, double d) {
            return base.Channel.Concat(s, d);
        }
        
        public System.Threading.Tasks.Task<string> ConcatAsync(string s, double d) {
            return base.Channel.ConcatAsync(s, d);
        }
        
        public Lab5.A Sum(Lab5.A a1, Lab5.A a2) {
            return base.Channel.Sum(a1, a2);
        }
        
        public System.Threading.Tasks.Task<Lab5.A> SumAsync(Lab5.A a1, Lab5.A a2) {
            return base.Channel.SumAsync(a1, a2);
        }
    }
}
