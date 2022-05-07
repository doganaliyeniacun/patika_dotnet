namespace DependencyInjection.DI
{
     public class DependencyInjectionExample
    {
        public void DITest()
        {
            Bar bar = new Bar();

            DIConstructor _diConstructor = new DIConstructor(bar);
            _diConstructor.DoSomething();
            
            DIProperty _diProperty = new DIProperty();
            _diProperty.SetBar(bar);
            _diProperty.DoSomething();

            DIMethod dIMethod = new DIMethod();

            dIMethod.DoSomething(bar);
        }
    }

    public class Bar
    {
        public void WriteSomething()
        {
            Console.WriteLine("Writing..");
        }
    }

    public class DIConstructor
    {
        private readonly Bar _bar;

        public DIConstructor(Bar bar)
        {
            _bar = bar;
        }

        public void DoSomething()
        {
            _bar.WriteSomething();
        }
    }

    public class DIProperty
    {
        private Bar _bar;

        public void SetBar(Bar bar)
        {
            _bar = bar;
        }

        public void DoSomething()
        {
            _bar.WriteSomething();
        }
    }

    public class DIMethod
    {
        public void DoSomething(Bar bar)
        {
            bar.WriteSomething();
        }
    }
}